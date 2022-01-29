using UnityEngine;

public class DropSurface : Interactable
{
    [SerializeField] private Transform _dropPosition;

    public override void DoAction(GameObject player)
    {
        player.GetComponent<PickupItemsController>().Place(_dropPosition);
    }
}