using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    private void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();

        // display a message if the inventory is empty
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }
        foreach (string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            // method loads assets from the Resources folder
            Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent($"({count})", image));
            // shift sideways each time through the loop.
            posX += width + buffer;
        }
    }
}
