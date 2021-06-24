using AutoMapper;
using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Model.Profiles
{
    public class StatusesProfile : Profile
    {
        public StatusesProfile()
        {
            CreateMap<StatusFinalBill, StatusesModel>();
            CreateMap<StatusesModel, StatusFinalBill>();

        }
    }
}
