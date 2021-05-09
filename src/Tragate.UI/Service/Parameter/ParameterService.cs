using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Parameter;

namespace Tragate.UI.Service.Parameter
{
    public class ParameterService : IParameterService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public ParameterService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }
        public ParameterResponse GetParameters(string query)
        {
            return _restClient.Get<ParameterResponse>(string.Format($"{_settings.ApiUrl}/{API.Parameter.GetByType}", query));
        }
    }
}
