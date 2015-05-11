using System;
using System.Collections.Generic;

namespace SavannahState.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }
        public String DMId { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Prefix { get; set; }
        public String Suffix { get; set; }
        public String Building { get; set; }
        public String OfficeNumber { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Biography { get; set; }
        public String Interests { get; set; }
        public String Gender { get; set; }
        public String EmployeeType { get; set; }
        public List<YearlyData> YearlyDatas = new List<YearlyData>();
        public List<Assignment> Assignments = new List<Assignment>();
        public List<Award> Awards = new List<Award>();
        public List<Education> Schools = new List<Education>();
        public List<Publication> Publications = new List<Publication>();

        public Employee()
        {
        }
    }
}

