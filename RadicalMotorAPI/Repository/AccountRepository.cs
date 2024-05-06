using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RadicalMotor.Models;

namespace RadicalMotorAPI.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationDbContext _context;
        //private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAccountAsync(string username, string email, string password, string accountTypeName = "Member")
        {
            var accountType = await GetDefaultAccountTypeAsync(accountTypeName);
            if (accountType == null)
            {
                throw new Exception("Default account type not found.");
            }

            var hashedPassword = HashPassword(password);
            var account = new Account
            {
                Email = email,
                Username = username,
                Password = hashedPassword,
                AccountType = accountType
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }


        public async Task<Account> GetAccountAsync(string accountId)
        {
            return await _context.Accounts.Include(a => a.AccountType)
                                          .FirstOrDefaultAsync(a => a.AccountId == accountId);
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(string username)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AccountType> GetDefaultAccountTypeAsync(string typeName)
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(at => at.TypeName == typeName);
        }
        //      public AccountRepository(ApplicationDbContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        //{
        //	_context = context;
        //	_configuration = configuration;
        //	_httpContextAccessor = httpContextAccessor;
        //}

        //public async Task<List<Account>> GetAllAsync()
        //{
        //	return await _context.Accounts.ToListAsync();
        //}

        //public async Task<Account> GetByIdAsync(string id)
        //{
        //	return await _context.Accounts.Include(a => a.AccountType).SingleOrDefaultAsync(a => a.AccountId == id);
        //}

        //public async Task<Account> AddAsync(Account account)
        //{
        //	_context.Accounts.Add(account);
        //	await _context.SaveChangesAsync();
        //	return account;
        //}

        //public async Task UpdateAsync(Account account)
        //{
        //	_context.Entry(account).State = EntityState.Modified;
        //	await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(string id)
        //{
        //	var account = await _context.Accounts.FindAsync(id);
        //	if (account != null)
        //	{
        //		_context.Accounts.Remove(account);
        //		await _context.SaveChangesAsync();
        //	}
        //}



        //public async Task<Account> GetByEmailAsync(string email)
        //{
        //	return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        //}

        //public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        //{
        //	return await _context.Accounts.ToListAsync();
        //}

        //public async Task<string> CreateTokenAsync(Account account, bool rememberMe)
        //{
        //	if (rememberMe)
        //	{
        //		var claims = new List<Claim>
        //		{
        //			new Claim(ClaimTypes.Name, account.Email),
        //                  // Add additional claims as needed
        //              };

        //		var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //		var authProperties = new AuthenticationProperties
        //		{
        //			IsPersistent = true,
        //			ExpiresUtc = DateTimeOffset.UtcNow.AddMonths(1)
        //		};

        //		await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        //		return null;
        //	}
        //	else
        //	{
        //		return "Remember me is not enabled";
        //	}
        //}
    }
}
