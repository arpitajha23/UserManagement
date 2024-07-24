using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPersentationLayer.Models;

namespace ServiceLayer.IService
{
    public interface IUserService
    {
        //crud
        Task<IEnumerable<ArUsers>> GetArUsers();
        Task<CreateUserDTO> CreateUser(CreateUserDTO userDto);
        Task<CreateUserDTO?> GetUserById(int id);


        //login
        Task<string> LoginUser(LoginDto loginDTO);
    }
}
