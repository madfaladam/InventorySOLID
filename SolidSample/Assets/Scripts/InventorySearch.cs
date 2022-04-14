using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySearch : MonoBehaviour
{
    public void SearchItem(string itemName, List<Item> items, Transform itemContainer)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name.ToLower().Contains(itemName.ToLower()))
            {
                itemContainer.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                itemContainer.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
