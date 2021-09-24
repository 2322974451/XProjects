using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFlowerRankDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFlowerRankDocument.uuID;
			}
		}

		public bool CanGetAward
		{
			get
			{
				return this._canGetAward;
			}
			set
			{
				this._canGetAward = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_FlowerRank, true);
				bool flag = this.View != null;
				if (flag)
				{
					this.View.RefreshRedPoint();
				}
			}
		}

		public bool CanGetActivityAward
		{
			get
			{
				return this._canGetActivityAward;
			}
			set
			{
				this._canGetActivityAward = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_FlowerRank, true);
				bool flag = this.View != null;
				if (flag)
				{
					this.View.RefreshRedPoint();
				}
			}
		}

		public XFlowerRankHandler View { get; set; }

		public XFlowerAwardListInfo AwardListInfo
		{
			get
			{
				return this._awardListInfo;
			}
		}

		public ShowFlowerPageRes FlowerPageData
		{
			get
			{
				return this._myFlowerPageData;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFlowerRankDocument.AsyncLoader.AddTask("Table/FlowerRankReward", XFlowerRankDocument._flowerRankRewardTable, false);
			XFlowerRankDocument.AsyncLoader.AddTask("Table/FlowerWeekRankReward", XFlowerRankDocument._flowerWeekRankRewardTable, false);
			XFlowerRankDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._todayRankList = new XFlowerRankNormalList();
			this._weekRankList = new XFlowerRankNormalList();
			this._yesterdayRankList = new XFlowerRankNormalList();
			this._historyRankList = new XFlowerRankNormalList();
			this._activityRankList = new XFlowerRankActivityList();
			this._awardListInfo = new XFlowerAwardListInfo();
			this._rankDic.Clear();
			this._rankDic.Add(XRankType.FlowerTodayRank, this._todayRankList);
			this._rankDic.Add(XRankType.FlowerYesterdayRank, this._yesterdayRankList);
			this._rankDic.Add(XRankType.FlowerHistoryRank, this._historyRankList);
			this._rankDic.Add(XRankType.FlowerWeekRank, this._weekRankList);
			this._rankDic.Add(XRankType.FlowerActivityRank, this._activityRankList);
		}

		public XBaseRankList GetRankList(XRankType type)
		{
			XBaseRankList xbaseRankList;
			bool flag = this._rankDic.TryGetValue(type, out xbaseRankList);
			XBaseRankList result;
			if (flag)
			{
				result = xbaseRankList;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void SelectItem(uint index, bool refresh = false)
		{
			this.currentSelectIndex = index;
			XBaseRankList rankList = this.GetRankList(this.currentSelectRankTab);
			bool flag = rankList != null;
			if (flag)
			{
				bool flag2 = (ulong)index < (ulong)((long)rankList.rankList.Count);
				if (flag2)
				{
					XBaseRankInfo xbaseRankInfo = rankList.rankList[(int)index];
					this.View.RefreshCharacterInfo(xbaseRankInfo, index);
					this.ReqUnitAppearance(xbaseRankInfo.id);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog(string.Format("index out of range. index = {0} while list count = {1}", index, rankList.rankList.Count), null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
			bool flag3 = this.View != null && this.View.IsVisible() && refresh;
			if (flag3)
			{
				this.View.RefreshRankContent();
			}
		}

		public void ReqUnitAppearance(ulong id)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = id;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 3U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 524495;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		public void OnGetUnitAppearance(GetUnitAppearanceRes oRes)
		{
			bool flag = oRes.UnitAppearance == null;
			if (!flag)
			{
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.UpdateCharacterInfo(oRes);
				}
			}
		}

		public void ReqRankList(XRankType type)
		{
			XBaseRankList rankList = this.GetRankList(type);
			bool flag = rankList != null;
			if (flag)
			{
				RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
				rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(XBaseRankList.GetKKSGType(type));
				rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = rankList.timeStamp;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Rank type not init: ", type.ToString(), null, null, null, null);
			}
		}

		public void OnGetRankList(ClientQueryRankListRes oRes)
		{
			XRankType xtype = XBaseRankList.GetXType((RankeType)oRes.RankType);
			bool flag = oRes.ErrorCode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XBaseRankList rankList = this.GetRankList(xtype);
				bool flag2 = rankList != null;
				if (flag2)
				{
					rankList.timeStamp = oRes.TimeStamp;
					XFlowerRankDocument.ProcessRankListData(oRes.RankList, rankList);
					XFlowerRankDocument.ProcessSelfRankData(oRes, rankList);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Rank type not inited: ", xtype.ToString(), null, null, null, null);
				}
			}
			bool flag3 = this.View != null && this.View.IsVisible();
			if (flag3)
			{
				this.View.RefreshRankWindow();
			}
		}

		public static void ProcessRankListData(RankList data, XBaseRankList rank)
		{
			int num = Math.Max(rank.rankList.Count, data.RankData.Count);
			for (int i = rank.rankList.Count; i < num; i++)
			{
				rank.rankList.Add(rank.CreateNewInfo());
			}
			bool flag = data.RankData.Count < rank.rankList.Count;
			if (flag)
			{
				rank.rankList.RemoveRange(data.RankData.Count, rank.rankList.Count - data.RankData.Count);
			}
			for (int j = 0; j < rank.rankList.Count; j++)
			{
				XBaseRankInfo xbaseRankInfo = rank.rankList[j];
				xbaseRankInfo.ProcessData(data.RankData[j]);
				xbaseRankInfo.rank = (uint)j;
			}
		}

		public static void ProcessSelfRankData(ClientQueryRankListRes oRes, XBaseRankList rank)
		{
			bool flag = oRes.RoleRankData != null;
			if (flag)
			{
				rank.myRankInfo = rank.CreateNewInfo();
				rank.myRankInfo.ProcessData(oRes.RoleRankData);
				rank.upperBound = oRes.RankAllCount;
				bool flag2 = oRes.RankList.RankData.Count > 0 && rank.myRankInfo.name == "";
				if (flag2)
				{
					rank.myRankInfo.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
					rank.myRankInfo.id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					rank.myRankInfo.rank = XFlowerRankDocument.INVALID_RANK;
				}
			}
			else
			{
				rank.myRankInfo = null;
			}
		}

		public void ReqAward()
		{
			RpcC2G_GetFlowerReward rpc = new RpcC2G_GetFlowerReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetAward(GetFlowerRewardArg oArg, GetFlowerRewardRes oRes)
		{
			bool flag = oRes.errorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(XStringDefineProxy.GetString(oRes.errorCode), null, null, null, null, null);
			}
			this.CanGetAward = false;
			this._awardListInfo.canGetAward = false;
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshAwardInfo();
			}
		}

		public void ReqAwardList()
		{
			RpcC2M_MSGetFlowerRewardList rpc = new RpcC2M_MSGetFlowerRewardList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetAwardList(NewGetFlowerRewardListArg oArg, NewGetFlowerRewardListRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this._awardListInfo.listCount = this.GetAwardCount();
				this._awardListInfo.canGetAward = oRes.canGetReward;
				this._awardListInfo.selfIndex = -1;
				this._awardList = oRes.briefList;
				for (int i = 0; i < oRes.briefList.Count; i++)
				{
					bool flag2 = oRes.briefList[i].roleID == XSingleton<XGame>.singleton.PlayerID;
					if (flag2)
					{
						this._awardListInfo.selfIndex = i;
					}
				}
			}
			bool flag3 = this.View != null && this.View.IsVisible();
			if (flag3)
			{
				this.View.RefreshAwardInfo();
			}
		}

		public int GetAwardCount()
		{
			FlowerRankRewardTable.RowData[] table = XFlowerRankDocument._flowerRankRewardTable.Table;
			int num = 0;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].reward[0, 0] != 0;
				if (flag)
				{
					num = i;
				}
			}
			FlowerRankRewardTable.RowData rowData = table[num];
			return rowData.rank[1];
		}

		public SeqListRef<int> GetAwardInfo(int index, out uint designationID, bool yesterday)
		{
			int num = index + 1;
			foreach (FlowerRankRewardTable.RowData rowData in XFlowerRankDocument._flowerRankRewardTable.Table)
			{
				bool flag = rowData.rank[0] <= num && rowData.rank[1] >= num;
				if (flag)
				{
					designationID = (yesterday ? rowData.yesterday : rowData.history);
					return rowData.reward;
				}
			}
			designationID = 0U;
			return default(SeqListRef<int>);
		}

		public int GetActivityAwardCount()
		{
			FlowerRankRewardTable.RowData[] table = XFlowerRankDocument._flowerRankRewardTable.Table;
			int num = 0;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].activity[0, 0] != 0;
				if (flag)
				{
					num = i;
				}
			}
			FlowerRankRewardTable.RowData rowData = table[num];
			return rowData.rank[1];
		}

		public SeqListRef<int> GetActivityAwardInfo(int index)
		{
			int num = index + 1;
			foreach (FlowerRankRewardTable.RowData rowData in XFlowerRankDocument._flowerRankRewardTable.Table)
			{
				bool flag = rowData.rank[0] <= num && rowData.rank[1] >= num;
				if (flag)
				{
					return rowData.activity;
				}
			}
			return default(SeqListRef<int>);
		}

		public void ReqMyFlowersInfo()
		{
			RpcC2M_ShowFlowerPageNew rpcC2M_ShowFlowerPageNew = new RpcC2M_ShowFlowerPageNew();
			rpcC2M_ShowFlowerPageNew.oArg.roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ShowFlowerPageNew);
		}

		public void OnGetMyFlowers(ShowFlowerPageRes oRes)
		{
			this._myFlowerPageData = oRes;
			this.View.RefreshMyFlowersPage();
		}

		public static uint GetFlowerCharmPoint(ulong flowerID)
		{
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("Flower2Charm", XGlobalConfig.AllSeparators);
			uint result = 0U;
			for (int i = 0; i < andSeparateValue.Length; i += 2)
			{
				bool flag = flowerID == ulong.Parse(andSeparateValue[i]);
				if (flag)
				{
					result = uint.Parse(andSeparateValue[i + 1]);
				}
			}
			return result;
		}

		public void CanGetAwardNtf()
		{
			this.CanGetAward = true;
		}

		public SeqListRef<int> GetWeekRankAward(int rank = 1)
		{
			for (int i = 0; i < XFlowerRankDocument._flowerWeekRankRewardTable.Table.Length; i++)
			{
				FlowerWeekRankReward.RowData rowData = XFlowerRankDocument._flowerWeekRankRewardTable.Table[i];
				bool flag = rank >= rowData.Rank[0] && rank <= rowData.Rank[1];
				if (flag)
				{
					return rowData.Reward;
				}
			}
			return default(SeqListRef<int>);
		}

		public void GetFlowerActivityReward()
		{
			RpcC2M_GetFlowerActivityReward rpc = new RpcC2M_GetFlowerActivityReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetFlowerActivityReward(GetFlowerActivityRewardRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this.CanGetActivityAward = false;
			}
		}

		public bool ShowRedPoint()
		{
			return this._canGetAward || this._canGetActivityAward;
		}

		public void RecordActivityPastTime(uint time, SeqListRef<uint> timestage)
		{
			this._lastTime = Time.realtimeSinceStartup;
			this._recordTime = time;
			bool flag = timestage.count >= 2;
			if (flag)
			{
				this._secondStageTimeStart = (timestage[0, 0] * 60U + timestage[0, 1]) * 60U;
			}
		}

		public bool IsActivityShowTime()
		{
			float num = Time.realtimeSinceStartup - this._lastTime;
			float num2 = this._recordTime + num;
			return num2 > this._secondStageTimeStart;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerRankDocument");

		public static readonly uint INVALID_RANK = uint.MaxValue;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static FlowerRankRewardTable _flowerRankRewardTable = new FlowerRankRewardTable();

		private static FlowerWeekRankReward _flowerWeekRankRewardTable = new FlowerWeekRankReward();

		private bool _canGetAward = false;

		private bool _canGetActivityAward = false;

		public XRankType currentSelectRankTab = XRankType.FlowerTodayRank;

		public uint currentSelectIndex = 0U;

		private XFlowerAwardListInfo _awardListInfo;

		private XBaseRankList _todayRankList;

		private XBaseRankList _yesterdayRankList;

		private XBaseRankList _historyRankList;

		private XBaseRankList _weekRankList;

		private XBaseRankList _activityRankList;

		private List<RoleBriefInfo> _awardList;

		private ShowFlowerPageRes _myFlowerPageData = null;

		private Dictionary<XRankType, XBaseRankList> _rankDic = new Dictionary<XRankType, XBaseRankList>(default(XFastEnumIntEqualityComparer<XRankType>));

		private float _lastTime = 0f;

		private uint _recordTime = 0U;

		private uint _secondStageTimeStart = 0U;
	}
}
