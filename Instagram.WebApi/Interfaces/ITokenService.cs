using System;
using System.Threading.Tasks;
using Instagram.WebApi.Models;

namespace Instagram.WebApi.Interfaces
{
    public interface ITokenService
    {
        Task<TokenOuput> RenewToken(string token);
    }
}
