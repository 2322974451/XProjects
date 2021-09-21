using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A0 RID: 416
	[Serializable]
	public class XException : ApplicationException
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x00030E06 File Offset: 0x0002F006
		public XException()
		{
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00030E10 File Offset: 0x0002F010
		public XException(string message) : base(message)
		{
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00030E1B File Offset: 0x0002F01B
		public XException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
