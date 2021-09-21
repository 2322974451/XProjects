using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000924 RID: 2340
	internal class XGuildDonateDocument : XDocComponent
	{
		// Token: 0x17002BAF RID: 11183
		// (get) Token: 0x06008D43 RID: 36163 RVA: 0x00134CD4 File Offset: 0x00132ED4
		public override uint ID
		{
			get
			{
				return XGuildDonateDocument.uuID;
			}
		}

		// Token: 0x17002BB0 RID: 11184
		// (get) Token: 0x06008D44 RID: 36164 RVA: 0x00134CEC File Offset: 0x00132EEC
		public static XGuildDonateDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildDonateDocument.uuID) as XGuildDonateDocument;
			}
		}

		// Token: 0x06008D45 RID: 36165 RVA: 0x00134D17 File Offset: 0x00132F17
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDonateDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008D46 RID: 36166 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008D47 RID: 36167 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008D48 RID: 36168 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008D49 RID: 36169 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008D4A RID: 36170 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008D4B RID: 36171 RVA: 0x00134D28 File Offset: 0x00132F28
		public GuildDonateRankInfo GetRankInfoByIndex(int index, DonateRankType type)
		{
			bool flag = type == DonateRankType.TodayRank && index < this._todayRankList.Count;
			GuildDonateRankInfo result;
			if (flag)
			{
				result = this._todayRankList[index];
			}
			else
			{
				bool flag2 = type == DonateRankType.HistoryRank && index < this._rankList.Count;
				if (flag2)
				{
					result = this._rankList[index];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06008D4C RID: 36172 RVA: 0x00134D8C File Offset: 0x00132F8C
		public void SortRankListWithRankType(DonateRankType type)
		{
			bool flag = type == DonateRankType.HistoryRank;
			if (flag)
			{
				this._rankList.Sort(new Comparison<GuildDonateRankInfo>(this.SortHistory));
			}
			else
			{
				this._todayRankList.Sort(new Comparison<GuildDonateRankInfo>(this.SortToday));
			}
		}

		// Token: 0x17002BB1 RID: 11185
		// (get) Token: 0x06008D4D RID: 36173 RVA: 0x00134DD8 File Offset: 0x00132FD8
		// (set) Token: 0x06008D4E RID: 36174 RVA: 0x00134DF0 File Offset: 0x00132FF0
		public List<GuildDonateItemInfo> DailyDonateOverviewList
		{
			get
			{
				return this._dailyDonateItemList;
			}
			set
			{
				this._dailyDonateItemList = value;
			}
		}

		// Token: 0x17002BB2 RID: 11186
		// (get) Token: 0x06008D4F RID: 36175 RVA: 0x00134DFC File Offset: 0x00132FFC
		// (set) Token: 0x06008D50 RID: 36176 RVA: 0x00134E14 File Offset: 0x00133014
		public uint DailyDonatedNum
		{
			get
			{
				return this._dailyDonatedNum;
			}
			set
			{
				this._dailyDonatedNum = value;
			}
		}

		// Token: 0x06008D51 RID: 36177 RVA: 0x00134E20 File Offset: 0x00133020
		public void SendGetDonateBaseInfo()
		{
			RpcC2M_GetGuildDonateInfo rpc = new RpcC2M_GetGuildDonateInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D52 RID: 36178 RVA: 0x00134E40 File Offset: 0x00133040
		public void OnGetDonateInfo(GetGuildDonateInfoRes res)
		{
			List<GuildMemberAskInfo> info = res.info;
			List<GuildMemberDonateRankItem> rankitem = res.rankitem;
			this.UpdateRankList(rankitem);
			this._dailyDonatedNum = res.donatenum;
			this._dailyDonateItemList.Clear();
			this._weeklyDonateItemList.Clear();
			for (int i = 0; i < info.Count; i++)
			{
				GuildMemberAskInfo guildMemberAskInfo = info[i];
				bool flag = guildMemberAskInfo.item.tasktype == PeriodTaskType.PeriodTaskType_Daily;
				if (flag)
				{
					this._dailyDonateItemList.Add(new GuildDonateItemInfo
					{
						name = guildMemberAskInfo.name,
						profession = guildMemberAskInfo.profession,
						id = guildMemberAskInfo.item.id,
						roleID = guildMemberAskInfo.item.roleid,
						publishTime = guildMemberAskInfo.item.publishtime,
						itemID = guildMemberAskInfo.item.itemid,
						needCount = guildMemberAskInfo.item.needCount,
						getCount = guildMemberAskInfo.item.getCount,
						taskID = guildMemberAskInfo.item.taskid
					});
				}
				else
				{
					this._weeklyDonateItemList.Add(new GuildDonateItemInfo
					{
						name = guildMemberAskInfo.name,
						profession = guildMemberAskInfo.profession,
						id = guildMemberAskInfo.item.id,
						roleID = guildMemberAskInfo.item.roleid,
						publishTime = guildMemberAskInfo.item.publishtime,
						itemID = guildMemberAskInfo.item.itemid,
						needCount = guildMemberAskInfo.item.needCount,
						getCount = guildMemberAskInfo.item.getCount,
						itemType = guildMemberAskInfo.item.itemtype,
						itemQuality = guildMemberAskInfo.item.itemquality,
						index = guildMemberAskInfo.item.index,
						taskID = guildMemberAskInfo.item.taskid
					});
				}
			}
			bool flag2 = DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.RefreshCurDonateTypeUI();
			}
		}

		// Token: 0x06008D53 RID: 36179 RVA: 0x00135060 File Offset: 0x00133260
		private void UpdateRankList(List<GuildMemberDonateRankItem> rankitem)
		{
			this._rankList.Clear();
			this._todayRankList.Clear();
			for (int i = 0; i < rankitem.Count; i++)
			{
				GuildMemberDonateRankItem guildMemberDonateRankItem = rankitem[i];
				this._rankList.Add(new GuildDonateRankInfo
				{
					roleID = guildMemberDonateRankItem.roleid,
					todayCount = guildMemberDonateRankItem.todaycount,
					totalCount = guildMemberDonateRankItem.totalcount,
					lastTime = guildMemberDonateRankItem.lasttime,
					roleName = guildMemberDonateRankItem.name,
					level = guildMemberDonateRankItem.level,
					profession = guildMemberDonateRankItem.profession
				});
				bool flag = this._rankList[i].todayCount > 0U;
				if (flag)
				{
					this._todayRankList.Add(this._rankList[i]);
				}
			}
		}

		// Token: 0x06008D54 RID: 36180 RVA: 0x00135140 File Offset: 0x00133340
		public GuildDonateItemInfo GetDonateItemInfoByIndex(GuildDonateType type, int index)
		{
			List<GuildDonateItemInfo> list = (type == GuildDonateType.DailyDonate) ? this._dailyDonateItemList : this._weeklyDonateItemList;
			bool flag = index < list.Count;
			GuildDonateItemInfo result;
			if (flag)
			{
				result = list[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008D55 RID: 36181 RVA: 0x0013517C File Offset: 0x0013337C
		public void SendDonateMemberItem(uint id, uint count, List<ulong> itemList = null)
		{
			RpcC2M_DonateMemberItem rpcC2M_DonateMemberItem = new RpcC2M_DonateMemberItem();
			rpcC2M_DonateMemberItem.oArg.id = id;
			rpcC2M_DonateMemberItem.oArg.count = count;
			bool flag = itemList != null;
			if (flag)
			{
				rpcC2M_DonateMemberItem.oArg.itemuid.AddRange(itemList);
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DonateMemberItem);
		}

		// Token: 0x06008D56 RID: 36182 RVA: 0x001351D0 File Offset: 0x001333D0
		public int GetMyRankIndex(DonateRankType type)
		{
			List<GuildDonateRankInfo> list = (type == DonateRankType.TodayRank) ? this._todayRankList : this._rankList;
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06008D57 RID: 36183 RVA: 0x00135234 File Offset: 0x00133434
		public int GetRankContentCount(DonateRankType type)
		{
			return (type == DonateRankType.TodayRank) ? this._todayRankList.Count : this._rankList.Count;
		}

		// Token: 0x06008D58 RID: 36184 RVA: 0x00135264 File Offset: 0x00133464
		public void OnGetDonateMemberReply(DonateMemberItemArg oArg, DonateMemberItemRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DonateSuccess"), "fece00");
				this.UpdateRankList(oRes.rankitem);
				for (int i = 0; i < this._dailyDonateItemList.Count; i++)
				{
					bool flag2 = this._dailyDonateItemList[i].id == oArg.id;
					if (flag2)
					{
						this._dailyDonateItemList[i].getCount += oArg.count;
						this._dailyDonatedNum += oArg.count;
					}
				}
				for (int j = 0; j < this._weeklyDonateItemList.Count; j++)
				{
					bool flag3 = this._weeklyDonateItemList[j].id == oArg.id;
					if (flag3)
					{
						this._weeklyDonateItemList[j].getCount += oArg.count;
						this._dailyDonatedNum += oArg.count;
					}
				}
				bool flag4 = DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.RefreshCurDonateTypeUI();
				}
			}
			else
			{
				bool flag5 = oRes.result == ErrorCode.ERR_TASK_ASKITEM_REFRESH || oRes.result == ErrorCode.ERR_TASK_NO_ASKINFO;
				if (flag5)
				{
					this.SendGetDonateBaseInfo();
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06008D59 RID: 36185 RVA: 0x001353F4 File Offset: 0x001335F4
		public void ShowViewWithID(uint id, GuildDonateType type = GuildDonateType.DailyDonate)
		{
			bool inGuild = XGuildDocument.InGuild;
			if (inGuild)
			{
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.toSelectID = id;
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.DonateType = type;
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06008D5A RID: 36186 RVA: 0x00135444 File Offset: 0x00133644
		public void ShowViewWithType(GuildDonateType type)
		{
			bool inGuild = XGuildDocument.InGuild;
			if (inGuild)
			{
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.DonateType = type;
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06008D5B RID: 36187 RVA: 0x00135488 File Offset: 0x00133688
		public uint GetCanDonateMaxNum()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskDonateNum");
			return (uint)(((long)@int <= (long)((ulong)this._dailyDonatedNum)) ? 0 : (@int - (int)this._dailyDonatedNum));
		}

		// Token: 0x06008D5C RID: 36188 RVA: 0x001354C0 File Offset: 0x001336C0
		private int SortHistory(GuildDonateRankInfo x, GuildDonateRankInfo y)
		{
			bool flag = x.totalCount != y.totalCount;
			int result;
			if (flag)
			{
				result = (int)(y.totalCount - x.totalCount);
			}
			else
			{
				result = (int)(y.lastTime - x.lastTime);
			}
			return result;
		}

		// Token: 0x06008D5D RID: 36189 RVA: 0x00135504 File Offset: 0x00133704
		private int SortToday(GuildDonateRankInfo x, GuildDonateRankInfo y)
		{
			bool flag = x.todayCount != y.todayCount;
			int result;
			if (flag)
			{
				result = (int)(y.todayCount - x.todayCount);
			}
			else
			{
				result = (int)(y.lastTime - x.lastTime);
			}
			return result;
		}

		// Token: 0x06008D5E RID: 36190 RVA: 0x00135548 File Offset: 0x00133748
		public int GetDonationListCount(GuildDonateType donateType)
		{
			int result;
			if (donateType != GuildDonateType.DailyDonate)
			{
				if (donateType != GuildDonateType.WeeklyDonate)
				{
					result = 0;
				}
				else
				{
					result = this._weeklyDonateItemList.Count;
				}
			}
			else
			{
				result = this._dailyDonateItemList.Count;
			}
			return result;
		}

		// Token: 0x06008D5F RID: 36191 RVA: 0x00135584 File Offset: 0x00133784
		public GuildDonateItemInfo GetDonationItemInfoWithTypeID(GuildDonateType donateType, uint id)
		{
			List<GuildDonateItemInfo> list = (donateType == GuildDonateType.DailyDonate) ? this._dailyDonateItemList : this._weeklyDonateItemList;
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].id == id;
				if (flag)
				{
					return list[i];
				}
			}
			return null;
		}

		// Token: 0x04002DD4 RID: 11732
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDonateDocument");

		// Token: 0x04002DD5 RID: 11733
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002DD6 RID: 11734
		private List<GuildDonateRankInfo> _todayRankList = new List<GuildDonateRankInfo>();

		// Token: 0x04002DD7 RID: 11735
		private List<GuildDonateItemInfo> _dailyDonateItemList = new List<GuildDonateItemInfo>();

		// Token: 0x04002DD8 RID: 11736
		private List<GuildDonateRankInfo> _rankList = new List<GuildDonateRankInfo>();

		// Token: 0x04002DD9 RID: 11737
		private List<GuildDonateItemInfo> _weeklyDonateItemList = new List<GuildDonateItemInfo>();

		// Token: 0x04002DDA RID: 11738
		private uint _dailyDonatedNum = 0U;
	}
}
