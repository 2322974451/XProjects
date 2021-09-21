using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000904 RID: 2308
	internal class XDragonGuildListData : XDragonGuildBaseData
	{
		// Token: 0x06008B97 RID: 35735 RVA: 0x0012B6E4 File Offset: 0x001298E4
		public override void Init(DragonGuildInfo info)
		{
			base.Init(info);
			this.bIsApplying = info.isSendApplication;
			this.requiredPPT = info.recruitppt;
			this.bNeedApprove = info.needapproval;
		}

		// Token: 0x04002CA9 RID: 11433
		public bool bIsApplying;

		// Token: 0x04002CAA RID: 11434
		public bool bNeedApprove;

		// Token: 0x04002CAB RID: 11435
		public uint requiredPPT;

		// Token: 0x04002CAC RID: 11436
		public static int[] DefaultSortDirection = new int[]
		{
			1,
			-1,
			-1,
			-1,
			1,
			1,
			1
		};
	}
}
