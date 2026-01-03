using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Features.authentication.Commands.Models;
using Domain.Models;

namespace Core.Mapping.Authentication
{
    public partial class ApplicationUserProfile
    {
        public void AddApplicationUserMapping()
        {
            CreateMap<AddUserCommand,ApplicationUser>();
        }
    }
}