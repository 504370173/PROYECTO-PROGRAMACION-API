using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.DataToObject
{
    public class JobOfferVM
    {
        public string position { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool status { get; set; }
        public int companyId { get; set; }

    }
}
