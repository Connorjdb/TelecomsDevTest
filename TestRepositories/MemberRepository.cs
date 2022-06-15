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

        public async Task DeleteMemberAsync(Guid memberId, CancellationToken cancellationToken)
        {
            var member = await _context.Members.FirstAsync(x => x.Id == memberId, cancellationToken);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<MembershipDetail> GetMembershipDetailAsync(Guid memberId, CancellationToken cancellationToken)
        {
            return await _context.Members
                .Include(x => x.MembershipType)
                .Where(x => x.Id == memberId)
                .Select(x => new MembershipDetail
                {
                    DayFrom = (DayOfWeek)x.MembershipType.DayFrom,
                    DayTo = (DayOfWeek)x.MembershipType.DayTo,
                })
                .FirstAsync(cancellationToken);
        }

        public async Task<IEnumerable<MemberModel>> GetMembersAsync(CancellationToken cancellationToken)
        {
            return await _context.Members.Include(x => x.MembershipType).Include(x => x.AccessInformation).Select(x => new MemberModel
            {
                DateOfBirth = x.DateOfBirth,
                FirstName = x.FirstName,
                Surname = x.Surname,
                Id = x.Id,
                MembershipNumber = x.MembershipNumber,
                AccessCode = x.AccessInformation.Code.ToString(),
                MembershipType = x.MembershipType.DisplayText
            }).ToListAsync(cancellationToken);
        }
    }
}