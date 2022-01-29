using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItemsController : MonoBehaviour
{
    [SerializeField] private Transform _pickupLocation;
    [SerializeField] private InputActionReference _throwInput;
    [SerializeField] private InputActionReference _addToInventoryInput;
    [SerializeField] private InputActionReference _selectInventory;
    [SerializeField] private Inventory _inventory;

    private PickupItem _currentItem;

    public bool HasItem
    {
        get
        {
            return _currentItem;
        }
    }

    private void Start()
    {
        _throwInput.action.performed += Throw;
        _addToInventoryInput.action.performed += AddToInventory;
        _selectInventory.action.performed += SelectInventory;
        _inventory.Controller = this;
        _inventory.Clear();
    }

    private void Throw(InputAction.CallbackContext context)
    {
        if (_currentItem)
        {
            _currentItem.transform.SetParent(null);
            _inventory.Remove(_currentItem);
            _currentItem.Throw(100 * _pickupLocation.forward);
            _currentItem = null;
        }
    }

    public void AddToInventory(InputAction.CallbackContext context)
    {
        Hide();
    }
    public void SelectInventory(InputAction.CallbackContext context)
    {
        _inventory.SelectItem();
    }

    public void Hide()
    {
        if (_currentItem)
        {
            _currentItem.gameObject.SetActive(false);
            _currentItem = null;
        }
    }

    public void SwitchItem(PickupItem item)
    {
        if (item != _currentItem)
        {
            if (_currentItem)
            {
                _currentItem.gameObject.SetActive(false);
            }
            item.gameObject.SetActive(true);
            _currentItem = item;
        }
    }

    public void Pickup(PickupItem item)
    {
        if (!_currentItem)
        {
            _currentItem = item;
            item.transform.SetParent(_pickupLocation);
            _inventory.Add(_currentItem);
            StartCoroutine(Pickup(0.3f));
        }
    }

    IEnumerator Pickup(float time)
    {
        var wait = new WaitForEndOfFrame();
        float passedTime = 0;
        Vector3 startPosition = _currentItem.transform.position;
        Quaternion startRotation = _currentItem.transform.rotation;
        while (passedTime<time)
        {
            yield return wait;
            passedTime += Time.deltaTime;
            if (passedTime > time)
            {
                passedTime = time;
            }
            float alpha = passedTime / time;
            _currentItem.transform.position = Vector3.Lerp(startPosition, _pickupLocation.position, alpha);
            _currentItem.transform.rotation = Quaternion.Lerp(startRotation, _pickupLocation.rotation, alpha);
            
        }

    }
}