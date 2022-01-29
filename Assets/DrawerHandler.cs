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
    }
    public override void DoAction()
    {
            isOpened = !isOpened;
            TriggerDrawer(); 
    }

    void TriggerDrawer()
    {
        anim.SetBool("isOPened", isOpened);
    }
  
}
