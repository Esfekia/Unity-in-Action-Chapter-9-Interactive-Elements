using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    // how far away from the player to activate devices
    public float radius = 1.5f;

    private void Update()
    {
        // respond when the named key is pressed down.
        if (Input.GetKeyDown(KeyCode.C))
        {
            // OverlapSphere() returns a list of nearby objects
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                // SendMessage() tries to call the named function, regardless of the target's type
                hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
