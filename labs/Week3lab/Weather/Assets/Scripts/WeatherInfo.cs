using Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Weather
    {
        public int id;
        public string main;
    }

    public class WeatherInfo
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }


}


