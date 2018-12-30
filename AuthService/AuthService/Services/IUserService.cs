using AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Services
{
    public interface IUserService
    {
        Task<User> RegisterNewUser(string login, string password);
        Task<User> RegisterNewAdmin(string login, string password);
        Task<string> LoginUser(string login, string password);
    }
}
