using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Instagram.WebApi.Interfaces;
using Instagram.WebApi.Models;
using Newtonsoft.Json;

namespace Instagram.WebApi.Services
{
    public class TokenService : ITokenService
    {
        public async Task<TokenOuput> RenewToken(string token)
        {
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder("https://graph.instagram.com/refresh_access_token");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["grant_type"] = "ig_refresh_token";
                query["access_token"] = token;
                builder.Query = query.ToString();

                var res = await client.GetStringAsync(builder.ToString());
                return JsonConvert.DeserializeObject<TokenOuput>(res);
            }
        }
    }
}
