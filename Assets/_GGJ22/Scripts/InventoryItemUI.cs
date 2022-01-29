using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private GameObject _border;

    public void SetImage(Sprite image)
    {
        _iconImage.sprite = image;
    }

    public void Select()
    {
        _border.SetActive(true);
    }

    public void Deselect()
    {
        _border.SetActive(false);
    }
}
