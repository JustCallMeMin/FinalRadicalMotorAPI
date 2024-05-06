﻿using System.Threading.Tasks;
using RadicalMotor.Models;
using RadicalMotorAPI.Models;

namespace RadicalMotorAPI.Repositories
{
	public interface IAccountRepository
	{
        //Task<Account> AddAsync(Account account);
        //Task<IEnumerable<Account>> GetAllAccountsAsync();
        //Task<Account> GetByIdAsync(string id);
        //Task<Account> GetByEmailAsync(string email);
        Task<Account> CreateAccountAsync(string username,string email, string password, string accountTypeName = "Member");
        Task<Account> GetAccountAsync(string email);
        Task<Account> UpdateAccountAsync(Account user);
        Task DeleteAccountAsync(string username);
        Task<AccountType> GetDefaultAccountTypeAsync(string typeName);
        //Task UpdateAsync(Account account);
        //Task DeleteAsync(string id);
        //Task<string> CreateTokenAsync(Account account, bool rememberMe);
    }
}
