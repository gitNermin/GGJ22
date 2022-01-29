using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject _portalB;
    [SerializeField]
    private float _portalsGapTime = 2;


    private GameObject _myEffect;

    private Transform _portalBPoint;
    private GameObject _portalBEffect;

    private GameObject _Item;

    private void Start()
    {
        _myEffect = transform.GetChild(0).gameObject;
        _portalBEffect = _portalB.transform.GetChild(0).gameObject;
        _portalBPoint = _portalB.transform.GetChild(1); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();

        if(item && !item.itemChanged)
        {
            _myEffect.SetActive(true);
            _Item = collision.gameObject;
            StartCoroutine(TransferItem());
        }
    }

    private IEnumerator TransferItem()
    {
        yield return new WaitForSeconds(_portalsGapTime);
        _myEffect.SetActive(false);
        _portalBEffect.SetActive(true);
        _Item.SetActive(false);

        yield return new WaitForSeconds(_portalsGapTime);
        _portalBEffect.SetActive(false);
        _Item.transform.position = _portalBPoint.position;
        _Item.SetActive(true);
        _Item.GetComponent<Item>().ChangeItem();
    }
}
