using System;

namespace XMainClient
{
	// Token: 0x02000F1B RID: 3867
	internal class XTimeProfiler
	{
		// Token: 0x0600CCF5 RID: 52469 RVA: 0x002F3CB8 File Offset: 0x002F1EB8
		public static XTimeProfiler getLogProfiler(int timeLimit, string message)
		{
			bool flag = XTimeProfiler._Instance == null;
			if (flag)
			{
				XTimeoutLogHandler handler = new XTimeoutLogHandler();
				XTimeProfiler._Instance = new XTimeProfiler(timeLimit);
				XTimeProfiler._Instance.SetHandler(handler);
			}
			else
			{
				XTimeProfiler._Instance._timeLimit = timeLimit;
			}
			(XTimeProfiler._Instance._handler as XTimeoutLogHandler).Message = message;
			return XTimeProfiler._Instance;
		}

		// Token: 0x0600CCF6 RID: 52470 RVA: 0x002F3D1E File Offset: 0x002F1F1E
		public XTimeProfiler(int timeLimit)
		{
			this._timeLimit = timeLimit;
			this._start = 0;
			this._handler = null;
		}

		// Token: 0x0600CCF7 RID: 52471 RVA: 0x002F3D3D File Offset: 0x002F1F3D
		public void SetHandler(XTimeoutHandler handler)
		{
			this._handler = handler;
		}

		// Token: 0x0600CCF8 RID: 52472 RVA: 0x002F3D47 File Offset: 0x002F1F47
		public void Begin()
		{
			this._start = Environment.TickCount;
		}

		// Token: 0x0600CCF9 RID: 52473 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void End()
		{
		}

		// Token: 0x04005B20 RID: 23328
		private int _timeLimit;

		// Token: 0x04005B21 RID: 23329
		private int _start;

		// Token: 0x04005B22 RID: 23330
		private XTimeoutHandler _handler;

		// Token: 0x04005B23 RID: 23331
		private static XTimeProfiler _Instance;
	}
}
