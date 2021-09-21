using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A5 RID: 421
	[Serializable]
	public class XZeroDelayException : XException
	{
		// Token: 0x06000956 RID: 2390 RVA: 0x00030E27 File Offset: 0x0002F027
		public XZeroDelayException(string message) : base(message)
		{
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00030E32 File Offset: 0x0002F032
		public XZeroDelayException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
