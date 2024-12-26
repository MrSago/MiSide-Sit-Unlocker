using System.Reflection;
using System.Runtime.InteropServices;
using Mod.Properties;

[assembly: AssemblyTitle(BuildInfo.NAME)]
[assembly: AssemblyDescription(BuildInfo.DESCRIPTION)]
[assembly: AssemblyProduct(BuildInfo.PACKAGE)]
[assembly: AssemblyCompany(BuildInfo.COMPANY)]
[assembly: AssemblyCopyright("Created by " + BuildInfo.AUTHOR)]
[assembly: AssemblyVersion(BuildInfo.VERSION)]
[assembly: AssemblyFileVersion(BuildInfo.VERSION)]

[assembly: ComVisible(false)]
[assembly: Guid(BuildInfo.GUID)]
