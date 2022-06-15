using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharedModels.Models;

namespace Interfaces.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberModel>> LoadMembersAsync(CancellationToken token);
        Task DeleteMemberAsync(Guid memberId, CancellationToken token);
    }
}
