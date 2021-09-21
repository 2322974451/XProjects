using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A6E RID: 2670
	internal class XWorldBossDocument : XDocComponent, IWorldBossBattleSource, IRankSource
	{
		// Token: 0x17002F55 RID: 12117
		// (get) Token: 0x0600A234 RID: 41524 RVA: 0x001B99CC File Offset: 0x001B7BCC
		public override uint ID
		{
			get
			{
				return XWorldBossDocument.uuID;
			}
		}

		// Token: 0x17002F56 RID: 12118
		// (get) Token: 0x0600A235 RID: 41525 RVA: 0x001B99E4 File Offset: 0x001B7BE4
		public List<WorldBossDamageInfo> EndListDamage
		{
			get
			{
				return this._EndListDamage;
			}
		}

		// Token: 0x17002F57 RID: 12119
		// (get) Token: 0x0600A236 RID: 41526 RVA: 0x001B99FC File Offset: 0x001B7BFC
		public uint EncourageCount
		{
			get
			{
				return this._EncourageCount;
			}
		}

		// Token: 0x17002F58 RID: 12120
		// (get) Token: 0x0600A237 RID: 41527 RVA: 0x001B9A14 File Offset: 0x001B7C14
		public uint EncourgeGuildCount
		{
			get
			{
				return this._EncourgeGuildCount;
			}
		}

		// Token: 0x17002F59 RID: 12121
		// (get) Token: 0x0600A238 RID: 41528 RVA: 0x001B9A2C File Offset: 0x001B7C2C
		public XWorldBossDamageRankList DamageRankList
		{
			get
			{
				return this._DamageRankList;
			}
		}

		// Token: 0x17002F5A RID: 12122
		// (get) Token: 0x0600A239 RID: 41529 RVA: 0x001B9A44 File Offset: 0x001B7C44
		public XWorldBossGuildRankList GuildRankList
		{
			get
			{
				return this._GuildRankList;
			}
		}

		// Token: 0x17002F5B RID: 12123
		// (get) Token: 0x0600A23A RID: 41530 RVA: 0x001B9A5C File Offset: 0x001B7C5C
		public XWorldBossGuildRoleRankList GuildRoleRankList
		{
			get
			{
				return this._GuildRoleRankList;
			}
		}

		// Token: 0x0600A23B RID: 41531 RVA: 0x001B9A74 File Offset: 0x001B7C74
		public static void Execute(OnLoadedCallback callback = null)
		{
			XWorldBossDocument.AsyncLoader.AddTask("Table/WorldBossReward", XWorldBossDocument.WorldBossAwardTable, false);
			XWorldBossDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A23C RID: 41532 RVA: 0x001B9A9C File Offset: 0x001B7C9C
		public uint GetWorldBossSceneID()
		{
			return (uint)XSingleton<XGlobalConfig>.singleton.GetInt("WorldBossSceneID");
		}

		// Token: 0x0600A23D RID: 41533 RVA: 0x001B9AC0 File Offset: 0x001B7CC0
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

		// Token: 0x0600A23E RID: 41534 RVA: 0x001B9AF8 File Offset: 0x001B7CF8
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS;
			if (flag)
			{
				this.BattleHandler.RefreshAllEnacourage();
			}
		}

		// Token: 0x0600A23F RID: 41535 RVA: 0x001B9B2C File Offset: 0x001B7D2C
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool worldBossEnd = this._WorldBossEnd;
			if (worldBossEnd)
			{
				this._WorldBossEnd = false;
			}
		}

		// Token: 0x0600A240 RID: 41536 RVA: 0x001B9B54 File Offset: 0x001B7D54
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Rank_WorldBoss, true);
			}
		}

		// Token: 0x0600A241 RID: 41537 RVA: 0x001B9B8C File Offset: 0x001B7D8C
		public void ReqWorldBossState()
		{
			RpcC2M_GetWorldBossStateNew rpcC2M_GetWorldBossStateNew = new RpcC2M_GetWorldBossStateNew();
			rpcC2M_GetWorldBossStateNew.oArg.type = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetWorldBossStateNew);
		}

		// Token: 0x0600A242 RID: 41538 RVA: 0x001B9BBC File Offset: 0x001B7DBC
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

		// Token: 0x0600A243 RID: 41539 RVA: 0x001B9C4C File Offset: 0x001B7E4C
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

		// Token: 0x0600A244 RID: 41540 RVA: 0x001B9CAC File Offset: 0x001B7EAC
		public void ReqRankData(RankeType type, bool inFight)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(type);
			rpcC2M_ClientQueryRankListNtf.oArg.TimeStamp = 1U;
			rpcC2M_ClientQueryRankListNtf.oArg.sendPunishData = (inFight ? 1U : 0U);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x0600A245 RID: 41541 RVA: 0x001B9D00 File Offset: 0x001B7F00
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

		// Token: 0x0600A246 RID: 41542 RVA: 0x001B9E88 File Offset: 0x001B8088
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

		// Token: 0x0600A247 RID: 41543 RVA: 0x001B9EC4 File Offset: 0x001B80C4
		public void ReqBattleInfo()
		{
			RpcC2M_GetWorldBossTimeLeft rpc = new RpcC2M_GetWorldBossTimeLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A248 RID: 41544 RVA: 0x001B9EE4 File Offset: 0x001B80E4
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

		// Token: 0x0600A249 RID: 41545 RVA: 0x001B9F4A File Offset: 0x001B814A
		public void OnGetAttrCount(WorldBossAttrNtf ntf)
		{
			this._EncourageCount = ntf.count;
		}

		// Token: 0x0600A24A RID: 41546 RVA: 0x001B9F5C File Offset: 0x001B815C
		public void ReqEncourageTwo()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReqEncourageTwo", null, null, null, null, null);
			RpcC2M_WorldBossGuildAddAttr rpcC2M_WorldBossGuildAddAttr = new RpcC2M_WorldBossGuildAddAttr();
			rpcC2M_WorldBossGuildAddAttr.oArg.count = this._EncourgeGuildCount;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_WorldBossGuildAddAttr);
		}

		// Token: 0x0600A24B RID: 41547 RVA: 0x001B9FA4 File Offset: 0x001B81A4
		public void OnGetEncourageTwo(WorldBossGuildAddAttrArg arg, WorldBossGuildAddAttrRes oRes)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnGetEncourageTwo", null, null, null, null, null);
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		// Token: 0x0600A24C RID: 41548 RVA: 0x001B9FF0 File Offset: 0x001B81F0
		public void ReceiveGuildAttAttrSync(WorldBossGuildAddAttrSyncClient ntf)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReceiveGuildAttAttrSync:" + ntf.count.ToString(), null, null, null, null, null);
			this._EncourgeGuildCount = ntf.count;
			this.BattleHandler.RefreshEncourage(1);
		}

		// Token: 0x0600A24D RID: 41549 RVA: 0x001BA040 File Offset: 0x001B8240
		public void ReqEncourage()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReqEncourage", null, null, null, null, null);
			RpcC2G_AddTempAttr rpcC2G_AddTempAttr = new RpcC2G_AddTempAttr();
			rpcC2G_AddTempAttr.oArg.type = 0U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AddTempAttr);
		}

		// Token: 0x0600A24E RID: 41550 RVA: 0x001BA084 File Offset: 0x001B8284
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

		// Token: 0x0600A24F RID: 41551 RVA: 0x001BA0D4 File Offset: 0x001B82D4
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

		// Token: 0x0600A250 RID: 41552 RVA: 0x001BA170 File Offset: 0x001B8370
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

		// Token: 0x0600A251 RID: 41553 RVA: 0x001BA200 File Offset: 0x001B8400
		public void OnWorldBossStateNtf(WorldBossStateNtf stateInfo)
		{
			bool flag = stateInfo.state == WorldBossState.WorldBoss_WaitEnd;
			if (flag)
			{
				this._WorldBossEnd = true;
				DlgBase<XWorldBossResultView, GuildDragonChallengeResultBehaviour>.singleton.ShowResult(stateInfo.iswin);
			}
		}

		// Token: 0x0600A252 RID: 41554 RVA: 0x00160161 File Offset: 0x0015E361
		public void ReqQutiScene()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x0600A253 RID: 41555 RVA: 0x001BA238 File Offset: 0x001B8438
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

		// Token: 0x0600A254 RID: 41556 RVA: 0x001BA2CC File Offset: 0x001B84CC
		public void ReqWorldBossEnd()
		{
			RpcC2M_WorldBossEnd rpc = new RpcC2M_WorldBossEnd();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A255 RID: 41557 RVA: 0x001BA2EC File Offset: 0x001B84EC
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

		// Token: 0x0600A256 RID: 41558 RVA: 0x001BA340 File Offset: 0x001B8540
		public void LeaveSceneCountDown(uint time)
		{
			bool flag = this.BattleHandler != null && this.BattleHandler.IsVisible();
			if (flag)
			{
				this.BattleHandler.OnLeaveSceneCountDown(time);
			}
		}

		// Token: 0x0600A257 RID: 41559 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003A8C RID: 14988
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WorldBossDocument");

		// Token: 0x04003A8D RID: 14989
		public ActivityWorldBossHandler ActivityWorldBossView;

		// Token: 0x04003A8E RID: 14990
		public XWorldBossDamageRankHandler RankHandler;

		// Token: 0x04003A8F RID: 14991
		public BattleWorldBossHandler BattleHandler;

		// Token: 0x04003A90 RID: 14992
		public XWorldBossView WorldBossDescView;

		// Token: 0x04003A91 RID: 14993
		public XWorldBossResultView WorldBossResultView;

		// Token: 0x04003A92 RID: 14994
		public XWorldBossEndRankView WorldBossEndRankView;

		// Token: 0x04003A93 RID: 14995
		private uint _BossHP;

		// Token: 0x04003A94 RID: 14996
		private bool _WorldBossEnd = false;

		// Token: 0x04003A95 RID: 14997
		private List<WorldBossDamageInfo> _EndListDamage = new List<WorldBossDamageInfo>();

		// Token: 0x04003A96 RID: 14998
		private uint _EncourageCount = 0U;

		// Token: 0x04003A97 RID: 14999
		private uint _EncourgeGuildCount = 0U;

		// Token: 0x04003A98 RID: 15000
		private XWorldBossDamageRankList _DamageRankList = new XWorldBossDamageRankList();

		// Token: 0x04003A99 RID: 15001
		private XWorldBossGuildRankList _GuildRankList = new XWorldBossGuildRankList();

		// Token: 0x04003A9A RID: 15002
		private XWorldBossGuildRoleRankList _GuildRoleRankList = new XWorldBossGuildRoleRankList();

		// Token: 0x04003A9B RID: 15003
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003A9C RID: 15004
		public static WorldBossRewardTable WorldBossAwardTable = new WorldBossRewardTable();

		// Token: 0x04003A9D RID: 15005
		public bool MainInterfaceState = false;

		// Token: 0x04003A9E RID: 15006
		private float fCdTime = 0f;
	}
}
