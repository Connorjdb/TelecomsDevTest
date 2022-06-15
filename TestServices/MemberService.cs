using Interfaces.Repositories;
using Interfaces.Services;
using TestSharedModels.Models;

namespace TestServices
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<bool> CheckInMemberAsync(Guid memberId, CancellationToken token)
        {
            var memberDetails = await _memberRepository.GetMembershipDetailAsync(memberId, token);
            var today = DateTime.Now.DayOfWeek;

            return memberDetails.DayFrom <= today && memberDetails.DayTo >= today;
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