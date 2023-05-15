using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.RequestObjects
{
    public class CandidateVM
    {
        public string name { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string summary { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool status { get; set; }

    }
}
