using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
namespace m
{
	public class ShopManager : MonoBehaviour
	{
		public int currentBallIndex;
		public GameObject[] ballModels;
		public string[] ballNames;
		public int[] ballCosts;

		public TMP_Text ballNameText;
		public TMP_Text coinText;
		public TMP_Text ballPriceText;
		public Button selectButton;

		void Start()
		{
			//currentBallIndex = PlayerPrefs.GetInt("SelectedBall", 0);
			foreach (GameObject ball in ballModels)
				ball.SetActive(false);

			ballModels[currentBallIndex].SetActive(true);

			UpdateBallUI();
		}

		public void ChangeNext()
		{
			SoundManager._instance.FncButton();
			ballModels[currentBallIndex].SetActive(false);

			currentBallIndex++;
			if (currentBallIndex == ballModels.Length)
				currentBallIndex = 0;

			ballModels[currentBallIndex].SetActive(true);
			//PlayerPrefs.SetInt("SelectedBall", currentBallIndex);

			UpdateBallUI();
		}

		public void ChangePrevious()
		{
			SoundManager._instance.FncButton();
			ballModels[currentBallIndex].SetActive(false);

			currentBallIndex--;
			if (currentBallIndex == -1)
				currentBallIndex = ballModels.Length - 1;

			ballModels[currentBallIndex].SetActive(true);
			//PlayerPrefs.SetInt("SelectedBall", currentBallIndex);

			UpdateBallUI();
		}

		private void UpdateBallUI()
		{
			if (ballNameText != null)
			{
				ballNameText.text = ballNames[currentBallIndex];
			}

			if (coinText != null)
			{
				int playerCoins = PlayerPrefs.GetInt("TotalCoins", 0);
				coinText.text = "Coins: " + playerCoins;

				if (playerCoins >= ballCosts[currentBallIndex])
				{
					selectButton.interactable = true;
				}
				else
				{
					selectButton.interactable = false;
				}
			}

			if (ballPriceText != null)
			{
				ballPriceText.text = "Price: " + ballCosts[currentBallIndex] + " Coins";
			}
		}

		public void SelectBall()
		{
			SoundManager._instance.FncButton();
			int playerCoins = PlayerPrefs.GetInt("TotalCoins", 0);

			if (playerCoins >= ballCosts[currentBallIndex])
			{
				playerCoins -= ballCosts[currentBallIndex];
				PlayerPrefs.SetInt("TotalCoins", playerCoins);
				PlayerPrefs.SetInt("SelectedBall", currentBallIndex+1);
				PlayerPrefs.Save();

				Debug.Log("Ball selected: " + ballNames[currentBallIndex] + ". Remaining Coins: " + playerCoins);

				UpdateBallUI();
			}
			else
			{
				Debug.Log("Not enough coins to purchase this ball.");
			}
		}
	}
}
