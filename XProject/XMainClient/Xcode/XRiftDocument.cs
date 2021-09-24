using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	[Hotfix]
	internal class XRiftDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRiftDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public List<RankRewardStatus> RankRewardList
		{
			get
			{
				return this._rankRewardList;
			}
		}

		public List<PointRewardStatus> WeekFirstPassList
		{
			get
			{
				return this._firstpassList;
			}
		}

		public List<PointRewardStatus> WelfareList
		{
			get
			{
				return this._welfareList;
			}
		}

		public Rift.RowData currRiftRow
		{
			get
			{
				return this.GetRiftData(this.currFloor, this.currRift);
			}
		}

		public Rift.RowData GetRiftData(int floor, int rift)
		{
			int i = 0;
			int num = XRiftDocument.m_tableRift.Table.Length;
			while (i < num)
			{
				bool flag = XRiftDocument.m_tableRift.Table[i].floor == floor && XRiftDocument.m_tableRift.Table[i].id == rift;
				if (flag)
				{
					return XRiftDocument.m_tableRift.Table[i];
				}
				i++;
			}
			return null;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XRiftDocument.AsyncLoader.AddTask("Table/Rift", XRiftDocument.m_tableRift, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftType", XRiftDocument.m_tableRiftType, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftRankReward", XRiftDocument.m_tableRiftRewd, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftWelfareReward", XRiftDocument.m_tableRiftWelfare, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftBuffSuitMonsterType", XRiftDocument.m_tabRiftSuit, false);
			XRiftDocument.AsyncLoader.Execute(null);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.ReculRankList();
			return true;
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = this.max_floor == 0;
			if (flag)
			{
				int num = XRiftDocument.m_tableRift.Table.Length;
				this.max_floor = XRiftDocument.m_tableRift.Table[num - 1].floor;
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RIFT;
			if (flag)
			{
				bool flag2 = Time.time > this.lastShowInfoTime + 10f;
				if (flag2)
				{
					this.ReqSceneTime();
					this.lastShowInfoTime = Time.time;
				}
			}
		}

		public RiftBuffSuitMonsterType.RowData GetBuffSuitRow(uint buff, int level)
		{
			int i = 0;
			int num = XRiftDocument.m_tabRiftSuit.Table.Length;
			while (i < num)
			{
				bool flag = XRiftDocument.m_tabRiftSuit.Table[i].buff[0] == buff && (ulong)XRiftDocument.m_tabRiftSuit.Table[i].buff[1] == (ulong)((long)level);
				if (flag)
				{
					return XRiftDocument.m_tabRiftSuit.Table[i];
				}
				i++;
			}
			return null;
		}

		public void ReculRankList()
		{
			this._rankRewardList.Clear();
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData != null;
			if (flag)
			{
				for (int i = 0; i < XRiftDocument.m_tableRiftRewd.Table.Length; i++)
				{
					RiftRankReward.RowData rowData = XRiftDocument.m_tableRiftRewd.Table[i];
					bool flag2 = rowData.levelrange == this.currRift;
					if (flag2)
					{
						RankRewardStatus rankRewardStatus = new RankRewardStatus();
						rankRewardStatus.isRange = (rowData.rank[0] != rowData.rank[1]);
						bool flag3 = !rankRewardStatus.isRange;
						if (flag3)
						{
							rankRewardStatus.rank = rowData.rank[0];
						}
						else
						{
							rankRewardStatus.rank = rowData.rank[1];
						}
						rankRewardStatus.reward = rowData.reward;
						this._rankRewardList.Add(rankRewardStatus);
					}
				}
			}
		}

		public int RewardCompare(PointRewardStatus reward1, PointRewardStatus reward2)
		{
			int status = (int)reward1.status;
			int status2 = (int)reward2.status;
			bool flag = status != status2;
			int result;
			if (flag)
			{
				result = status2.CompareTo(status);
			}
			else
			{
				result = (int)(reward1.point - reward2.point);
			}
			return result;
		}

		public void CulFirstPass()
		{
			this._firstpassList.Clear();
			int i = 0;
			int num = XRiftDocument.m_tableRift.Table.Length;
			while (i < num)
			{
				bool flag = XRiftDocument.m_tableRift.Table[i].id == this.currRift;
				if (flag)
				{
					PointRewardStatus pointRewardStatus = new PointRewardStatus();
					pointRewardStatus.reward = XRiftDocument.m_tableRift.Table[i].weekfirstpass;
					pointRewardStatus.point = (uint)XRiftDocument.m_tableRift.Table[i].floor;
					pointRewardStatus.status = 1U;
					this._firstpassList.Add(pointRewardStatus);
				}
				i++;
			}
		}

		public void CulWelfare()
		{
			this._welfareList.Clear();
			int i = 0;
			int num = XRiftDocument.m_tableRiftWelfare.Table.Length;
			while (i < num)
			{
				bool flag = XRiftDocument.m_tableRiftWelfare.Table[i].levelrange == this.currRift;
				if (flag)
				{
					PointRewardStatus pointRewardStatus = new PointRewardStatus();
					pointRewardStatus.reward = XRiftDocument.m_tableRiftWelfare.Table[i].reward;
					pointRewardStatus.point = (uint)XRiftDocument.m_tableRiftWelfare.Table[i].floor[0];
					pointRewardStatus.status = 1U;
					this._welfareList.Add(pointRewardStatus);
				}
				i++;
			}
		}

		public void ReqMyRiftInfo()
		{
			RpcC2G_GetMyRiftInfo rpc = new RpcC2G_GetMyRiftInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ResRiftInfo(GetMyRiftInfoRes oRes)
		{
			this.buffIDS.Clear();
			this.buffLevels.Clear();
			for (int i = 0; i < oRes.buffIDs.Count; i++)
			{
				this.buffIDS.Add(oRes.buffIDs[i].buffID);
				this.buffLevels.Add(oRes.buffIDs[i].buffLevel);
			}
			this.currFloor = oRes.curRiftFloor;
			this.currRift = oRes.curRiftID;
			this.items = oRes.gotItemsCount;
			this.sceneid = (uint)oRes.curSceneID;
			bool flag = this.currFloor < -1 || this.currRift < 0 || this.sceneid <= 0U;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_DATA_ERROR"), "fece00");
			}
			else
			{
				bool flag2 = this.currFloor == -1;
				if (flag2)
				{
					this.currFloor = this.max_floor;
					this.all_finish = true;
				}
			}
			bool flag3 = DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.Refresh();
			}
		}

		public void ReqGuildRank()
		{
			RpcC2M_GetRiftGuildRank rpc = new RpcC2M_GetRiftGuildRank();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ResGuildRank(GetRiftGuildRankRes oRes)
		{
			this.currGuidRiftID = oRes.curRiftID;
			this.guildInfos = oRes.infos;
			this.guildBuffLevels.Clear();
			this.guildBuffIDs.Clear();
			int i = 0;
			int count = oRes.buffIDs.Count;
			while (i < count)
			{
				this.guildBuffIDs.Add(oRes.buffIDs[i].buffID);
				this.guildBuffLevels.Add(oRes.buffIDs[i].buffLevel);
				i++;
			}
			bool flag = DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.OpenGuildInfoHanlder();
			}
		}

		public void ReqRankSelf()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.onlySelfData = true;
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.RiftRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ResRank(int rank)
		{
			bool flag = rank >= 0;
			if (flag)
			{
				this.self_rank = (uint)(rank + 1);
			}
			else
			{
				this.self_rank = 0U;
			}
		}

		public void ReqFirstPassRwd(RiftFirstPassOpType type, uint floor)
		{
			RpcC2G_RiftFirstPassReward rpcC2G_RiftFirstPassReward = new RpcC2G_RiftFirstPassReward();
			rpcC2G_RiftFirstPassReward.oArg.opType = type;
			rpcC2G_RiftFirstPassReward.oArg.floor = floor;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_RiftFirstPassReward);
		}

		public void ResFisrtPassRwd(RiftFirstPassOpType type, RiftFirstPassRewardRes oRes)
		{
			this.hasNewFirstPass = false;
			int i = 0;
			int count = this._firstpassList.Count;
			while (i < count)
			{
				bool flag = oRes.floorInfos.Count > 0;
				if (flag)
				{
					RiftFloorStatus floorStatus = this.GetFloorStatus(this._firstpassList[i].point, oRes);
					bool flag2 = floorStatus == RiftFloorStatus.RiftFloor_CanGetReward;
					if (flag2)
					{
						this._firstpassList[i].status = 3U;
						this.hasNewFirstPass = true;
					}
					else
					{
						bool flag3 = floorStatus == RiftFloorStatus.RiftFloor_GotReward;
						if (flag3)
						{
							this._firstpassList[i].status = 0U;
						}
						else
						{
							bool flag4 = floorStatus == RiftFloorStatus.RiftFloor_NotPass;
							if (flag4)
							{
								this._firstpassList[i].status = 1U;
							}
							else
							{
								bool flag5 = floorStatus == RiftFloorStatus.RiftFloor_Complete;
								if (flag5)
								{
									this._firstpassList[i].status = 2U;
								}
							}
						}
					}
				}
				i++;
			}
			bool flag6 = DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.IsVisible();
			if (flag6)
			{
				DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.RefreshFirstPassRift();
				DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.RefreshRed();
			}
		}

		public void SetFirstPassClaim(int floor)
		{
			int i = 0;
			int count = this._firstpassList.Count;
			while (i < count)
			{
				bool flag = (ulong)this._firstpassList[i].point == (ulong)((long)floor);
				if (flag)
				{
					this._firstpassList[i].status = 0U;
					break;
				}
				i++;
			}
			bool flag2 = false;
			int j = 0;
			int count2 = this._firstpassList.Count;
			while (j < count2)
			{
				bool flag3 = this._firstpassList[j].status == 3U;
				if (flag3)
				{
					flag2 = true;
					break;
				}
				j++;
			}
			this.hasNewFirstPass = flag2;
		}

		private RiftFloorStatus GetFloorStatus(uint floor, RiftFirstPassRewardRes oRes)
		{
			List<RiftEachFloorInfo> floorInfos = oRes.floorInfos;
			int i = 0;
			int count = floorInfos.Count;
			while (i < count)
			{
				bool flag = (long)(floorInfos[i].floor + 1) == (long)((ulong)floor);
				if (flag)
				{
					return floorInfos[i].status;
				}
				i++;
			}
			return (RiftFloorStatus)0;
		}

		public void OnRiftSceneInfo(RiftSceneInfoNtfData data)
		{
			this.scene_rift_data = data;
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.Refresh((float)data.floor, data.buffIDs);
			}
		}

		public void ReqSceneTime()
		{
			RpcC2G_QuerySceneTime rpc = new RpcC2G_QuerySceneTime();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ResSceneTime(int time)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.s_time = (uint)time;
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MysterioursDocument");

		public int currRift = 1;

		public int currFloor = 1;

		public uint sceneid = 1U;

		public bool hasNewFirstPass = false;

		public List<MapIntItem> items;

		private int max_floor = 0;

		public uint self_rank = 0U;

		public bool all_finish = false;

		public bool stop_timer = false;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static Rift m_tableRift = new Rift();

		private static RiftType m_tableRiftType = new RiftType();

		private static RiftRankReward m_tableRiftRewd = new RiftRankReward();

		private static RiftWelfareReward m_tableRiftWelfare = new RiftWelfareReward();

		private static RiftBuffSuitMonsterType m_tabRiftSuit = new RiftBuffSuitMonsterType();

		private List<RankRewardStatus> _rankRewardList = new List<RankRewardStatus>();

		private List<PointRewardStatus> _firstpassList = new List<PointRewardStatus>();

		private List<PointRewardStatus> _welfareList = new List<PointRewardStatus>();

		private float lastShowInfoTime;

		public List<int> buffIDS = new List<int>();

		public List<int> buffLevels = new List<int>();

		public int currGuidRiftID;

		public List<int> guildBuffIDs = new List<int>();

		public List<int> guildBuffLevels = new List<int>();

		public List<RiftGuildRankInfo> guildInfos;

		public RiftSceneInfoNtfData scene_rift_data;
	}
}
