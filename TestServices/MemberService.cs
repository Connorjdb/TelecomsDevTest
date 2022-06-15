using Interfaces.Repositories;
using Interfaces.Services;
using TestSharedModels.Models;

namespace TestServices
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IQrGeneratorService _qrGenerationService;

        public MemberService(IMemberRepository memberRepository, IQrGeneratorService qrGenerationService)
        {
            _memberRepository = memberRepository;
            _qrGenerationService = qrGenerationService;
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

        public async Task<string> GenerateQr(Guid memberId, CancellationToken token)
        {
            var memberCode = await _memberRepository.LoadMembersCodeAsync(memberId, token);
            var bytes = _qrGenerationService.GenerateQR(memberCode.ToString(), "#FFF", "#000");
            return Convert.ToBase64String(bytes);
        }

        public async Task<IEnumerable<MemberModel>> LoadMembersAsync(CancellationToken token)
        {
            return await _memberRepository.GetMembersAsync(token);
        }
    }
}