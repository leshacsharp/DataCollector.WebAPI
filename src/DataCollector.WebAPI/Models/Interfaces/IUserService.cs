using DataCollector.WebAPI.Models.Api;
using DataCollector.WebAPI.Models.Dto;
using DataCollector.WebAPI.Models.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Models.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAsync(UserFilterModel filter);

        Task<User> GetByIdAsync(string userId);
    }
}
