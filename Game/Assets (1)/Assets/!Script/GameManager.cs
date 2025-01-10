using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
namespace m
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameObject pnl_SelectControls, pnl_Paused, pnl_Loading, pnl_Buttons, pnl_Failed, pnl_Complete;
        public GameObject _rain, _Snow;
        public Transform _checkPoints;
        public Slider _speedSlider;
        public PlayerController _player;
        public TMP_Text txt_Coins,txt_Speed,txt_Weather,txt_City;
        public bool isGameOver;
        public int NextLevel;
        public Button Btn_Reward;
        int coinCount;
        public int Currlvl;
        bool isGiveCoins;
        void OnEnable()
        {
            instance = this;
            Time.timeScale = 1.0f;
            coinCount = 0;
            isGameOver = false;
            pnl_SelectControls.SetActive(true);

            _speedSlider.value = _player.speed;
            txt_Speed.text ="Speed " + _speedSlider.value;

            PlayerPrefs.SetInt("CurrentLvl", Currlvl);
            
        }

        private void Update()
        {
            if(WeatherManager._instance)
            {
                txt_Weather.text = WeatherManager._instance._myWeather;
                txt_City.text = WeatherManager._instance._myCity;

                if(WeatherManager._instance._myWeather == "broken clouds" || WeatherManager._instance._myWeather == "light rain")
                {
                    _rain.SetActive(true);
                }

                if (WeatherManager._instance._myWeather == "snow" || WeatherManager._instance._myWeather == "light snow")
                {
                    _Snow.SetActive(true);
                }
            }
        }

        #region Buttons
        public void OnSelectAcce()
        {
            _player.ResetAll();
            SoundManager._instance.FncButton();
            _player.isAcceleration = true;
            pnl_SelectControls.SetActive(false);
        }
        public void OnSelectGyro()
        {
            _player.ResetAll();
            SoundManager._instance.FncButton();
            _player.isGyro = true;
            pnl_SelectControls.SetActive(false);
        }
        public void OnSelectKeyBoard()
        {
            SoundManager._instance.FncButton();
            _player.ResetAll();
            _player.isKeyBoard = true;
            pnl_SelectControls.SetActive(false);
        }

        public void OnSelectButton()
        {
            SoundManager._instance.FncButton();
            _player.ResetAll();
            _player.isButton = true;
            pnl_SelectControls.SetActive(false);
        }

        public void OnSelectAgain()
        {
            SoundManager._instance.FncButton();
            pnl_Loading.SetActive(true);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        public void OnSelectPaused()
        {
            SoundManager._instance._HFC.LightFeedback();
            Time.timeScale = 0;
            SoundManager._instance.FncButton();
            pnl_Paused.SetActive(true);
        }
        public void OnSelectResume()
        {
            SoundManager._instance.FncButton();
            Time.timeScale = 1;
            pnl_Paused.SetActive(false);
        }

        public void OnSelectHome()
        {
            SoundManager._instance.FncButton();
            pnl_Loading.SetActive(true);
            SceneManager.LoadSceneAsync(0);
        }

        public void OnSelectNext()
        {
            SoundManager._instance.FncButton();
            pnl_Loading.SetActive(true);
            SceneManager.LoadSceneAsync(NextLevel);
        }

        public void FncHorizontal(int h)
        {
            SoundManager._instance.FncButton();
            _player.moveHorizontal = h;
        }
        public void FncVertical(int v)
        {
            SoundManager._instance.FncButton();
            _player.moveVertical = v;
        }

        #endregion

        public void FncCollectCoins()
        {
            SoundManager._instance.FncCoins();
            coinCount++;
            txt_Coins.text = coinCount.ToString();
            SaveCoins();
        }

        void SaveCoins()
        {
            int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            totalCoins += coinCount; // Add current level coins to saved total
            PlayerPrefs.SetInt("TotalCoins", totalCoins);
            PlayerPrefs.Save();

            //coinCount = 0; // Reset coin count after saving
        }

        public void FncOnChangeValue()
        {
            _player.speed = _speedSlider.value;
            txt_Speed.text = "Speed " + _speedSlider.value;
        }

        public void FncClickReward()
        {
            AdsManager._instance.FnShowRewardads();
        }

        public void FncClickRewardCoins()
        {
            isGiveCoins = true;
            AdsManager._instance.FnShowRewardads();
        }


        public void FncGiveReward()
        {
            if(isGiveCoins == false)
            {
                _player.transform.position = _checkPoints.position;
                Time.timeScale = 1;
                pnl_Failed.SetActive(false);
                isGameOver = false;
            }
            if(isGiveCoins == true)
            {
                PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins")+ 20);
                Debug.Log("total" + PlayerPrefs.GetInt("TotalCoins"));
            }
        
        }
    }


}
