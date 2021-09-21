using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A9 RID: 425
	[Serializable]
	public class XZeroCoolDownTimeException : XException
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x00030E27 File Offset: 0x0002F027
		public XZeroCoolDownTimeException(string message) : base(message)
		{
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00030E32 File Offset: 0x0002F032
		public XZeroCoolDownTimeException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
