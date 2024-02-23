using MauiAppEMPCURD.Model;
using MauiAppEMPCURD.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppEMPCURD.ViewModels
{
    public class ShowEmployeePageViewModel
    {
        #region Properties

        public ObservableCollection<EmployeeModel> Employees { get; set; } = new ObservableCollection<EmployeeModel>();
        private readonly EmployeeService _employeeService;
        #endregion

        #region Constructor
        public ShowEmployeePageViewModel()
        {
            _employeeService = new EmployeeService();
        }
        #endregion

        #region Methods
        public void ShowEmployee()
        {
            var allEmployees = _employeeService.GetAllEmployees();

            if (allEmployees?.Count > 0)
            {
                //Employees.Clear();
                foreach (var employee in allEmployees)
                {
                    Employees.Add(employee);
                }
            }
        }
        #endregion


        #region Commands
        public ICommand NavigateToAddEmployeePageCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
        });


        public ICommand SelectedEmployeeCommand => new Command<EmployeeModel>(async (employee) =>
        {
            string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

            switch (res)
            {
                case "Update":
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage(employee));
                    break;
                case "Delete":
                    int del = _employeeService.DeleteEmployee(employee);
                    if (del > 0)
                    {
                        Employees.Remove(employee);
                    }
                    break;
            }
        });
        #endregion
    }
}
