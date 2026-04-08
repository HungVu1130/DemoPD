using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DemoPD.Domain
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
