using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class ApplicationUserRepository:IApplicationUserRepository
    {
        private readonly IApplicationDbContext _context;

        public ApplicationUserRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<ApplicationUser> GetAllApplicationUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public string GetUserIdByFullname(string fullname)
        {
            return _context.Users.SingleOrDefault(u => u.Fullname == fullname)?.Id;
        }
    }
}