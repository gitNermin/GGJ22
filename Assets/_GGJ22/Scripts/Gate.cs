using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator _anim;

    public void Open()
    {
        _anim.enabled = true;
    }

}
