using RadicalMotor.Models;

namespace RadicalMotorAPI.Repository
{
    public interface ILoginRepository
    {
        Task<Account> ValidateUserByEmail(string email, string password);
    }
}
