using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using TestDatabase;
using TestSharedModels.Models;

namespace TestRepositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly RadiusGymContext _context;

        public MemberRepository(RadiusGymContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MemberModel>> GetMembersAsync(CancellationToken cancellationToken)
        {
            return await _context.Members.Select(x => new MemberModel
            {
                DateOfBirth = x.DateOfBirth,
                FirstName = x.FirstName,
                Surname = x.Surname,
                Id = x.Id,
                MembershipNumber = x.MembershipNumber
            }).ToListAsync(cancellationToken);
        }
    }
}