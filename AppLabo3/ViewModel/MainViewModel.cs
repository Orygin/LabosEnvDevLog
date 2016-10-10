using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabo3.Model;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace AppLabo3.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navSvc;
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                RaisePropertyChanged("Students");
            }
        }
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                Debug.WriteLine("Selected;");
                if(_selectedStudent != null)
                {
                    RaisePropertyChanged("SelectedStudent");
                }
            }
        }
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
            if (CanExecute())
            {
                _navSvc.NavigateTo("SecondPage", SelectedStudent);
            }
        }
        public bool CanExecute()
        {
            return SelectedStudent != null;
        }
        [PreferredConstructor]
        public MainViewModel(INavigationService navigation = null)
        {
            _navSvc = navigation;
            Students = new ObservableCollection<Student>(AllStudents.GetAllStudents());
            Debug.WriteLine("Exec view");
        }
    }
}
