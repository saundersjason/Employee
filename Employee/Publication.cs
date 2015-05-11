using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class Publication
    {
        public Int32 Id { get; set; }
        public Guid FacultyId { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Publisher { get; set; }
        public string Volume { get; set; }
        public string Issue { get; set; }
        public string PageNumber { get; set; }
        public DateTime PublicationDate { get; set; }
        public string DMIntellContId { get; set; }
        public List<Author> Authors = new List<Author>();

        public Publication()
        {
        }
    }
}
