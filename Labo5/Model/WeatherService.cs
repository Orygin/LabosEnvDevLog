using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Labo5.Model
{
    class WeatherService
    {
        public async Task<IEnumerable<WeatherForecast>> GetForecast(int cityId)
        {
            return await FetchForecast("http://api.openweathermap.org/data/2.5/forecast?id=" + cityId.ToString() + "&mode=json&APPID=e6f6a715dcd801d9ea1678adb73ef17d&lang=fr");
        }
        public async Task<IEnumerable<WeatherForecast>> GetForecast(string city)
        {
            return await FetchForecast("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&mode=json&APPID=e6f6a715dcd801d9ea1678adb73ef17d&lang=fr");
        }
        private async Task<IEnumerable<WeatherForecast>> FetchForecast(string url)
        {
            var wc = new HttpClient();
            var weather = await wc.GetStringAsync(url);
            var rawWeather = JObject.Parse(weather);
            var forecast = rawWeather["list"].Children().Select(d => new WeatherForecast()
            {
                Date = d["dt_txt"].Value<DateTime>(),
                MinTemp = d["main"]["temp_min"].Value<double>(),
                MaxTemp = d["main"]["temp_max"].Value<double>(),
                WeatherDescription = d["weather"].First["description"].Value<string>(),
                WindSpeed = d["wind"]["speed"].Value<double>()
            });
            return forecast;
        }
    }
}
