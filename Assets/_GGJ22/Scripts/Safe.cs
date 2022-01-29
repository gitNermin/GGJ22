using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Safe : Interactable
{
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private Animator _door;

    [SerializeField]
    private StarterAssetsInputs _playerInput;

    [SerializeField]
    private string _rightCode;

    [SerializeField]
    private TextMesh _screenText;

    private int _numberOfChar = 0;

    public void EnterNumber(string number)
    {
        if(number.Equals("star"))
        {
            Exit();
            return;
        }

        if (number.Equals("hash"))
        {
            ClearCode();
            return;
        }

        if (_numberOfChar == 0)
            _screenText.text = number;
        else
            _screenText.text += number;

        _numberOfChar++;

        CheckCode();
    }

    private void OpenSafe()
    {
        _door.enabled = true;
        _screenText.gameObject.SetActive(false);
    }

    private void ClearCode()
    {
        _numberOfChar = 0;
        _screenText.text = "";
    }

    private void CheckCode()
    {
        if (_numberOfChar == _rightCode.Length)
        {
            if (_rightCode.ToLower().Equals(_screenText.text.ToLower()))
            {
                OpenSafe();
            }
            else
            {
                ClearCode();
            }
        }
    }

    public override void DoAction(GameObject player)
    {
        _camera.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
        _playerInput.SetCursorState(false);
    }

    public void Exit()
    {
        _camera.SetActive(false);
        GetComponent<BoxCollider>().enabled = true;
        _playerInput.SetCursorState(true);
    }
}
