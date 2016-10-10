using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Labo5.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Labo5.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navSvc;
        private ICommand _editStudentCommand;
        public ICommand EditStudentCommand
        {
            get
            {
                if (this._editStudentCommand == null)
                    this._editStudentCommand = new RelayCommand(() => EditStudent());
                return this._editStudentCommand;
            }
        }
        private void EditStudent()
        {
            if (CityName == null || CityName == "")
                return;
            _navSvc.NavigateTo("ForecastPage", CityName);
        }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set {
                if (value != _cityName)
                {
                    _cityName = value;
                    RaisePropertyChanged("CityName");
                }
            }
        }

        [PreferredConstructor]
        public MainViewModel(INavigationService navigation = null)
        {
            _navSvc = navigation;
        }
        
    }
}
