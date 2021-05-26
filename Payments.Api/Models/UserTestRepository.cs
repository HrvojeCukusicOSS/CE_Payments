using Microsoft.EntityFrameworkCore;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Models
{
    public class UserTestRepository : IUserTestRepository
    {

        private readonly AppDbContext appDbContext;

        public UserTestRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<UserTest>> GetUserTests()
        {
            
           // var a = appDbContext.UserTests.ToList();
            return await appDbContext.UserTests.ToListAsync();
        }
        public async Task<UserTest> GetUserTest(int UserTestId)
        {
            return await appDbContext.UserTests.FirstOrDefaultAsync(e => e.UserTestId == UserTestId);
        }


        public async Task<UserTest> AddUserTest(UserTest userTest)
        {
            var result = await appDbContext.UserTests.AddAsync(userTest);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<UserTest> UpdateUserTest(UserTest userTest)
        {
            var result = await appDbContext.UserTests.FirstOrDefaultAsync(e => e.UserTestId == userTest.UserTestId);
            if(result != null)
            {
                result.UserTestNamse = userTest.UserTestNamse;
                result.Age = userTest.Age;
                result.Nickname = userTest.Nickname;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<UserTest> DeleteUserTest(int UserTestId)
        {
            var result = await appDbContext.UserTests.FirstOrDefaultAsync(e => e.UserTestId == UserTestId);
            if( result != null)
            {
                appDbContext.UserTests.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        
    }
}
