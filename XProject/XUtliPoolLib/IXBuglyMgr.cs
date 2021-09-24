using System;

namespace XUtliPoolLib
{

	public interface IXBuglyMgr : IXInterface
	{

		void ReportCrashToBugly(string serverid, string rolename, uint rolelevel, int roleprof, string openid, string version, string realtime, string scenename, string sceneid, string content);
	}
}
