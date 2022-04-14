using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemObj : MonoBehaviour
{
    Button itemBtn;
    Image itemImg;
    Item item;

    private void Awake()
    {
        itemBtn = GetComponent<Button>();
        itemImg = transform.GetChild(0).GetComponent<Image>();
        itemBtn.onClick.AddListener(Click);
    }

    private void Click()
    {
        InventoryEvents.ItemClickedEvent(item);
    }

    internal void SetItem(Item arg0)
    {
        item = arg0;
        itemImg.sprite = item.icon;
    }
}
