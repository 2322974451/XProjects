using System;
using System.Reflection;

namespace XMainClient
{
	// Token: 0x02000F16 RID: 3862
	internal class XLinkTimeStamp
	{
		// Token: 0x0600CCE4 RID: 52452 RVA: 0x002F389C File Offset: 0x002F1A9C
		public static void FetchBuildDateTime()
		{
			XLinkTimeStamp.version = Assembly.GetExecutingAssembly().GetName().Version;
			XLinkTimeStamp.BuildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(864000000000L * (long)XLinkTimeStamp.version.Build + 20000000L * (long)XLinkTimeStamp.version.Revision));
		}

		// Token: 0x04005B1C RID: 23324
		public static DateTime BuildDateTime;

		// Token: 0x04005B1D RID: 23325
		public static Version version;
	}
}
