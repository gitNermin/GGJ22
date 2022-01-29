using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private InputActionReference _input;
    [SerializeField] private ActionWindow _actionWindow;
    private Interactable _currentInteractable;
    private PickupItemsController _controller;

    private void Start()
    {
        _input.action.performed += OnInteract;
        _controller = GetComponent<PickupItemsController>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 5, _interactableLayer))
        {
            var interactable = hit.transform.GetComponent<Interactable>();
            _currentInteractable = interactable;
            if (interactable)
            {
                if (interactable is PickupItem && _controller.HasItem)
                {
                    Deactivate();
                }
                else
                {
                    Activate();
                }
            }
            else
            {
                Deactivate();
            }
        }
        else
        {
            Deactivate();
        }
    }
    
    public void OnInteract(InputAction.CallbackContext value)
    {
        if (_currentInteractable)
        {
            _currentInteractable.DoAction(gameObject);
        }
    }


    void Activate()
    {
        _actionWindow.Activate(_currentInteractable.ActionName);
    }

    void Deactivate()
    {
        _currentInteractable = null;
        _actionWindow.Deactivate();
    }
}
