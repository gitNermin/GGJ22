using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator _anim;
    public GameObject _collider;

    public void Open()
    {
        _anim.enabled = true;
        _collider.SetActive(false);
    }

}
