using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class AddressDto
    {
        public int AddressId { get; set; }

        public int? UserId { get; set; }

        public string AddressType { get; set; } = null!;

        public string? Addresss { get; set; }
        public string? City { get; set; }
        public string? States { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}
