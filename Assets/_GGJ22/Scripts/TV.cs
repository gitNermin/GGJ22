using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _channels;

    [SerializeField]
    private GameObject _nosignalChannel;

    public bool canBeOpen;

    private int _currChannel = 0;


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
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SwitchONOFF();

        if (Input.GetMouseButtonDown(0))
            ChangeChanel();
    }*/
}
