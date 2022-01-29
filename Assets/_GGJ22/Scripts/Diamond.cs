using UnityEngine;

public class Diamond : Interactable
{
    public override void DoAction(GameObject player)
    {
        FindObjectOfType<GameManager>().OnGemCollected();
        Destroy(gameObject);
    }
}
