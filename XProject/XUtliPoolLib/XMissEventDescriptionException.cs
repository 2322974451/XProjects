using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A4 RID: 420
	[Serializable]
	public class XMissEventDescriptionException : XException
	{
		// Token: 0x06000954 RID: 2388 RVA: 0x00030E27 File Offset: 0x0002F027
		public XMissEventDescriptionException(string message) : base(message)
		{
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00030E32 File Offset: 0x0002F032
		public XMissEventDescriptionException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
