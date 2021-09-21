using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B6 RID: 2486
	internal class XOnlineRewardDocument : XDocComponent
	{
		// Token: 0x17002D69 RID: 11625
		// (get) Token: 0x060096CC RID: 38604 RVA: 0x0016D458 File Offset: 0x0016B658
		public override uint ID
		{
			get
			{
				return XOnlineRewardDocument.uuID;
			}
		}

		// Token: 0x17002D6A RID: 11626
		// (get) Token: 0x060096CD RID: 38605 RVA: 0x0016D46F File Offset: 0x0016B66F
		// (set) Token: 0x060096CE RID: 38606 RVA: 0x0016D477 File Offset: 0x0016B677
		public int CurrentID { get; set; }

		// Token: 0x060096CF RID: 38607 RVA: 0x0016D480 File Offset: 0x0016B680
		public static void Execute(OnLoadedCallback callback = null)
		{
			XOnlineRewardDocument.AsyncLoader.AddTask("Table/OnlineReward", XOnlineRewardDocument.RewardTable, false);
			XOnlineRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060096D0 RID: 38608 RVA: 0x0016D4A8 File Offset: 0x0016B6A8
		public void SendGetReward(int index)
		{
			RpcC2G_GetOnlineReward rpcC2G_GetOnlineReward = new RpcC2G_GetOnlineReward();
			rpcC2G_GetOnlineReward.oArg.index = (uint)index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetOnlineReward);
		}

		// Token: 0x060096D1 RID: 38609 RVA: 0x0016D4D8 File Offset: 0x0016B6D8
		public void QueryStatus()
		{
			PtcC2G_OnlineRewardReport proto = new PtcC2G_OnlineRewardReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x060096D2 RID: 38610 RVA: 0x0016D4F8 File Offset: 0x0016B6F8
		public void RefreshStatus(List<uint> status, List<uint> leftTime)
		{
			this.Status.Clear();
			this.LeftTime.Clear();
			for (int i = 0; i < status.Count; i++)
			{
				this.Status.Add((int)status[i]);
				this.LeftTime.Add((int)leftTime[i]);
			}
			bool flag = this.Status.Count == 0;
			if (flag)
			{
				this.Status.Add(2);
				this.LeftTime.Add(1);
			}
			this.CurrentID = this.Status.Count - 1;
			for (int j = 0; j < this.Status.Count; j++)
			{
				bool flag2 = this.Status[j] <= 1;
				if (flag2)
				{
					this.CurrentID = j;
					break;
				}
			}
			XSingleton<XGameSysMgr>.singleton.OnlineRewardRemainTime = (float)this.LeftTime[this.CurrentID];
			bool flag3 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() && XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag3)
			{
			}
			bool flag4 = !DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>.singleton.IsVisible();
			if (!flag4)
			{
				DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>.singleton.RefreshItemList();
				DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>.singleton.SetGetRewardLabel(this.Status[this.CurrentID]);
			}
		}

		// Token: 0x060096D3 RID: 38611 RVA: 0x0016D660 File Offset: 0x0016B860
		private bool CanClaim()
		{
			for (int i = 0; i < this.Status.Count; i++)
			{
				bool flag = this.Status[i] == 1;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060096D4 RID: 38612 RVA: 0x0016D6A8 File Offset: 0x0016B8A8
		public bool CheckOver()
		{
			for (int i = 0; i < this.Status.Count; i++)
			{
				bool flag = this.Status[i] != 2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060096D5 RID: 38613 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400335C RID: 13148
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("OnlineRewardDocument");

		// Token: 0x0400335D RID: 13149
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400335E RID: 13150
		public static OnlineRewardTable RewardTable = new OnlineRewardTable();

		// Token: 0x0400335F RID: 13151
		public List<int> Status = new List<int>();

		// Token: 0x04003360 RID: 13152
		public List<int> LeftTime = new List<int>();
	}
}
