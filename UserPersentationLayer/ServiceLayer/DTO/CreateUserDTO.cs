using System;
using System.Collections.Generic;

namespace ServiceLayer.DTO
{
    public class CreateUserDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? Gender { get; set; }

        public DateOnly? DateOfJoining { get; set; }

        public DateOnly? Dob { get; set; }

        public string Email { get; set; } = null!;

        public string Passwords { get; set; } = null!;

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Assuming ImageUrl is a string representing the URL or path to the image
        public string? ImageUrl { get; set; }

        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public List<PhoneNumberDto> PhoneNumbers { get; set; } = new List<PhoneNumberDto>();
    }
}
