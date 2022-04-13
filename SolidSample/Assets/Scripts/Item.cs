using System;
using UnityEngine;

public enum ItemTypeEnum
{
    WEAPON, ACCESSORY, POTION 
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite icon;
    public GameObject obj;
    public Properties properties;
}
[Serializable]
public class Properties
{
    public ItemTypeEnum itemTypeEnum;
    public int width;
    public int height;
}
