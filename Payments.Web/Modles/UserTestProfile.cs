using AutoMapper;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Modles
{
    public class UserTestProfile : Profile
    {
        public UserTestProfile()
        {
            CreateMap<UserTest, EditUserTestModel>();
            CreateMap<EditUserTestModel, UserTest>();
        }
    }
}
