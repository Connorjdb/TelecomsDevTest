﻿using Interfaces.Services;
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

        [HttpGet]
        [Route("checkin/{id:Guid}")]
        public async Task<bool> CheckIn(Guid id, CancellationToken token = default)
        {
            _logger.LogInformation($"Check in member called: {DateTime.UtcNow}, ID: {id}");
            return await _memberService.CheckInMemberAsync(id, token);
        }

        [HttpGet]
        [Route("qr/{id:Guid}")]
        public async Task<string> GetQr(Guid id, CancellationToken token = default)
        {
            _logger.LogInformation($"Get QR called: {DateTime.UtcNow}, ID: {id}");
            return await _memberService.GenerateQr(id, token);
        }
    }
}