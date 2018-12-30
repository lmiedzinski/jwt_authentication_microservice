﻿using AuthService.DbConnectors;
using AuthService.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbConnector connector)
        {
            _users = connector.Database.GetCollection<User>("Users");
        }

        public async Task<List<User>> Get()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<List<User>> Get(string id)
        {
            var docId = new ObjectId(id);
            return await _users.Find(user => user.Id == docId).ToListAsync();
        }

        public async Task<List<User>> GetByLogin(string login)
        {
            return await _users.Find(user => user.Login == login).ToListAsync();
        }

        public async Task<User> Create(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task Update(string id, User userIn)
        {
            var docId = new ObjectId(id);
            await _users.ReplaceOneAsync(user => user.Id == docId, userIn);
        }

        public async Task Remove(User userIn)
        {
            await _users.DeleteOneAsync(user => user.Id == userIn.Id);
        }

        public async Task Remove(string id)
        {
            var docId = new ObjectId(id);
            await _users.DeleteOneAsync(user => user.Id == docId);
        }


    }
}
