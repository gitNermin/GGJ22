using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemA;

    [SerializeField]
    private GameObject _itemB;

    [HideInInspector]
    public bool itemChanged;

    private void Start()
    {
        _itemA.SetActive(true);
        _itemB.SetActive(false);

        itemChanged = false;
    }

    public void ChangeItem()
    {
        itemChanged = true;

        if (!_itemA || !_itemB)
            return;

        _itemA.SetActive(false);
        _itemB.SetActive(true);
    }
}
