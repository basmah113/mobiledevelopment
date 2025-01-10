using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace m
{

    public class MainMenu : MonoBehaviour
    {
        public TMP_Text[] totalCoinsTxt;
        public TMP_Text _myCity;
        public GameObject settingsPanel;
        public GameObject mainMenuPanel;
        public GameObject levelPanel;
        public GameObject shopPanel,shopAds, pnl_loading;
        bool isSoundOn;
        void Start()
        {
            int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            for (int i = 0; i < totalCoinsTxt.Length; i++)
            {
                totalCoinsTxt[i].text = "Total Coins: " + totalCoins.ToString();
            }
          

            Debug.Log("Loaded Total Coins: " + totalCoins);

            isSoundOn = PlayerPrefs.GetInt("Sound") == 0 ? true : false;

            SoundManager._instance.FncCheckMusic();
        }

        private void Update()
        {
            if(WeatherManager._instance)
            {
                _myCity.text = WeatherManager._instance._myCity;
            }
        }

        public void UpdateTotalCoinsUI()
        {
            int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            for (int i = 0; i < totalCoinsTxt.Length; i++)
            {
                totalCoinsTxt[i].text = "Total Coins: " + totalCoins.ToString();
            }
        }

        public void NewGame()
        {
            SoundManager._instance._HFC.LightFeedback();
            mainMenuPanel.SetActive(false);

            levelPanel.SetActive(true);
            SoundManager._instance.FncButton();
            Debug.Log("Level selection panel activated.");
        }

        public void StartLevel(int levelIndex)
        {
            SoundManager._instance._HFC.LightFeedback();
            AdsManager._instance.FncShowInitads();
            PlayerPrefs.SetInt("SavedLevel", levelIndex);
            PlayerPrefs.Save();
            SoundManager._instance.FncButton();
            Debug.Log("Starting Level: " + levelIndex);
            pnl_loading.SetActive(true);
            SceneManager.LoadScene("Level " + levelIndex);
           
        }

        public void LoadGame()
        {

            int savedLevel = PlayerPrefs.GetInt("SavedLevel", 1);
            Debug.Log("Loading Saved Level: " + savedLevel);
            SoundManager._instance.FncButton();
            pnl_loading.SetActive(true);
            SceneManager.LoadScene("Level " + savedLevel);
        }

     

        public void OpenShop()
        {
            SoundManager._instance._HFC.LightFeedback();
            SoundManager._instance.FncButton();
            mainMenuPanel.SetActive(false);
            shopPanel.SetActive(true);
        }

        public void BackToMainMenu()
        {
            SoundManager._instance.FncButton();
            settingsPanel.SetActive(false);
            levelPanel.SetActive(false);
            shopPanel.SetActive(false);
            shopAds.SetActive(false);

            mainMenuPanel.SetActive(true);
        }

        public void FncButtonSound()
        {
            SoundManager._instance.FncButton();
        }
        public void ExitGame()
        {
            SoundManager._instance.FncButton();
            Debug.Log("Exit button clicked! Exiting the game...");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }


        #region Setting

        public void FncQuality(int id)
        {
            SoundManager._instance._HFC.LightFeedback();
            SoundManager._instance.FncButton();
            QualitySettings.SetQualityLevel(id);
        }
        public void OpenSettings()
        {
            SoundManager._instance._HFC.LightFeedback();
            SoundManager._instance.FncButton();
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
        public void CloseSettings()
        {
            SoundManager._instance.FncButton();
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        public void FncSound(int id)
        {
            switch (id)
            {
                case 0:
                    SoundManager._instance.FncButton();
                    PlayerPrefs.SetInt("Sound", 0);
                    SoundManager._instance.FncCheckMusic();
                    break;
                case 1:
                    PlayerPrefs.SetInt("Sound", 1);
                    SoundManager._instance.FncButton();
                    SoundManager._instance.FncCheckMusic();
                    break;
            }
        }

        #endregion

    }
}
