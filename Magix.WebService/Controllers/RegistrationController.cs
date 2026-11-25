using Magix.WebService.Models;
using Magix.WebService.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supabase;
using Supabase.Gotrue;

namespace Magix.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly SupabaseService _supabaseService;

        public RegistrationController(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetLeaderCountAsync()
        {
            var authorization = Request.Headers.Authorization.ToString();

            if(string.IsNullOrWhiteSpace(authorization) || !authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return Unauthorized();
            }

            var accessToken = authorization["Bearer ".Length..].Trim();

            var count = await _supabaseService.TestGetLeaderCountAsync(accessToken);
                
            return Ok(count);
            
        }

    }
}
