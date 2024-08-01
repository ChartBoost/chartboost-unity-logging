using Chartboost.Editor;
using NUnit.Framework;

namespace Chartboost.Logging.Tests.Editor
{
    public class VersionValidator
    {
        private const string UnityPackageManagerPackageName = "com.chartboost.unity.logging";
        private const string NuGetPackageName = "Chartboost.CSharp.Logging.Unity";
        
        [Test]
        public void ValidateVersion() 
            => VersionCheck.ValidateVersions(UnityPackageManagerPackageName, NuGetPackageName);
    }
}
