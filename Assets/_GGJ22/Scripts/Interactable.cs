using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected string _actionName;

    public string ActionName => _actionName;

    public abstract void DoAction(GameObject player);
}
