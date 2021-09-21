using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000A80 RID: 2688
	internal class XGuildRedPacketDetail
	{
		// Token: 0x04003B27 RID: 15143
		public XGuildRedPacketBrief brif = new XGuildRedPacketBrief();

		// Token: 0x04003B28 RID: 15144
		public int itemTotalCount;

		// Token: 0x04003B29 RID: 15145
		public uint getTotalCount;

		// Token: 0x04003B2A RID: 15146
		public int getCount;

		// Token: 0x04003B2B RID: 15147
		public string content;

		// Token: 0x04003B2C RID: 15148
		public ulong leaderID;

		// Token: 0x04003B2D RID: 15149
		public ulong luckestID;

		// Token: 0x04003B2E RID: 15150
		public bool canThank;

		// Token: 0x04003B2F RID: 15151
		public List<ILogData> logList = new List<ILogData>();
	}
}
