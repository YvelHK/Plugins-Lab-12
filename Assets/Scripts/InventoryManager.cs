using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] int inventorySize;
    List<InventoryItem> inventory = new List<InventoryItem>();

    private void Start()
    {
        // Generate random list
        for (int i = 0; i < inventorySize; i++)
        {
            inventory.Add(new InventoryItem(Random.Range(1, 1001), "item_" + i, Random.Range(1, 101)));
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }

    public InventoryItem BinarySearchByID(int id)
    {
        inventory.Sort((a,b) => a.id.CompareTo(b.id));
        int left = 0;
        int right = inventory.Count - 1;
        int mid;
        while (left <= right)
        {
            mid = (left + right) / 2;

            if (id == inventory[mid].id)
                return inventory[mid];
            else if (id < inventory[mid].id)
                right = mid - 1;
            else if (id > inventory[mid].id)
                left = mid + 1;
        }
        return null;
    }

    public int partition(int first, int last)
    {
        int pivotVal = inventory[last].value;
        int smaller = (first - 1);

        for (int element = first; element < last; element++)
        {
            if (inventory[element].value < pivotVal)
            {
                smaller++;

                InventoryItem temporary = inventory[smaller];
                inventory[smaller] = inventory[element];
                inventory[element] = temporary;
            }
        }

        InventoryItem temporaryNext = inventory[smaller + 1];
        inventory[smaller + 1] = inventory[last];
        inventory[last] = temporaryNext;

        return smaller + 1;

    }

    public void QuickSortByValue(int first, int last)
    {
        if (first < last)
        {
            int pivot = partition(first, last);

            QuickSortByValue(first, pivot - 1);
            QuickSortByValue(pivot + 1, last);
        }
    }
}
