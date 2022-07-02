using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // type the name of this item in the Inspector
    [SerializeField] string itemName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Item collected: {itemName}");
        
        // this referes only to this script component
        // this.gameObject refers to the object the script is attached to
        Destroy(this.gameObject);
    }
}
