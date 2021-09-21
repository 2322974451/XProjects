using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A2 RID: 418
	[Serializable]
	public class XErrorEventArgTypeException : XException
	{
		// Token: 0x06000950 RID: 2384 RVA: 0x00030E27 File Offset: 0x0002F027
		public XErrorEventArgTypeException(string message) : base(message)
		{
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00030E32 File Offset: 0x0002F032
		public XErrorEventArgTypeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
