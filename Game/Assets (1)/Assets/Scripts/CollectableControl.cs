using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableControl : MonoBehaviour
{
	public static int coinCount = 0;
	public TMP_Text coinCountDisplay;

	void Update()
	{
		// Update in-game coin counter
		if (coinCountDisplay != null)
		{
			coinCountDisplay.text = coinCount.ToString();
		}
	}

	public static void SaveCoins()
	{
		int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
		totalCoins += coinCount; // Add current level coins to saved total
		PlayerPrefs.SetInt("TotalCoins", totalCoins);
		PlayerPrefs.Save();

		Debug.Log("Coins Saved! Total Coins: " + totalCoins);
		coinCount = 0; // Reset coin count after saving
	}


}
