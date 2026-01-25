using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repositories.OrganizationRoleRepository;
using Microsoft.EntityFrameworkCore;


namespace Service.Services.OrganizationRoleService
{
    public class OrganizationRoleService : IOrganizationRoleService
    {
        private readonly IOrganizationRoleRepository _organizationRoleRepository;
        public OrganizationRoleService(IOrganizationRoleRepository organizationRoleRepository)
        {
            _organizationRoleRepository = organizationRoleRepository;

        }

        public async Task<string> CreateOrganizationRole(OrganizationRole organizationRole)
        {
            var exists = await _organizationRoleRepository.GetTableNoTracking()
         .AnyAsync(x => x.Name == organizationRole.Name && x.OrganizationId == organizationRole.OrganizationId);
            if (exists) return "exists";
            await _organizationRoleRepository.AddAsync(organizationRole);
            return "Success";
        }

        public async Task<List<OrganizationRole>> GetOrganizationRolesAsyncByWonerId(Guid WonerId)
        {
            return await _organizationRoleRepository.GetTableNoTracking()
                                                    .Where(x => !x.IsDeleted)
                                                    .OrderByDescending(x => x.CreatedAt)
                                                    .ToListAsync();
        }
    }
}