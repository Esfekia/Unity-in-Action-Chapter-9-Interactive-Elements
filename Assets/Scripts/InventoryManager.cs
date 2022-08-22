using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    // property can be read from anywhere but set only within this script
    public ManagerStatus status { get; private set; }
        
    public void Startup()
    {
        // any long-running startup tasks go here
        Debug.Log("Inventory manager starting...");        
        
        // for long-running tasks, use status "Initialized" instead:
        
        // once finished, then "Started"
        status = ManagerStatus.Started;
    }
}
