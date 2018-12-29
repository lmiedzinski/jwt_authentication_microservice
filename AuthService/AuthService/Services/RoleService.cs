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
    public class RoleService
    {
        private readonly IMongoCollection<Role> _roles;

        public RoleService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("AuthDb"));
            var database = client.GetDatabase("AuthDb");
            _roles = database.GetCollection<Role>("Roles");
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
