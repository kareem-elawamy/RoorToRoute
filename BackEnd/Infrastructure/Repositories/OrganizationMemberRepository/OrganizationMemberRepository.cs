using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.OrganizationMemberRepository
{
    public class OrganizationMemberRepository : GenericRepositoryAsync<OrganizationMember>, IOrganizationMemberRepository
    {
        public OrganizationMemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}