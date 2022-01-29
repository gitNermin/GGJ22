using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponentInParent<Safe>().EnterNumber(name);
    }
}
