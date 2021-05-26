using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Models
{
    public interface IUserTestRepository
    {
        Task<IEnumerable<UserTest>> GetUserTests();
        Task<UserTest> GetUserTest(int UserTestId);
        Task<UserTest> AddUserTest(UserTest userTest);
        Task<UserTest> UpdateUserTest(UserTest userTest);
        Task<UserTest> DeleteUserTest(int UserTestId);

    }
}
