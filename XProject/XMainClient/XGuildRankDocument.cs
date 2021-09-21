using System;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000937 RID: 2359
	internal class XGuildRankDocument : XDocComponent
	{
		// Token: 0x17002BED RID: 11245
		// (get) Token: 0x06008E78 RID: 36472 RVA: 0x0013B94C File Offset: 0x00139B4C
		public override uint ID
		{
			get
			{
				return XGuildRankDocument.uuID;
			}
		}

		// Token: 0x17002BEE RID: 11246
		// (get) Token: 0x06008E79 RID: 36473 RVA: 0x0013B964 File Offset: 0x00139B64
		public uint EndTime
		{
			get
			{
				return this.m_EndTime;
			}
		}

		// Token: 0x17002BEF RID: 11247
		// (get) Token: 0x06008E7A RID: 36474 RVA: 0x0013B97C File Offset: 0x00139B7C
		public uint KeepTime
		{
			get
			{
				return this.m_KeepTime;
			}
		}

		// Token: 0x17002BF0 RID: 11248
		// (get) Token: 0x06008E7B RID: 36475 RVA: 0x0013B994 File Offset: 0x00139B94
		public uint RankIndex
		{
			get
			{
				return this.m_rankIndex;
			}
		}

		// Token: 0x17002BF1 RID: 11249
		// (get) Token: 0x06008E7C RID: 36476 RVA: 0x0013B9AC File Offset: 0x00139BAC
		// (set) Token: 0x06008E7D RID: 36477 RVA: 0x0013B9C4 File Offset: 0x00139BC4
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

		// Token: 0x06008E7E RID: 36478 RVA: 0x0013B9CE File Offset: 0x00139BCE
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRankDocument.AsyncLoader.AddTask("Table/GuildRankReward", XGuildRankDocument.m_RankRewardTable, false);
			XGuildRankDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008E7F RID: 36479 RVA: 0x0013B9F4 File Offset: 0x00139BF4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendGuildRankInfo();
			}
		}

		// Token: 0x06008E80 RID: 36480 RVA: 0x0013BA18 File Offset: 0x00139C18
		public void SendGuildRankInfo()
		{
			RpcC2M_ReqGuildRankInfo rpc = new RpcC2M_ReqGuildRankInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008E81 RID: 36481 RVA: 0x0013BA38 File Offset: 0x00139C38
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

		// Token: 0x04002E75 RID: 11893
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildRankDocument");

		// Token: 0x04002E76 RID: 11894
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002E77 RID: 11895
		public static GuildRankRewardTable m_RankRewardTable = new GuildRankRewardTable();

		// Token: 0x04002E78 RID: 11896
		private uint m_EndTime;

		// Token: 0x04002E79 RID: 11897
		private uint m_KeepTime;

		// Token: 0x04002E7A RID: 11898
		private uint m_rankIndex;

		// Token: 0x04002E7B RID: 11899
		public int m_lastTime = 0;
	}
}
