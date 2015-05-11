using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using SavannahState.Employee;


namespace SavannahState
{
    [WebService(Namespace = "http://www.savannahstate.edu", Description = "Returns all employees.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {
        private IEmployeeRepository _employeeRepo;

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public SavannahState.Employee.Employee GetEmployee(String id, String firstName, String middleName, String lastName)
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            Context.Response.AddHeader("Access-Control-Max-Age", "3600");
            if (!String.IsNullOrEmpty(id))
            {
                return _employeeRepo.GetEmployeeById(id);
            }
            else
            {
                return _employeeRepo.GetEmployeeByName(firstName, middleName, lastName);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<SavannahState.Employee.Employee> Search(String keyword, String searchType, Int32 numberOfEmployees)
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            Context.Response.AddHeader("Access-Control-Max-Age", "300");
            return _employeeRepo.Search(keyword, searchType, numberOfEmployees);
        }

        public EmployeeService()
        {
            _employeeRepo = new EmployeeRepository(new EmployeeData().Load(false));
        }
    }
}
