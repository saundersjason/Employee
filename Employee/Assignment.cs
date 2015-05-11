using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class Assignment
    {
        public Int32 Id { get; set; }
        public Guid FacultyId { get; set; }
        public string Role { get; set; }
        public string Scope { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Assignment() { }
    }
}
