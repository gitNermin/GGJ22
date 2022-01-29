using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int _numberOfGems = 0;
	public Gate gate;
	public int maxNumberOfGems = 2;

	public void OnGemCollected()
    {
		_numberOfGems++;
		if (_numberOfGems == maxNumberOfGems)
			gate.Open();
    }
}
