using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Threading.Tasks;
using Assets;
using UnityEngine.Networking;

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "6e55bcbe1ed0f40c7a000af923cea220";
    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
    public GameObject SnowSystem;
    public string CityId;
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    void Start()
    {
        StartCoroutine(GetWeather(CheckSnowStatus));
    }
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckSnowStatus));
        }
    }

    private IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
        {
            using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY)))
            {
                yield return req.Send();
                while (!req.isDone)
                    yield return null;
                byte[] result = req.downloadHandler.data;
                string weatherJSON = System.Text.Encoding.Default.GetString(result);
                WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
                onSuccess(info);
            }
        }

    public void CheckSnowStatus(WeatherInfo weatherObj)
    {
        bool snowing = weatherObj.weather[0].main.Equals("Snow");
        if (snowing)
            SnowSystem.SetActive(true);
        else
            SnowSystem.SetActive(false);
    }


    /* public async void CheckSnowStatus()
       {
           bool snowing = (await GetWeather()).weather[0].main.Equals("Snow");
           if (snowing)
               SnowSystem.SetActive(true);
           else
               SnowSystem.SetActive(false);
       }
       private async Task<WeatherInfo> GetWeather()
       {
           HttpWebRequest request =
           (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}",
            CityId, API_KEY));
           HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
           StreamReader reader = new StreamReader(response.GetResponseStream());
           string jsonResponse = reader.ReadToEnd();
           WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
           return info;
     }
   */

}


