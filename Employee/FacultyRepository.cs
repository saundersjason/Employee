using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class FacultyRepository:IEmployeeRepository
    {
        private List<Employee> _facultyMembers;

        public FacultyRepository(List<Employee> employees)
        {
            this._facultyMembers = employees;
        }

        public Employee GetEmployeeById(string id)
        {
            Employee employee;
            employee = _facultyMembers.Find(f => f.Id == new Guid(id));
            if (employee == null)
            {
                employee = new Employee();
            }
            return employee;
        }

        public Employee GetEmployeeByName(string firstName, string middleName, string lastName)
        {
            Employee employee;
            employee = _facultyMembers.Find(e => e.FirstName == firstName && e.MiddleName == middleName && e.LastName == lastName);
            if (employee == null)
            {
                employee = _facultyMembers.Find(e => e.FirstName.Contains(firstName) || e.MiddleName.Contains(middleName) || e.LastName.Contains(lastName));
                if (employee == null)
                {
                    employee = new Employee();
                }
            }
            return employee;
        }

        public List<Employee> GetAllEmployees(string employeeType)
        {
            return _facultyMembers;
        }

        public List<Employee> Search(string keyword, string searchType, int numberOfResults)
        {
            List<Employee> employees = new List<Employee>();

            switch (searchType.ToLower())
            {
                case "department":
                    employees = _facultyMembers.Where(employee => employee.YearlyDatas.Any(yearlydata => yearlydata.YearlyDataDepartments.Any(yearlydatadepartment => yearlydatadepartment.Department.ToLower().Contains(keyword.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "discipline":
                    employees = _facultyMembers.Where(employee => employee.YearlyDatas.Any(yearlydata => yearlydata.YearlyDataDepartments.Any(yearlydatadepartment => yearlydatadepartment.Discipline != null && yearlydatadepartment.Discipline.ToLower().Contains(keyword.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "name":
                    employees = _facultyMembers.Where(employee => employee.FirstName.ToLower().Contains(keyword.ToLower()) || employee.LastName.ToLower().Contains(keyword.ToLower())).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "bio":
                    employees = _facultyMembers.Where(employee => employee.Biography != null && employee.Biography.ToLower().Contains(keyword.ToLower())).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "degree":
                    employees = _facultyMembers.Where(employee => employee.Schools.Any(school => school.Degree.ToLower().Contains(keyword.ToLower()))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "award":
                    employees = _facultyMembers.Where(employee => employee.Awards != null && employee.Awards.Any(award => award.Name.ToLower().Contains(keyword.ToLower()) || (award.Organization != null && award.Organization.ToLower().Contains(keyword.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                case "publication":
                    employees = _facultyMembers.Where(employee => employee.Publications != null && employee.Publications.Any(publication => (publication.Title != null && publication.Title.ToLower().Contains(keyword.ToLower())) || (publication.Publisher != null && publication.Publisher.ToLower().Contains(keyword.ToLower())))).OrderBy(employee => employee.LastName).ToList();
                    break;
                default:
                    employees = _facultyMembers.OrderBy(employee => employee.LastName).ToList();
                    break;
            }

            return employees;
        }
    }
}
