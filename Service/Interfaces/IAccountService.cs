﻿using Data;
using Domain;

namespace Service
{
    public interface IAccountService
    {
        Task<bool> AddAccount(Accounts accounts);
        Task<object?> GetAll();
        Task<object?> GetBalance(string account);
        Task<object?> GetAccounts(int id);   
        Task<Accounts?> GetAccount(string account);   
        Task<bool> ChangeBalance(string account, decimal value);
        Task<bool> PayToAccount(string accountFrom, string accountTo, decimal value);

        event EventHandler<AccountEventArgs>? Notification;
    }
}
