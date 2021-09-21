using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200098E RID: 2446
	internal class XFlowerRankDocument : XDocComponent
	{
		// Token: 0x17002CB2 RID: 11442
		// (get) Token: 0x06009302 RID: 37634 RVA: 0x00156D4C File Offset: 0x00154F4C
		public override uint ID
		{
			get
			{
				return XFlowerRankDocument.uuID;
			}
		}

		// Token: 0x17002CB3 RID: 11443
		// (get) Token: 0x06009303 RID: 37635 RVA: 0x00156D64 File Offset: 0x00154F64
		// (set) Token: 0x06009304 RID: 37636 RVA: 0x00156D7C File Offset: 0x00154F7C
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

		// Token: 0x17002CB4 RID: 11444
		// (get) Token: 0x06009305 RID: 37637 RVA: 0x00156DBC File Offset: 0x00154FBC
		// (set) Token: 0x06009306 RID: 37638 RVA: 0x00156DD4 File Offset: 0x00154FD4
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

		// Token: 0x17002CB5 RID: 11445
		// (get) Token: 0x06009307 RID: 37639 RVA: 0x00156E12 File Offset: 0x00155012
		// (set) Token: 0x06009308 RID: 37640 RVA: 0x00156E1A File Offset: 0x0015501A
		public XFlowerRankHandler View { get; set; }

		// Token: 0x17002CB6 RID: 11446
		// (get) Token: 0x06009309 RID: 37641 RVA: 0x00156E24 File Offset: 0x00155024
		public XFlowerAwardListInfo AwardListInfo
		{
			get
			{
				return this._awardListInfo;
			}
		}

		// Token: 0x17002CB7 RID: 11447
		// (get) Token: 0x0600930A RID: 37642 RVA: 0x00156E3C File Offset: 0x0015503C
		public ShowFlowerPageRes FlowerPageData
		{
			get
			{
				return this._myFlowerPageData;
			}
		}

		// Token: 0x0600930B RID: 37643 RVA: 0x00156E54 File Offset: 0x00155054
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFlowerRankDocument.AsyncLoader.AddTask("Table/FlowerRankReward", XFlowerRankDocument._flowerRankRewardTable, false);
			XFlowerRankDocument.AsyncLoader.AddTask("Table/FlowerWeekRankReward", XFlowerRankDocument._flowerWeekRankRewardTable, false);
			XFlowerRankDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600930C RID: 37644 RVA: 0x00156E90 File Offset: 0x00155090
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

		// Token: 0x0600930D RID: 37645 RVA: 0x00156F58 File Offset: 0x00155158
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

		// Token: 0x0600930E RID: 37646 RVA: 0x00156F84 File Offset: 0x00155184
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

		// Token: 0x0600930F RID: 37647 RVA: 0x00157050 File Offset: 0x00155250
		public void ReqUnitAppearance(ulong id)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = id;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 3U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 524495;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		// Token: 0x06009310 RID: 37648 RVA: 0x0015709C File Offset: 0x0015529C
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

		// Token: 0x06009311 RID: 37649 RVA: 0x001570E4 File Offset: 0x001552E4
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

		// Token: 0x06009312 RID: 37650 RVA: 0x00157164 File Offset: 0x00155364
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

		// Token: 0x06009313 RID: 37651 RVA: 0x00157210 File Offset: 0x00155410
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

		// Token: 0x06009314 RID: 37652 RVA: 0x00157304 File Offset: 0x00155504
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

		// Token: 0x06009315 RID: 37653 RVA: 0x001573D0 File Offset: 0x001555D0
		public void ReqAward()
		{
			RpcC2G_GetFlowerReward rpc = new RpcC2G_GetFlowerReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009316 RID: 37654 RVA: 0x001573F0 File Offset: 0x001555F0
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

		// Token: 0x06009317 RID: 37655 RVA: 0x00157464 File Offset: 0x00155664
		public void ReqAwardList()
		{
			RpcC2M_MSGetFlowerRewardList rpc = new RpcC2M_MSGetFlowerRewardList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009318 RID: 37656 RVA: 0x00157484 File Offset: 0x00155684
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

		// Token: 0x06009319 RID: 37657 RVA: 0x00157554 File Offset: 0x00155754
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

		// Token: 0x0600931A RID: 37658 RVA: 0x001575B8 File Offset: 0x001557B8
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

		// Token: 0x0600931B RID: 37659 RVA: 0x0015764C File Offset: 0x0015584C
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

		// Token: 0x0600931C RID: 37660 RVA: 0x001576B0 File Offset: 0x001558B0
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

		// Token: 0x0600931D RID: 37661 RVA: 0x0015772C File Offset: 0x0015592C
		public void ReqMyFlowersInfo()
		{
			RpcC2M_ShowFlowerPageNew rpcC2M_ShowFlowerPageNew = new RpcC2M_ShowFlowerPageNew();
			rpcC2M_ShowFlowerPageNew.oArg.roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ShowFlowerPageNew);
		}

		// Token: 0x0600931E RID: 37662 RVA: 0x00157767 File Offset: 0x00155967
		public void OnGetMyFlowers(ShowFlowerPageRes oRes)
		{
			this._myFlowerPageData = oRes;
			this.View.RefreshMyFlowersPage();
		}

		// Token: 0x0600931F RID: 37663 RVA: 0x00157780 File Offset: 0x00155980
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

		// Token: 0x06009320 RID: 37664 RVA: 0x001577DE File Offset: 0x001559DE
		public void CanGetAwardNtf()
		{
			this.CanGetAward = true;
		}

		// Token: 0x06009321 RID: 37665 RVA: 0x001577EC File Offset: 0x001559EC
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

		// Token: 0x06009322 RID: 37666 RVA: 0x00157868 File Offset: 0x00155A68
		public void GetFlowerActivityReward()
		{
			RpcC2M_GetFlowerActivityReward rpc = new RpcC2M_GetFlowerActivityReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009323 RID: 37667 RVA: 0x00157888 File Offset: 0x00155A88
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

		// Token: 0x06009324 RID: 37668 RVA: 0x001578C4 File Offset: 0x00155AC4
		public bool ShowRedPoint()
		{
			return this._canGetAward || this._canGetActivityAward;
		}

		// Token: 0x06009325 RID: 37669 RVA: 0x001578E8 File Offset: 0x00155AE8
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

		// Token: 0x06009326 RID: 37670 RVA: 0x0015793C File Offset: 0x00155B3C
		public bool IsActivityShowTime()
		{
			float num = Time.realtimeSinceStartup - this._lastTime;
			float num2 = this._recordTime + num;
			return num2 > this._secondStageTimeStart;
		}

		// Token: 0x06009327 RID: 37671 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400315F RID: 12639
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerRankDocument");

		// Token: 0x04003160 RID: 12640
		public static readonly uint INVALID_RANK = uint.MaxValue;

		// Token: 0x04003161 RID: 12641
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003162 RID: 12642
		private static FlowerRankRewardTable _flowerRankRewardTable = new FlowerRankRewardTable();

		// Token: 0x04003163 RID: 12643
		private static FlowerWeekRankReward _flowerWeekRankRewardTable = new FlowerWeekRankReward();

		// Token: 0x04003164 RID: 12644
		private bool _canGetAward = false;

		// Token: 0x04003165 RID: 12645
		private bool _canGetActivityAward = false;

		// Token: 0x04003167 RID: 12647
		public XRankType currentSelectRankTab = XRankType.FlowerTodayRank;

		// Token: 0x04003168 RID: 12648
		public uint currentSelectIndex = 0U;

		// Token: 0x04003169 RID: 12649
		private XFlowerAwardListInfo _awardListInfo;

		// Token: 0x0400316A RID: 12650
		private XBaseRankList _todayRankList;

		// Token: 0x0400316B RID: 12651
		private XBaseRankList _yesterdayRankList;

		// Token: 0x0400316C RID: 12652
		private XBaseRankList _historyRankList;

		// Token: 0x0400316D RID: 12653
		private XBaseRankList _weekRankList;

		// Token: 0x0400316E RID: 12654
		private XBaseRankList _activityRankList;

		// Token: 0x0400316F RID: 12655
		private List<RoleBriefInfo> _awardList;

		// Token: 0x04003170 RID: 12656
		private ShowFlowerPageRes _myFlowerPageData = null;

		// Token: 0x04003171 RID: 12657
		private Dictionary<XRankType, XBaseRankList> _rankDic = new Dictionary<XRankType, XBaseRankList>(default(XFastEnumIntEqualityComparer<XRankType>));

		// Token: 0x04003172 RID: 12658
		private float _lastTime = 0f;

		// Token: 0x04003173 RID: 12659
		private uint _recordTime = 0U;

		// Token: 0x04003174 RID: 12660
		private uint _secondStageTimeStart = 0U;
	}
}
