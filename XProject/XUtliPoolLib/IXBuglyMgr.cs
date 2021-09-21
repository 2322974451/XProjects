using System;

namespace XUtliPoolLib
{
	// Token: 0x02000076 RID: 118
	public interface IXBuglyMgr : IXInterface
	{
		// Token: 0x0600040E RID: 1038
		void ReportCrashToBugly(string serverid, string rolename, uint rolelevel, int roleprof, string openid, string version, string realtime, string scenename, string sceneid, string content);
	}
}
