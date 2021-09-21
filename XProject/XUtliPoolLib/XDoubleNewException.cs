using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A1 RID: 417
	[Serializable]
	public class XDoubleNewException : XException
	{
		// Token: 0x0600094E RID: 2382 RVA: 0x00030E27 File Offset: 0x0002F027
		public XDoubleNewException(string message) : base(message)
		{
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00030E32 File Offset: 0x0002F032
		public XDoubleNewException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
