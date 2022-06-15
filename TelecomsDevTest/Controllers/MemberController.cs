using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TelecomsDevTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IEnumerable<TestSharedModels.Models.MemberModel>> Get(CancellationToken token = default)
        {
            _logger.LogInformation($"Get members called: {DateTime.UtcNow}");
            return await _memberService.LoadMembersAsync(token);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IEnumerable<TestSharedModels.Models.MemberModel>> Delete(Guid id, CancellationToken token = default)
        {
            _logger.LogInformation($"Delete member called: {DateTime.UtcNow}, ID: {id}");
            await _memberService.DeleteMemberAsync(id, token);
            return await _memberService.LoadMembersAsync(token);
        }
    }
}