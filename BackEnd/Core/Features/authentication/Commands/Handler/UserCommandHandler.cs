using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Features.authentication.Commands.Models;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Domain.Models;
namespace Core.Features.authentication.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // 

            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user != null)
                return BadRequest<string>("Email Duplicate");
            var userIdentity = _mapper.Map<ApplicationUser>(request);
            var createdResult = await _userManager.CreateAsync(userIdentity, request.Password!);
            if (!createdResult.Succeeded)
                return BadRequest<string>();
            return Created<string>("Regsiter Done");
        }
    }
}