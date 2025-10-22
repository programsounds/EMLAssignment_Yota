using StarterAssets;
using UnityEngine;
using UnityEngine.AI; 
 
// Moves Robot object towards Player object along Nav Mesh Surface
public class Robot : MonoBehaviour
{
    private FirstPersonController _player;   
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    private void Start()
    {
        _player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
