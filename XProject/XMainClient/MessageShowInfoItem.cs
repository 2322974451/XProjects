using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000952 RID: 2386
	public class MessageShowInfoItem
	{
		// Token: 0x04002F57 RID: 12119
		public RoleBriefInfo roleInfo;

		// Token: 0x04002F58 RID: 12120
		public ulong audioID;

		// Token: 0x04002F59 RID: 12121
		public uint audioTime;

		// Token: 0x04002F5A RID: 12122
		public string promiseWords;

		// Token: 0x04002F5B RID: 12123
		public int taskID;

		// Token: 0x04002F5C RID: 12124
		public MentorMsgApplyType msgType;

		// Token: 0x04002F5D RID: 12125
		public bool applied = false;
	}
}
