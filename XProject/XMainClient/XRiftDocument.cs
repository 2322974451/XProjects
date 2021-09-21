using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200096A RID: 2410
	[Hotfix]
	internal class XRiftDocument : XDocComponent
	{
		// Token: 0x17002C5C RID: 11356
		// (get) Token: 0x06009130 RID: 37168 RVA: 0x0014C148 File Offset: 0x0014A348
		public override uint ID
		{
			get
			{
				return XRiftDocument.uuID;
			}
		}

		// Token: 0x06009131 RID: 37169 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x17002C5D RID: 11357
		// (get) Token: 0x06009132 RID: 37170 RVA: 0x0014C160 File Offset: 0x0014A360
		public List<RankRewardStatus> RankRewardList
		{
			get
			{
				return this._rankRewardList;
			}
		}

		// Token: 0x17002C5E RID: 11358
		// (get) Token: 0x06009133 RID: 37171 RVA: 0x0014C178 File Offset: 0x0014A378
		public List<PointRewardStatus> WeekFirstPassList
		{
			get
			{
				return this._firstpassList;
			}
		}

		// Token: 0x17002C5F RID: 11359
		// (get) Token: 0x06009134 RID: 37172 RVA: 0x0014C190 File Offset: 0x0014A390
		public List<PointRewardStatus> WelfareList
		{
			get
			{
				return this._welfareList;
			}
		}

		// Token: 0x17002C60 RID: 11360
		// (get) Token: 0x06009135 RID: 37173 RVA: 0x0014C1A8 File Offset: 0x0014A3A8
		public Rift.RowData currRiftRow
		{
			get
			{
				return this.GetRiftData(this.currFloor, this.currRift);
			}
		}

		// Token: 0x06009136 RID: 37174 RVA: 0x0014C1CC File Offset: 0x0014A3CC
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

		// Token: 0x06009137 RID: 37175 RVA: 0x0014C240 File Offset: 0x0014A440
		public static void Execute(OnLoadedCallback callback = null)
		{
			XRiftDocument.AsyncLoader.AddTask("Table/Rift", XRiftDocument.m_tableRift, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftType", XRiftDocument.m_tableRiftType, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftRankReward", XRiftDocument.m_tableRiftRewd, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftWelfareReward", XRiftDocument.m_tableRiftWelfare, false);
			XRiftDocument.AsyncLoader.AddTask("Table/RiftBuffSuitMonsterType", XRiftDocument.m_tabRiftSuit, false);
			XRiftDocument.AsyncLoader.Execute(null);
		}

		// Token: 0x06009138 RID: 37176 RVA: 0x0014C2C8 File Offset: 0x0014A4C8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009139 RID: 37177 RVA: 0x0014C2EC File Offset: 0x0014A4EC
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.ReculRankList();
			return true;
		}

		// Token: 0x0600913A RID: 37178 RVA: 0x0014C308 File Offset: 0x0014A508
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

		// Token: 0x0600913B RID: 37179 RVA: 0x0014C354 File Offset: 0x0014A554
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

		// Token: 0x0600913C RID: 37180 RVA: 0x0014C3AC File Offset: 0x0014A5AC
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

		// Token: 0x0600913D RID: 37181 RVA: 0x0014C430 File Offset: 0x0014A630
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

		// Token: 0x0600913E RID: 37182 RVA: 0x0014C52C File Offset: 0x0014A72C
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

		// Token: 0x0600913F RID: 37183 RVA: 0x0014C574 File Offset: 0x0014A774
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

		// Token: 0x06009140 RID: 37184 RVA: 0x0014C618 File Offset: 0x0014A818
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

		// Token: 0x06009141 RID: 37185 RVA: 0x0014C6C0 File Offset: 0x0014A8C0
		public void ReqMyRiftInfo()
		{
			RpcC2G_GetMyRiftInfo rpc = new RpcC2G_GetMyRiftInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009142 RID: 37186 RVA: 0x0014C6E0 File Offset: 0x0014A8E0
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

		// Token: 0x06009143 RID: 37187 RVA: 0x0014C810 File Offset: 0x0014AA10
		public void ReqGuildRank()
		{
			RpcC2M_GetRiftGuildRank rpc = new RpcC2M_GetRiftGuildRank();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009144 RID: 37188 RVA: 0x0014C830 File Offset: 0x0014AA30
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

		// Token: 0x06009145 RID: 37189 RVA: 0x0014C8E4 File Offset: 0x0014AAE4
		public void ReqRankSelf()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.onlySelfData = true;
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.RiftRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009146 RID: 37190 RVA: 0x0014C924 File Offset: 0x0014AB24
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

		// Token: 0x06009147 RID: 37191 RVA: 0x0014C950 File Offset: 0x0014AB50
		public void ReqFirstPassRwd(RiftFirstPassOpType type, uint floor)
		{
			RpcC2G_RiftFirstPassReward rpcC2G_RiftFirstPassReward = new RpcC2G_RiftFirstPassReward();
			rpcC2G_RiftFirstPassReward.oArg.opType = type;
			rpcC2G_RiftFirstPassReward.oArg.floor = floor;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_RiftFirstPassReward);
		}

		// Token: 0x06009148 RID: 37192 RVA: 0x0014C98C File Offset: 0x0014AB8C
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

		// Token: 0x06009149 RID: 37193 RVA: 0x0014CAA4 File Offset: 0x0014ACA4
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

		// Token: 0x0600914A RID: 37194 RVA: 0x0014CB50 File Offset: 0x0014AD50
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

		// Token: 0x0600914B RID: 37195 RVA: 0x0014CBB0 File Offset: 0x0014ADB0
		public void OnRiftSceneInfo(RiftSceneInfoNtfData data)
		{
			this.scene_rift_data = data;
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.Refresh((float)data.floor, data.buffIDs);
			}
		}

		// Token: 0x0600914C RID: 37196 RVA: 0x0014CC08 File Offset: 0x0014AE08
		public void ReqSceneTime()
		{
			RpcC2G_QuerySceneTime rpc = new RpcC2G_QuerySceneTime();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600914D RID: 37197 RVA: 0x0014CC28 File Offset: 0x0014AE28
		public void ResSceneTime(int time)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_riftHandler.s_time = (uint)time;
			}
		}

		// Token: 0x04003022 RID: 12322
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MysterioursDocument");

		// Token: 0x04003023 RID: 12323
		public int currRift = 1;

		// Token: 0x04003024 RID: 12324
		public int currFloor = 1;

		// Token: 0x04003025 RID: 12325
		public uint sceneid = 1U;

		// Token: 0x04003026 RID: 12326
		public bool hasNewFirstPass = false;

		// Token: 0x04003027 RID: 12327
		public List<MapIntItem> items;

		// Token: 0x04003028 RID: 12328
		private int max_floor = 0;

		// Token: 0x04003029 RID: 12329
		public uint self_rank = 0U;

		// Token: 0x0400302A RID: 12330
		public bool all_finish = false;

		// Token: 0x0400302B RID: 12331
		public bool stop_timer = false;

		// Token: 0x0400302C RID: 12332
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400302D RID: 12333
		private static Rift m_tableRift = new Rift();

		// Token: 0x0400302E RID: 12334
		private static RiftType m_tableRiftType = new RiftType();

		// Token: 0x0400302F RID: 12335
		private static RiftRankReward m_tableRiftRewd = new RiftRankReward();

		// Token: 0x04003030 RID: 12336
		private static RiftWelfareReward m_tableRiftWelfare = new RiftWelfareReward();

		// Token: 0x04003031 RID: 12337
		private static RiftBuffSuitMonsterType m_tabRiftSuit = new RiftBuffSuitMonsterType();

		// Token: 0x04003032 RID: 12338
		private List<RankRewardStatus> _rankRewardList = new List<RankRewardStatus>();

		// Token: 0x04003033 RID: 12339
		private List<PointRewardStatus> _firstpassList = new List<PointRewardStatus>();

		// Token: 0x04003034 RID: 12340
		private List<PointRewardStatus> _welfareList = new List<PointRewardStatus>();

		// Token: 0x04003035 RID: 12341
		private float lastShowInfoTime;

		// Token: 0x04003036 RID: 12342
		public List<int> buffIDS = new List<int>();

		// Token: 0x04003037 RID: 12343
		public List<int> buffLevels = new List<int>();

		// Token: 0x04003038 RID: 12344
		public int currGuidRiftID;

		// Token: 0x04003039 RID: 12345
		public List<int> guildBuffIDs = new List<int>();

		// Token: 0x0400303A RID: 12346
		public List<int> guildBuffLevels = new List<int>();

		// Token: 0x0400303B RID: 12347
		public List<RiftGuildRankInfo> guildInfos;

		// Token: 0x0400303C RID: 12348
		public RiftSceneInfoNtfData scene_rift_data;
	}
}
