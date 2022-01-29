using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryItemUI _prefab;

    private int _selectedItem = -1;


    private void Start()
    {
        _inventory.OnItemsChanged.AddListener(OnItemAdded);
        _inventory.OnItemsSelected.AddListener(OnItemSelected);
    }

    void OnItemAdded()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _inventory.Items.Count; i++)
        {
            var item = Instantiate(_prefab);
            item.transform.SetParent(transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale = Vector3.one;
            item.SetImage(_inventory.Items[i].Thumbnail);
        }
    }

    void OnItemSelected()
    {
        if (_selectedItem > 0 && transform.childCount > _selectedItem)
        {
            transform.GetChild(_selectedItem).GetComponent<InventoryItemUI>().Deselect();
        }

        if (_inventory.CurrentSelectedItem >= 0 && transform.childCount > _inventory.CurrentSelectedItem)
        {
            _selectedItem = _inventory.CurrentSelectedItem;
            transform.GetChild(_selectedItem).GetComponent<InventoryItemUI>().Select();
        }

    }
}
