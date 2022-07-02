using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basic interface that the data managers will implement
public interface IGameManager
{
    ManagerStatus status {get;}

    void Startup();

}
   
