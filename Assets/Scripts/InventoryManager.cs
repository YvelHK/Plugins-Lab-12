using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

        quickSort(inventory.Select(a => a.value).ToArray(), 0, inventorySize - 1);
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

    // DO THE QUICK SORT, WE MUST MOVE QUICKLY

    public int partition(int[] array, int first, int last)
    {
        int pivot = array[last];
        int smaller = (first - 1);

        for (int element = first; element < last; element++)
        {
            if (array[element] < pivot)
            {
                element++;

                int temporary = array[smaller];
                array[smaller] = array[element];
                array[element] = temporary;
            }
        }

        int temporaryNext = array[smaller + 1];
        array[smaller + 1] = array[last];
        array[last] = temporaryNext;

        return smaller + 1;

    }

    public void quickSort(int[] array, int first, int last)
    {
        if (first < last)
        {
            int pivot = partition(array, first, last);

            quickSort(array, first, pivot - 1);
            quickSort(array, pivot + 1, last);

        }
    }
}
