using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    // property can be read from anywhere but set only within this script
    public ManagerStatus status { get; private set; }

    // dictionary is declared with two types: the key and the value
    private Dictionary<string, int> items;
    public void Startup()
    {
        // any long-running startup tasks go here
        Debug.Log("Inventory manager starting...");

        // initialize the empty item dictionary
        items = new Dictionary<string, int>();

        // for long-running tasks, use status "Initialized" instead:

        // once finished, then "Started"
        status = ManagerStatus.Started;
    }

    // print console message of the current inventory
    public void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach(KeyValuePair<string, int> item in items)
        {
            itemDisplay += item.Key + " (" + item.Value + ") ";
        }
        Debug.Log(itemDisplay);
    }

    // other scripts can't manipulate the item list directly but can call this.
    public void AddItem(string name)
    {
        // check for existing entries before entering new data
        if (items.ContainsKey(name))
        {
            items[name] += 1;
        }
        else
        {
            items[name] = 1;
        }
        
        DisplayItems();
    }

    // method to return a list of all the dictionary keys
    public List<string> GetItemList()
    {
        List<string> list = new List<string>(items.Keys);
        return list;
    }

    // method that returns how many of that item are in inventory
    public int GetItemCount(string name)
    {
        if (items.ContainsKey(name))
        {
            return items[name];
        }
        return 0;
    }
}
