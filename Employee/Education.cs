using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class Education
    {
        public Int32 Id { get; set; }
        public Guid FacultyId { get; set; }
        public string Degree { get; set; }
        public string DegreeOther { get; set; }
        public string Major { get; set; }
        public string Location { get; set; }
        public string School { get; set; }

        public Education()
        {
        }
    }
}
