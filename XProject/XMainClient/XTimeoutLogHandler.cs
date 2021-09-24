using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTimeoutLogHandler : XTimeoutHandler
	{

		public void OnReport(int limit, int used)
		{
			XSingleton<XDebug>.singleton.AddLog(this.Message, " used: ", used.ToString(), " limit: ", limit.ToString(), " ms", XDebugColor.XDebug_None);
		}

		public string Message;
	}
}
