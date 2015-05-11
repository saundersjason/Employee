using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class YearlyDataDepartment
    {
        public Int32 Id { get; set; }
        public Guid YearlyDataId { get; set; }
        public String Department { get; set; }
        public String Program { get; set; }
        public String Discipline { get; set; }
        public YearlyDataDepartment() { }
    }   
}
