using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class InventoryGenerate : MonoBehaviour
{
    [SerializeField] GameObject itemPref;
    [SerializeField] Transform itemContainer;
    [Space]
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] Sprite[] accessorySprites;
    [SerializeField] Sprite[] potionSprites;

    int weaponIdx = 0;
    int accessoryIdx = 0;
    int potionIdx = 0;

    public List<Item> GenerateItem(int count, List<Item> items)
    {
        Reset(items);

        for (int i = 0; i < count; i++)
        {
            int randomNumber = UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemTypeEnum)).Length);
            GameObject itemObj = LeanPool.Spawn(itemPref, itemContainer);// Instantiate(itemPref, itemContainer);

            Item item = new Item();
            item.id = i;
            item.name = GetNameItem(randomNumber)+"_"+ GetNumberItem(randomNumber);
            item.icon = GetIconItem(randomNumber);
            item.obj = itemObj;

            Properties properties = new Properties();
            properties.itemTypeEnum = (ItemTypeEnum)randomNumber;
            properties.height = 5;
            properties.width = 3;

            item.properties = properties;

            items.Add(item);

        }

        return items;
    }

    private void Reset(List<Item> items)
    {
        items.Clear();
        weaponIdx = 0;
        accessoryIdx = 0;
        potionIdx = 0;
    }

    private int GetNumberItem(int value)
    {
        if ((ItemTypeEnum)value == ItemTypeEnum.WEAPON)
        {
            return weaponIdx++;
        }
        else if ((ItemTypeEnum)value == ItemTypeEnum.ACCESSORY)
        {
            return accessoryIdx++;
        }
        else
        {
            return potionIdx++;
        }
    }

    private Sprite GetIconItem(int value)
    {
        if ((ItemTypeEnum)value == ItemTypeEnum.WEAPON)
        {
            return weaponSprites[UnityEngine.Random.Range(0, weaponSprites.Length-1)];
        }
        else if ((ItemTypeEnum)value == ItemTypeEnum.ACCESSORY)
        {
            return accessorySprites[UnityEngine.Random.Range(0, accessorySprites.Length - 1)];
        }
        else
        {
            return potionSprites[UnityEngine.Random.Range(0, potionSprites.Length - 1)];
        }
    }

    private string GetNameItem(int value)
    {
        if ((ItemTypeEnum)value == ItemTypeEnum.WEAPON)
        {
            return "Weapon";
        }
        else if ((ItemTypeEnum)value == ItemTypeEnum.ACCESSORY)
        {
            return "Accessory";
        }
        else 
        {
            return "Potion";
        }
    }
}
