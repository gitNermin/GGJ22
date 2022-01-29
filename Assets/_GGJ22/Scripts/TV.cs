using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactable
{
    [SerializeField]
    private GameObject[] _channels;

    [SerializeField] private GameObject _diamond;

    [SerializeField]
    private GameObject _nosignalChannel;

    [SerializeField] private int _rightChannel;

    private bool _canbeOpen;
    public bool canBeOpen
    {
        get
        {
            return _canbeOpen;
        }
        set
        {
            _canbeOpen = value;
            _collider.enabled = value;
        }
    }

    private int _currChannel = 0;

    private Collider _collider;

    private void Start()
    {
        _actionName = "Click To SwitchOn";
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    public void SwitchONOFF()
    {
        if (!canBeOpen)
            return;

        _nosignalChannel.SetActive(!_nosignalChannel.activeSelf);
        _channels[_currChannel].SetActive(!_nosignalChannel.activeSelf);

    }

    public void ChangeChanel()
    {
        if (_nosignalChannel.activeSelf)
            return;

        _channels[_currChannel].SetActive(false);
        _currChannel = (_currChannel + 1) % _channels.Length;
        _channels[_currChannel].SetActive(true);
        
        if (_currChannel == _rightChannel)
        {
            if(_diamond)_diamond.SetActive(true);
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SwitchONOFF();

        if (Input.GetMouseButtonDown(0))
            ChangeChanel();
    }*/
    public override void DoAction(GameObject player)
    {
        if (_nosignalChannel.activeSelf)
        {
            SwitchONOFF();
            _actionName = "Click To Change Channel";
        }
        else
            ChangeChanel();
    }
}
