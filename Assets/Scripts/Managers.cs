using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ensure that various managers exist
[RequireComponent (typeof(PlayerManager))]
[RequireComponent (typeof(InventoryManager))]

public class Managers : MonoBehaviour
{
    // static properties that other code uses to access managers
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    // the list of managers to loop through during the startup sequence
    private List<IGameManager> startSequence;

    //awake runs even before Start()
    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        // List objects are similar to arrays, they are declared with a specific type and store a series of entries in sequence
        // lists can change size later, whereas arrays are static size
        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);

        // launch the startup sequence asynchronously
        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in startSequence)
        {
            manager.Startup();
        }
        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        // keep looking until all managers are started
        while (numReady < numModules)
        {
            int lastReady = numReady;

            foreach (IGameManager manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
            {
                Debug.Log($"Progress: {numReady} / {numModules}");
            }

            // pause for one frame before checking again.
            yield return null;
        }
        Debug.Log("All managers started up!");

    }

}
