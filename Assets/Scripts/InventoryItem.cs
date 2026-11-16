using UnityEngine;

public class InventoryItem
{
    public int id, value;
    public string name;
    public InventoryItem(int id, string name, int value)
    {
        this.id = id;
        this.name = name;
        this.value = value;
    }
}
