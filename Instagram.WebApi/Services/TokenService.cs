using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Instagram.WebApi.Interfaces;

namespace Instagram.WebApi.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> RenewToken(string token)
        {
            if (token is null)
            {
                return "No token to renew";
            }
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder("https://graph.instagram.com/refresh_access_token");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["grant_type"] = "ig_refresh_token";
                query["access_token"] = token;
                builder.Query = query.ToString();

                var res = await client.GetStringAsync(builder.ToString());
                return res;
            }
        }
    }
}
