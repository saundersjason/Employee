using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace SavannahState.Employee
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employees;
        private Int32 _queryLimit = 50;
        public EmployeeRepository(List<Employee> employees) {
            this._employees = employees;
        }

        public Employee GetEmployeeById(String id)
        {
            Employee employee;
            employee = _employees.Find(e => e.Id == new Guid(id));
            if(employee == null){
                employee = new Employee();
            }
            return employee;
        }

        public Employee GetEmployeeByName(String firstName, String middleName, String lastName)
        {
            Employee employee;
            if (!String.IsNullOrEmpty(middleName))
            {
                employee = _employees.Find(e => e.FirstName.ToLower() == firstName.ToLower() && e.MiddleName.ToLower() == middleName.ToLower() && e.LastName.ToLower() == lastName.ToLower());
                if (employee == null)
                {
                    employee = _employees.Find(e => (e.FirstName != null && e.FirstName.ToLower().Contains(firstName.ToLower())) || (e.MiddleName != null && e.MiddleName.ToLower().Contains(middleName.ToLower())) || (e.LastName != null && e.LastName.ToLower().Contains(lastName.ToLower())));
                    if (employee == null)
                    {
                        employee = new Employee();
                    }
                }
            } else {
                employee = _employees.Find(e => e.FirstName.ToLower() == firstName.ToLower() && e.LastName.ToLower() == lastName.ToLower());
            }
            return employee;
        }

        public List<Employee> GetAllEmployees(String employeeType)
        {
            return _employees;
        }

        public List<Employee> Search(String keyword, String searchType, Int32 numberOfResults)
        {

            String keywordConverted = HttpUtility.UrlDecode(keyword);

            List<Employee> employees = new List<Employee>();
            if (String.IsNullOrEmpty(searchType)) {
                searchType = "name";
            }

            if (numberOfResults==0)
            {
                numberOfResults = _queryLimit;
            }


            switch (searchType.ToLower())
            {
                case "department":
                    employees = _employees.Where(employee => employee.YearlyDatas.Any(yearlydata => yearlydata.YearlyDataDepartments.Any(yearlydatadepartment => yearlydatadepartment.Department.ToLower().Contains(keywordConverted.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "discipline":
                    employees = _employees.Where(employee => employee.YearlyDatas.Any(yearlydata => yearlydata.YearlyDataDepartments.Any(yearlydatadepartment => yearlydatadepartment.Discipline != null && yearlydatadepartment.Discipline.ToLower().Contains(keywordConverted.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "name":
                    String[] names = keywordConverted.Split(' ');

                    if (names.Length > 1)
                    {
                        employees = _employees.Where(employee => employee.FirstName.ToLower().Contains(names[0].ToLower()) || employee.LastName.ToLower().Contains(names[0].ToLower()) || employee.FirstName.ToLower().Contains(names[1].ToLower()) || employee.LastName.ToLower().Contains(names[1].ToLower())).OrderBy(employee => employee.LastName).ToList();
                    }
                    else
                    {
                        employees = _employees.Where(employee => employee.FirstName.ToLower().Contains(keywordConverted.ToLower()) || employee.LastName.ToLower().Contains(keywordConverted.ToLower())).OrderBy(employee => employee.LastName).ToList();
                    }
                    break;
                case "bio":
                    employees = _employees.Where(employee => employee.Biography != null && employee.Biography.ToLower().Contains(keywordConverted.ToLower())).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "degree":
                    employees = _employees.Where(employee => employee.Schools.Any(school => school.Degree.ToLower().Contains(keywordConverted.ToLower()))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "award":
                    employees = _employees.Where(employee => employee.Awards != null && employee.Awards.Any(award => award.Name.ToLower().Contains(keywordConverted.ToLower()) || (award.Organization != null && award.Organization.ToLower().Contains(keywordConverted.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "publication":
                    employees = _employees.Where(employee => employee.Publications != null && employee.Publications.Any(publication => (publication.Title != null && publication.Title.ToLower().Contains(keywordConverted.ToLower())) || (publication.Publisher != null && publication.Publisher.ToLower().Contains(keywordConverted.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                default:
                    employees = _employees.Where(employee => employee.FirstName.ToLower().Contains(keywordConverted.ToLower()) || employee.LastName.ToLower().Contains(keywordConverted.ToLower())).OrderBy(employee => employee.LastName).ToList();
                    break;
            }

            return employees.Take(numberOfResults).ToList();
        }
    }
}
