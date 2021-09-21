using System;

namespace XUtliPoolLib
{
	// Token: 0x020001A7 RID: 423
	[Serializable]
	public class XSkillUnexpectedFireException : XException
	{
		// Token: 0x0600095A RID: 2394 RVA: 0x00030E27 File Offset: 0x0002F027
		public XSkillUnexpectedFireException(string message) : base(message)
		{
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00030E32 File Offset: 0x0002F032
		public XSkillUnexpectedFireException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
