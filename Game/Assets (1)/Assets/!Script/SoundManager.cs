using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m
{

    public class SoundManager : MonoBehaviour
    {

        public static SoundManager _instance;
        public AudioSource GameMusic,Btn_sound,_coins,_Blast,_failed,_Win;
        public CandyCoded.HapticFeedback.HapticFeedbackController _HFC;
        private void OnEnable()
        {
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void FncPlayMusic()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                GameMusic.Play();
            }
 
        }

        public void FncButton()
        {
            if(PlayerPrefs.GetInt("Sound") ==0)
            {
                Btn_sound.Play();
            }
            
        }
        public void FncCoins()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                _coins.Play();
            }
        }
        public void FncBlast()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                _Blast.Play();
            }
        }
        public void FncFailed()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                _failed.Play();
            }
        }
        public void FncWin()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                _Win.Play();
            }
        }

        public void FncLowVibrate()
        {
            StartCoroutine(VibrateLow());
        }

        IEnumerator VibrateLow()
        {
            Handheld.Vibrate();
            yield return new WaitForSeconds(0.1f); // Short vibration
        }

        public void FncCheckMusic()
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                GameMusic.enabled = Btn_sound.enabled = _coins.enabled = _Blast.enabled = _failed.enabled = _Win.enabled = false;
            }
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                GameMusic.enabled = Btn_sound.enabled = _coins.enabled = _Blast.enabled = _failed.enabled = _Win.enabled = true;
            }
            FncPlayMusic();
        }
    }
}
