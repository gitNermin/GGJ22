using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public static PickupItem CurrentPickupItem;
    
    [SerializeField] private Sprite _thumbnail;
    [SerializeField] private string _name;

    public Sprite Thumbnail => _thumbnail;
    public string Name => _name;

    private Collider _collider;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidBody = gameObject.AddComponent<Rigidbody>();
    }

    public override void DoAction(GameObject player)
    {
        PickupItemsController _controller = player.GetComponent<PickupItemsController>();
        
        if (_controller)
        {
            _controller.Pickup(this);
            _collider.enabled = false;
            Destroy(_rigidBody);
        }
    }

    public void Throw(Vector2 force)
    {
        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _collider.enabled = true;
        //_rigidBody.AddForce(force);
    }

}
