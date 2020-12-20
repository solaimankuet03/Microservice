using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Models.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCustomerModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }
    }
}
