using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharedModels.Models;

namespace Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Task<MembershipDetail> GetMembershipDetailAsync(Guid memberId, CancellationToken cancellationToken);
        Task<IEnumerable<MemberModel>> GetMembersAsync(CancellationToken cancellationToken);
        Task DeleteMemberAsync(Guid memberId, CancellationToken cancellationToken);
        Task<int> LoadMembersCodeAsync(Guid memberId, CancellationToken cancellationToken);
    }
}
