using DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPersentationLayer.Models;

namespace RepositoryLayer.Repository
{
  public class UserRepository : IUserRepository
    {

        private readonly SDirectContext _context;

        public UserRepository(SDirectContext context)
        {
            _context = context;
        }

        //get repo
        public async Task<IEnumerable<ArUsers>> GetArUsers()
        {
            return await _context.ArUsers.ToListAsync();
        }

        public async Task<ArUsers> AddUser(ArUsers user)
        {
            _context.ArUsers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ArUsers?> GetUserById(int id)
        {
            return await _context.ArUsers
                .Include(u => u.ArAddresses)
                .Include(u => u.ArPhoneNumbers)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }


        //login
        public async Task<ArUsers> LoginUser(string email)
        {
            return await _context.ArUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
