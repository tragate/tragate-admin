using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Location;

namespace Tragate.UI.Service.Location
{
    public class LocationService : ILocationService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public LocationService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }
        public LocationResponse GetLocation(string query)
        {
            return _restClient.Get<LocationResponse>(string.Format($"{_settings.ApiUrl}/{API.Location.GetLocation}", query));
        }
    }
}
