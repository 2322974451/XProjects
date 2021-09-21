using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B5 RID: 2485
	internal class XNextDayRewardDocument : XDocComponent
	{
		// Token: 0x17002D65 RID: 11621
		// (get) Token: 0x060096BE RID: 38590 RVA: 0x0016D3B4 File Offset: 0x0016B5B4
		public override uint ID
		{
			get
			{
				return XNextDayRewardDocument.uuID;
			}
		}

		// Token: 0x17002D66 RID: 11622
		// (get) Token: 0x060096BF RID: 38591 RVA: 0x0016D3CB File Offset: 0x0016B5CB
		// (set) Token: 0x060096C0 RID: 38592 RVA: 0x0016D3D3 File Offset: 0x0016B5D3
		public int Status { get; set; }

		// Token: 0x17002D67 RID: 11623
		// (get) Token: 0x060096C1 RID: 38593 RVA: 0x0016D3DC File Offset: 0x0016B5DC
		// (set) Token: 0x060096C2 RID: 38594 RVA: 0x0016D3E4 File Offset: 0x0016B5E4
		public int LeftTime { get; set; }

		// Token: 0x17002D68 RID: 11624
		// (get) Token: 0x060096C3 RID: 38595 RVA: 0x0016D3ED File Offset: 0x0016B5ED
		// (set) Token: 0x060096C4 RID: 38596 RVA: 0x0016D3F5 File Offset: 0x0016B5F5
		public bool HallShow { get; set; }

		// Token: 0x060096C5 RID: 38597 RVA: 0x0016D400 File Offset: 0x0016B600
		public void SendGetReward()
		{
			RpcC2G_GetNextDayReward rpc = new RpcC2G_GetNextDayReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060096C6 RID: 38598 RVA: 0x0016D420 File Offset: 0x0016B620
		public void QueryStatus()
		{
			PtcC2G_NextDayRewardReport proto = new PtcC2G_NextDayRewardReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x060096C7 RID: 38599 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshStatus(uint status, uint leftTime)
		{
		}

		// Token: 0x060096C8 RID: 38600 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060096C9 RID: 38601 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void LuaShow(bool show)
		{
		}

		// Token: 0x04003358 RID: 13144
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NextDayRewardDocument");
	}
}
