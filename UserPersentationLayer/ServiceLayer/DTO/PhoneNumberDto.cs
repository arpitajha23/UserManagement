using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class PhoneNumberDto
    {
        public int PhoneNumberId { get; set; }

        public int? UserId { get; set; }

        public string PhoneType { get; set; }

   
        public string PhoneNumber { get; set; }
    }
}
