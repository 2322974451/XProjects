using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A8 RID: 424
	[Serializable]
	public class XMissAnimationException : XException
	{
		// Token: 0x0600095C RID: 2396 RVA: 0x00030E27 File Offset: 0x0002F027
		public XMissAnimationException(string message) : base(message)
		{
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00030E32 File Offset: 0x0002F032
		public XMissAnimationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
