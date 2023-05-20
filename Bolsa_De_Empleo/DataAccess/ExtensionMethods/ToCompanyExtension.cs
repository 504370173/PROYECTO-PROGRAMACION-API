using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ExtensionMethods
{
    public static class ToCompanyExtension
    {
        public static Company toCompany(this CompanyVM obj)
        {
            Company company = new Company();
            company.Name = obj.Name;
            company.email = obj.email;
            company.phoneNumber = obj.phoneNumber;
            company.webSite = obj.webSite;
            return company;
        }
    }
}
