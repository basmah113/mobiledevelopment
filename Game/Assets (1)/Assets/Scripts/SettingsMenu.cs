using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer mainMixer;

	public void SetVolume(float sliderValue)
	{
		float minimumVolume = -70f;

		if (sliderValue <= minimumVolume)
		{
			mainMixer.SetFloat("volume", minimumVolume);
		}
		else
		{
			mainMixer.SetFloat("volume", sliderValue);
		}
	}

	public void SetFullscreen(bool isFullscreen)
	{
		if (isFullscreen)
		{
			Screen.fullScreen = true;

#if UNITY_ANDROID
            try
            {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    var window = activity.Call<AndroidJavaObject>("getWindow");
                    var decorView = window.Call<AndroidJavaObject>("getDecorView");

                    int flags = 0x00000400 // SYSTEM_UI_FLAG_FULLSCREEN
                              | 0x00000200 // SYSTEM_UI_FLAG_HIDE_NAVIGATION
                              | 0x00001000; // SYSTEM_UI_FLAG_IMMERSIVE_STICKY
                    decorView.Call("setSystemUiVisibility", flags);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error setting immersive mode: " + ex.Message);
            }
#endif
		}
		else
		{
			Screen.fullScreen = false;

#if UNITY_ANDROID
            try
            {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    var window = activity.Call<AndroidJavaObject>("getWindow");
                    var decorView = window.Call<AndroidJavaObject>("getDecorView");

                    int flags = 0x00000000; // SYSTEM_UI_FLAG_VISIBLE
                    decorView.Call("setSystemUiVisibility", flags);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error clearing immersive mode: " + ex.Message);
            }
#endif
		}
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
}
