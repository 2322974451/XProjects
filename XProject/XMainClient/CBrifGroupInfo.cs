using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008EA RID: 2282
	public class CBrifGroupInfo : LoopItemData
	{
		// Token: 0x04002BDB RID: 11227
		public ulong id;

		// Token: 0x04002BDC RID: 11228
		public uint createtype;

		// Token: 0x04002BDD RID: 11229
		public string name;

		// Token: 0x04002BDE RID: 11230
		public DateTime msgtime = DateTime.Today;

		// Token: 0x04002BDF RID: 11231
		public bool captain;

		// Token: 0x04002BE0 RID: 11232
		public uint memberCnt;

		// Token: 0x04002BE1 RID: 11233
		public string rolename;

		// Token: 0x04002BE2 RID: 11234
		public ulong leaderid;

		// Token: 0x04002BE3 RID: 11235
		public string chat;

		// Token: 0x04002BE4 RID: 11236
		public uint createTime;
	}
}
