using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(String id);
        Employee GetEmployeeByName(String firstName, String middleName, String lastName);
        List<Employee> GetAllEmployees(String employeeType);
        List<Employee> Search(String keyword, String searchType, Int32 numberOfResults);
    }
}
