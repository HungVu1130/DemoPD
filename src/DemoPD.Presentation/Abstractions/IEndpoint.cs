using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder; 

namespace DemoPD.Presentation.Abstractions
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
