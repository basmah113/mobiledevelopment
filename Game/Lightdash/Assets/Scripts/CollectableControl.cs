using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableControl : MonoBehaviour
{
	public static int coinCount;
	public TMP_Text coinCountDisplay;

	void Update()
	{
		coinCountDisplay.text = "" + coinCount;
	}
   
}