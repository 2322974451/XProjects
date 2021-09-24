using System;

namespace XMainClient
{

	internal class XTimeProfiler
	{

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

		public XTimeProfiler(int timeLimit)
		{
			this._timeLimit = timeLimit;
			this._start = 0;
			this._handler = null;
		}

		public void SetHandler(XTimeoutHandler handler)
		{
			this._handler = handler;
		}

		public void Begin()
		{
			this._start = Environment.TickCount;
		}

		public void End()
		{
		}

		private int _timeLimit;

		private int _start;

		private XTimeoutHandler _handler;

		private static XTimeProfiler _Instance;
	}
}
