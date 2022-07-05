using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherit from the MonoBehavior class and implement the IGameManager interface
// in other words: gain all functionality of MonoBehavior while also needing to implement
// structure imposed by IGameManager (one property and one method)
public class PlayerManager : MonoBehaviour, IGameManager
{
    // status can be read from anywhere (getter is public), but set only within this script (the setter is private)
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    public int maxHealth { get; private set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");

        // these values could be initialized with saved data
        health = 50;
        maxHealth = 100;

        // change status to started after only everything loads/finishes, otherwise it is "Initialized"
        status = ManagerStatus.Started;
    }

    // other scripts cannot set health directly, but can call this function
    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
        Debug.Log($"Health: {health} / {maxHealth}");
    }

}
