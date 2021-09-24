using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildDonateDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildDonateDocument.uuID;
			}
		}

		public static XGuildDonateDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XGuildDonateDocument.uuID) as XGuildDonateDocument;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDonateDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public void SendGetDonateBaseInfo()
		{
			RpcC2M_GetGuildDonateInfo rpc = new RpcC2M_GetGuildDonateInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int GetRankContentCount(DonateRankType type)
		{
			return (type == DonateRankType.TodayRank) ? this._todayRankList.Count : this._rankList.Count;
		}

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

		public uint GetCanDonateMaxNum()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskDonateNum");
			return (uint)(((long)@int <= (long)((ulong)this._dailyDonatedNum)) ? 0 : (@int - (int)this._dailyDonatedNum));
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDonateDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private List<GuildDonateRankInfo> _todayRankList = new List<GuildDonateRankInfo>();

		private List<GuildDonateItemInfo> _dailyDonateItemList = new List<GuildDonateItemInfo>();

		private List<GuildDonateRankInfo> _rankList = new List<GuildDonateRankInfo>();

		private List<GuildDonateItemInfo> _weeklyDonateItemList = new List<GuildDonateItemInfo>();

		private uint _dailyDonatedNum = 0U;
	}
}
