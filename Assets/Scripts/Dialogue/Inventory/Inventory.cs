using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{ 
    public List<Item> items = new List<Item>();
    
    public void AddItem(ItemInfo itemInfo, int amount = 1)
    {
        Item item = items.FirstOrDefault(i => i.itemInfo.id == itemInfo.id);
        if (item != null)
        {
            item.amount++;
        }
        else
        {
            items.Add(new Item() { itemInfo = itemInfo, amount = amount });
        }

        Debug.Log("В интвентаре:");
        foreach (var VARIABLE in items)
        {
            Debug.Log($"{VARIABLE.amount}:{VARIABLE.itemInfo.name}");
        }
    }
    public void RemoveItem(ItemInfo itemInfo)
    {
        Item item = items.FirstOrDefault(i => i.itemInfo.id == itemInfo.id);

        if(item != null)
        {
            item.amount--;
            if(item.amount == 0)
            {
                items.Remove(item);
            }
        }
        
        Debug.Log("В интвентаре:");
        foreach (var VARIABLE in items)
        {
            Debug.Log($"{VARIABLE.amount}:{VARIABLE.itemInfo.name}");
        }
    }
}

