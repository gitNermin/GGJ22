using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _channels;

    private int _currChannel = 0;

    public void ChangeChanel()
    {
        _channels[_currChannel].SetActive(false);
        _currChannel = (_currChannel + 1) % _channels.Length;
        _channels[_currChannel].SetActive(true);
    }
}
