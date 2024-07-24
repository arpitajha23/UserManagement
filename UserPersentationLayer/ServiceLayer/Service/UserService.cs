using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using ServiceLayer.DTO;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserPersentationLayer.Models;

namespace ServiceLayer.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        //get user service
        public async Task<IEnumerable<ArUsers>> GetArUsers()
        {
            var list = await _userRepository.GetArUsers();
            return list;

        }

        //add user
        public async Task<CreateUserDTO> CreateUser(CreateUserDTO userDto)
        {
            var user = new ArUsers
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MiddleName = userDto.MiddleName,
                Gender = userDto.Gender,
                DateOfJoining = userDto.DateOfJoining,
                Dob = userDto.Dob,
                Email = userDto.Email,
                Passwords = userDto.Passwords,
                IsActive = userDto.IsActive,
                CreatedAt = userDto.CreatedAt,
                UpdatedAt = userDto.UpdatedAt,
                ImageUrl = userDto.ImageUrl
            };

            foreach (var addressDto in userDto.Addresses)
            {
                user.ArAddresses.Add(new ArAddress
                {
                    AddressType = addressDto.AddressType,
                    Addresss = addressDto.Addresss,
                    City = addressDto.City,
                    States = addressDto.States,
                    Country = addressDto.Country,
                    ZipCode = addressDto.ZipCode
                });
            }

            foreach (var phoneNumberDto in userDto.PhoneNumbers)
            {
                user.ArPhoneNumbers.Add(new ArPhoneNumber
                {
                    PhoneType = phoneNumberDto.PhoneType,
                    PhoneNumber = phoneNumberDto.PhoneNumber
                });
            }

            var createdUser = await _userRepository.AddUser(user);

            userDto.UserId = createdUser.UserId;
            return userDto;
        }



        //getuser by id
        public async Task<CreateUserDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }

            var userDto = new CreateUserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Gender = user.Gender,
                DateOfJoining = user.DateOfJoining,
                Dob = user.Dob,
                Email = user.Email,
                Passwords = user.Passwords,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                ImageUrl = user.ImageUrl
            };

            foreach (var address in user.ArAddresses)
            {
                userDto.Addresses.Add(new AddressDto
                {
                    AddressId = address.AddressId,
                    UserId = address.UserId,
                    AddressType = address.AddressType,
                    Addresss = address.Addresss,
                    City = address.City,
                    States = address.States,
                    Country = address.Country,
                    ZipCode = address.ZipCode
                });
            }

            foreach (var phoneNumber in user.ArPhoneNumbers)
            {
                userDto.PhoneNumbers.Add(new PhoneNumberDto
                {
                    PhoneNumberId = phoneNumber.PhoneNumberId,
                    UserId = phoneNumber.UserId,
                    PhoneType = phoneNumber.PhoneType,
                    PhoneNumber = phoneNumber.PhoneNumber
                });
            }

            return userDto;
        }


        //login
        public async Task<string> LoginUser(LoginDto loginDTO)
        {
            var user = await _userRepository.LoginUser(loginDTO.Email);

     
            if (user == null)
            {
                return null; 
            }

         
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }

    }
}
