using System;
using KKSG;

namespace XMainClient
{

	internal class XGuildListData : XGuildBasicData
	{

		public override void Init(GuildInfo info)
		{
			base.Init(info);
			this.bIsApplying = info.isSendApplication;
			this.requiredPPT = (uint)info.ppt;
			this.bNeedApprove = (info.needapproval == 1);
		}

		public bool bIsApplying;

		public bool bNeedApprove;

		public uint requiredPPT;

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
