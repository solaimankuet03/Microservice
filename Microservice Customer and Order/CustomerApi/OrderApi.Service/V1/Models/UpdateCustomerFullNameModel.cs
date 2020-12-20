using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Service.V1.Models
{
    public class UpdateCustomerFullNameModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
