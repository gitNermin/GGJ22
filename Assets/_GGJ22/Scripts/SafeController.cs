using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : Interactable
{
    [SerializeField] GameObject _virtualCamera;
    public override void DoAction(GameObject player)
    {
        _virtualCamera.SetActive(true);
    }

}
