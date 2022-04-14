using System;

public class InventoryEvents
{
    public static event Action<Item> OnItemClicked;

    public static void ItemClickedEvent(Item item)
    {
        OnItemClicked?.Invoke(item);
    }
}
