using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildListDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildListDocument.uuID;
			}
		}

		public XGuildListView GuildListView { get; set; }

		public List<XGuildListData> ListData
		{
			get
			{
				return this._ListData;
			}
		}

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

		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		public string SearchText { get; set; }

		private void _ClearAllList()
		{
			for (int i = 0; i < this._ListData.Count; i++)
			{
				this._ListData[i].Recycle();
			}
			this._ListData.Clear();
		}

		private void _AddTail()
		{
			XGuildListData data = XDataPool<XGuildListData>.GetData();
			data.uid = 0UL;
			this._ListData.Add(data);
		}

		private void _RemoveTail()
		{
			bool flag = this._ListData.Count > 0 && this._ListData[this._ListData.Count - 1].uid == 0UL;
			if (flag)
			{
				this._ListData[this._ListData.Count - 1].Recycle();
				this._ListData.RemoveAt(this._ListData.Count - 1);
			}
		}

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

		public void ReqGuildList()
		{
			this._ClearAllList();
			this._ReqGuildList(0, XGuildListDocument.COUNT_PER_PULL);
		}

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

		public void ReqMoreGuilds()
		{
			this._RemoveTail();
			this._ReqGuildList(this._ListData.Count, XGuildListDocument.COUNT_PER_PULL);
		}

		public void ReqQuickJoin()
		{
			this.ReqApplyGuild(0UL, "");
		}

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

		public void ReqApplyGuild(ulong uid, string name)
		{
			RpcC2M_CreateOrEnterGuild rpcC2M_CreateOrEnterGuild = new RpcC2M_CreateOrEnterGuild();
			rpcC2M_CreateOrEnterGuild.oArg.iscreate = false;
			rpcC2M_CreateOrEnterGuild.oArg.gid = uid;
			rpcC2M_CreateOrEnterGuild.oArg.gname = name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrEnterGuild);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildListDocument");

		private static readonly int COUNT_PER_PULL = 5;

		private static readonly int COUNT_ALL = 500;

		private static readonly int NAME_LENGTH_LIMIT = 8;

		private List<XGuildListData> _ListData = new List<XGuildListData>();

		private GuildSortType m_SortType = GuildSortType.GuildSortByLevel;

		private int m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<GuildSortType>.ToInt(GuildSortType.GuildSortByLevel)];
	}
}
