using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000A73 RID: 2675
	internal class XGuildListData : XGuildBasicData
	{
		// Token: 0x0600A2BE RID: 41662 RVA: 0x001BC258 File Offset: 0x001BA458
		public override void Init(GuildInfo info)
		{
			base.Init(info);
			this.bIsApplying = info.isSendApplication;
			this.requiredPPT = (uint)info.ppt;
			this.bNeedApprove = (info.needapproval == 1);
		}

		// Token: 0x04003AC0 RID: 15040
		public bool bIsApplying;

		// Token: 0x04003AC1 RID: 15041
		public bool bNeedApprove;

		// Token: 0x04003AC2 RID: 15042
		public uint requiredPPT;

		// Token: 0x04003AC3 RID: 15043
		public static int[] DefaultSortDirection = new int[]
		{
			1,
			1,
			-1,
			-1,
			-1,
			1,
			1
		};
	}
}
