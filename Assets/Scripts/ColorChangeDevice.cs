using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
    // declare a method with the same name as the door script
    public void Operate()
    {
        // the numbers are RGB values that range from 0 to 1
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        // the color is set in the material attached to the object.
        GetComponent<Renderer>().material.color = random;
    }
}
