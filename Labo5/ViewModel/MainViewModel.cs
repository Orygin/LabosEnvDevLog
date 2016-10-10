using GalaSoft.MvvmLight;
using Labo5.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo5.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<WeatherForecast> _forecast = null;

        public ObservableCollection<WeatherForecast> Forecast
        {
            get
            {
                return _forecast;
            }
            set
            {
                if(_forecast == value)
                {
                    return;
                }
                _forecast = value;
                RaisePropertyChanged("Forecast");
            }
        }

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                var forecast = new Forecast() { Cityname = "Namur" };
                var weatherForecasts = new List<WeatherForecast>();
                for(int i= 0; i < 40; i++)
                {
                    weatherForecasts.Add(new WeatherForecast()
                    {
                        Date = DateTime.Now.AddDays(i),
                        MaxTemp = 5 + i / 2,
                        MinTemp = i / 2,
                        WeatherDescription = "Peu de nuages",
                        WindSpeed = i % 7
                    });
                }
                forecast.WeatherForecasts = weatherForecasts;
                Forecast = new ObservableCollection<WeatherForecast>(weatherForecasts);
            }
            else
                InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var service = new WeatherService();
            var forecast = await service.GetForecast();
            Forecast = new ObservableCollection<WeatherForecast>(forecast);
        }
    }
}
