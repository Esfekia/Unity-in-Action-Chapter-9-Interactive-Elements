using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    // property can be read from anywhere but set only within this script
    public ManagerStatus status { get; private set; }

    private List<string> items;
    public void Startup()
    {
        // any long-running startup tasks go here
        Debug.Log("Inventory manager starting...");

        // initialize the empty item list
        items = new List<string>();

        // for long-running tasks, use status "Initialized" instead:

        // once finished, then "Started"
        status = ManagerStatus.Started;
    }

    // print console message of the current inventory
    public void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach(string item in items)
        {
            itemDisplay += item + " ";
        }
        Debug.Log(itemDisplay);
    }

    // other scripts can't manipulate the item list directly but can call this.
    public void AddItem(string name)
    {
        items.Add(name);

        DisplayItems();
    }
}
