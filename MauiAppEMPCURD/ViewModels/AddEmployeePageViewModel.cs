using MauiAppEMPCURD.Model;
using MauiAppEMPCURD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace MauiAppEMPCURD.ViewModels
{
    public class AddEmployeePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Properties
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                var args = new PropertyChangedEventArgs(nameof(Name));
                PropertyChanged?.Invoke(this, args);
            }

        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                var args = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                var args = new PropertyChangedEventArgs(nameof(Address));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private int _employeeID;
        private readonly EmployeeService _employeeService;


        #endregion

        #region Constructor
        public AddEmployeePageViewModel()
        {
            _employeeService = new EmployeeService();
        }

        public AddEmployeePageViewModel(EmployeeModel employeeObj)
        {
            Name = employeeObj.Name;
            Email = employeeObj.Email;
            Address = employeeObj.Address;
            _employeeID = employeeObj.ID;
            _employeeService = new EmployeeService();

        }
        #endregion


        #region Commands
        public ICommand AddEmployeeCommand => new Command(async () =>
        {
            EmployeeModel obj = new EmployeeModel
            {
                Email = Email,
                Address = Address,
                Name = Name,
                ID = _employeeID,
            };
            if (_employeeID > 0)
            {
                _employeeService.UpdateEmployee(obj);
            }
            else
            {
                _employeeService.InsertEmployee(obj);
            }
            await Application.Current.MainPage.Navigation.PopAsync();
        });
        #endregion
    }
}
