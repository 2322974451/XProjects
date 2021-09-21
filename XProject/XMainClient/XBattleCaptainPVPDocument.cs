using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A87 RID: 2695
	internal class XBattleCaptainPVPDocument : XDocComponent
	{
		// Token: 0x17002FAD RID: 12205
		// (get) Token: 0x0600A3EE RID: 41966 RVA: 0x001C2D54 File Offset: 0x001C0F54
		public override uint ID
		{
			get
			{
				return XBattleCaptainPVPDocument.uuID;
			}
		}

		// Token: 0x17002FAE RID: 12206
		// (get) Token: 0x0600A3EF RID: 41967 RVA: 0x001C2D6C File Offset: 0x001C0F6C
		// (set) Token: 0x0600A3F0 RID: 41968 RVA: 0x001C2D84 File Offset: 0x001C0F84
		public BattleCaptainPVPHandler Handler
		{
			get
			{
				return this._handler;
			}
			set
			{
				this._handler = value;
			}
		}

		// Token: 0x17002FAF RID: 12207
		// (get) Token: 0x0600A3F1 RID: 41969 RVA: 0x001C2D90 File Offset: 0x001C0F90
		public XCaptainPVPDocument CaptainDoc
		{
			get
			{
				bool flag = this._capDoc == null;
				if (flag)
				{
					this._capDoc = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
				}
				return this._capDoc;
			}
		}

		// Token: 0x17002FB0 RID: 12208
		// (get) Token: 0x0600A3F2 RID: 41970 RVA: 0x001C2DC8 File Offset: 0x001C0FC8
		public bool InCaptainPVPTeam
		{
			get
			{
				return this.TeamBlood != null && this.TeamBlood.Count != 0;
			}
		}

		// Token: 0x17002FB1 RID: 12209
		// (get) Token: 0x0600A3F3 RID: 41971 RVA: 0x001C2DF4 File Offset: 0x001C0FF4
		public ulong myId
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			}
		}

		// Token: 0x17002FB2 RID: 12210
		// (get) Token: 0x0600A3F4 RID: 41972 RVA: 0x001C2E18 File Offset: 0x001C1018
		public static int InfoDelayTime
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("PVPInfoDelayTime");
			}
		}

		// Token: 0x17002FB3 RID: 12211
		// (get) Token: 0x0600A3F5 RID: 41973 RVA: 0x001C2E3C File Offset: 0x001C103C
		public static int ReviveTime
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("PVPDieReviveTime");
			}
		}

		// Token: 0x17002FB4 RID: 12212
		// (get) Token: 0x0600A3F6 RID: 41974 RVA: 0x001C2E60 File Offset: 0x001C1060
		public static int EndTime
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("PVPTimeDown");
			}
		}

		// Token: 0x0600A3F7 RID: 41975 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A3F8 RID: 41976 RVA: 0x001C2E84 File Offset: 0x001C1084
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP;
			if (flag)
			{
				this.Handler.SetVisible(true);
				this._ScaleFx1 = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_bhdz", null, true);
				this._ScaleFx2 = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_bhdz", null, true);
				this.ReqBattleCaptainPVPRefreshInfo(true);
				bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
				if (bSpectator)
				{
					this.spectateInitTeam = 0;
					this.spectateNowTeam = 0;
				}
				else
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					bool flag2 = !specificDocument.bInTeam;
					if (flag2)
					{
						XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Activity_CaptainPVP, EXStage.Hall);
					}
				}
			}
		}

		// Token: 0x0600A3F9 RID: 41977 RVA: 0x001C2F50 File Offset: 0x001C1150
		public override void OnLeaveScene()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP;
			if (flag)
			{
				bool flag2 = this._ScaleFx1 != null;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._ScaleFx1, true);
					this._ScaleFx1 = null;
				}
				bool flag3 = this._ScaleFx2 != null;
				if (flag3)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._ScaleFx2, true);
					this._ScaleFx2 = null;
				}
			}
		}

		// Token: 0x0600A3FA RID: 41978 RVA: 0x001C2FC2 File Offset: 0x001C11C2
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_OnRevived, new XComponent.XEventHandler(this.OnPlayerReviveEvent));
		}

		// Token: 0x0600A3FB RID: 41979 RVA: 0x001C2FE4 File Offset: 0x001C11E4
		public bool OnPlayerReviveEvent(XEventArgs args)
		{
			bool flag = this.Handler == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XOnRevivedArgs xonRevivedArgs = args as XOnRevivedArgs;
				bool flag2 = !xonRevivedArgs.entity.IsPlayer;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this.Handler.m_Relive.gameObject.SetActive(false);
					XSingleton<XDebug>.singleton.AddGreenLog("PlayerRevive", null, null, null, null, null);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600A3FC RID: 41980 RVA: 0x001C3054 File Offset: 0x001C1254
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.Handler == null || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_PVP;
			if (!flag)
			{
				this.Handler.RefreshLeaderHp();
				bool flag2 = Time.time > this.lastShowInfoTime + (float)XBattleCaptainPVPDocument.InfoDelayTime;
				if (flag2)
				{
					while (this.qInfo.Count != 0)
					{
						this.qInfo.Clear();
						this.isChange = true;
					}
				}
				bool flag3 = Time.time > this.lastKillTime + (float)XBattleCaptainPVPDocument.ConKillIconShowTime;
				if (flag3)
				{
					bool flag4 = this.ShowConKillcnt != 0;
					if (flag4)
					{
						this.ShowConKillcnt = 0;
						this.isChange = true;
					}
				}
				bool flag5 = Time.time > this.lastDeadTime + (float)XBattleCaptainPVPDocument.ReviveTime;
				if (flag5)
				{
					bool flag6 = this.isDead;
					if (flag6)
					{
						this.isDead = false;
						this.Handler.ShowReviveTime(this.lastDeadTime + (float)XBattleCaptainPVPDocument.ReviveTime - Time.time, true);
					}
				}
				bool flag7 = Time.time > this.lastEndTime + (float)XBattleCaptainPVPDocument.EndTime - 0.3f;
				if (flag7)
				{
					bool flag8 = this.isEnd;
					if (flag8)
					{
						this.isEnd = false;
						this.Handler.ShowEndTime(this.lastEndTime + (float)XBattleCaptainPVPDocument.EndTime - Time.time, true, this.isEndAll);
					}
				}
				bool flag9 = this.isEnd;
				if (flag9)
				{
					this.Handler.ShowEndTime(this.lastEndTime + (float)XBattleCaptainPVPDocument.EndTime - Time.time, false, this.isEndAll);
				}
				bool flag10 = this.isDead;
				if (flag10)
				{
					this.Handler.ShowReviveTime(this.lastDeadTime + (float)XBattleCaptainPVPDocument.ReviveTime - Time.time, false);
				}
				bool flag11 = this.isChange;
				if (flag11)
				{
					this.Handler.ShowGameInfo();
					this.Handler.ShowConKill(this.ShowConKillcnt);
					this.isChange = false;
				}
			}
		}

		// Token: 0x0600A3FD RID: 41981 RVA: 0x001C325C File Offset: 0x001C145C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP;
			if (flag)
			{
				this.ReqBattleCaptainPVPRefreshInfo(true);
			}
		}

		// Token: 0x0600A3FE RID: 41982 RVA: 0x001C3288 File Offset: 0x001C1488
		public void ReqBattleCaptainPVPRefreshInfo(bool bNoShowLog)
		{
			RpcC2G_PvpNowAllData rpcC2G_PvpNowAllData = new RpcC2G_PvpNowAllData();
			rpcC2G_PvpNowAllData.oArg.bNoShowLog = bNoShowLog;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpNowAllData);
		}

		// Token: 0x0600A3FF RID: 41983 RVA: 0x001C32B8 File Offset: 0x001C14B8
		public void SetReqBattleCaptainPVPRefreshInfo(roArg oArg, PvpNowGameData oRes)
		{
			bool flag = this.Handler == null || oRes.isAllEnd;
			if (!flag)
			{
				this.Handler.StartAutoRefresh(null);
				List<PvpNowUnitData> nowUnitdData = oRes.nowUnitdData;
				this.num = nowUnitdData.Count;
				this.userIdToRole.Clear();
				for (int i = 0; i < this.num; i++)
				{
					XBattleCaptainPVPDocument.RoleData value;
					value.roleID = nowUnitdData[i].roleID;
					value.group = nowUnitdData[i].groupid;
					value.Level = nowUnitdData[i].roleLevel;
					value.Name = nowUnitdData[i].roleName;
					value.Profession = nowUnitdData[i].roleProfession;
					this.userIdToRole.Add(nowUnitdData[i].roleID, value);
					bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag2)
					{
						bool flag3 = this.myId == nowUnitdData[i].roleID;
						if (flag3)
						{
							this.myTeam = nowUnitdData[i].groupid;
						}
					}
				}
				bool flag4 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag4)
				{
					bool flag5 = this.spectateInitTeam == 0;
					if (flag5)
					{
						bool flag6 = XSingleton<XEntityMgr>.singleton.Player.WatchTo == null;
						if (flag6)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("WatchTo is Null", null, null, null, null, null);
							return;
						}
						this.SpectateTeamChange(XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID);
					}
				}
				bool flag7 = this.GetInitTeam() == 0;
				if (flag7)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("No Team", null, null, null, null, null);
				}
				bool flag8 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag8)
				{
					this.TeamBlood.Clear();
					for (int j = 0; j < this.num; j++)
					{
						bool flag9 = this.myTeam != nowUnitdData[j].groupid;
						if (!flag9)
						{
							XTeamBloodUIData xteamBloodUIData = new XTeamBloodUIData();
							xteamBloodUIData.uid = nowUnitdData[j].roleID;
							xteamBloodUIData.entityID = nowUnitdData[j].roleID;
							xteamBloodUIData.level = nowUnitdData[j].roleLevel;
							xteamBloodUIData.name = nowUnitdData[j].roleName;
							xteamBloodUIData.profession = (RoleType)nowUnitdData[j].roleProfession;
							xteamBloodUIData.bIsLeader = false;
							this.TeamBlood.Add(xteamBloodUIData);
						}
					}
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
				}
				this.RankList.Clear();
				int k = 0;
				while (k < this.num)
				{
					bool flag10 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (!flag10)
					{
						goto IL_2F9;
					}
					bool flag11 = this.myTeam != nowUnitdData[k].groupid;
					if (!flag11)
					{
						goto IL_2F9;
					}
					IL_35F:
					k++;
					continue;
					IL_2F9:
					XCaptainPVPInfo xcaptainPVPInfo = new XCaptainPVPInfo();
					xcaptainPVPInfo.name = nowUnitdData[k].roleName;
					xcaptainPVPInfo.kill = nowUnitdData[k].killCount;
					xcaptainPVPInfo.dead = nowUnitdData[k].dieCount;
					xcaptainPVPInfo.id = nowUnitdData[k].roleID;
					this.RankList.Add(xcaptainPVPInfo);
					goto IL_35F;
				}
				XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
				specificDocument.OnGetRank(this.RankList);
				bool flag12 = this.GetInitTeam() == 1;
				if (flag12)
				{
					this.Handler.m_Blue.SetText(oRes.group1WinCount.ToString());
					this.Handler.m_Red.SetText(oRes.group2WinCount.ToString());
				}
				else
				{
					bool flag13 = this.GetInitTeam() == 2;
					if (flag13)
					{
						this.Handler.m_Blue.SetText(oRes.group2WinCount.ToString());
						this.Handler.m_Red.SetText(oRes.group1WinCount.ToString());
					}
				}
				bool flag14 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && oRes.LeftTime > 0U;
				if (flag14)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(oRes.LeftTime, -1);
				}
				bool flag15 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded() && oRes.LeftTime > 0U;
				if (flag15)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime(oRes.LeftTime);
				}
				this.ClearPosition();
				this.RefreshLeader(oRes.group1Leader, oRes.group2Leader);
			}
		}

		// Token: 0x0600A400 RID: 41984 RVA: 0x001C3778 File Offset: 0x001C1978
		private void RefreshLeader(ulong Leader1, ulong Leader2)
		{
			bool active = false;
			this.groupLeader1 = Leader1;
			this.groupLeader2 = Leader2;
			bool flag = this.groupLeader1 == 0UL && this.groupLeader2 == 0UL;
			if (!flag)
			{
				ulong num = this.MyPosition(true);
				ulong redLeader = (num == this.groupLeader1) ? this.groupLeader2 : this.groupLeader1;
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					this.ChangePosition(this.TeamBlood, num);
					active = (num == this.myId);
					this.Handler.ShowLeaderHpName(num, redLeader);
				}
				bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
					bool flag4 = this.MyPosition(false) == this.groupLeader1;
					if (flag4)
					{
						this.ChangePosition(specificDocument.LeftTeamMonitorData, this.groupLeader1);
						this.ChangePosition(specificDocument.RightTeamMonitorData, this.groupLeader2);
						this.Handler.ShowLeaderHpName(this.groupLeader1, this.groupLeader2);
					}
					else
					{
						bool flag5 = this.MyPosition(false) == this.groupLeader2;
						if (flag5)
						{
							this.ChangePosition(specificDocument.LeftTeamMonitorData, this.groupLeader2);
							this.ChangePosition(specificDocument.RightTeamMonitorData, this.groupLeader1);
							this.Handler.ShowLeaderHpName(this.groupLeader2, this.groupLeader1);
						}
					}
				}
				XBattleCaptainPVPDocument.RoleData roleInfo = this.GetRoleInfo(num);
				bool flag6 = roleInfo.roleID == 0UL;
				if (flag6)
				{
					this.Handler.m_Leader.SetText("");
				}
				else
				{
					this.Handler.m_Leader.SetText(roleInfo.Name);
				}
				bool flag7 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag7)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.OnTeamInfoChanged();
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_TeamLeader.SetActive(active);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.ClearTeamIndicate();
				}
				bool flag8 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag8)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnTeamInfoChanged();
				}
				bool flag9 = this.GetInitTeam() == 1;
				if (flag9)
				{
					bool flag10 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag10)
					{
						XBattleDocument.SetMiniMapElement(this.groupLeader1, "smap_10", 20, 16);
						XBattleDocument.SetMiniMapElement(this.groupLeader2, "smap_11", 20, 16);
					}
					bool flag11 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
					if (flag11)
					{
						XSpectateSceneDocument.SetMiniMapElement(this.groupLeader1, "smap_10", 20, 16);
						XSpectateSceneDocument.SetMiniMapElement(this.groupLeader2, "smap_11", 20, 16);
					}
				}
				bool flag12 = this.GetInitTeam() == 2;
				if (flag12)
				{
					bool flag13 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag13)
					{
						XBattleDocument.SetMiniMapElement(this.groupLeader2, "smap_10", 20, 16);
						XBattleDocument.SetMiniMapElement(this.groupLeader1, "smap_11", 20, 16);
					}
					bool flag14 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
					if (flag14)
					{
						XSpectateSceneDocument.SetMiniMapElement(this.groupLeader2, "smap_10", 20, 16);
						XSpectateSceneDocument.SetMiniMapElement(this.groupLeader1, "smap_11", 20, 16);
					}
				}
				this.FxPlay();
			}
		}

		// Token: 0x0600A401 RID: 41985 RVA: 0x001C3AAC File Offset: 0x001C1CAC
		private void ClearPosition()
		{
			bool flag = this.groupLeader1 == 0UL && this.groupLeader2 == 0UL;
			if (!flag)
			{
				bool flag2 = this._ScaleFx1 != null;
				if (flag2)
				{
					this._ScaleFx1.Stop();
				}
				bool flag3 = this._ScaleFx2 != null;
				if (flag3)
				{
					this._ScaleFx2.Stop();
				}
				bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag4)
				{
					XBattleDocument.ResetMiniMapElement(this.groupLeader1);
					XBattleDocument.ResetMiniMapElement(this.groupLeader2);
					this.ChangePosition(this.TeamBlood, 0UL);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.OnTeamInfoChanged();
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_TeamLeader.SetActive(false);
				}
				bool flag5 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag5)
				{
					XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
					XSpectateSceneDocument.ResetMiniMapElement(this.groupLeader1);
					XSpectateSceneDocument.ResetMiniMapElement(this.groupLeader2);
					this.ChangePosition(specificDocument.LeftTeamMonitorData, 0UL);
					this.ChangePosition(specificDocument.RightTeamMonitorData, 0UL);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnTeamInfoChanged();
				}
				this.groupLeader1 = 0UL;
				this.groupLeader2 = 0UL;
			}
		}

		// Token: 0x0600A402 RID: 41986 RVA: 0x001C3BE0 File Offset: 0x001C1DE0
		public void SetBattleBegin(PtcG2C_PvpBattleBeginNtf roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog("SetBattleBegin", Time.time.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this.Handler != null;
			if (flag)
			{
				this.Handler.ShowStart();
			}
			this.ClearPosition();
			this.RefreshLeader(roPtc.Data.group1Leader, roPtc.Data.group2Leader);
		}

		// Token: 0x0600A403 RID: 41987 RVA: 0x001C3C50 File Offset: 0x001C1E50
		public void SetBattleEnd(PtcG2C_PvpBattleEndNtf roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog("SetBattleEnd ", Time.time.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this.Handler == null;
			if (!flag)
			{
				this.Handler.RefreshLeaderHp();
				this.isEndAll = roPtc.Data.isAllEnd;
				this.isEnd = true;
				this.Handler.m_Relive.gameObject.SetActive(false);
				this.ShowConKillcnt = 0;
				this.isChange = true;
				bool flag2 = roPtc.Data.wingroup == 3;
				if (!flag2)
				{
					bool flag3 = roPtc.Data.wingroup == this.GetInitTeam();
					if (flag3)
					{
						this.Handler.ShowSorce(true);
					}
					else
					{
						this.Handler.ShowSorce(false);
					}
				}
				this.PlaySmallResult(roPtc);
			}
		}

		// Token: 0x0600A404 RID: 41988 RVA: 0x001C3D34 File Offset: 0x001C1F34
		public void PlaySmallResult(PtcG2C_PvpBattleEndNtf roPtc)
		{
			this.lastEndTime = Time.time;
			this.Handler.m_End.PlayTween(true, -1f);
			this.Handler.m_EndIcon.gameObject.SetActive(false);
			this.Handler.m_Draw.SetActive(false);
			this.Handler.m_Win.SetActive(false);
			this.Handler.m_Lose.SetActive(false);
			bool flag = roPtc.Data.wingroup == 3;
			if (flag)
			{
				this.Handler.m_Draw.SetActive(true);
			}
			else
			{
				bool flag2 = roPtc.Data.wingroup == this.GetNowTeam();
				if (flag2)
				{
					this.Handler.m_Win.SetActive(true);
				}
				else
				{
					this.Handler.m_Lose.SetActive(true);
				}
			}
			bool flag3 = PVP_ONEGAMEEND_REASON.PVP_OGE_TIMELIMIT == roPtc.Data.reason;
			if (flag3)
			{
				bool flag4 = roPtc.Data.wingroup == 3;
				if (flag4)
				{
					this.Handler.m_EndText.SetText(XStringDefineProxy.GetString("CAPTAIN_DRAW"));
				}
				else
				{
					bool flag5 = roPtc.Data.wingroup == this.GetNowTeam();
					if (flag5)
					{
						this.Handler.m_EndText.SetText(XStringDefineProxy.GetString("CAPTAIN_WIN_OVERTIME"));
					}
					else
					{
						this.Handler.m_EndText.SetText(XStringDefineProxy.GetString("CAPTAIN_LOSE_OVERTIME"));
					}
				}
			}
			else
			{
				bool flag6 = roPtc.Data.wingroup == 3;
				if (flag6)
				{
					this.Handler.m_EndText.SetText(XStringDefineProxy.GetString("CAPTAIN_DRAW"));
				}
				else
				{
					bool flag7 = roPtc.Data.wingroup == this.GetNowTeam();
					if (flag7)
					{
						string @string = XStringDefineProxy.GetString("CAPTAIN_WIN");
						bool flag8 = string.IsNullOrEmpty(this.DeadLeader) || string.IsNullOrEmpty(this.KillLeader);
						if (flag8)
						{
							this.Handler.m_EndText.SetText("");
						}
						else
						{
							this.Handler.m_EndText.SetText(string.Format(XStringDefineProxy.GetString("CAPTAIN_WIN"), this.DeadLeader, this.KillLeader));
						}
						this.DeadLeader = null;
						this.KillLeader = null;
					}
					else
					{
						this.Handler.m_EndText.SetText(XStringDefineProxy.GetString("CAPTAIN_LOSE"));
					}
				}
			}
		}

		// Token: 0x0600A405 RID: 41989 RVA: 0x001C3FB4 File Offset: 0x001C21B4
		public void PlayBigResult()
		{
			bool flag = this.playedBigResult;
			if (!flag)
			{
				this.isEnd = true;
				this.playedBigResult = true;
				this.lastEndTime = Time.time;
				this.Handler.m_End.PlayTween(true, -1f);
				this.Handler.m_EndIcon.gameObject.SetActive(false);
				this.Handler.m_Draw.SetActive(false);
				this.Handler.m_Win.SetActive(false);
				this.Handler.m_Lose.SetActive(false);
				string format = "atlas/UI/Battle/{0}";
				this.Handler.m_EndIcon.gameObject.SetActive(true);
				int res = this.GetRes();
				bool flag2 = res == 0;
				if (flag2)
				{
					this.Handler.picPath = string.Format(format, "draw");
					this.Handler.m_EndIcon.SetTexturePath(this.Handler.picPath);
				}
				else
				{
					bool flag3 = res > 0;
					if (flag3)
					{
						this.Handler.picPath = string.Format(format, "victery");
						this.Handler.m_EndIcon.SetTexturePath(this.Handler.picPath);
						this.Handler.PlayAudio(6);
					}
					else
					{
						bool flag4 = res < 0;
						if (flag4)
						{
							this.Handler.picPath = string.Format(format, "failure");
							this.Handler.m_EndIcon.SetTexturePath(this.Handler.picPath);
							this.Handler.PlayAudio(7);
						}
					}
				}
			}
		}

		// Token: 0x0600A406 RID: 41990 RVA: 0x001C414C File Offset: 0x001C234C
		public void SetBattleKill(PtcG2C_PvpBattleKill roPtc)
		{
			bool flag = this.Handler == null;
			if (!flag)
			{
				ulong killID = roPtc.Data.killID;
				ulong deadID = roPtc.Data.deadID;
				XBattleCaptainPVPDocument.RoleData roleInfo = this.GetRoleInfo(killID);
				XBattleCaptainPVPDocument.RoleData roleInfo2 = this.GetRoleInfo(deadID);
				bool flag2 = roleInfo.roleID == 0UL || roleInfo2.roleID == 0UL;
				if (!flag2)
				{
					bool flag3 = this.GetInitTeam() == roleInfo.group;
					string text;
					string text2;
					if (flag3)
					{
						text = this.blue;
						text2 = this.red;
					}
					else
					{
						text = this.red;
						text2 = this.blue;
					}
					text += roleInfo.Name;
					text2 += roleInfo2.Name;
					this.AddGameInfo(text, text2, false);
					bool flag4 = this.myId == killID;
					if (flag4)
					{
						this.ShowConKillcnt = roPtc.Data.contiKillCount;
						XSingleton<XDebug>.singleton.AddLog("ConKillcnt:" + this.ShowConKillcnt.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
						this.lastKillTime = Time.time;
						XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/pVP_kill", true, AudioChannel.Action);
					}
					bool flag5 = this.myId == deadID;
					if (flag5)
					{
						this.isDead = true;
						this.lastDeadTime = Time.time;
						bool flag6 = this.Handler != null;
						if (flag6)
						{
							this.Handler.m_Relive.PlayTween(true, -1f);
						}
					}
					bool flag7 = this.groupLeader1 == deadID || this.groupLeader2 == deadID;
					if (flag7)
					{
						this.KillLeader = text;
						this.DeadLeader = text2;
					}
					this.isChange = true;
					for (int i = 0; i < this.RankList.Count; i++)
					{
						bool flag8 = killID == this.RankList[i].id;
						if (flag8)
						{
							bool flag9 = deadID == this.groupLeader1 || deadID == this.groupLeader2;
							if (flag9)
							{
								this.RankList[i].kill += XSingleton<XGlobalConfig>.singleton.GetInt("PVPLeaderKillCount");
							}
							else
							{
								this.RankList[i].kill++;
							}
						}
						bool flag10 = deadID == this.RankList[i].id;
						if (flag10)
						{
							this.RankList[i].dead++;
						}
					}
					XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
					specificDocument.OnGetRank(this.RankList);
				}
			}
		}

		// Token: 0x0600A407 RID: 41991 RVA: 0x001C43F8 File Offset: 0x001C25F8
		public void AddGameInfo(ulong roleID, uint doodadID)
		{
			XBattleCaptainPVPDocument.RoleData roleInfo = this.GetRoleInfo(roleID);
			BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)doodadID, 1);
			string text = string.Empty;
			bool flag = buffData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("CaptainPVP: Buff data not found: [{0} {1}]", doodadID, 1), null, null, null, null, null);
			}
			else
			{
				text = buffData.BuffName;
			}
			bool flag2 = this.GetInitTeam() == roleInfo.group;
			string infoLeft;
			if (flag2)
			{
				infoLeft = string.Format("{0}{1}", this.blue, roleInfo.Name);
			}
			else
			{
				infoLeft = string.Format("{0}{1}", this.red, roleInfo.Name);
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag3 = false;
			for (int i = 0; i < text.Length; i++)
			{
				bool flag4 = text[i] == '[';
				if (flag4)
				{
					flag3 = true;
				}
				bool flag5 = text[i] == ')';
				if (flag5)
				{
					flag3 = false;
				}
				bool flag6 = flag3;
				if (flag6)
				{
					stringBuilder.Append(text[i]);
				}
				bool flag7 = text[i] == '(';
				if (flag7)
				{
					flag3 = true;
				}
				bool flag8 = text[i] == ']';
				if (flag8)
				{
					flag3 = false;
				}
			}
			this.AddGameInfo(infoLeft, stringBuilder.ToString(), true);
		}

		// Token: 0x0600A408 RID: 41992 RVA: 0x001C454C File Offset: 0x001C274C
		public void AddGameInfo(string infoLeft, string infoRight, bool IsDoodad = false)
		{
			this.lastShowInfoTime = Time.time;
			XBattleCaptainPVPDocument.KillInfo item;
			item.KillName = infoLeft;
			item.DeadName = infoRight;
			item.IsDoodad = IsDoodad;
			this.qInfo.Enqueue(item);
			bool flag = (long)this.qInfo.Count > (long)((ulong)XBattleCaptainPVPDocument.GAME_INFO);
			if (flag)
			{
				this.qInfo.Dequeue();
			}
			bool flag2 = this.Handler != null;
			if (flag2)
			{
				this.Handler.ShowGameInfo();
			}
		}

		// Token: 0x0600A409 RID: 41993 RVA: 0x001C45CC File Offset: 0x001C27CC
		private void FxPlay()
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.groupLeader1);
			bool flag = entity != null && this._ScaleFx1 != null;
			if (flag)
			{
				this._ScaleFx1.Play(entity.EngineObject, Vector3.zero, entity.Height / entity.Scale * Vector3.one, 1f, true, false, "", 0f);
			}
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(this.groupLeader2);
			bool flag2 = entity2 != null && this._ScaleFx2 != null;
			if (flag2)
			{
				this._ScaleFx2.Play(entity2.EngineObject, Vector3.zero, entity2.Height / entity2.Scale * Vector3.one, 1f, true, false, "", 0f);
			}
		}

		// Token: 0x0600A40A RID: 41994 RVA: 0x001C46A4 File Offset: 0x001C28A4
		public void SpectateTeamChange(ulong roleID)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = this.userIdToRole != null && this.userIdToRole.size > 0;
				if (flag2)
				{
					this.spectateInitTeam = this.GetRoleInfo(roleID).group;
					this.spectateNowTeam = this.spectateInitTeam;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("userIdToRole Is Null", null, null, null, null, null);
				}
			}
		}

		// Token: 0x0600A40B RID: 41995 RVA: 0x001C4718 File Offset: 0x001C2918
		public XBattleCaptainPVPDocument.RoleData GetRoleInfo(ulong roleId)
		{
			XBattleCaptainPVPDocument.RoleData result;
			bool flag = !this.userIdToRole.TryGetValue(roleId, out result);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("No Find roleId! roleId:" + roleId, null, null, null, null, null);
				for (int i = 0; i < this.userIdToRole.size; i++)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("RoleId:" + this.userIdToRole.BufferKeys[i], null, null, null, null, null);
				}
			}
			return result;
		}

		// Token: 0x0600A40C RID: 41996 RVA: 0x001C47B0 File Offset: 0x001C29B0
		public void ChangePosition(List<XTeamBloodUIData> team, ulong leaderId)
		{
			for (int i = 0; i < team.Count; i++)
			{
				team[i].bIsLeader = (leaderId == team[i].uid);
			}
		}

		// Token: 0x0600A40D RID: 41997 RVA: 0x001C47F0 File Offset: 0x001C29F0
		public ulong MyPosition(bool isNowTeam)
		{
			if (isNowTeam)
			{
				bool flag = this.GetNowTeam() == 1;
				if (flag)
				{
					return this.groupLeader1;
				}
				bool flag2 = this.GetNowTeam() == 2;
				if (flag2)
				{
					return this.groupLeader2;
				}
			}
			else
			{
				bool flag3 = this.GetInitTeam() == 1;
				if (flag3)
				{
					return this.groupLeader1;
				}
				bool flag4 = this.GetInitTeam() == 2;
				if (flag4)
				{
					return this.groupLeader2;
				}
			}
			return 0UL;
		}

		// Token: 0x0600A40E RID: 41998 RVA: 0x001C486C File Offset: 0x001C2A6C
		private int GetNowTeam()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			int result;
			if (flag)
			{
				result = this.spectateNowTeam;
			}
			else
			{
				result = this.myTeam;
			}
			return result;
		}

		// Token: 0x0600A40F RID: 41999 RVA: 0x001C489C File Offset: 0x001C2A9C
		private int GetInitTeam()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			int result;
			if (flag)
			{
				result = this.spectateInitTeam;
			}
			else
			{
				result = this.myTeam;
			}
			return result;
		}

		// Token: 0x0600A410 RID: 42000 RVA: 0x001C48CC File Offset: 0x001C2ACC
		private int GetRes()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded() && this.spectateNowTeam == 2;
			int num;
			int num2;
			if (flag)
			{
				num = int.Parse(this.Handler.m_Red.GetText());
				num2 = int.Parse(this.Handler.m_Blue.GetText());
			}
			else
			{
				num = int.Parse(this.Handler.m_Blue.GetText());
				num2 = int.Parse(this.Handler.m_Red.GetText());
			}
			return num - num2;
		}

		// Token: 0x04003B6F RID: 15215
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BattleCaptainPVPDocument");

		// Token: 0x04003B70 RID: 15216
		public static readonly uint CONTINUOUS_KILL = 5U;

		// Token: 0x04003B71 RID: 15217
		public static readonly uint GAME_INFO = 3U;

		// Token: 0x04003B72 RID: 15218
		private BattleCaptainPVPHandler _handler = null;

		// Token: 0x04003B73 RID: 15219
		private XCaptainPVPDocument _capDoc = null;

		// Token: 0x04003B74 RID: 15220
		public List<XCaptainPVPInfo> RankList = new List<XCaptainPVPInfo>();

		// Token: 0x04003B75 RID: 15221
		public List<XTeamBloodUIData> TeamBlood = new List<XTeamBloodUIData>();

		// Token: 0x04003B76 RID: 15222
		private int num;

		// Token: 0x04003B77 RID: 15223
		public int myTeam;

		// Token: 0x04003B78 RID: 15224
		public int spectateInitTeam;

		// Token: 0x04003B79 RID: 15225
		public int spectateNowTeam;

		// Token: 0x04003B7A RID: 15226
		public ulong groupLeader1;

		// Token: 0x04003B7B RID: 15227
		public ulong groupLeader2;

		// Token: 0x04003B7C RID: 15228
		public string KillLeader;

		// Token: 0x04003B7D RID: 15229
		public string DeadLeader;

		// Token: 0x04003B7E RID: 15230
		private float lastShowInfoTime;

		// Token: 0x04003B7F RID: 15231
		private float lastKillTime;

		// Token: 0x04003B80 RID: 15232
		private float lastDeadTime;

		// Token: 0x04003B81 RID: 15233
		private float lastEndTime;

		// Token: 0x04003B82 RID: 15234
		private XBetterDictionary<ulong, XBattleCaptainPVPDocument.RoleData> userIdToRole = new XBetterDictionary<ulong, XBattleCaptainPVPDocument.RoleData>(0);

		// Token: 0x04003B83 RID: 15235
		public Queue<XBattleCaptainPVPDocument.KillInfo> qInfo = new Queue<XBattleCaptainPVPDocument.KillInfo>();

		// Token: 0x04003B84 RID: 15236
		public int ShowConKillcnt = 0;

		// Token: 0x04003B85 RID: 15237
		private bool isChange = false;

		// Token: 0x04003B86 RID: 15238
		public bool isDead = false;

		// Token: 0x04003B87 RID: 15239
		public bool isEnd = false;

		// Token: 0x04003B88 RID: 15240
		private bool isEndAll = false;

		// Token: 0x04003B89 RID: 15241
		public bool playedBigResult = false;

		// Token: 0x04003B8A RID: 15242
		private XFx _ScaleFx1 = null;

		// Token: 0x04003B8B RID: 15243
		private XFx _ScaleFx2 = null;

		// Token: 0x04003B8C RID: 15244
		public string red = "[ef2717]";

		// Token: 0x04003B8D RID: 15245
		public string blue = "[21b2ff]";

		// Token: 0x04003B8E RID: 15246
		public static int ConKillIconDis = 130;

		// Token: 0x04003B8F RID: 15247
		public static int ConKillIconShowTime = 3;

		// Token: 0x0200198E RID: 6542
		public struct KillInfo
		{
			// Token: 0x04007EEE RID: 32494
			public string KillName;

			// Token: 0x04007EEF RID: 32495
			public string DeadName;

			// Token: 0x04007EF0 RID: 32496
			public bool IsDoodad;
		}

		// Token: 0x0200198F RID: 6543
		public struct RoleData
		{
			// Token: 0x04007EF1 RID: 32497
			public ulong roleID;

			// Token: 0x04007EF2 RID: 32498
			public int group;

			// Token: 0x04007EF3 RID: 32499
			public uint Level;

			// Token: 0x04007EF4 RID: 32500
			public string Name;

			// Token: 0x04007EF5 RID: 32501
			public uint Profession;
		}
	}
}
