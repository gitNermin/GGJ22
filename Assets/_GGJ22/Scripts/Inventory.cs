using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "GGJ22/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public UnityEvent OnItemAdded;
    
    private List<PickupItem> _items = new List<PickupItem>();

    public List<PickupItem> Items => _items;

    private int _currentSelectedItem = -1;
    
    
    public PickupItemsController Controller;

    public void Clear()
    {
        _currentSelectedItem = -1;
        _items.Clear();
    }
    
    public void Add(PickupItem item)
    {
        _items.Add(item);
        OnItemAdded?.Invoke();
    }

    public void SelectItem()
    {
        _currentSelectedItem++;
        if (_currentSelectedItem == _items.Count)
        {
            _currentSelectedItem = -1;
        }

        if (_currentSelectedItem >= 0)
        {
            Controller.SwitchItem(_items[_currentSelectedItem]);
        }
        else
        {
            Controller.Hide();
        }
        
        
    }

    public void Remove(PickupItem item)
    {
        _items.Remove(item);
    }
    
    
}