using AutoMapper;
using contactinfo.web.Data.Entities;
using contactinfo.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contactinfo.web.AutoMapperProfile
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
