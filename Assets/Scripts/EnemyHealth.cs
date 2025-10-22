using UnityEngine; 

public class EnemyHealth : MonoBehaviour 
{
    [SerializeField] private int startingHealth = 3;
    private int _currentHealth; 

    void Awake()
    {
        _currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
