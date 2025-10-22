using UnityEngine;
using TMPro;
 
public class ItemCountUI : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private TextMeshProUGUI tmpText;

    private void Update()
    {
        string text = $"Items: {itemManager.ItemCount}";
        tmpText.text = text;
    }
}