using System;

namespace XUtliPoolLib
{
	// Token: 0x020001AA RID: 426
	[Serializable]
	public class XDataFileLoadException : XException
	{
		// Token: 0x06000960 RID: 2400 RVA: 0x00030E27 File Offset: 0x0002F027
		public XDataFileLoadException(string message) : base(message)
		{
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00030E32 File Offset: 0x0002F032
		public XDataFileLoadException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
