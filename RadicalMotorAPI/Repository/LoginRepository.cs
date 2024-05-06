using Microsoft.EntityFrameworkCore;
using RadicalMotor.Models;
namespace RadicalMotorAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LoginRepository> _logger; // Logger
        public LoginRepository(ApplicationDbContext context, ILogger<LoginRepository> logger)
        {
            _context = context;
            _logger = logger; // Inject logger vào constructor
        }

        public async Task<Account> ValidateUserByEmail(string email, string password)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Email == email);

            if (account != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, account.Password);
                if (isPasswordValid)
                {
                    _logger.LogInformation("Password verified successfully for email: {Email}", email); // Log khi mật khẩu được xác minh thành công
                    return account;
                }
                else
                {
                    _logger.LogWarning("Password verification failed for email: {Email}", email); // Log khi mật khẩu xác minh thất bại
                }
            }
            else
            {
                _logger.LogWarning("Account not found for email: {Email}", email); // Log khi không tìm thấy tài khoản
            }

            return null;
        }
    }
}
