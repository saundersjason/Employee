using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class Award
    {
        public Int32 Id { get; set; }
        public Guid FacultyId { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Scope { get; set; }
        public string Locale { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Award()
        {
        }
    }
}
