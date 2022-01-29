using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "GGJ22/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public UnityEvent OnItemsChanged;
    public UnityEvent OnItemsSelected;
    
    private List<PickupItem> _items = new List<PickupItem>();

    public List<PickupItem> Items => _items;

    private int _currentSelectedItem = -1;

    public int CurrentSelectedItem
    {
        get
        {
            return _currentSelectedItem;
        }
    }
    
    
    public PickupItemsController Controller;

    public void Clear()
    {
        _currentSelectedItem = -1;
        _items.Clear();
    }
    
    public void Add(PickupItem item)
    {
        _items.Add(item);
        _currentSelectedItem = _items.Count - 1;
        OnItemsChanged?.Invoke();
        OnItemsSelected?.Invoke();
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
        
        OnItemsSelected?.Invoke();
    }

    public void Remove(PickupItem item)
    {
        _items.Remove(item);
        _currentSelectedItem = -1;
        OnItemsChanged.Invoke();
        OnItemsSelected?.Invoke();
    }
    
    
}