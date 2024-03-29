using MauiAppEMPCURD.Model;
using MauiAppEMPCURD.ViewModels;

namespace MauiAppEMPCURD;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage()
	{
		InitializeComponent();
        this.BindingContext = new AddEmployeePageViewModel();
    }
    public AddEmployeePage(EmployeeModel obj)
    {
        InitializeComponent();
        this.BindingContext = new AddEmployeePageViewModel(obj);
    }
}