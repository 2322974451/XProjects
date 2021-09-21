using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A72 RID: 2674
	internal class XGuildListDocument : XDocComponent
	{
		// Token: 0x17002F71 RID: 12145
		// (get) Token: 0x0600A2A5 RID: 41637 RVA: 0x001BBAC0 File Offset: 0x001B9CC0
		public override uint ID
		{
			get
			{
				return XGuildListDocument.uuID;
			}
		}

		// Token: 0x17002F72 RID: 12146
		// (get) Token: 0x0600A2A6 RID: 41638 RVA: 0x001BBAD7 File Offset: 0x001B9CD7
		// (set) Token: 0x0600A2A7 RID: 41639 RVA: 0x001BBADF File Offset: 0x001B9CDF
		public XGuildListView GuildListView { get; set; }

		// Token: 0x17002F73 RID: 12147
		// (get) Token: 0x0600A2A8 RID: 41640 RVA: 0x001BBAE8 File Offset: 0x001B9CE8
		public List<XGuildListData> ListData
		{
			get
			{
				return this._ListData;
			}
		}

		// Token: 0x17002F74 RID: 12148
		// (get) Token: 0x0600A2A9 RID: 41641 RVA: 0x001BBB00 File Offset: 0x001B9D00
		// (set) Token: 0x0600A2AA RID: 41642 RVA: 0x001BBB18 File Offset: 0x001B9D18
		public GuildSortType SortType
		{
			get
			{
				return this.m_SortType;
			}
			set
			{
				bool flag = this.m_SortType != value;
				if (flag)
				{
					this.m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<GuildSortType>.ToInt(value)];
				}
				else
				{
					this.m_Direction = -this.m_Direction;
				}
				this.m_SortType = value;
			}
		}

		// Token: 0x17002F75 RID: 12149
		// (get) Token: 0x0600A2AB RID: 41643 RVA: 0x001BBB60 File Offset: 0x001B9D60
		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		// Token: 0x17002F76 RID: 12150
		// (get) Token: 0x0600A2AC RID: 41644 RVA: 0x001BBB78 File Offset: 0x001B9D78
		// (set) Token: 0x0600A2AD RID: 41645 RVA: 0x001BBB80 File Offset: 0x001B9D80
		public string SearchText { get; set; }

		// Token: 0x0600A2AF RID: 41647 RVA: 0x001BBBB8 File Offset: 0x001B9DB8
		private void _ClearAllList()
		{
			for (int i = 0; i < this._ListData.Count; i++)
			{
				this._ListData[i].Recycle();
			}
			this._ListData.Clear();
		}

		// Token: 0x0600A2B0 RID: 41648 RVA: 0x001BBC00 File Offset: 0x001B9E00
		private void _AddTail()
		{
			XGuildListData data = XDataPool<XGuildListData>.GetData();
			data.uid = 0UL;
			this._ListData.Add(data);
		}

		// Token: 0x0600A2B1 RID: 41649 RVA: 0x001BBC2C File Offset: 0x001B9E2C
		private void _RemoveTail()
		{
			bool flag = this._ListData.Count > 0 && this._ListData[this._ListData.Count - 1].uid == 0UL;
			if (flag)
			{
				this._ListData[this._ListData.Count - 1].Recycle();
				this._ListData.RemoveAt(this._ListData.Count - 1);
			}
		}

		// Token: 0x0600A2B2 RID: 41650 RVA: 0x001BBCAC File Offset: 0x001B9EAC
		private void _ReqGuildList(int start, int count)
		{
			RpcC2M_ReqGuildList rpcC2M_ReqGuildList = new RpcC2M_ReqGuildList();
			rpcC2M_ReqGuildList.oArg.start = start;
			rpcC2M_ReqGuildList.oArg.count = count;
			rpcC2M_ReqGuildList.oArg.reason = 1;
			rpcC2M_ReqGuildList.oArg.sortType = XFastEnumIntEqualityComparer<GuildSortType>.ToInt(this.m_SortType);
			rpcC2M_ReqGuildList.oArg.name = this.SearchText;
			rpcC2M_ReqGuildList.oArg.reverse = (this.m_Direction * XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<GuildSortType>.ToInt(this.m_SortType)] != 1);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildList);
		}

		// Token: 0x0600A2B3 RID: 41651 RVA: 0x001BBD46 File Offset: 0x001B9F46
		public void ReqGuildList()
		{
			this._ClearAllList();
			this._ReqGuildList(0, XGuildListDocument.COUNT_PER_PULL);
		}

		// Token: 0x0600A2B4 RID: 41652 RVA: 0x001BBD60 File Offset: 0x001B9F60
		public void OnGetGuildList(FetchGuildListArg oArg, FetchGuildListRes oRes)
		{
			int num = Math.Min(this._ListData.Count, oArg.start);
			for (int i = 0; i < oRes.guilds.Count; i++)
			{
				GuildInfo guildInfo = oRes.guilds[i];
				for (int j = 0; j < num; j++)
				{
					bool flag = this._ListData[j].uid == guildInfo.id;
					if (flag)
					{
						this._ClearAllList();
						this._ReqGuildList(0, oArg.start + oArg.count);
						return;
					}
				}
				int num2 = oArg.start + i;
				bool flag2 = num2 < this._ListData.Count;
				XGuildListData xguildListData;
				if (flag2)
				{
					xguildListData = this._ListData[num2];
				}
				else
				{
					xguildListData = XDataPool<XGuildListData>.GetData();
					this._ListData.Add(xguildListData);
				}
				xguildListData.Init(guildInfo);
			}
			bool flag3 = oRes.guilds.Count != 0 && oArg.count != XGuildListDocument.COUNT_ALL;
			if (flag3)
			{
				this._AddTail();
			}
			else
			{
				bool flag4 = this._ListData.Count > 0;
				if (flag4)
				{
					bool flag5 = oArg.count != XGuildListDocument.COUNT_ALL;
					if (flag5)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_LIST_NO_MORE_GUILDS"), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_LIST_NO_GUILDS"), "fece00");
				}
			}
			bool flag6 = this.GuildListView != null && this.GuildListView.IsVisible();
			if (flag6)
			{
				bool flag7 = oArg.start == 0 && (oArg.count == XGuildListDocument.COUNT_PER_PULL || oArg.count == XGuildListDocument.COUNT_ALL);
				if (flag7)
				{
					this.GuildListView.RefreshPage(true);
				}
				else
				{
					this.GuildListView.NewContentAppended();
				}
				return;
			}
		}

		// Token: 0x0600A2B5 RID: 41653 RVA: 0x001BBF56 File Offset: 0x001BA156
		public void ReqMoreGuilds()
		{
			this._RemoveTail();
			this._ReqGuildList(this._ListData.Count, XGuildListDocument.COUNT_PER_PULL);
		}

		// Token: 0x0600A2B6 RID: 41654 RVA: 0x001BBF77 File Offset: 0x001BA177
		public void ReqQuickJoin()
		{
			this.ReqApplyGuild(0UL, "");
		}

		// Token: 0x0600A2B7 RID: 41655 RVA: 0x001BBF88 File Offset: 0x001BA188
		public void ReqSearch(string text)
		{
			this.SearchText = text;
			this._ClearAllList();
			bool flag = this.SearchText != "";
			if (flag)
			{
				this._ReqGuildList(0, XGuildListDocument.COUNT_ALL);
			}
			else
			{
				this.ReqGuildList();
			}
		}

		// Token: 0x0600A2B8 RID: 41656 RVA: 0x001BBFD0 File Offset: 0x001BA1D0
		public void ReqCreateGuild(string name, int portraitIndex)
		{
			bool flag = name.Length > XGuildListDocument.NAME_LENGTH_LIMIT;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_NAME_LENGTH_LIMIT", new object[]
				{
					XGuildListDocument.NAME_LENGTH_LIMIT
				}), "fece00");
			}
			else
			{
				RpcC2M_CreateOrEnterGuild rpcC2M_CreateOrEnterGuild = new RpcC2M_CreateOrEnterGuild();
				rpcC2M_CreateOrEnterGuild.oArg.iscreate = true;
				rpcC2M_CreateOrEnterGuild.oArg.gname = name;
				rpcC2M_CreateOrEnterGuild.oArg.icon = portraitIndex;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrEnterGuild);
			}
		}

		// Token: 0x0600A2B9 RID: 41657 RVA: 0x001BC058 File Offset: 0x001BA258
		public void OnCreateGuild(CreateOrJoinGuild oArg, CreateOrJoinGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				XSingleton<XGameSysMgr>.singleton.OpenGuildSystem(XSysDefine.XSys_GuildHall);
			}
		}

		// Token: 0x0600A2BA RID: 41658 RVA: 0x001BC0C4 File Offset: 0x001BA2C4
		public void ReqApplyGuild(ulong uid, string name)
		{
			RpcC2M_CreateOrEnterGuild rpcC2M_CreateOrEnterGuild = new RpcC2M_CreateOrEnterGuild();
			rpcC2M_CreateOrEnterGuild.oArg.iscreate = false;
			rpcC2M_CreateOrEnterGuild.oArg.gid = uid;
			rpcC2M_CreateOrEnterGuild.oArg.gname = name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrEnterGuild);
		}

		// Token: 0x0600A2BB RID: 41659 RVA: 0x001BC10C File Offset: 0x001BA30C
		public void OnApplyGuild(CreateOrJoinGuild oArg, CreateOrJoinGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				bool flag2 = oRes.result != ErrorCode.ERR_GUILD_WAITAPPROVAL;
				if (flag2)
				{
					return;
				}
			}
			DlgBase<XGuildApplyView, XGuildApplyBehaviour>.singleton.Hide();
			bool flag3 = oRes.result == ErrorCode.ERR_GUILD_WAITAPPROVAL;
			if (flag3)
			{
				for (int i = 0; i < this._ListData.Count; i++)
				{
					bool flag4 = this._ListData[i].uid == oArg.gid;
					if (flag4)
					{
						this._ListData[i].bIsApplying = true;
						break;
					}
				}
				bool flag5 = this.GuildListView != null && this.GuildListView.IsVisible();
				if (flag5)
				{
					this.GuildListView.RefreshPage(false);
				}
			}
			else
			{
				bool flag6 = DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.IsVisible();
				if (flag6)
				{
					DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				XSingleton<XGameSysMgr>.singleton.OpenGuildSystem(XSysDefine.XSys_GuildHall);
			}
		}

		// Token: 0x0600A2BC RID: 41660 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003AB7 RID: 15031
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildListDocument");

		// Token: 0x04003AB8 RID: 15032
		private static readonly int COUNT_PER_PULL = 5;

		// Token: 0x04003AB9 RID: 15033
		private static readonly int COUNT_ALL = 500;

		// Token: 0x04003ABA RID: 15034
		private static readonly int NAME_LENGTH_LIMIT = 8;

		// Token: 0x04003ABC RID: 15036
		private List<XGuildListData> _ListData = new List<XGuildListData>();

		// Token: 0x04003ABD RID: 15037
		private GuildSortType m_SortType = GuildSortType.GuildSortByLevel;

		// Token: 0x04003ABE RID: 15038
		private int m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<GuildSortType>.ToInt(GuildSortType.GuildSortByLevel)];
	}
}
