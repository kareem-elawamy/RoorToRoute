using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.OrganizationRoleRepository
{
    public class OrganizationRoleRepository : GenericRepositoryAsync<OrganizationRole>, IOrganizationRoleRepository
    {
        public OrganizationRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}