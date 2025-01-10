using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager _instance;
    private const string IpApiUrl = "http://ip-api.com/json/";
    private const string WeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";
    private const string ApiKey = "8867b778b164b3bc67eb69e0128fae08"; // Replace with your API key

    public string _myCity;
    public string _myWeather;

    private void OnEnable()
    {
        
        if(_instance ==null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(GetLocationAndWeather());
    }

    IEnumerator GetLocationAndWeather()
    {
        // Step 1: Get location data from IP
        UnityWebRequest locationRequest = UnityWebRequest.Get(IpApiUrl);
        yield return locationRequest.SendWebRequest();

        if (locationRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to fetch location data: " + locationRequest.error);
            yield break;
        }

        // Parse location data
        var locationData = JsonUtility.FromJson<LocationData>(locationRequest.downloadHandler.text);
        Debug.Log($"Location: {locationData.city}, Lat: {locationData.lat}, Lon: {locationData.lon}");

        _myCity = locationData.city;

        // Step 2: Get weather data from latitude and longitude
        string weatherUrl = $"{WeatherApiUrl}?lat={locationData.lat}&lon={locationData.lon}&appid={ApiKey}";
        UnityWebRequest weatherRequest = UnityWebRequest.Get(weatherUrl);
        yield return weatherRequest.SendWebRequest();

        if (weatherRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to fetch weather data: " + weatherRequest.error);
            yield break;
        }

        // Parse weather data
        var weatherData = JsonUtility.FromJson<WeatherData>(weatherRequest.downloadHandler.text);
        Debug.Log($"Weather: {weatherData.weather[0].description}");
        _myWeather = weatherData.weather[0].description;
    }

    // Location data model
    [System.Serializable]
    private class LocationData
    {
        public string city;
        public float lat;
        public float lon;
    }

    // Weather data model
    [System.Serializable]
    private class WeatherData
    {
        public Weather[] weather;
    }

    [System.Serializable]
    private class Weather
    {
        public string main;
        public string description;
    }
}

