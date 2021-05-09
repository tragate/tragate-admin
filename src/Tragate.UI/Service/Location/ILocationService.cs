using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Response.Location;

namespace Tragate.UI.Service.Location
{
    public interface ILocationService
    {
        LocationResponse GetLocation(string query);
    }
}
