using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class YearlyData
    {
        public Guid Id { get; set; }
        public Guid FacultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String College { get; set; }
        public String Rank { get; set; }
        public List<YearlyDataDepartment> YearlyDataDepartments = new List<YearlyDataDepartment>();
        public YearlyData() { }
    }
}
