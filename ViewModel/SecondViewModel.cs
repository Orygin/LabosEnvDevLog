using AppLabo3.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace AppLabo3.ViewModel
{
    public class SecondViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public Student SelectedStudent { get; set; }

        private INavigationService _navSvc;
        
        [PreferredConstructor]
        public SecondViewModel(INavigationService nav = null)
        {
            _navSvc = nav;
        }
        public void OnNavigateTo(NavigationEventArgs e)
        {
            SelectedStudent = (Student)e.Parameter;
        }
    }
}
