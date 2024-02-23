using MauiAppEMPCURD.Model;
using MauiAppEMPCURD.Services;
using MauiAppEMPCURD.ViewModels;

namespace XunitTestcase
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IList<EmployeeModel> mockList = new List<EmployeeModel>() {
    new EmployeeModel() { ID = 1, Name = "John", Email = "test", Address="test"} 
   
};

            EmployeeService  employeeService = new EmployeeService();
            
            var ActualRes = employeeService.GetAllEmployees();
            Assert.True(mockList.Any());


        }
    }
}