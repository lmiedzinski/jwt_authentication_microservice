using AuthService.DbConnectors;
using AuthService.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly IMongoCollection<Role> _roles;

        public RoleRepository(MongoDbConnector connector)
        {
            _roles = connector.Database.GetCollection<Role>("Roles");
        }

        public async Task<List<Role>> Get()
        {
            return await _roles.Find(role => true).ToListAsync();
        }

        public async Task<List<Role>> Get(string id)
        {
            var docId = new ObjectId(id);
            return await _roles.Find(role => role.Id == docId).ToListAsync();
        }

        public async Task<List<Role>> GetByName(string roleName)
        {
            return await _roles.Find(role => role.RoleName == roleName).ToListAsync();
        }

        public async Task<Role> Create(Role role)
        {
            await _roles.InsertOneAsync(role);
            return role;
        }

        public async Task Update(string id, Role roleIn)
        {
            var docId = new ObjectId(id);
            await _roles.ReplaceOneAsync(role => role.Id == docId, roleIn);
        }

        public async Task Remove(Role roleIn)
        {
            await _roles.DeleteOneAsync(role => role.Id == roleIn.Id);
        }

        public async Task Remove(string id)
        {
            var docId = new ObjectId(id);
            await _roles.DeleteOneAsync(role => role.Id == docId);
        }
    }
}
