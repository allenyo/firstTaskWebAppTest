﻿using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface IUserService
    {
        Task<object?> GetUser();
        Task<object?> GetUser(string name);
        Task<object?> GetUser(int id);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(UserID user);

    }
}
