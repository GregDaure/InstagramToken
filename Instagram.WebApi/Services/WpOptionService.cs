
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Entity.Models;
using Instagram.WebApi.Interfaces;
using Instagram.WebApi.Serializers;

namespace Instagram.WebApi.Services
{
    public class WpOptionService : IWpOptionService
    {
        private readonly ITokenService _tokenService;
        private readonly IRepositoryService<WpOptions> _repository;

        private static readonly string OPTION_NAME = "wpzoom-instagram-widget-settings";
        private static readonly string TOKEN_KEY_NAME = "basic-access-token";


        public WpOptionService(ITokenService tokenService, IRepositoryService<WpOptions> repository)
        {
            _tokenService = tokenService;
            _repository = repository;
        }

        public async Task UpdateInstagramtoken()
        {
            var option = _repository.GetAll().FirstOrDefault(c => c.OptionName == OPTION_NAME);
            var serializer = new PhpSerializer();

            var decoded = serializer.Deserialize(option.OptionValue) as IDictionary<object,object>;
            var newToken = await _tokenService.RenewToken(decoded[TOKEN_KEY_NAME].ToString());
            
            decoded[TOKEN_KEY_NAME] = newToken.AccessToken;

            var newOption = new WpOptions
            {
                Autoload = option.Autoload,
                OptionId = option.OptionId,
                OptionName = option.OptionName,
                OptionValue = serializer.Serialize(decoded)
            };
            await _repository.Update(newOption);

        }
    }
}
