using System;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRankDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildRankDocument.uuID;
			}
		}

		public uint EndTime
		{
			get
			{
				return this.m_EndTime;
			}
		}

		public uint KeepTime
		{
			get
			{
				return this.m_KeepTime;
			}
		}

		public uint RankIndex
		{
			get
			{
				return this.m_rankIndex;
			}
		}

		public int LastTime
		{
			get
			{
				return this.m_lastTime;
			}
			set
			{
				this.m_lastTime = value;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRankDocument.AsyncLoader.AddTask("Table/GuildRankReward", XGuildRankDocument.m_RankRewardTable, false);
			XGuildRankDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendGuildRankInfo();
			}
		}

		public void SendGuildRankInfo()
		{
			RpcC2M_ReqGuildRankInfo rpc = new RpcC2M_ReqGuildRankInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveGuildRankInfo(ReqGuildRankInfoRes res)
		{
			this.m_EndTime = res.endTime;
			this.m_KeepTime = res.keepTime;
			this.m_rankIndex = res.rank;
			this.LastTime = (int)(res.endTime - res.nowTime);
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Refresh();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildRankDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildRankRewardTable m_RankRewardTable = new GuildRankRewardTable();

		private uint m_EndTime;

		private uint m_KeepTime;

		private uint m_rankIndex;

		public int m_lastTime = 0;
	}
}
