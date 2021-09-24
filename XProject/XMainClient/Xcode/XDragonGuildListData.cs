using System;
using KKSG;

namespace XMainClient
{

	internal class XDragonGuildListData : XDragonGuildBaseData
	{

		public override void Init(DragonGuildInfo info)
		{
			base.Init(info);
			this.bIsApplying = info.isSendApplication;
			this.requiredPPT = info.recruitppt;
			this.bNeedApprove = info.needapproval;
		}

		public bool bIsApplying;

		public bool bNeedApprove;

		public uint requiredPPT;

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
