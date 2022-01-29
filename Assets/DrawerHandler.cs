using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerHandler : Interactable
{
    Animator anim;
    [SerializeField] bool isOpened;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        TriggerDrawer();
        if (isOpened)
            _actionName = "Close";
        else
            _actionName = "Open";
    }
    public override void DoAction(GameObject player)
    {
        isOpened = !isOpened;
        TriggerDrawer();
        if (isOpened)
            _actionName = "Close";
        else
            _actionName = "Open";
    }

    void TriggerDrawer()
    {
        anim.SetBool("isOPened", isOpened);
    }

}
