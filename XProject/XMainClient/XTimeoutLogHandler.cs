using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F1A RID: 3866
	internal class XTimeoutLogHandler : XTimeoutHandler
	{
		// Token: 0x0600CCF3 RID: 52467 RVA: 0x002F3C86 File Offset: 0x002F1E86
		public void OnReport(int limit, int used)
		{
			XSingleton<XDebug>.singleton.AddLog(this.Message, " used: ", used.ToString(), " limit: ", limit.ToString(), " ms", XDebugColor.XDebug_None);
		}

		// Token: 0x04005B1F RID: 23327
		public string Message;
	}
}
