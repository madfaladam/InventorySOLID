using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [Header("var")]
    [SerializeField] int itemGenerateCount = 5000;
    public List<Item> items = new List<Item>();
    [Space]
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] InventoryGenerate inventoryGenerate;
    [SerializeField] InventorySearch inventorySearch;
    [SerializeField] InventorySort inventorySort;

    // Start is called before the first frame update
    void Start()
    {
        LoadComponents();
        InitUI();
    }

    private void LoadComponents()
    {
        inventoryUI = GetComponent<InventoryUI>();
        inventoryGenerate = GetComponent<InventoryGenerate>();
        inventorySearch = GetComponent<InventorySearch>();
        inventorySort = GetComponent<InventorySort>();
    }

    private void InitUI()
    {
        inventoryUI.generateInput.text = itemGenerateCount.ToString();

        inventoryUI.OnGenerateItem += GenerateItem;
        inventoryUI.OnSearchItem += SearchItem;
        inventoryUI.OnSortItem += SortItem;

        InventoryEvents.OnItemClicked += ClickItem;
    }

    private void SortItem(int value)
    {
        items = inventorySort.SortItem(inventoryUI.sortDropDown.options[inventoryUI.sortDropDown.value].text, items, inventoryGenerate.itemContainer);
    }

    private void SearchItem()
    {
        if (String.IsNullOrEmpty(inventoryUI.searchInput.text))
        {
            return;
        }
        inventorySearch.SearchItem(inventoryUI.searchInput.text, items, inventoryGenerate.itemContainer);
        inventoryUI.searchInput.text = "";
    }

    [ContextMenu("GenerateItem")]
    private void GenerateItem()
    {
        inventoryUI.sortDropDown.value = 0;
        items = inventoryGenerate.GenerateItem(int.Parse(inventoryUI.generateInput.text), items);

        ViewItems();
    }

    private void ViewItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            ItemObj itemObj = items[i].obj.GetComponent<ItemObj>();
            itemObj.SetItem(items[i]);
        }
    }

    private void ClickItem(Item item)
    {
        inventoryUI.itemImageShow.sprite = item.icon;
        inventoryUI.itemNameShow.text = item.name;
        inventoryUI.itemPropertiesShow.text = "Type: " + item.properties.itemTypeEnum + "\nHeight: " + item.properties.height + "\nWidth: " + item.properties.width;
    }
}
