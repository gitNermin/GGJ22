using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _channels;

    [SerializeField]
    private int _rightChannel;

    [SerializeField]
    private TV _tv;


    private AudioSource _audioSource;
    private int _currChannel = 0;


    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _channels[_currChannel];
        _audioSource.loop = true;
    }

    public void SwitchONOFF()
    {
        if (_audioSource.isPlaying)
            _audioSource.Stop();
        else
            _audioSource.Play();
    }

    public void ChangeChanel()
    {
        if (!_audioSource.isPlaying)
            return;

        _currChannel = (_currChannel + 1) % _channels.Length;
        _audioSource.clip = _channels[_currChannel];

        _audioSource.Play();

        if (_currChannel == _rightChannel && _tv && !_tv.canBeOpen)
        {
            _tv.canBeOpen = true;
            _tv.SwitchONOFF();
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SwitchONOFF();

        if (Input.GetMouseButtonDown(0))
            ChangeChanel();
    }*/
}
