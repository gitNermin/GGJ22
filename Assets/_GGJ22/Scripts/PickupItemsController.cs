using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
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
            StartCoroutine(MoveObject(_currentItem.transform, 0.3f, _pickupLocation, null));
        }
    }

    IEnumerator MoveObject(Transform obj, float time, Transform endValues, UnityAction onFinished)
    {
        var wait = new WaitForEndOfFrame();
        float passedTime = 0;
        Vector3 startPosition = obj.position;
        Quaternion startRotation = obj.rotation;
        while (passedTime<time)
        {
            yield return wait;
            passedTime += Time.deltaTime;
            if (passedTime > time)
            {
                passedTime = time;
            }
            float alpha = passedTime / time;
            obj.position = Vector3.Lerp(startPosition, endValues.position, alpha);
            obj.rotation = Quaternion.Lerp(startRotation, endValues.rotation, alpha);
            
        }
        onFinished?.Invoke();
    }

    public void Place(Transform dropPosition)
    {
        if (_currentItem)
        {
            _currentItem.transform.SetParent(null);
            _inventory.Remove(_currentItem);
            PickupItem item = _currentItem;
            StartCoroutine(MoveObject(_currentItem.transform,0.3f, dropPosition, () => { item.Throw(Vector3.zero);}));
            _currentItem = null;
        }
    }
}