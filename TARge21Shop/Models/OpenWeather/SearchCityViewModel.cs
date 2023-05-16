﻿namespace TARge21Shop.Models.OpenWeather
{
    public class SearchCityViewModel
    {
        public string CityName { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public double Speed { get; set; }
    }
}