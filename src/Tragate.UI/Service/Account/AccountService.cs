using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;
using Tragate.UI.Models.Response.User;

namespace Tragate.UI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public AccountService(IRestClient restClient, IOptions<ConfigSettings> settings){
            _restClient = restClient;
            _settings = settings.Value;
        }

        public LoginResponse Login(LoginViewModel model){
            var response = _restClient.Post<LoginResponse>($"{_settings.ApiUrl}/{API.Account.Login}", model);
            return response;
        }
    }
}