using DemoPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.Abstractions.Authentication
{
    public interface IJwtTokenProvider
    {
        string Generate(User user);
    }
}
