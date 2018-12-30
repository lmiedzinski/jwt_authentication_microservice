using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Models;
using AuthService.Repositories;
using CryptoHelper;

namespace AuthService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<string> LoginUser(string login, string password)
        {
            var userToLogin = (await _userRepository.GetByLogin(login)).FirstOrDefault();
            if (userToLogin == null) return null;
            if (!Crypto.VerifyHashedPassword(userToLogin.PasswordHash, password)) return null;
            // later it should return the token
            return userToLogin.Login;
        }

        public async Task<User> RegisterNewAdmin(string login, string password)
        {
            if ((await _userRepository.GetByLogin(login)).Count > 0) return null;
            var adminRole = (await _roleRepository.GetByName(Role.ADMIN_ROLE_NAME)).FirstOrDefault();
            if (adminRole == null) return null;
            User newUser = new User
            {
                Login = login,
                PasswordHash = Crypto.HashPassword(password)
            };
            newUser.Roles.Add(adminRole.Id);
            return await _userRepository.Create(newUser);
        }

        public async Task<User> RegisterNewUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
