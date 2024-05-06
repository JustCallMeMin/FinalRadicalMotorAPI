namespace RadicalMotorAPI.JWT
{
    using Microsoft.IdentityModel.Tokens;
    using RadicalMotor.Models;
    using RadicalMotorAPI.Repository;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JwtService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly ILogger<LoginRepository> _logger;

        public JwtService(IConfiguration configuration, ILogger<LoginRepository> logger)
        {
            try
            {
                _secret = configuration["Jwt:Key"];
                _issuer = configuration["Jwt:Issuer"];
                _audience = configuration["Jwt:Audience"];
                _logger = logger;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while reading JWT configuration from appsettings.json");
                throw; // Re-throw exception để xử lý tại mức cao hơn nếu cần
            }
        }

        public string GenerateToken(Account account)
        {
            if (string.IsNullOrEmpty(account.AccountId))
            {
                _logger.LogError("AccountId is null or empty for the account.");
                throw new ArgumentNullException(nameof(account.AccountId));
            }

            if (string.IsNullOrEmpty(account.Username))
            {
                _logger.LogError("Username is null or empty for the account with ID {AccountId}", account.AccountId);
                throw new ArgumentNullException(nameof(account.Username));
            }

            if (account.AccountTypeId == null)
            {
                _logger.LogError("Account type is null or empty for the account with ID {AccountId}", account.AccountId);
                throw new ArgumentNullException(nameof(account.AccountTypeId));
            }

            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, account.Username),
                    new Claim("accountId", account.AccountId.ToString()),
                    new Claim("typeId", account.AccountTypeId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(24),
                    signingCredentials: creds);

                string generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                _logger.LogInformation("Token generated successfully for account {AccountId}", account.AccountId);

                return generatedToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating token for account {AccountId}", account.AccountId);
                throw;
            }
        }
    }
}
