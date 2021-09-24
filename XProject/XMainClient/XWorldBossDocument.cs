using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWorldBossDocument : XDocComponent, IWorldBossBattleSource, IRankSource
	{

		public override uint ID
		{
			get
			{
				return XWorldBossDocument.uuID;
			}
		}

		public List<WorldBossDamageInfo> EndListDamage
		{
			get
			{
				return this._EndListDamage;
			}
		}

		public uint EncourageCount
		{
			get
			{
				return this._EncourageCount;
			}
		}

		public uint EncourgeGuildCount
		{
			get
			{
				return this._EncourgeGuildCount;
			}
		}

		public XWorldBossDamageRankList DamageRankList
		{
			get
			{
				return this._DamageRankList;
			}
		}

		public XWorldBossGuildRankList GuildRankList
		{
			get
			{
				return this._GuildRankList;
			}
		}

		public XWorldBossGuildRoleRankList GuildRoleRankList
		{
			get
			{
				return this._GuildRoleRankList;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XWorldBossDocument.AsyncLoader.AddTask("Table/WorldBossReward", XWorldBossDocument.WorldBossAwardTable, false);
			XWorldBossDocument.AsyncLoader.Execute(callback);
		}

		public uint GetWorldBossSceneID()
		{
			return (uint)XSingleton<XGlobalConfig>.singleton.GetInt("WorldBossSceneID");
		}

		public uint GetEncourageCount(int index)
		{
			bool flag = index == 0;
			uint result;
			if (flag)
			{
				result = this._EncourageCount;
			}
			else
			{
				bool flag2 = index == 1;
				if (flag2)
				{
					result = this._EncourgeGuildCount;
				}
				else
				{
					result = 0U;
				}
			}
			return result;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS;
			if (flag)
			{
				this.BattleHandler.RefreshAllEnacourage();
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool worldBossEnd = this._WorldBossEnd;
			if (worldBossEnd)
			{
				this._WorldBossEnd = false;
			}
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Rank_WorldBoss, true);
			}
		}

		public void ReqWorldBossState()
		{
			RpcC2M_GetWorldBossStateNew rpcC2M_GetWorldBossStateNew = new RpcC2M_GetWorldBossStateNew();
			rpcC2M_GetWorldBossStateNew.oArg.type = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetWorldBossStateNew);
		}

		public void OnGetWorldBossLeftState(GetWorldBossStateRes oRes)
		{
			bool flag = this.ActivityWorldBossView != null && this.ActivityWorldBossView.active;
			if (flag)
			{
				this.ActivityWorldBossView.SetLeftTime(oRes.TimeLeft);
			}
			bool flag2 = this.WorldBossDescView != null && this.WorldBossDescView.IsVisible();
			if (flag2)
			{
				this.WorldBossDescView.SetLeftTime(oRes.TimeLeft, oRes.BossHp);
				this.WorldBossDescView.ShowCurrentBoss(oRes.BossId);
			}
			this._BossHP = oRes.BossHp;
		}

		public void ReqEnterWorldBossScene()
		{
			bool flag = Time.realtimeSinceStartup - this.fCdTime < 1f;
			if (!flag)
			{
				this._WorldBossEnd = false;
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = this.GetWorldBossSceneID();
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
				this.fCdTime = Time.realtimeSinceStartup;
			}
		}

		public void ReqRankData(RankeType type, bool inFight)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(type);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 1U;
			rpcC2M_ClientQueryRankListNtf.oArg.sendPunishData = (inFight ? 1U : 0U);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void OnGetLatestRankInfo(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (!flag)
			{
				RankeType rankType = (RankeType)oRes.RankType;
				bool flag2 = rankType == RankeType.WorldBossGuildRank;
				if (flag2)
				{
					this._GuildRankList.timeStamp = oRes.TimeStamp;
					XRankDocument.ProcessRankListData(oRes.RankList, this._GuildRankList);
					XRankDocument.ProcessSelfRankData(oRes, this._GuildRankList);
				}
				else
				{
					bool flag3 = rankType == RankeType.WorldBossDamageRank;
					if (flag3)
					{
						this._DamageRankList.timeStamp = oRes.TimeStamp;
						XRankDocument.ProcessRankListData(oRes.RankList, this._DamageRankList);
						XRankDocument.ProcessSelfRankData(oRes, this._DamageRankList);
					}
					else
					{
						bool flag4 = rankType == RankeType.WorldBossGuildRoleRank;
						if (flag4)
						{
							this._GuildRoleRankList.timeStamp = oRes.TimeStamp;
							XRankDocument.ProcessRankListData(oRes.RankList, this._GuildRoleRankList);
							XRankDocument.ProcessSelfRankData(oRes, this._GuildRoleRankList);
						}
					}
				}
				bool flag5 = this.RankHandler != null && this.RankHandler.PanelObject != null && this.RankHandler.IsVisible();
				if (flag5)
				{
					this.RankHandler.RefreshPage();
				}
				bool flag6 = this.WorldBossDescView != null && this.WorldBossDescView.IsVisible();
				if (flag6)
				{
					this.WorldBossDescView.RefreshDamageRank();
					this.WorldBossDescView.SetMyRankFrame();
				}
				bool flag7 = rankType == RankeType.WorldBossGuildRank && this.WorldBossEndRankView != null && this.WorldBossEndRankView.IsVisible();
				if (flag7)
				{
					this.WorldBossEndRankView.RefreshGuildRank();
					this.WorldBossEndRankView.SetMyRankFrame();
				}
			}
		}

		public XBaseRankList GetRankList(RankeType type)
		{
			bool flag = type == RankeType.WorldBossGuildRank;
			XBaseRankList result;
			if (flag)
			{
				result = this._GuildRankList;
			}
			else
			{
				bool flag2 = type == RankeType.WorldBossGuildRoleRank;
				if (flag2)
				{
					result = this._GuildRoleRankList;
				}
				else
				{
					result = this._DamageRankList;
				}
			}
			return result;
		}

		public void ReqBattleInfo()
		{
			RpcC2M_GetWorldBossTimeLeft rpc = new RpcC2M_GetWorldBossTimeLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetBattleInfo(GetWorldBossTimeLeftRes oRes)
		{
			bool flag = this.BattleHandler != null && this.BattleHandler.active;
			if (flag)
			{
				this.BattleHandler.SetLeftTime(oRes.timeleft);
			}
			bool flag2 = this.RankHandler != null && this.RankHandler.active;
			if (flag2)
			{
				this.RankHandler.SetGuildMemberCount(oRes.guildrolecount);
			}
		}

		public void OnGetAttrCount(WorldBossAttrNtf ntf)
		{
			this._EncourageCount = ntf.count;
		}

		public void ReqEncourageTwo()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReqEncourageTwo", null, null, null, null, null);
			RpcC2M_WorldBossGuildAddAttr rpcC2M_WorldBossGuildAddAttr = new RpcC2M_WorldBossGuildAddAttr();
			rpcC2M_WorldBossGuildAddAttr.oArg.count = this._EncourgeGuildCount;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_WorldBossGuildAddAttr);
		}

		public void OnGetEncourageTwo(WorldBossGuildAddAttrArg arg, WorldBossGuildAddAttrRes oRes)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnGetEncourageTwo", null, null, null, null, null);
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		public void ReceiveGuildAttAttrSync(WorldBossGuildAddAttrSyncClient ntf)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReceiveGuildAttAttrSync:" + ntf.count.ToString(), null, null, null, null, null);
			this._EncourgeGuildCount = ntf.count;
			this.BattleHandler.RefreshEncourage(1);
		}

		public void ReqEncourage()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReqEncourage", null, null, null, null, null);
			RpcC2G_AddTempAttr rpcC2G_AddTempAttr = new RpcC2G_AddTempAttr();
			rpcC2G_AddTempAttr.oArg.type = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AddTempAttr);
		}

		public void OnGetEncourage(AddTempAttrRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this._EncourageCount = oRes.count;
				this.BattleHandler.RefreshEncourage(0);
			}
		}

		public List<WorldBossRewardTable.RowData> GetAwardList(uint roleLevel)
		{
			List<WorldBossRewardTable.RowData> list = new List<WorldBossRewardTable.RowData>();
			WorldBossRewardTable.RowData[] table = XWorldBossDocument.WorldBossAwardTable.Table;
			int num = 0;
			for (int i = 0; i < table.Length; i++)
			{
				WorldBossRewardTable.RowData rowData = table[i];
				bool flag = (ulong)roleLevel >= (ulong)((long)rowData.Level);
				if (flag)
				{
					num = i;
				}
			}
			for (int j = 0; j < table.Length; j++)
			{
				bool flag2 = table[j].Level == table[num].Level;
				if (flag2)
				{
					list.Add(table[j]);
				}
			}
			return list;
		}

		public WorldBossRewardTable.RowData GetDropReward(uint roleLevel)
		{
			WorldBossRewardTable.RowData[] table = XWorldBossDocument.WorldBossAwardTable.Table;
			int num = 0;
			for (int i = 0; i < table.Length; i++)
			{
				WorldBossRewardTable.RowData rowData = table[i];
				bool flag = (ulong)roleLevel >= (ulong)((long)rowData.Level);
				if (flag)
				{
					num = i;
				}
			}
			for (int j = 0; j < table.Length; j++)
			{
				bool flag2 = table[j].Level == table[num].Level;
				if (flag2)
				{
					return table[j];
				}
			}
			return null;
		}

		public void OnWorldBossStateNtf(WorldBossStateNtf stateInfo)
		{
			bool flag = stateInfo.state == WorldBossState.WorldBoss_WaitEnd;
			if (flag)
			{
				this._WorldBossEnd = true;
				DlgBase<XWorldBossResultView, GuildDragonChallengeResultBehaviour>.singleton.ShowResult(stateInfo.iswin);
			}
		}

		public void ReqQutiScene()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		public void GetWorldBossTime(ref int startTime, ref int endTime)
		{
			XActivityDocument doc = XActivityDocument.Doc;
			for (int i = 0; i < doc.MulActivityTable.Table.Length; i++)
			{
				bool flag = doc.MulActivityTable.Table[i].SystemID == XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Activity_WorldBoss);
				if (flag)
				{
					SeqListRef<uint> openDayTime = doc.MulActivityTable.Table[i].OpenDayTime;
					bool flag2 = openDayTime.Count > 0;
					if (flag2)
					{
						startTime = (int)openDayTime[0, 0];
						endTime = (int)openDayTime[0, 1];
					}
				}
			}
		}

		public void ReqWorldBossEnd()
		{
			RpcC2M_WorldBossEnd rpc = new RpcC2M_WorldBossEnd();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnWorldBossEnd(WorldBossEndArg oArg, WorldBossEndRes oRes)
		{
			this._EndListDamage = oRes.damages;
			bool flag = this.WorldBossEndRankView != null && this.WorldBossEndRankView.IsVisible();
			if (flag)
			{
				this.WorldBossEndRankView.RefreshDamageRank();
				this.WorldBossEndRankView.SetMyRankFrame(oRes.selfdamage);
			}
		}

		public void LeaveSceneCountDown(uint time)
		{
			bool flag = this.BattleHandler != null && this.BattleHandler.IsVisible();
			if (flag)
			{
				this.BattleHandler.OnLeaveSceneCountDown(time);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WorldBossDocument");

		public ActivityWorldBossHandler ActivityWorldBossView;

		public XWorldBossDamageRankHandler RankHandler;

		public BattleWorldBossHandler BattleHandler;

		public XWorldBossView WorldBossDescView;

		public XWorldBossResultView WorldBossResultView;

		public XWorldBossEndRankView WorldBossEndRankView;

		private uint _BossHP;

		private bool _WorldBossEnd = false;

		private List<WorldBossDamageInfo> _EndListDamage = new List<WorldBossDamageInfo>();

		private uint _EncourageCount = 0U;

		private uint _EncourgeGuildCount = 0U;

		private XWorldBossDamageRankList _DamageRankList = new XWorldBossDamageRankList();

		private XWorldBossGuildRankList _GuildRankList = new XWorldBossGuildRankList();

		private XWorldBossGuildRoleRankList _GuildRoleRankList = new XWorldBossGuildRoleRankList();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static WorldBossRewardTable WorldBossAwardTable = new WorldBossRewardTable();

		public bool MainInterfaceState = false;

		private float fCdTime = 0f;
	}
}
