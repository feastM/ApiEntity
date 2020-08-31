using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;
using Users.API.Resources;

namespace Users.API.Mapping
{
    public class ResourceToModelUpdate : Profile
    {
        public ResourceToModelUpdate()
        {
            CreateMap<SaveUpdateEmployee, Employee>();
        }
    }
}
