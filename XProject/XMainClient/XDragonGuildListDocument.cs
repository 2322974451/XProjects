using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000906 RID: 2310
	internal class XDragonGuildListDocument : XDocComponent
	{
		// Token: 0x17002B5D RID: 11101
		// (get) Token: 0x06008B9C RID: 35740 RVA: 0x0012B7C8 File Offset: 0x001299C8
		public override uint ID
		{
			get
			{
				return XDragonGuildListDocument.uuID;
			}
		}

		// Token: 0x17002B5E RID: 11102
		// (get) Token: 0x06008B9D RID: 35741 RVA: 0x0012B7E0 File Offset: 0x001299E0
		public static XDragonGuildListDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonGuildListDocument.uuID) as XDragonGuildListDocument;
			}
		}

		// Token: 0x17002B5F RID: 11103
		// (get) Token: 0x06008B9E RID: 35742 RVA: 0x0012B80C File Offset: 0x00129A0C
		public List<XDragonGuildListData> ListData
		{
			get
			{
				return this._ListData;
			}
		}

		// Token: 0x17002B60 RID: 11104
		// (get) Token: 0x06008B9F RID: 35743 RVA: 0x0012B824 File Offset: 0x00129A24
		// (set) Token: 0x06008BA0 RID: 35744 RVA: 0x0012B83C File Offset: 0x00129A3C
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

		// Token: 0x17002B61 RID: 11105
		// (get) Token: 0x06008BA1 RID: 35745 RVA: 0x0012B884 File Offset: 0x00129A84
		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		// Token: 0x17002B62 RID: 11106
		// (get) Token: 0x06008BA2 RID: 35746 RVA: 0x0012B89C File Offset: 0x00129A9C
		// (set) Token: 0x06008BA3 RID: 35747 RVA: 0x0012B8A4 File Offset: 0x00129AA4
		public string SearchText { get; set; }

		// Token: 0x06008BA4 RID: 35748 RVA: 0x0012B8B0 File Offset: 0x00129AB0
		private void _ClearAllList()
		{
			for (int i = 0; i < this._ListData.Count; i++)
			{
				this._ListData[i].Recycle();
			}
			this._ListData.Clear();
		}

		// Token: 0x06008BA5 RID: 35749 RVA: 0x0012B8F8 File Offset: 0x00129AF8
		private void _AddTail()
		{
			XDragonGuildListData data = XDataPool<XDragonGuildListData>.GetData();
			data.uid = 0UL;
			this._ListData.Add(data);
		}

		// Token: 0x06008BA6 RID: 35750 RVA: 0x0012B924 File Offset: 0x00129B24
		private void _RemoveTail()
		{
			bool flag = this._ListData.Count > 0 && this._ListData[this._ListData.Count - 1].uid == 0UL;
			if (flag)
			{
				this._ListData[this._ListData.Count - 1].Recycle();
				this._ListData.RemoveAt(this._ListData.Count - 1);
			}
		}

		// Token: 0x06008BA7 RID: 35751 RVA: 0x0012B9A4 File Offset: 0x00129BA4
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

		// Token: 0x06008BA8 RID: 35752 RVA: 0x0012BA20 File Offset: 0x00129C20
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

		// Token: 0x06008BA9 RID: 35753 RVA: 0x0012BA60 File Offset: 0x00129C60
		public void ReqApplyDragonGuild(ulong uid, string name)
		{
			RpcC2M_CreateOrJoinDragonGuild rpcC2M_CreateOrJoinDragonGuild = new RpcC2M_CreateOrJoinDragonGuild();
			rpcC2M_CreateOrJoinDragonGuild.oArg.iscreate = false;
			rpcC2M_CreateOrJoinDragonGuild.oArg.dgid = uid;
			rpcC2M_CreateOrJoinDragonGuild.oArg.dgname = name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CreateOrJoinDragonGuild);
		}

		// Token: 0x06008BAA RID: 35754 RVA: 0x0012BAA8 File Offset: 0x00129CA8
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

		// Token: 0x06008BAB RID: 35755 RVA: 0x0012BB8F File Offset: 0x00129D8F
		public void ReqQuickJoin()
		{
			this.ReqApplyDragonGuild(0UL, "");
		}

		// Token: 0x06008BAC RID: 35756 RVA: 0x0012BBA0 File Offset: 0x00129DA0
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

		// Token: 0x06008BAD RID: 35757 RVA: 0x0012BBE7 File Offset: 0x00129DE7
		public void ReqDragonGuildList()
		{
			this._ClearAllList();
			this._ReqDragonGuildList(0, XDragonGuildListDocument.COUNT_PER_PULL);
		}

		// Token: 0x06008BAE RID: 35758 RVA: 0x0012BBFE File Offset: 0x00129DFE
		public void ReqMoreGuilds()
		{
			this._RemoveTail();
			this._ReqDragonGuildList(this._ListData.Count, XDragonGuildListDocument.COUNT_PER_PULL);
		}

		// Token: 0x06008BAF RID: 35759 RVA: 0x0012BC20 File Offset: 0x00129E20
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

		// Token: 0x06008BB0 RID: 35760 RVA: 0x0012BCBC File Offset: 0x00129EBC
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

		// Token: 0x06008BB1 RID: 35761 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002CB8 RID: 11448
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildListDocument");

		// Token: 0x04002CB9 RID: 11449
		private static readonly int COUNT_PER_PULL = 5;

		// Token: 0x04002CBA RID: 11450
		private static readonly int COUNT_ALL = 500;

		// Token: 0x04002CBB RID: 11451
		private static readonly int NAME_LENGTH_LIMIT = 8;

		// Token: 0x04002CBC RID: 11452
		private List<XDragonGuildListData> _ListData = new List<XDragonGuildListData>();

		// Token: 0x04002CBD RID: 11453
		private DragonGuildSortType m_SortType = DragonGuildSortType.DragonGuildSortByLevel;

		// Token: 0x04002CBE RID: 11454
		private int m_Direction = XGuildListData.DefaultSortDirection[XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(DragonGuildSortType.DragonGuildSortByLevel)];

		// Token: 0x04002CC0 RID: 11456
		public XDragonGuildListHandler View;
	}
}
