using Interfaces.Repositories;
using Interfaces.Services;
using TestSharedModels.Models;

namespace TestServices
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository, IQrGeneratorService qrGeneratorService)
        {
            _memberRepository = memberRepository;
        }

        public async Task DeleteMemberAsync(Guid memberId, CancellationToken token)
        {
            await _memberRepository.DeleteMemberAsync(memberId, token);
        }

        public async Task<IEnumerable<MemberModel>> LoadMembersAsync(CancellationToken token)
        {
            return await _memberRepository.GetMembersAsync(token);
        }
    }
}