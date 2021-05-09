using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Response.Parameter;

namespace Tragate.UI.Service.Parameter
{
    public interface IParameterService
    {
        ParameterResponse GetParameters(string query);
    }
}
