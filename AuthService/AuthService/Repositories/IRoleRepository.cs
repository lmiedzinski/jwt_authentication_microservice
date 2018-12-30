using AuthService.DbConnectors;
using AuthService.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Repositories
{
    public interface IRoleRepository
    {

        Task<List<Role>> Get();

        Task<List<Role>> Get(string id);

        Task<List<Role>> GetByName(string roleName);

        Task<Role> Create(Role role);

        Task Update(string id, Role roleIn);

        Task Remove(Role roleIn);

        Task Remove(string id);
    }
}
