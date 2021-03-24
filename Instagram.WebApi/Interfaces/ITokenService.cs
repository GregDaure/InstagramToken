using System;
using System.Threading.Tasks;

namespace Instagram.WebApi.Interfaces
{
    public interface ITokenService
    {
        Task<string> RenewToken(string token);
    }
}
