using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
    }
}
