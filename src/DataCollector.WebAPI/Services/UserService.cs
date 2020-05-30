using DataCollector.WebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _db;
        public UserService(IDbContext db)
        {
            _db = db;
        }
    }
}
