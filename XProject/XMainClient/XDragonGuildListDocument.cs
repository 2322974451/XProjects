using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildListDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonGuildListDocument.uuID;
			}
		}

		public static XDragonGuildListDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonGuildListDocument.uuID) as XDragonGuildListDocument;
			}
		}

		public List<XDragonGuildListData> ListData
		{
			get
			{
				return this._ListData;
			}
		}

		public DragonGuildSortType SortType
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
					this.m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(value)];
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
			XDragonGuildListData data = XDataPool<XDragonGuildListData>.GetData();
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

		public void ReqCreateDragonGuild(string name)
		{
			bool flag = name.Length > XDragonGuildListDocument.NAME_LENGTH_LIMIT;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_NAME_LENGTH_LIMIT", new object[]
				{
					XDragonGuildListDocument.NAME_LENGTH_LIMIT
				}), "fece00");
			}
			else
			{
				RpcC2M_CreateOrJoinDragonGuild rpcC2M_CreateOrJoinDragonGuild = new RpcC2M_CreateOrJoinDragonGuild();
				rpcC2M_CreateOrJoinDragonGuild.oArg.iscreate = true;
				rpcC2M_CreateOrJoinDragonGuild.oArg.dgname = name;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrJoinDragonGuild);
			}
		}

		public void OnCreateDragonGuild(CreateOrJoinDragonGuildArg oArg, CreateOrJoinDragonGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshDragonGuildPage();
			}
		}

		public void ReqApplyDragonGuild(ulong uid, string name)
		{
			RpcC2M_CreateOrJoinDragonGuild rpcC2M_CreateOrJoinDragonGuild = new RpcC2M_CreateOrJoinDragonGuild();
			rpcC2M_CreateOrJoinDragonGuild.oArg.iscreate = false;
			rpcC2M_CreateOrJoinDragonGuild.oArg.dgid = uid;
			rpcC2M_CreateOrJoinDragonGuild.oArg.dgname = name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrJoinDragonGuild);
		}

		public void OnApplyDragonGuild(CreateOrJoinDragonGuildArg oArg, CreateOrJoinDragonGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				bool flag2 = oRes.result != ErrorCode.ERR_DG_WAITAPPROVAL;
				if (flag2)
				{
					return;
				}
			}
			DlgBase<XDragonGuildApplyView, XDragonGuildApplyBehaviour>.singleton.Hide();
			bool flag3 = oRes.result == ErrorCode.ERR_DG_WAITAPPROVAL;
			if (flag3)
			{
				for (int i = 0; i < this._ListData.Count; i++)
				{
					bool flag4 = this._ListData[i].uid == oArg.dgid;
					if (flag4)
					{
						this._ListData[i].bIsApplying = true;
						break;
					}
				}
				bool flag5 = this.View != null && this.View.IsVisible();
				if (flag5)
				{
					this.View.RefreshPage(false);
				}
			}
		}

		public void ReqQuickJoin()
		{
			this.ReqApplyDragonGuild(0UL, "");
		}

		public void ReqSearch(string text)
		{
			this.SearchText = text;
			this._ClearAllList();
			bool flag = this.SearchText != "";
			if (flag)
			{
				this._ReqDragonGuildList(0, XDragonGuildListDocument.COUNT_ALL);
			}
			else
			{
				this.ReqDragonGuildList();
			}
		}

		public void ReqDragonGuildList()
		{
			this._ClearAllList();
			this._ReqDragonGuildList(0, XDragonGuildListDocument.COUNT_PER_PULL);
		}

		public void ReqMoreGuilds()
		{
			this._RemoveTail();
			this._ReqDragonGuildList(this._ListData.Count, XDragonGuildListDocument.COUNT_PER_PULL);
		}

		private void _ReqDragonGuildList(int start, int count)
		{
			RpcC2M_FetchDragonGuildList rpcC2M_FetchDragonGuildList = new RpcC2M_FetchDragonGuildList();
			rpcC2M_FetchDragonGuildList.oArg.start = start;
			rpcC2M_FetchDragonGuildList.oArg.count = count;
			rpcC2M_FetchDragonGuildList.oArg.reason = 1;
			rpcC2M_FetchDragonGuildList.oArg.sortType = XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(this.m_SortType);
			rpcC2M_FetchDragonGuildList.oArg.name = this.SearchText;
			rpcC2M_FetchDragonGuildList.oArg.reverse = (this.m_Direction * XDragonGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(this.m_SortType)] != 1);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchDragonGuildList);
		}

		public void OnGetDragonGuildList(FetchDragonGuildListArg oArg, FetchDragonGuildRes oRes)
		{
			int num = Math.Min(this._ListData.Count, oArg.start);
			for (int i = 0; i < oRes.dragonguilds.Count; i++)
			{
				DragonGuildInfo dragonGuildInfo = oRes.dragonguilds[i];
				for (int j = 0; j < num; j++)
				{
					bool flag = this._ListData[j].uid == dragonGuildInfo.id;
					if (flag)
					{
						this._ClearAllList();
						this._ReqDragonGuildList(0, oArg.start + oArg.count);
						return;
					}
				}
				int num2 = oArg.start + i;
				bool flag2 = num2 < this._ListData.Count;
				XDragonGuildListData xdragonGuildListData;
				if (flag2)
				{
					xdragonGuildListData = this._ListData[num2];
				}
				else
				{
					xdragonGuildListData = XDataPool<XDragonGuildListData>.GetData();
					this._ListData.Add(xdragonGuildListData);
				}
				xdragonGuildListData.Init(dragonGuildInfo);
			}
			bool flag3 = oRes.dragonguilds.Count != 0 && oArg.count != XDragonGuildListDocument.COUNT_ALL;
			if (flag3)
			{
				this._AddTail();
			}
			else
			{
				bool flag4 = this._ListData.Count > 0;
				if (flag4)
				{
					bool flag5 = oArg.count != XDragonGuildListDocument.COUNT_ALL;
					if (flag5)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_LIST_NO_MORE_GUILDS"), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_LIST_NO_GUILDS"), "fece00");
				}
			}
			bool flag6 = this.View != null && this.View.IsVisible();
			if (flag6)
			{
				bool flag7 = oArg.start == 0 && (oArg.count == XDragonGuildListDocument.COUNT_PER_PULL || oArg.count == XDragonGuildListDocument.COUNT_ALL);
				if (flag7)
				{
					this.View.RefreshPage(true);
				}
				else
				{
					this.View.NewContentAppended();
				}
				return;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildListDocument");

		private static readonly int COUNT_PER_PULL = 5;

		private static readonly int COUNT_ALL = 500;

		private static readonly int NAME_LENGTH_LIMIT = 8;

		private List<XDragonGuildListData> _ListData = new List<XDragonGuildListData>();

		private DragonGuildSortType m_SortType = DragonGuildSortType.DragonGuildSortByLevel;

		private int m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(DragonGuildSortType.DragonGuildSortByLevel)];

		public XDragonGuildListHandler View;
	}
}
