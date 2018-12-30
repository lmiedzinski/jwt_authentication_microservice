using AuthService.DbConnectors;
using AuthService.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Services
{
    public interface IUserService
    {
        Task<List<User>> Get();

        Task<List<User>> Get(string id);

        Task<User> Create(User user);

        Task Update(string id, User userIn);

        Task Remove(User userIn);

        Task Remove(string id);
    }
}
