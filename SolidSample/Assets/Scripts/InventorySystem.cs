using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [Header("var")]
    [SerializeField] int itemGenerateCount = 5000;
    public List<Item> items = new List<Item>();
    [Space]
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] InventoryGenerate inventoryGenerate;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        LoadComponents();
        InitUI();
    }

    private void LoadComponents()
    {
        inventoryUI = GetComponent<InventoryUI>();
        inventoryGenerate = GetComponent<InventoryGenerate>();
    }

    private void InitUI()
    {
        inventoryUI.generateBtn.onClick.AddListener(GenerateItem);
    }

    [ContextMenu("GenerateItem")]
    private void GenerateItem()
    {
        items = inventoryGenerate.GenerateItem(itemGenerateCount, items);

        ViewItems();
    }

    private void ViewItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            ItemObj itemObj = items[i].obj.GetComponent<ItemObj>();
            itemObj.itemImg.sprite = items[i].icon;
            int id = items[i].id;
            itemObj.itemBtn.onClick.AddListener(()=>ClickItem(id));
        }
    }

    private void ClickItem(int id)
    {
        inventoryUI.ItemImageShow.sprite = items[id].icon;
        inventoryUI.ItemNameShow.text = items[id].name;
        inventoryUI.ItemPropertiesShow.text = "Type: " + items[id].properties.itemTypeEnum + "\nHeight: " + items[id].properties.height + "\nWidth: " + items[id].properties.width;
    }
}
