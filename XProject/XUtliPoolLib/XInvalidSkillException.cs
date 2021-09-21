using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A6 RID: 422
	[Serializable]
	public class XInvalidSkillException : XException
	{
		// Token: 0x06000958 RID: 2392 RVA: 0x00030E27 File Offset: 0x0002F027
		public XInvalidSkillException(string message) : base(message)
		{
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00030E32 File Offset: 0x0002F032
		public XInvalidSkillException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
