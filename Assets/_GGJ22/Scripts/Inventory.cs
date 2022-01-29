using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "GGJ22/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public UnityEvent OnItemAdded;
    
    private List<PickupItem> _items = new List<PickupItem>();

    public List<PickupItem> Items => _items;
    
    public void Add(PickupItem item)
    {
        _items.Add(item);
        OnItemAdded?.Invoke();
    }

    public void Remove(PickupItem item)
    {
        _items.Remove(item);
    }
}