using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Find ItemManager on Player
        var itemManager = other.GetComponentInParent<ItemManager>();

        itemManager.AddItem();  // Increase the inventory counter
        Destroy(gameObject);    // Remove the capsule from the scene
    }
}
