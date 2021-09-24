using System;
using System.Reflection;

namespace XMainClient
{

	internal class XLinkTimeStamp
	{

		public static void FetchBuildDateTime()
		{
			XLinkTimeStamp.version = Assembly.GetExecutingAssembly().GetName().Version;
			XLinkTimeStamp.BuildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(864000000000L * (long)XLinkTimeStamp.version.Build + 20000000L * (long)XLinkTimeStamp.version.Revision));
		}

		public static DateTime BuildDateTime;

		public static Version version;
	}
}
