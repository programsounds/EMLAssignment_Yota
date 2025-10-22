using StarterAssets;
using UnityEngine;
 
public class Weapon : MonoBehaviour 
{
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private int damageAmount = 1;
    private StarterAssetsInputs _starterAssetsInputs;  // StarterAssetsInputs component has shoot status variable (bool)

    private void Awake()
    {
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    
    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!_starterAssetsInputs.shoot) return;  // true when left-mouse click input

        RaycastHit hit;
        
        //Raycast from the camera position to the crosshair (= screen center = camera direction)
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
            
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth)  // Check the collider has EnemyHealth component (i.e., shot enemy?)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
            // shoot variable must be true for one frame only
            _starterAssetsInputs.ShootInput(false);
        }
    }
}
