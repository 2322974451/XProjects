using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMobaBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMobaBattleDocument.uuID;
			}
		}

		public MobaLevel MobaLevelReader
		{
			get
			{
				return XMobaBattleDocument._mobaLevelReader;
			}
		}

		public XBetterDictionary<ulong, MobaMemberData> MobaData
		{
			get
			{
				return this._mobaData;
			}
		}

		private XHeroBattleSkillDocument _skillDoc
		{
			get
			{
				bool flag = this._valueDoc == null;
				if (flag)
				{
					this._valueDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
				}
				return this._valueDoc;
			}
		}

		public int SkillPoint
		{
			get
			{
				int num = 0;
				for (int i = 2; i <= 5; i++)
				{
					num += XBattleSkillDocument.SkillLevel[i];
				}
				return this.MyLevel() - num;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XMobaBattleDocument.AsyncLoader.AddTask("Table/MobaLevel", XMobaBattleDocument._mobaLevelReader, false);
			XMobaBattleDocument.AsyncLoader.AddTask("Table/MobaSignal", XMobaBattleDocument.MobaSignalReader, false);
			XMobaBattleDocument.AsyncLoader.AddTask("Table/MobaMiniMap", XMobaBattleDocument._miniMapReader, false);
			XMobaBattleDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_OnEntityCreated, new XComponent.XEventHandler(this.OnEntityCreate));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag)
			{
				this._TowerMgr.Clear();
				this._miniMapIconToken.Clear();
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = !XSingleton<XScene>.singleton.bSpectator && !specificDocument.bInTeam;
				if (flag2)
				{
					XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Moba, EXStage.Hall);
				}
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag)
			{
				this.MyData = null;
				this._mobaData.Clear();
				this._TowerMgr.Clear();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		private bool OnEntityCreate(XEventArgs args)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_MOBA;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XOnEntityCreatedArgs xonEntityCreatedArgs = args as XOnEntityCreatedArgs;
				this._TowerMgr.TryAddTower(xonEntityCreatedArgs.entity);
				result = true;
			}
			return result;
		}

		public void OnEntityTargetChange(EntityTargetData changeData)
		{
			this._TowerMgr.OnTargetChange(changeData);
		}

		public void SetBattleMsg(List<MobaBattleTeamData> list)
		{
			bool flag = list.Count < 2 || this.MyData == null || (list[0].teamid != this.MyData.teamID && list[1].teamid != this.MyData.teamID);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("set team msg error.", null, null, null, null, null);
			}
			else
			{
				bool flag2 = list[0].teamid == this.MyData.teamID;
				if (flag2)
				{
					this.MyTeamkill = list[0].headcount;
					this.MyTeamLevel = list[0].grouplevel;
					this.OtherTeamKill = list[1].headcount;
					this.OtherTeamLevel = list[1].grouplevel;
				}
				else
				{
					this.MyTeamkill = list[1].headcount;
					this.MyTeamLevel = list[1].grouplevel;
					this.OtherTeamKill = list[0].headcount;
					this.OtherTeamLevel = list[0].grouplevel;
				}
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.RefreshBattleMsg();
				}
			}
		}

		public void SetAllData(MobaBattleTeamRoleData data)
		{
			this._skillDoc.TAS.Clear();
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				for (int i = 0; i < data.datalist1.Count; i++)
				{
					bool flag2 = data.datalist1[i].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						this.InitData(data.datalist1[i], data.team1);
					}
				}
				for (int j = 0; j < data.datalist2.Count; j++)
				{
					bool flag3 = data.datalist2[j].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag3)
					{
						this.InitData(data.datalist2[j], data.team2);
					}
				}
				for (int k = 0; k < data.datalist1.Count; k++)
				{
					bool flag4 = data.datalist1[k].uid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag4)
					{
						this.InitData(data.datalist1[k], data.team1);
					}
				}
				for (int l = 0; l < data.datalist2.Count; l++)
				{
					bool flag5 = data.datalist2[l].uid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag5)
					{
						this.InitData(data.datalist2[l], data.team2);
					}
				}
				bool flag6 = this._skillDoc._HeroBattleTeamHandler != null && this._skillDoc._HeroBattleTeamHandler.IsVisible();
				if (flag6)
				{
					this._skillDoc._HeroBattleTeamHandler.Refresh();
				}
				bool flag7 = !this._skillDoc.CSSH && this._skillDoc.m_HeroBattleSkillHandler != null;
				if (flag7)
				{
					this._skillDoc.m_HeroBattleSkillHandler.RefreshTab();
				}
			}
		}

		public void InitData(MobaRoleData data, uint teamID)
		{
			MobaMemberData mobaMemberData = null;
			bool flag = !this._mobaData.TryGetValue(data.uid, out mobaMemberData);
			if (flag)
			{
				mobaMemberData = new MobaMemberData(data.uid, teamID);
				this._mobaData[data.uid] = mobaMemberData;
			}
			bool flag2 = data.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag2)
			{
				this.MyData = mobaMemberData;
			}
			this.TurnFromServerData(data, ref mobaMemberData);
		}

		public void OnDataChange(List<MobaRoleData> list)
		{
			bool flag = false;
			this._heroChange = false;
			for (int i = 0; i < list.Count; i++)
			{
				MobaMemberData mobaMemberData = null;
				bool flag2 = this._mobaData.TryGetValue(list[i].uid, out mobaMemberData);
				if (flag2)
				{
					flag = (this.TurnFromServerData(list[i], ref mobaMemberData) || flag);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddGreenLog("server want to change moba data but client haven't! roleID = ", list[i].uid.ToString(), null, null, null, null);
				}
			}
			bool flag3 = flag && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
			if (flag3)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.SetupDetailMsg();
			}
			bool heroChange = this._heroChange;
			if (heroChange)
			{
				bool flag4 = this._skillDoc._HeroBattleTeamHandler != null && this._skillDoc._HeroBattleTeamHandler.IsVisible();
				if (flag4)
				{
					this._skillDoc._HeroBattleTeamHandler.Refresh();
				}
				bool flag5 = !this._skillDoc.CSSH && this._skillDoc.m_HeroBattleSkillHandler != null;
				if (flag5)
				{
					this._skillDoc.m_HeroBattleSkillHandler.RefreshTab();
				}
			}
		}

		public bool TurnFromServerData(MobaRoleData data, ref MobaMemberData info)
		{
			bool nameSpecified = data.nameSpecified;
			if (nameSpecified)
			{
				info.name = data.name;
			}
			bool heroidSpecified = data.heroidSpecified;
			if (heroidSpecified)
			{
				info.heroID = data.heroid;
				this._heroChange = true;
				bool flag = this.MyData != null && this.MyData.teamID == info.teamID;
				if (flag)
				{
					this._skillDoc.TAS.Add(info.heroID);
				}
				bool flag2 = info.isMy && info.heroID != 0U && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleSkillHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleSkillHandler.SetVisible(false);
				}
				bool flag3 = this.MyData != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetHeroMiniMapElement(info.uid, info.heroID, info.teamID == this.MyData.teamID, false);
				}
			}
			bool flag4 = false;
			bool attackLevelSpecified = data.attackLevelSpecified;
			if (attackLevelSpecified)
			{
				bool flag5 = info.isMy && info.attackLevel != data.attackLevel && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag5)
				{
					flag4 = true;
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.ShowAdditionFx(0);
				}
				info.attackLevel = data.attackLevel;
			}
			bool defenseLevelSpecified = data.defenseLevelSpecified;
			if (defenseLevelSpecified)
			{
				bool flag6 = info.isMy && info.defenseLevel != data.defenseLevel && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag6)
				{
					flag4 = true;
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.ShowAdditionFx(1);
				}
				info.defenseLevel = data.defenseLevel;
			}
			bool killNumSpecified = data.killNumSpecified;
			if (killNumSpecified)
			{
				info.kill = data.killNum;
			}
			bool deathNumSpecified = data.deathNumSpecified;
			if (deathNumSpecified)
			{
				info.dead = data.deathNum;
			}
			bool assistNumSpecified = data.assistNumSpecified;
			if (assistNumSpecified)
			{
				info.assist = data.assistNum;
			}
			bool flag7 = info.isMy && (data.killNumSpecified || data.deathNumSpecified || data.assistNumSpecified);
			if (flag7)
			{
				bool flag8 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag8)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.RefreshMyScore();
				}
			}
			int num = 0;
			bool levelSpecified = data.levelSpecified;
			if (levelSpecified)
			{
				bool flag9 = info.level != data.level;
				if (flag9)
				{
					info.level = data.level;
					num = info.levelUpExp - info.exp;
					info.levelUpExp = this.GetLevelUpExp(info.level);
					this.OnRoleLevelUp(info.uid, info.level != 1U, info.isMy);
				}
			}
			bool expSpecified = data.expSpecified;
			if (expSpecified)
			{
				num += (int)data.exp - info.exp;
				info.exp = (int)data.exp;
				bool flag10 = num != 0;
				if (flag10)
				{
					this.ShowGetExp(num);
				}
			}
			bool reviveTimeSpecified = data.reviveTimeSpecified;
			if (reviveTimeSpecified)
			{
				info.reviveTime = data.reviveTime;
				bool flag11 = info.isMy && info.reviveTime > 0f && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag11)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.SetOnDeath();
				}
			}
			bool upgradeNumSpecified = data.upgradeNumSpecified;
			if (upgradeNumSpecified)
			{
				bool flag12 = info.isMy && info.additionPoint > data.upgradeNum && !flag4 && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag12)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.ShowAdditionFx(2);
				}
				info.additionPoint = data.upgradeNum;
				bool flag13 = info.isMy && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null;
				if (flag13)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.SetAdditionFrameState(info.additionPoint > 0U);
				}
			}
			return data.heroidSpecified || data.killNumSpecified || data.deathNumSpecified || data.assistNumSpecified || data.attackLevelSpecified || data.defenseLevelSpecified;
		}

		public int MyLevel()
		{
			bool flag = this.MyData == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				result = (int)this.MyData.level;
			}
			return result;
		}

		public bool GetRoleLevelAndExp(ulong uid, out int level, out float exp)
		{
			level = 1;
			exp = 0f;
			MobaMemberData mobaMemberData = null;
			bool flag = this._mobaData.TryGetValue(uid, out mobaMemberData);
			bool result;
			if (flag)
			{
				level = (int)mobaMemberData.level;
				exp = (float)mobaMemberData.exp * 1f / (float)mobaMemberData.levelUpExp;
				result = true;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("moba billboard try get level and exp error.", null, null, null, null, null);
				result = false;
			}
			return result;
		}

		public int GetLevelUpExp(uint level)
		{
			MobaLevel.RowData byLevel = XMobaBattleDocument._mobaLevelReader.GetByLevel(level);
			bool flag = byLevel == null;
			int result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find moba level up exp, level = ", level.ToString(), null, null, null, null);
				result = 1;
			}
			else
			{
				result = (int)byLevel.Exp;
			}
			return result;
		}

		public void ShowGetExp(int exp)
		{
		}

		public void OnRoleLevelUp(ulong uid, bool haveFx, bool isMy)
		{
			if (haveFx)
			{
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(uid);
				bool flag = XEntity.ValideEntity(entity);
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.CreateAndPlay(XSingleton<XGlobalConfig>.singleton.GetValue("LevelupFx"), entity.MoveObj, Vector3.zero, Vector3.one, 1f, true, 5f, true);
				}
			}
			if (isMy)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.RefreshAddBtn(null);
				}
			}
		}

		public void QuerySkillLevelUp(uint skillID)
		{
			RpcC2G_SceneMobaOp rpcC2G_SceneMobaOp = new RpcC2G_SceneMobaOp();
			rpcC2G_SceneMobaOp.oArg.op = MobaOp.MobaOp_LevelSkill;
			rpcC2G_SceneMobaOp.oArg.param = skillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SceneMobaOp);
		}

		public void QueryAdditionLevelUp(int type)
		{
			bool flag = this.MyData != null && this.MyData.additionPoint == 0U;
			if (!flag)
			{
				RpcC2G_SceneMobaOp rpcC2G_SceneMobaOp = new RpcC2G_SceneMobaOp();
				rpcC2G_SceneMobaOp.oArg.op = MobaOp.MobaOp_Upgrade;
				rpcC2G_SceneMobaOp.oArg.param = (uint)type;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SceneMobaOp);
			}
		}

		public void SendSignal(uint type)
		{
			RpcC2G_MobaSignaling rpcC2G_MobaSignaling = new RpcC2G_MobaSignaling();
			rpcC2G_MobaSignaling.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_MobaSignaling);
		}

		public void OnSignalGet(ulong uid, uint type, Vector3 pos)
		{
			uint heroID = 0U;
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag)
			{
				XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
				bool flag2 = !specificDocument.heroIDIndex.TryGetValue(uid, out heroID);
				if (flag2)
				{
					return;
				}
			}
			else
			{
				MobaMemberData mobaMemberData;
				bool flag3 = !this._mobaData.TryGetValue(uid, out mobaMemberData);
				if (flag3)
				{
					return;
				}
				heroID = mobaMemberData.heroID;
			}
			MobaSignalTable.RowData byID = XMobaBattleDocument.MobaSignalReader.GetByID(type);
			bool flag4 = !string.IsNullOrEmpty(byID.Effect);
			if (flag4)
			{
				bool flag5 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag5)
				{
					XBattleDocument.DelMiniMapFx(this._mapFxToken);
					this._mapFxToken = XBattleDocument.AddMiniMapFx(pos, byID.Effect);
				}
			}
			bool flag6 = !string.IsNullOrEmpty(byID.Audio);
			if (flag6)
			{
				XSingleton<XAudioMgr>.singleton.PlayUISound(byID.Audio, true, AudioChannel.Action);
			}
			OverWatchTable.RowData dataByHeroID = XHeroBattleDocument.GetDataByHeroID(heroID);
			bool flag7 = dataByHeroID != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.m_MapSignalHandler != null;
			if (flag7)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_MobaBattleHandler.m_MapSignalHandler.ShowSignal(dataByHeroID.Icon, dataByHeroID.IconAtlas, byID.Icon, byID.Text);
			}
			bool flag8 = dataByHeroID != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleHandler.m_MapSignalHandler != null;
			if (flag8)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleHandler.m_MapSignalHandler.ShowSignal(dataByHeroID.Icon, dataByHeroID.IconAtlas, byID.Icon, byID.Text);
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			this._TowerMgr.Update();
			bool flag = Time.realtimeSinceStartup - this._RefreshSignTime < 1f;
			if (!flag)
			{
				this._RefreshSignTime = Time.realtimeSinceStartup;
				int i = 0;
				int count = this._mobaData.BufferValues.Count;
				while (i < count)
				{
					bool flag2 = this._mobaData.BufferValues[i].reviveTime > 0f;
					if (flag2)
					{
						this._mobaData.BufferValues[i].reviveTime -= 1f;
						bool flag3 = this._mobaData.BufferValues[i].reviveTime < 0f;
						if (flag3)
						{
							this._mobaData.BufferValues[i].reviveTime = 0f;
						}
					}
					i++;
				}
			}
		}

		public bool isAlly(int teamID)
		{
			return this.MyData == null || (long)teamID == (long)((ulong)this.MyData.teamID);
		}

		public bool isAlly(ulong uid)
		{
			bool flag = this.MyData == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				MobaMemberData mobaMemberData;
				bool flag2 = !this._mobaData.TryGetValue(uid, out mobaMemberData);
				result = (!flag2 && this.MyData.teamID == mobaMemberData.teamID);
			}
			return result;
		}

		public void StartMvpCutScene(bool blueWin)
		{
			XSingleton<XCutScene>.singleton.Start(blueWin ? "CutScene/herocanyan_blue_cutscene" : "CutScene/herocanyan_red_cutscene", true, true);
		}

		public void SetMiniMapIcon(List<uint> list)
		{
			HashSet<uint> hashSet = new HashSet<uint>();
			for (int i = 0; i < list.Count; i++)
			{
				hashSet.Add(list[i]);
			}
			for (int j = this._miniMapIconToken.Count - 1; j >= 0; j--)
			{
				bool flag = !hashSet.Contains(this._miniMapIconToken[j]._index);
				if (flag)
				{
					XBattleDocument.DelMiniMapPic(this._miniMapIconToken[j]._token);
					this._miniMapIconToken.RemoveAt(j);
				}
				else
				{
					hashSet.Remove(this._miniMapIconToken[j]._index);
				}
			}
			foreach (uint num in hashSet)
			{
				MobaMiniMap.RowData byPosIndex = XMobaBattleDocument._miniMapReader.GetByPosIndex(num);
				bool flag2 = byPosIndex == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("get rowData from mobaminimap error, index = ", num.ToString(), null, null, null, null);
				}
				else
				{
					string fx = (byPosIndex.Icon.Length == 1 || this.MyData == null || this.MyData.teamID == 11U) ? byPosIndex.Icon[0] : byPosIndex.Icon[1];
					uint token = XBattleDocument.AddMiniMapPic(new Vector3(byPosIndex.Position[0], 0f, byPosIndex.Position[1]), fx);
					this._miniMapIconToken.Add(new XMobaBattleDocument.MobaMiniMapIcon
					{
						_index = num,
						_token = token
					});
				}
			}
		}

		public void MobaHintNotify(MobaHintNtf ntf)
		{
			this.CreateMessageInfo(ntf.index);
		}

		public void MobaKillerNotify(HeroKillNotifyData notify)
		{
			bool flag = notify.killer == null || notify.dead == null;
			if (!flag)
			{
				bool flag2 = notify.dead.type == HeroKillUnitType.HeroKillUnit_Enemy;
				if (flag2)
				{
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(notify.dead.id);
					uint num = EntityMask.CreateTag(byID);
					bool flag3 = (num & EntityMask.Moba_Tower) != 0U || (num & EntityMask.Moba_Home) > 0U;
					if (flag3)
					{
						this.CreateKillerInfo(XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_DESTROY), notify.killer, notify.dead, notify.assists);
					}
					else
					{
						this.CreateKillerInfo(XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_START), notify.killer, notify.dead, notify.assists);
					}
				}
				else
				{
					bool flag4 = notify.killer.type == HeroKillUnitType.HeroKillUnit_Enemy;
					if (flag4)
					{
						this.CreateKillerInfo(XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_START), notify.killer, notify.dead, notify.assists);
					}
					else
					{
						bool isFirstBlood = notify.isFirstBlood;
						MobaKillEnum en;
						if (isFirstBlood)
						{
							en = MobaKillEnum.KILL_FIRST;
						}
						else
						{
							bool flag5 = notify.multiKill >= 4U;
							if (flag5)
							{
								en = MobaKillEnum.KILL_FOUR;
							}
							else
							{
								bool flag6 = notify.multiKill == 3U;
								if (flag6)
								{
									en = MobaKillEnum.KILL_THREE;
								}
								else
								{
									bool flag7 = notify.multiKill == 2U;
									if (flag7)
									{
										en = MobaKillEnum.KILL_DOUBLE;
									}
									else
									{
										bool flag8 = notify.killer.continueCounts > 5U;
										if (flag8)
										{
											en = MobaKillEnum.KILL_SPREE;
										}
										else
										{
											bool flag9 = notify.killer.continueCounts > 2U;
											if (flag9)
											{
												en = MobaKillEnum.KILL_UNSTOPPABLE;
											}
											else
											{
												en = MobaKillEnum.KILL_START;
											}
										}
									}
								}
							}
						}
						this.CreateKillerInfo(XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(en), notify.killer, notify.dead, notify.assists);
						bool flag10 = notify.dead.continueCounts > 2U;
						if (flag10)
						{
							this.CreateKillerInfo(XFastEnumIntEqualityComparer<MobaKillEnum>.ToInt(MobaKillEnum.KILL_ENDUP), notify.killer, notify.dead, notify.assists);
						}
					}
				}
			}
		}

		private void CreateKillerInfo(int type, HeroKillUnit killer, HeroKillUnit deader, List<HeroKillUnit> assists)
		{
			MobaReminder info = MobaInfoPool.GetInfo();
			info.reminder = MobaReminderEnum.KILLER;
			info.killer = killer;
			info.deader = deader;
			info.assists = assists;
			info.type = type;
			MobaSignalTable.RowData byID = XMobaBattleDocument.MobaSignalReader.GetByID((uint)type);
			bool flag = byID != null;
			if (flag)
			{
				info.AudioName = byID.Audio;
				info.ReminderText = byID.Text;
			}
			DlgBase<MobaKillView, MobaKillBehaviour>.singleton.Enqueue(info);
		}

		private void CreateMessageInfo(int type)
		{
			MobaReminder info = MobaInfoPool.GetInfo();
			info.reminder = MobaReminderEnum.MESSAGE;
			info.type = type;
			MobaSignalTable.RowData byID = XMobaBattleDocument.MobaSignalReader.GetByID((uint)type);
			bool flag = byID != null;
			if (flag)
			{
				info.AudioName = byID.Audio;
				info.ReminderText = byID.Text;
			}
			DlgBase<MobaKillView, MobaKillBehaviour>.singleton.Enqueue(info);
		}

		public uint GetHeroIDByRoleID(ulong uid)
		{
			MobaMemberData mobaMemberData = null;
			bool flag = this._mobaData.TryGetValue(uid, out mobaMemberData);
			uint result;
			if (flag)
			{
				result = mobaMemberData.heroID;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MobaBattleDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static MobaLevel _mobaLevelReader = new MobaLevel();

		private static MobaMiniMap _miniMapReader = new MobaMiniMap();

		public static MobaSignalTable MobaSignalReader = new MobaSignalTable();

		private XBetterDictionary<ulong, MobaMemberData> _mobaData = new XBetterDictionary<ulong, MobaMemberData>(0);

		private List<XMobaBattleDocument.MobaMiniMapIcon> _miniMapIconToken = new List<XMobaBattleDocument.MobaMiniMapIcon>();

		private XHeroBattleSkillDocument _valueDoc;

		public uint MyTeamkill;

		public uint OtherTeamKill;

		public uint MyTeamLevel;

		public uint OtherTeamLevel;

		public MobaMemberData MyData = null;

		private uint _mapFxToken;

		private bool _heroChange;

		private XMobaTowerTargetMgr _TowerMgr = new XMobaTowerTargetMgr();

		private float _RefreshSignTime;

		private struct MobaMiniMapIcon
		{

			public uint _index;

			public uint _token;
		}
	}
}
