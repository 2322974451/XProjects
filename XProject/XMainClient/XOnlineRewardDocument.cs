using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOnlineRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XOnlineRewardDocument.uuID;
			}
		}

		public int CurrentID { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XOnlineRewardDocument.AsyncLoader.AddTask("Table/OnlineReward", XOnlineRewardDocument.RewardTable, false);
			XOnlineRewardDocument.AsyncLoader.Execute(callback);
		}

		public void SendGetReward(int index)
		{
			RpcC2G_GetOnlineReward rpcC2G_GetOnlineReward = new RpcC2G_GetOnlineReward();
			rpcC2G_GetOnlineReward.oArg.index = (uint)index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetOnlineReward);
		}

		public void QueryStatus()
		{
			PtcC2G_OnlineRewardReport proto = new PtcC2G_OnlineRewardReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("OnlineRewardDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static OnlineRewardTable RewardTable = new OnlineRewardTable();

		public List<int> Status = new List<int>();

		public List<int> LeftTime = new List<int>();
	}
}
