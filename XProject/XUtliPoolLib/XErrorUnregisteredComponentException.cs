using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A3 RID: 419
	[Serializable]
	public class XErrorUnregisteredComponentException : XException
	{
		// Token: 0x06000952 RID: 2386 RVA: 0x00030E27 File Offset: 0x0002F027
		public XErrorUnregisteredComponentException(string message) : base(message)
		{
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00030E32 File Offset: 0x0002F032
		public XErrorUnregisteredComponentException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
