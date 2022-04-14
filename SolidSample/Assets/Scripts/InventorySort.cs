using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySort : MonoBehaviour
{

    internal List<Item> SortItem(string value, List<Item> items, Transform itemContainer)
    {
        items = CheckValueItem(value, items);
        SortingItemObj(items, itemContainer);

        return items;
    }

    private void SortingItemObj(List<Item> items, Transform itemContainer)
    {
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < itemContainer.childCount; j++)
            {
                if (items[i].obj == itemContainer.GetChild(j).gameObject)
                {
                    itemContainer.GetChild(j).SetSiblingIndex(i);
                    continue;
                }
            }
        }
    }

    private List<Item> CheckValueItem(string value, List<Item> items)
    {
        if (value == "NAME ASC")
        {
            items = items.OrderBy(e => e.name).ToList();
        }
        else if (value == "NAME DESC")
        {
            items = items.OrderByDescending(e => e.name).ToList();
        }
        else if (value == "TYPE ASC")
        {
            items = items.OrderBy(e => e.properties.itemTypeEnum).ToList();
        }
        else if (value == "TYPE DESC")
        {
            items = items.OrderByDescending(e => e.properties.itemTypeEnum).ToList();
        }
        else if (value == "HEIGHT ASC")
        {
            items = items.OrderBy(e => e.properties.height).ToList();
        }
        else if (value == "HEIGHT DESC")
        {
            items = items.OrderByDescending(e => e.properties.height).ToList();
        }
        else if (value == "WIDTH ASC")
        {
            items = items.OrderBy(e => e.properties.width).ToList();
        }
        else if (value == "WIDTH DESC")
        {
            items = items.OrderByDescending(e => e.properties.width).ToList();
        }

        return items;
    }
}
