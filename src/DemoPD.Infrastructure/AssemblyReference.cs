using System.Reflection;

namespace DemoPD.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
