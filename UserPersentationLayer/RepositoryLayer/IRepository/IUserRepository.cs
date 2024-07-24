using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPersentationLayer.Models;

namespace RepositoryLayer.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<ArUsers>> GetArUsers();
        Task<ArUsers> AddUser(ArUsers user);
        Task<ArUsers> GetUserById(int id);



        //login
        Task<ArUsers> LoginUser(string email);

    }
}
