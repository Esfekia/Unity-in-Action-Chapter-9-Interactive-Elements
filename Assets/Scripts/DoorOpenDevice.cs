using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    // amount to offset the position by when the door opens
    [SerializeField] Vector3 dPos;
    
    // boolean to keep track of the open state of the door
    private bool open;

    public void Operate()
    {
        // open or close the door depending on the open state.
        if (open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        // toggle the boolean
        open = !open;
    }
}
