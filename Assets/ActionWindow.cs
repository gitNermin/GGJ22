using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _actionText;
    [SerializeField] private GameObject _active;
    [SerializeField] private GameObject _inActive;


    public void Activate(string action)
    {
        _active.SetActive(true);
        _inActive.SetActive(false);
        _actionText.text = action;
    }

    public void Deactivate()
    {
        _active.SetActive(false);
        _inActive.SetActive(true);
    }

}
