using StarterAssets;
using UnityEngine;
using System.Collections;
using System;
using System.IO;  
 
public class ItemManager : MonoBehaviour
{
    [Header("Speed Boost Settings")]
    [SerializeField] private float _speedMultiplier = 2f;
    [SerializeField] private float _boostSeconds = 3f;

    [Header("Drop Settings")]
    [SerializeField] private GameObject _itemWorldPrefab;
    [SerializeField] private float _dropDistance = 3f;
    [SerializeField] private float _dropHeightOffset = 0.1f;

    [Header("Sound Effects")] 
    [SerializeField] private AudioClip _sfxPickup;
    [SerializeField] private AudioClip _sfxUse;
    [SerializeField] private AudioClip _sfxDrop;
    
    private int _itemCount = 0;  // How many items the player has
    private StarterAssetsInputs _inputs;
    private FirstPersonController _controller;
    private float _originalMoveSpeed;
    private Coroutine _boostCoroutine;
    private AudioSource _audioSource;

    public int ItemCount
    {
        get { return _itemCount; }
    }
    
    [System.Serializable]
    private class InventorySave { public int itemCount; }

    // Saves inventory JSON file to /Users/<You>/Documents/YKGame/inventory.json (crossplatform)
    private static string SaveFolder =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YKGame");

    private static string SavePath => Path.Combine(SaveFolder, "Inventory.json");
    
    private void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<FirstPersonController>();
        _audioSource = GetComponent<AudioSource>();
        _originalMoveSpeed = _controller.MoveSpeed;
        LoadInventory();
        
        // Ensure the json save directory
        if (!Directory.Exists(SaveFolder)) Directory.CreateDirectory(SaveFolder);
        Debug.Log($"[ItemManager] Inventory will be stored at: {SavePath}");
    }
    
    private void Update()
    {
        if (_inputs.useItem)  // true when right-mouse click input
        {
            UseItem();
            _inputs.UseItemInput(false);
        }
        if (_inputs.dropItem)  // true when E key pressed
        {
            DropItem();
            _inputs.DropItemInput(false);
        }
    }

    public void AddItem()
    {
        _itemCount++;
        PlaySFX(_sfxPickup);
        Debug.Log($"Picked up SpeedItem. Count = {_itemCount}");
        SaveInventory();
    }

    public void UseItem()
    {
        if (_itemCount <= 0) return;

        _itemCount--;
        PlaySFX(_sfxUse);
        Debug.Log($"Item Used. Remaining = {_itemCount}");
        SaveInventory();

        if (_boostCoroutine != null) StopCoroutine(_boostCoroutine);  // Stop boost if ongoing
        _boostCoroutine = StartCoroutine(BoostRoutine());
    }

    private IEnumerator BoostRoutine()
    {
        _controller.MoveSpeed = _originalMoveSpeed * _speedMultiplier;
        yield return new WaitForSeconds(_boostSeconds);
        _controller.MoveSpeed = _originalMoveSpeed;
        _boostCoroutine = null;
    }

    private void DropItem()
    {
        if (_itemCount <= 0) return;

        // Drop (instantiate) item 
        var cam = Camera.main;
        Vector3 origin = cam.transform.position;
        Vector3 forward = cam.transform.forward;
        Vector3 spawnPos = origin + forward * _dropDistance + Vector3.up * _dropHeightOffset;
        Instantiate(_itemWorldPrefab, spawnPos, Quaternion.identity);

        _itemCount--;
        PlaySFX(_sfxDrop);
        Debug.Log($"Item Dropped. Remaining = {_itemCount}");
        SaveInventory();
    }

    private void PlaySFX(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    
    private void LoadInventory()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                // First run: nothing saved yet
                _itemCount = 0;
                return;
            }

            string json = File.ReadAllText(SavePath);
            var data = JsonUtility.FromJson<InventorySave>(json);
            _itemCount = data.itemCount;
            Debug.Log($"[ItemManager] Loaded itemCount = {_itemCount}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[ItemManager] Load failed: {e.Message}");
            _itemCount = 0;  // fallback
        }
    }

    private void SaveInventory()
    {
        try
        {
            var data = new InventorySave() { itemCount = _itemCount };
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SavePath, json);
            Debug.Log($"[ItemManager] Saved itemCount = {_itemCount}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[ItemManager] Save failed: {e.Message}");
        }
    }
    
    private void OnApplicationQuit() => SaveInventory();
}
