using System.Runtime.CompilerServices;
using Chartboost.Logging;
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]
[assembly: InternalsVisibleTo(AssemblyInfo.ChartboostLoggingAndroidAssembly)]
[assembly: InternalsVisibleTo(AssemblyInfo.ChartboostLoggingIOSAssembly)]

namespace Chartboost.Logging
{
    internal static class AssemblyInfo
    {
        public const string ChartboostLoggingAndroidAssembly = "Chartboost.Logging.Android";
        public const string ChartboostLoggingIOSAssembly = "Chartboost.Logging.iOS";
    }
}
