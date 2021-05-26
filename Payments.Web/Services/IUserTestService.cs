using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public interface IUserTestService
    {
        Task<IEnumerable<UserTest>> GetUserTests();
        Task<UserTest> GetUserTest(int Id);
    }
}
