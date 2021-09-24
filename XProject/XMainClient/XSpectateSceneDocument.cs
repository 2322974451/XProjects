using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpectateSceneDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSpectateSceneDocument.uuID;
			}
		}

		public SpectateSceneView _SpectateSceneView
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public uint CurrentBuffID
		{
			get
			{
				return this._currentBuffID;
			}
		}

		public bool ShowStrengthPresevedBar
		{
			get
			{
				return this._showStrengthPresevedBar;
			}
		}

		public bool ShowTeamMemberDamageHUD { get; set; }

		public LiveTable LiveConfigTable
		{
			get
			{
				return XSpectateSceneDocument._liveConfigTable;
			}
		}

		public bool IsCrossServerBattle { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSpectateSceneDocument.AsyncLoader.AddTask("Table/LiveTable", XSpectateSceneDocument._liveConfigTable, false);
			XSpectateSceneDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.ShowTeamMemberDamageHUD = (XSingleton<XGlobalConfig>.singleton.GetInt("ShowTeamMemberDamageHUD") == 1);
		}

		public void GetTargetNum(bool isBattle = false)
		{
			LiveTable.RowData rowData;
			if (isBattle)
			{
				rowData = XSpectateSceneDocument._liveConfigTable.Table[0];
			}
			else
			{
				rowData = XSpectateSceneDocument._liveConfigTable.GetBySceneType(XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType));
			}
			bool flag = rowData != null;
			if (flag)
			{
				this.WatchTarget = rowData.ShowWatch;
				this.CommendTarget = rowData.ShowPraise;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find liveConfigTable by Scenetype. Scenetype = ", XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType).ToString(), null, null, null, null);
			}
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this._BattleLines.Clear();
		}

		public override void OnEnterSceneFinally()
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this._view != null && this._view.IsLoaded() && this._view.IsVisible();
			if (flag)
			{
				this.SendCheckTime();
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ArmorRecover, new XComponent.XEventHandler(this.OnArmorRecover));
			base.RegisterEvent(XEventDefine.XEvent_ArmorBroken, new XComponent.XEventHandler(this.OnArmorBroken));
			base.RegisterEvent(XEventDefine.XEvent_WoozyOn, new XComponent.XEventHandler(this.OnWoozyOn));
			base.RegisterEvent(XEventDefine.XEvent_WoozyOff, new XComponent.XEventHandler(this.OnWoozyOff));
			base.RegisterEvent(XEventDefine.XEvent_StrengthPresevedOn, new XComponent.XEventHandler(this.OnStrengthPresevedOn));
			base.RegisterEvent(XEventDefine.XEvent_StrengthPresevedOff, new XComponent.XEventHandler(this.OnStrengthPresevedOff));
			base.RegisterEvent(XEventDefine.XEvent_ProjectDamage, new XComponent.XEventHandler(this.OnProjectDamage));
			base.RegisterEvent(XEventDefine.XEvent_BuffChange, new XComponent.XEventHandler(this.OnBuffChange));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityCreated, new XComponent.XEventHandler(this.OnEntityCreate));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityDeleted, new XComponent.XEventHandler(this.OnEntityDelete));
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				this.UnInitRoleList.Clear();
				this.BlueFightGroup = uint.MaxValue;
				this.RedFightGroup = uint.MaxValue;
			}
		}

		public bool TryGetSummonedIsBlueTeam(XEntity entity, out bool isBlueTeam)
		{
			isBlueTeam = true;
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(entity.Attributes.HostID);
			bool flag = XEntity.ValideEntity(entityConsiderDeath);
			bool result;
			if (flag)
			{
				result = this.TryGetEntityIsBlueTeam(entityConsiderDeath, out isBlueTeam);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Set Summoned billboard on spectator mode, but master invalide. try get team by fight group.", null, null, null, null, null);
				bool flag2 = entity.Attributes == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this.BlueFightGroup != uint.MaxValue;
					if (flag3)
					{
						isBlueTeam = (entity.Attributes.FightGroup == this.BlueFightGroup);
						result = true;
					}
					else
					{
						bool flag4 = this.RedFightGroup != uint.MaxValue;
						if (flag4)
						{
							isBlueTeam = (entity.Attributes.FightGroup != this.RedFightGroup);
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		public bool TryGetTeam(XEntity entity, out bool isBlueTeam)
		{
			isBlueTeam = true;
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			if (sceneType <= SceneType.SCENE_GPR)
			{
				if (sceneType != SceneType.SCENE_GMF && sceneType != SceneType.SCENE_GPR)
				{
					goto IL_BF;
				}
			}
			else if (sceneType != SceneType.SCENE_LEAGUE_BATTLE && sceneType != SceneType.SCENE_GCF)
			{
				goto IL_BF;
			}
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LEAGUE_BATTLE;
			ulong num;
			if (flag)
			{
				num = specificDocument.GetBattleTeamLeagueID(entity.Attributes.RoleID);
			}
			else
			{
				num = (entity.Attributes as XRoleAttributes).GuildID;
			}
			bool flag2 = num == this.BlueSaveID || num == this.RedSaveID;
			if (flag2)
			{
				isBlueTeam = (num == this.BlueSaveID);
				this.IsBlueTeamDict[entity.Attributes.RoleID] = isBlueTeam;
				return true;
			}
			return false;
			IL_BF:
			return this.IsBlueTeamDict.TryGetValue(entity.Attributes.RoleID, out isBlueTeam);
		}

		public bool TryGetEntityIsBlueTeam(XEntity entity, out bool isBlueTeam)
		{
			isBlueTeam = true;
			bool flag = entity.Attributes == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.TryGetTeam(entity, out isBlueTeam);
				if (flag2)
				{
					bool flag3 = !this.UnInitRoleList.Contains(entity.Attributes.RoleID);
					if (flag3)
					{
						this.UnInitRoleList.Add(entity.Attributes.RoleID);
					}
					XSingleton<XDebug>.singleton.AddLog("Can't find this player's TeamMsg, Maybe scene is end. ID  = ", entity.ID.ToString(), "  Name = ", entity.Name, "  Scene = ", XSingleton<XScene>.singleton.SceneType.ToString(), XDebugColor.XDebug_None);
					result = false;
				}
				else
				{
					bool flag4 = isBlueTeam;
					if (flag4)
					{
						this.BlueFightGroup = entity.Attributes.FightGroup;
					}
					else
					{
						this.RedFightGroup = entity.Attributes.FightGroup;
					}
					result = true;
				}
			}
			return result;
		}

		public void DealWithTeamMessage(OneLiveRecordInfo data)
		{
			XSingleton<XDebug>.singleton.AddLog("Get TeamMonitor Data In Spectator Mode.", null, null, null, null, null, XDebugColor.XDebug_None);
			this.liveRecordInfo = data;
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor != null;
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(true, this.LeftTeamMonitorData);
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(false, this.RightTeamMonitorData);
			}
			this.IsBlueTeamDict.Clear();
			bool flag2 = data.liveType == LiveType.LIVE_GUILDBATTLE || data.liveType == LiveType.LIVE_CROSSGVG;
			if (flag2)
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag3 = specificDocument.bInGuild && specificDocument.BasicData.guildName.Equals(data.nameInfos[1].guildName);
				if (flag3)
				{
					this.BlueSaveID = data.nameInfos[1].guildID;
					this.RedSaveID = data.nameInfos[0].guildID;
				}
				else
				{
					this.BlueSaveID = data.nameInfos[0].guildID;
					this.RedSaveID = data.nameInfos[1].guildID;
				}
			}
			else
			{
				bool flag4 = data.liveType == LiveType.LIVE_LEAGUEBATTLE;
				if (flag4)
				{
					XFreeTeamVersusLeagueDocument specificDocument2 = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
					bool flag5 = specificDocument2.TeamLeagueID == data.nameInfos[1].leagueID;
					if (flag5)
					{
						this.BlueSaveID = data.nameInfos[1].leagueID;
						this.RedSaveID = data.nameInfos[0].leagueID;
					}
					else
					{
						this.BlueSaveID = data.nameInfos[0].leagueID;
						this.RedSaveID = data.nameInfos[1].leagueID;
					}
				}
				else
				{
					XHeroBattleDocument specificDocument3 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					bool flag6 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
					if (flag6)
					{
						specificDocument3.SpectateUid = 0UL;
					}
					for (int i = 0; i < data.nameInfos.Count; i++)
					{
						this.IsBlueTeamDict[data.nameInfos[i].roleInfo.roleID] = data.nameInfos[i].isLeft;
						bool flag7 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE && data.nameInfos[i].isLeft && specificDocument3.SpectateUid == 0UL;
						if (flag7)
						{
							specificDocument3.SpectateUid = data.nameInfos[i].roleInfo.roleID;
						}
					}
				}
			}
			bool flag8 = this.UnInitRoleList.Count != 0;
			if (flag8)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("deal with un init role on spectate msg, cout = ", this.UnInitRoleList.Count.ToString(), null, null, null, null);
				foreach (ulong id in this.UnInitRoleList)
				{
					XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(id);
					bool flag9 = entityConsiderDeath != null;
					if (flag9)
					{
						this.DealWithUnitAppear(entityConsiderDeath);
						bool flag10 = entityConsiderDeath.BillBoard != null;
						if (flag10)
						{
							entityConsiderDeath.BillBoard.Refresh();
						}
						bool flag11 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
						if (flag11)
						{
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.ResetMiniMapElement(id);
						}
					}
				}
			}
		}

		public void DealWithUnitAppear(XEntity entity)
		{
			bool flag = !entity.IsRole;
			if (!flag)
			{
				bool flag2 = !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (!flag2)
				{
					for (int i = 0; i < this.LeftTeamMonitorData.Count; i++)
					{
						bool flag3 = this.LeftTeamMonitorData[i].uid == entity.Attributes.RoleID;
						if (flag3)
						{
							return;
						}
					}
					for (int j = 0; j < this.RightTeamMonitorData.Count; j++)
					{
						bool flag4 = this.RightTeamMonitorData[j].uid == entity.Attributes.RoleID;
						if (flag4)
						{
							return;
						}
					}
					XSingleton<XDebug>.singleton.AddLog("DealWithUnitAppear ID = ", entity.Attributes.RoleID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					bool flag5 = true;
					bool flag6 = !this.TryGetEntityIsBlueTeam(entity, out flag5);
					if (!flag6)
					{
						XTeamBloodUIData xteamBloodUIData = new XTeamBloodUIData();
						xteamBloodUIData.uid = entity.Attributes.RoleID;
						xteamBloodUIData.entityID = entity.Attributes.RoleID;
						xteamBloodUIData.level = entity.Attributes.Level;
						xteamBloodUIData.name = entity.Attributes.Name;
						xteamBloodUIData.profession = (RoleType)entity.Attributes.TypeID;
						xteamBloodUIData.bIsLeader = false;
						xteamBloodUIData.isLeft = flag5;
						bool flag7 = flag5;
						if (flag7)
						{
							this.LeftTeamMonitorData.Add(xteamBloodUIData);
							bool flag8 = this.LeftTeamMonitorData.Count == 1;
							if (flag8)
							{
								XSingleton<XEntityMgr>.singleton.Player.WatchIt(entity as XRole);
							}
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(true, this.LeftTeamMonitorData);
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(false, this.RightTeamMonitorData);
						}
						else
						{
							this.RightTeamMonitorData.Add(xteamBloodUIData);
							bool flag9 = this.LeftTeamMonitorData.Count == 0;
							if (flag9)
							{
								XSingleton<XEntityMgr>.singleton.Player.WatchIt(entity as XRole);
							}
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(true, this.LeftTeamMonitorData);
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(false, this.RightTeamMonitorData);
						}
					}
				}
			}
		}

		public void DealWithUnitDisAppear(ulong roleID)
		{
			bool flag = !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (!flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GMF || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GPR || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LEAGUE_BATTLE;
				if (flag2)
				{
					this.DeleteMonitorByRoleID(roleID);
				}
				else
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnTeamInfoChanged();
				}
				this.ChangeSpectateWhenWatchNull();
			}
		}

		public void DeleteMonitorByRoleID(ulong roleID)
		{
			XSingleton<XDebug>.singleton.AddLog("GuildArena DeleteMonitorByRoleID ID = ", roleID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			for (int i = 0; i < this.LeftTeamMonitorData.Count; i++)
			{
				bool flag = this.LeftTeamMonitorData[i].uid == roleID;
				if (flag)
				{
					this.LeftTeamMonitorData.RemoveAt(i);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(true, this.LeftTeamMonitorData);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(false, this.RightTeamMonitorData);
					return;
				}
			}
			for (int j = 0; j < this.RightTeamMonitorData.Count; j++)
			{
				bool flag2 = this.RightTeamMonitorData[j].uid == roleID;
				if (flag2)
				{
					this.RightTeamMonitorData.RemoveAt(j);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(true, this.LeftTeamMonitorData);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.OnLeftTeamInfoChanged(false, this.RightTeamMonitorData);
					return;
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Delete Monitor in Spectate Mode fail. MayBe isn't a role. ID = ", roleID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		private void ChangeSpectateWhenWatchNull()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo == null;
			if (flag)
			{
				for (int i = 0; i < this.LeftTeamMonitorData.Count; i++)
				{
					XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this.LeftTeamMonitorData[i].uid);
					bool flag2 = entityConsiderDeath != null && entityConsiderDeath.IsRole;
					if (flag2)
					{
						XSingleton<XEntityMgr>.singleton.Player.WatchIt(entityConsiderDeath as XRole);
						return;
					}
				}
				for (int j = 0; j < this.RightTeamMonitorData.Count; j++)
				{
					XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this.RightTeamMonitorData[j].uid);
					bool flag3 = entityConsiderDeath2 != null && entityConsiderDeath2.IsRole;
					if (flag3)
					{
						XSingleton<XEntityMgr>.singleton.Player.WatchIt(entityConsiderDeath2 as XRole);
						return;
					}
				}
				XSingleton<XDebug>.singleton.AddLog("Scene have not player. watch null.", null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		protected bool OnProjectDamage(XEventArgs args)
		{
			bool flag = this._view == null || !this._view.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XProjectDamageEventArgs xprojectDamageEventArgs = args as XProjectDamageEventArgs;
				this._view.OnProjectDamage(xprojectDamageEventArgs.Damage, xprojectDamageEventArgs.Receiver);
				result = true;
			}
			return result;
		}

		protected bool OnArmorRecover(XEventArgs args)
		{
			XArmorRecoverArgs xarmorRecoverArgs = args as XArmorRecoverArgs;
			XEntity self = xarmorRecoverArgs.Self;
			bool flag = this._view == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._view.OnPlaySuperarmorFx(self, false);
				this._view.SetupSpeedFx(self, false, Color.white);
				result = true;
			}
			return result;
		}

		protected bool OnArmorBroken(XEventArgs args)
		{
			XArmorBrokenArgs xarmorBrokenArgs = args as XArmorBrokenArgs;
			XEntity self = xarmorBrokenArgs.Self;
			bool flag = this._view == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._view.OnPlaySuperarmorFx(self, true);
				this._view.SetupSpeedFx(self, false, Color.white);
				result = true;
			}
			return result;
		}

		protected bool OnWoozyOn(XEventArgs args)
		{
			XWoozyOnArgs xwoozyOnArgs = args as XWoozyOnArgs;
			bool flag = this._view == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._view.OnStopSuperarmorFx(xwoozyOnArgs.Self);
				result = true;
			}
			return result;
		}

		protected bool OnWoozyOff(XEventArgs args)
		{
			XWoozyOffArgs xwoozyOffArgs = args as XWoozyOffArgs;
			bool flag = this._view == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._view.OnStopSuperarmorFx(xwoozyOffArgs.Self);
				result = true;
			}
			return result;
		}

		protected bool OnStrengthPresevedOn(XEventArgs args)
		{
			this._showStrengthPresevedBar = true;
			XStrengthPresevationOnArgs xstrengthPresevationOnArgs = args as XStrengthPresevationOnArgs;
			this._strengthPresevedEntity = xstrengthPresevationOnArgs.Host;
			bool flag = this._view == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._view.ShowStrengthPresevedBar(xstrengthPresevationOnArgs.Host);
				result = true;
			}
			return result;
		}

		protected bool OnStrengthPresevedOff(XEventArgs args)
		{
			XStrengthPresevationOffArgs xstrengthPresevationOffArgs = args as XStrengthPresevationOffArgs;
			bool flag = !this._showStrengthPresevedBar;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._strengthPresevedEntity == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this._showStrengthPresevedBar = false;
					this._strengthPresevedEntity = null;
					bool flag3 = this._view == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						this._view.HideStrengthPresevedBar();
						this._view.StopNotice();
						result = true;
					}
				}
			}
			return result;
		}

		protected bool OnBuffChange(XEventArgs args)
		{
			XBuffChangeEventArgs xbuffChangeEventArgs = args as XBuffChangeEventArgs;
			this.OnBuffChange(xbuffChangeEventArgs.entity);
			return true;
		}

		protected void OnBuffChange(XEntity entity)
		{
			bool flag = entity == null || !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (!flag)
			{
				bool isRole = entity.IsRole;
				if (isRole)
				{
					XBuffComponent buffs = entity.Buffs;
					bool flag2 = buffs != null;
					if (flag2)
					{
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.m_TeamMonitor_Left.OnTeamMemberBuffChange(entity.ID, buffs.GetUIBuffList());
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.m_TeamMonitor_Right.OnTeamMemberBuffChange(entity.ID, buffs.GetUIBuffList());
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.EnemyInfoHandler.OnBuffChange(entity.ID);
					}
				}
				else
				{
					bool isBoss = entity.IsBoss;
					if (isBoss)
					{
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.EnemyInfoHandler.OnBuffChange(entity.ID);
					}
				}
			}
		}

		public bool CheckBindQTE()
		{
			List<uint> buffList = XSingleton<XEntityMgr>.singleton.Player.Buffs.GetBuffList();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("BindBuffID").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < buffList.Count; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					bool flag = buffList[i] == uint.Parse(array[j]);
					if (flag)
					{
						this._currentBuffID = buffList[i];
						return true;
					}
				}
			}
			this._currentBuffID = 0U;
			return false;
		}

		public void LineStateChange(ulong e1, ulong e2, bool on)
		{
			BattleLine battleLine = this.FindBattleLine(e1, e2);
			if (on)
			{
				bool flag = battleLine == null;
				if (flag)
				{
					BattleLine battleLine2 = new BattleLine();
					battleLine2.e1 = e1;
					battleLine2.e2 = e2;
					this._BattleLines.Add(battleLine2);
					battleLine = battleLine2;
				}
				battleLine.xe1 = XSingleton<XEntityMgr>.singleton.GetEntity(e1);
				battleLine.xe2 = XSingleton<XEntityMgr>.singleton.GetEntity(e2);
				battleLine.fx = XSingleton<XFxMgr>.singleton.CreateFx(XSpectateSceneDocument.LINEFX, null, true);
				Vector3 position = (battleLine.xe1.EngineObject.Position + battleLine.xe2.EngineObject.Position) / 2f + new Vector3(0f, battleLine.xe1.Height / 2f, 0f);
				Quaternion rotation = Quaternion.FromToRotation(battleLine.xe1.EngineObject.Position - battleLine.xe2.EngineObject.Position, Vector3.right);
				battleLine.fx.Play(position, rotation, Vector3.one, 1f);
			}
			else
			{
				bool flag2 = battleLine != null;
				if (flag2)
				{
					this._BattleLines.Remove(battleLine);
					XSingleton<XFxMgr>.singleton.DestroyFx(battleLine.fx, true);
				}
			}
		}

		public void RefreshTowerSceneInfo(PtcG2C_TowerSceneInfoNtf infoNtf)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID(specificDocument.ExpeditionId);
			uint randomID = expeditionDataByID.RandomSceneIDs[infoNtf.Data.curTowerFloor - 1];
			List<uint> randomSceneList = specificDocument.GetRandomSceneList(randomID);
			bool flag = randomSceneList.Count > 0;
			if (flag)
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(randomSceneList[0]);
				string file = sceneData.configFile + "_sc";
				XSingleton<XLevelScriptMgr>.singleton.PreloadLevelScript(file);
			}
		}

		protected BattleLine FindBattleLine(ulong e1, ulong e2)
		{
			for (int i = 0; i < this._BattleLines.Count; i++)
			{
				bool flag = (e1 == this._BattleLines[i].e1 && e2 == this._BattleLines[i].e2) || (e1 == this._BattleLines[i].e2 && e2 == this._BattleLines[i].e1);
				if (flag)
				{
					return this._BattleLines[i];
				}
			}
			return null;
		}

		private bool OnEntityCreate(XEventArgs args)
		{
			XOnEntityCreatedArgs xonEntityCreatedArgs = args as XOnEntityCreatedArgs;
			this.DealWithUnitAppear(xonEntityCreatedArgs.entity);
			this.MiniMapAdd(xonEntityCreatedArgs.entity);
			return true;
		}

		private bool OnEntityDelete(XEventArgs args)
		{
			XOnEntityDeletedArgs xonEntityDeletedArgs = args as XOnEntityDeletedArgs;
			this.MiniMapDel(xonEntityDeletedArgs.Id);
			this.DealWithUnitDisAppear(xonEntityDeletedArgs.Id);
			return true;
		}

		private void MiniMapAdd(XEntity e)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapAdd(e);
				}
			}
		}

		private void MiniMapDel(ulong uid)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapDel(uid);
				}
			}
		}

		public static void SetMiniMapElement(ulong id, string spriteName, int width, int height)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.SetMiniMapElement(id, spriteName, width, height);
				}
			}
		}

		public static void ResetMiniMapElement(ulong id)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.ResetMiniMapElement(id);
				}
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			for (int i = 0; i < this._BattleLines.Count; i++)
			{
				this._BattleLines[i].fx.Position = (this._BattleLines[i].xe1.EngineObject.Position + this._BattleLines[i].xe2.EngineObject.Position) / 2f + new Vector3(0f, this._BattleLines[i].xe1.Height / 2f, 0f);
				this._BattleLines[i].fx.Rotation = Quaternion.FromToRotation(this._BattleLines[i].xe1.EngineObject.Position - this._BattleLines[i].xe2.EngineObject.Position, Vector3.right);
			}
		}

		public void SendCommendBtnClick()
		{
			RpcC2G_CommendWatchBattle rpc = new RpcC2G_CommendWatchBattle();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void LevelScene()
		{
			bool flag = Time.time - this.LastLevelSceneTime < 5f;
			if (!flag)
			{
				this.LastLevelSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
		}

		public static bool WhetherWathchNumShow(int watchNum, int commendNum, int sceneType)
		{
			LiveTable.RowData bySceneType = XSpectateSceneDocument._liveConfigTable.GetBySceneType(sceneType);
			bool flag = bySceneType == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = watchNum >= bySceneType.ShowWatch || commendNum >= bySceneType.ShowPraise;
				result = flag2;
			}
			return result;
		}

		public void CommendClickSuccess()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible() && DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateHandler != null;
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateHandler.CommendSuccess();
			}
		}

		public static void SetMiniMapSize(Vector2 size, float scale = 0f)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.SetMiniMapSize(size, scale);
				}
			}
		}

		public static uint AddMiniMapFx(Vector3 pos, string fx)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					return DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapFxAdd(pos, fx);
				}
			}
			return 0U;
		}

		public static void DelMiniMapFx(uint token)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapFxDel(token);
				}
			}
		}

		public static uint AddMiniMapPic(Vector3 pos, string fx)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					return DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapPicAdd(pos, fx);
				}
			}
			return 0U;
		}

		public static void DelMiniMapPic(uint token)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapPicDel(token);
				}
			}
		}

		public void SendCheckTime()
		{
			bool sceneStarted = XSingleton<XScene>.singleton.SceneStarted;
			if (sceneStarted)
			{
				RpcC2G_QuerySceneTime rpc = new RpcC2G_QuerySceneTime();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		public void ResetSceneTime(int time)
		{
			bool flag = !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ResetLeftTime(time);
			}
		}

		public void ChangeSpectator(XRole role)
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.ChangeWatchToEntity(role);
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP;
				if (flag2)
				{
					XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
					bool flag3 = specificDocument.spectateInitTeam == 0;
					if (flag3)
					{
						specificDocument.ReqBattleCaptainPVPRefreshInfo(true);
					}
					else
					{
						bool flag4 = this.IsBlueTeamDict[role.ID];
						if (flag4)
						{
							specificDocument.spectateNowTeam = 1;
						}
						else
						{
							specificDocument.spectateNowTeam = 2;
						}
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpectateSceneDocument");

		private SpectateSceneView _view = null;

		private uint _currentBuffID = 0U;

		private bool _showStrengthPresevedBar = false;

		private XEntity _strengthPresevedEntity = null;

		private List<BattleLine> _BattleLines = new List<BattleLine>();

		private static string LINEFX = "Effects/FX_Particle/Roles/Lzg_Ty/shuangren_xian";

		public List<XTeamBloodUIData> LeftTeamMonitorData = new List<XTeamBloodUIData>();

		public List<XTeamBloodUIData> RightTeamMonitorData = new List<XTeamBloodUIData>();

		public Dictionary<ulong, bool> IsBlueTeamDict = new Dictionary<ulong, bool>();

		public HashSet<ulong> UnInitRoleList = new HashSet<ulong>();

		public ulong BlueSaveID = 0UL;

		public ulong RedSaveID = 0UL;

		public uint BlueFightGroup = uint.MaxValue;

		public uint RedFightGroup = uint.MaxValue;

		public int WatchNum = 0;

		public int CommendNum = 0;

		public int WatchTarget;

		public int CommendTarget;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static LiveTable _liveConfigTable = new LiveTable();

		private float LastLevelSceneTime = 0f;

		public OneLiveRecordInfo liveRecordInfo;
	}
}
