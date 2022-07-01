using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    // list of target objects that this trigger will activate
    [SerializeField] GameObject[] targets;

    // OnTriggerEnter() is called when another object enters the trigger volume
    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }

    // OnTriggerExit() is called when an object leaves the trigger volume
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
