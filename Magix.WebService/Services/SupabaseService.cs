using System;
using Supabase;
using Supabase.Gotrue;
using Magix.WebService.Models;


namespace Magix.WebService.Services
{
    public class SupabaseService
    {
        private readonly Supabase.Client _client;
        public SupabaseService(IConfiguration configuration)
        {
            var url = configuration["Supabase:Url"]
                ?? throw new InvalidOperationException("Supabase URL is missing!");
            var key = configuration["Supabase:ApiKey"]
                ?? throw new InvalidOperationException("Supabase Key is missing!");

            var options = new SupabaseOptions
            {
                AutoConnectRealtime = false
            };

            _client = new Supabase.Client(url, key, options);
        }
        
        
        public async Task<int> TestGetLeaderCountAsync(string accessToken)
        {

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("Access token is required.", nameof(accessToken));
                 
            }
            await _client.Auth.SetSession(accessToken, "something");

            var count = await _client
                .From<Leader>()
                .Select("*")
                .Count(Supabase.Postgrest.Constants.CountType.Exact);
            return count;
        }
    }
}
