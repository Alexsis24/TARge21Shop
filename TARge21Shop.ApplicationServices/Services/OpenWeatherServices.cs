﻿using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            //127964 Tallinna kood
            string IDOWeather = "eac08d3c897df608a93804f6be62b2ab";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&APPID={IDOWeather}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherRootDto weatherResult = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.City = weatherResult.Name;
                dto.Temperature = Math.Round(weatherResult.Main.Temp);
                dto.Feels_like = Math.Round(weatherResult.Main.FeelsLike);
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.Speed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;
            }

            return dto;
        }
    }
}