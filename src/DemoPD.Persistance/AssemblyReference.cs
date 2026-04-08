using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DemoPD.Persistance
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
