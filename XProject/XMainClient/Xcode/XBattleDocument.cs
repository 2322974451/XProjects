using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBattleDocument.uuID;
			}
		}

		public BattleMain BattleMainView
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

		public bool ShowStrengthPresevedBar
		{
			get
			{
				return this._showStrengthPresevedBar;
			}
		}

		public int BindBuffID { get; set; }

		public int AbnormalBuffID { get; set; }

		public bool ShowTeamMemberDamageHUD { get; set; }

		public bool ShowMobDamageHUD { get; set; }

		public bool IsCrossServerBattle { get; set; }

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("ShowDamageHUD");
			this.ShowTeamMemberDamageHUD = (intList.Count > 0 && intList[0] == 1);
			this.ShowMobDamageHUD = (intList.Count > 1 && intList[1] == 1);
			this.LoadGlobalConfig();
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this._BattleLines.Clear();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.ProfTrialsHandler != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.ProfTrialsHandler.SetGeneralTab();
			}
			bool flag2 = this.TeamBlood.Count >= 1 && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
			if (flag2)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
			}
			this._charge_entity = 0UL;
			this._charge_basic = 0.0;
		}

		public override void OnSceneStarted()
		{
			base.OnSceneStarted();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_PromptFrame.gameObject.SetActive(false);
			}
		}

		public override void OnLeaveScene()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerID);
			this.TeamBlood.Clear();
			base.OnLeaveScene();
		}

		private void LoadGlobalConfig()
		{
			this._bind_buff.Clear();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("BindBuffID").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				this._bind_buff.Add(int.Parse(array[i]));
			}
			this._abnormal_buff.Clear();
			array = XSingleton<XGlobalConfig>.singleton.GetValue("AbnormalBuffID").Split(XGlobalConfig.ListSeparator);
			for (int j = 0; j < array.Length; j++)
			{
				this._abnormal_buff.Add(int.Parse(array[j]));
			}
			this._notice_buff.Clear();
			array = XSingleton<XGlobalConfig>.singleton.GetValue("NoticeBuffID").Split(XGlobalConfig.ListSeparator);
			for (int k = 0; k < array.Length; k++)
			{
				this._notice_buff.Add(int.Parse(array[k]));
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this._view != null && this._view.IsLoaded() && this._view.IsVisible();
			if (flag)
			{
				this.SendCheckTime();
				this._view.SetAutoPlayUI(XSingleton<XReconnection>.singleton.IsAutoFight);
				bool sceneStarted = XSingleton<XScene>.singleton.SceneStarted;
				if (sceneStarted)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_PromptFrame.gameObject.SetActive(false);
				}
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
			base.RegisterEvent(XEventDefine.XEvent_DoodadCreate, new XComponent.XEventHandler(this.OnDoodadCreate));
			base.RegisterEvent(XEventDefine.XEvent_DoodadDelete, new XComponent.XEventHandler(this.OnDoodadDelete));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityCreated, new XComponent.XEventHandler(this.OnEntityCreate));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityDeleted, new XComponent.XEventHandler(this.OnEntityDelete));
			base.RegisterEvent(XEventDefine.XEvent_FightGroupChanged, new XComponent.XEventHandler(this.FightGroupChange));
			base.RegisterEvent(XEventDefine.XEvent_EntityAttributeChange, new XComponent.XEventHandler(this.EntityAttributeChange));
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

		protected bool EntityAttributeChange(XEventArgs args)
		{
			XEntityAttrChangeEventArgs xentityAttrChangeEventArgs = args as XEntityAttrChangeEventArgs;
			XAttributeDefine attrKey = xentityAttrChangeEventArgs.AttrKey;
			if (attrKey == XAttributeDefine.XAttr_CurrentEnergy_Basic)
			{
				this.CheckCharge(xentityAttrChangeEventArgs.Entity.ID, xentityAttrChangeEventArgs.Value);
			}
			return true;
		}

		protected void OnBuffChange(XEntity entity)
		{
			bool flag = entity == null || !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (!flag)
			{
				bool isPlayer = entity.IsPlayer;
				if (isPlayer)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.OnPlayerBuffChange();
				}
				else
				{
					bool isRole = entity.IsRole;
					if (isRole)
					{
						XBuffComponent buffs = entity.Buffs;
						bool flag2 = buffs != null;
						if (flag2)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.OnTeamMemberBuffChange(entity.ID, buffs.GetUIBuffList());
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.EnemyInfoHandler.OnBuffChange(entity.ID);
						}
					}
					else
					{
						bool isBoss = entity.IsBoss;
						if (isBoss)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.EnemyInfoHandler.OnBuffChange(entity.ID);
						}
					}
				}
			}
		}

		private bool OnBuffChange(XEventArgs args)
		{
			XBuffChangeEventArgs xbuffChangeEventArgs = args as XBuffChangeEventArgs;
			this.OnBuffChange(xbuffChangeEventArgs.entity);
			bool flag = xbuffChangeEventArgs.addBuff != null;
			if (flag)
			{
				this.CheckBindQTE((int)xbuffChangeEventArgs.addBuff.buffID, xbuffChangeEventArgs.entity, true);
				this.CheckAbnormalQTE((int)xbuffChangeEventArgs.addBuff.buffID, (int)xbuffChangeEventArgs.addBuff.buffLevel, xbuffChangeEventArgs.entity, true);
				this.CheckMiniMapNotice((int)xbuffChangeEventArgs.addBuff.buffID, xbuffChangeEventArgs.entity, true);
			}
			bool flag2 = xbuffChangeEventArgs.removeBuff != null;
			if (flag2)
			{
				this.CheckBindQTE((int)xbuffChangeEventArgs.removeBuff.buffID, xbuffChangeEventArgs.entity, false);
				this.CheckAbnormalQTE((int)xbuffChangeEventArgs.removeBuff.buffID, (int)xbuffChangeEventArgs.removeBuff.buffLevel, xbuffChangeEventArgs.entity, false);
				this.CheckMiniMapNotice((int)xbuffChangeEventArgs.removeBuff.buffID, xbuffChangeEventArgs.entity, false);
			}
			return true;
		}

		private bool OnDoodadCreate(XEventArgs args)
		{
			XDoodadCreateArgs xdoodadCreateArgs = args as XDoodadCreateArgs;
			this.MiniMapAddDoodad(xdoodadCreateArgs.doo);
			return true;
		}

		private bool OnDoodadDelete(XEventArgs args)
		{
			XDoodadDeleteArgs xdoodadDeleteArgs = args as XDoodadDeleteArgs;
			this.MiniMapDelDoodad(xdoodadDeleteArgs.doo);
			return true;
		}

		private bool FightGroupChange(XEventArgs args)
		{
			XFightGroupChangedArgs xfightGroupChangedArgs = args as XFightGroupChangedArgs;
			XBattleDocument.ResetMiniMapElement(xfightGroupChangedArgs.targetEntity.ID);
			bool isPlayer = xfightGroupChangedArgs.targetEntity.IsPlayer;
			if (isPlayer)
			{
				XBattleDocument.ResetMiniMapAllElement();
			}
			return true;
		}

		private void MiniMapAddDoodad(XLevelDoodad doo)
		{
			bool flag = doo.type != XDoodadType.Buff && doo.type != XDoodadType.BuffSkill;
			if (!flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapBuffAdd(doo);
				}
			}
		}

		private void MiniMapDelDoodad(XLevelDoodad doo)
		{
			bool flag = doo.type != XDoodadType.Buff && doo.type != XDoodadType.BuffSkill;
			if (!flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapBuffDel(doo);
				}
			}
		}

		private void CheckCharge(ulong entityID, double value)
		{
			bool flag = entityID != this._charge_entity && value > 0.0;
			if (flag)
			{
				this._charge_entity = entityID;
				this._charge_basic = value;
				DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetChargeValue(0f);
				DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Charge, true);
			}
			else
			{
				bool flag2 = value <= 0.0;
				if (flag2)
				{
					this._charge_entity = 0UL;
					this._charge_basic = 0.0;
					DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Charge, false);
				}
				else
				{
					float chargeValue = 1f - (float)(value / this._charge_basic);
					DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetChargeValue(chargeValue);
				}
			}
		}

		private bool CheckBindQTE(int buffid, XEntity entity, bool status)
		{
			bool flag = this._bind_buff != null && entity != null && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				for (int i = 0; i < this._bind_buff.Count; i++)
				{
					bool flag2 = buffid == this._bind_buff[i] && entity.ID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						this.BindBuffID = buffid;
						DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Bind, status);
						return true;
					}
				}
			}
			return false;
		}

		private bool CheckAbnormalQTE(int buffid, int bufflevel, XEntity entity, bool status)
		{
			bool flag = this._abnormal_buff != null && entity != null && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				for (int i = 0; i < this._abnormal_buff.Count; i++)
				{
					bool flag2 = buffid == this._abnormal_buff[i] && entity.ID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						this.AbnormalBuffID = buffid;
						DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetAbnormalValue((float)bufflevel / 100f);
						DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Abnormal, status);
						return true;
					}
				}
			}
			return false;
		}

		private bool CheckMiniMapNotice(int buffid, XEntity entity, bool status)
		{
			bool flag = this._notice_buff != null && entity != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				for (int i = 0; i < this._notice_buff.Count; i++)
				{
					bool flag2 = buffid == this._notice_buff[i];
					if (flag2)
					{
						if (status)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapNoticeAdd(entity);
						}
						else
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapNoticeDel(entity);
						}
					}
				}
			}
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
				battleLine.fx = XSingleton<XFxMgr>.singleton.CreateFx(XBattleDocument.LINEFX, null, true);
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
			bool flag = this.BattleMainView.IsLoaded();
			if (flag)
			{
				this.BattleMainView.TeamTowerHandler.OnRefreshTowerInfo(infoNtf);
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
			this.MiniMapAdd(xonEntityCreatedArgs.entity);
			return true;
		}

		private bool OnEntityDelete(XEventArgs args)
		{
			XOnEntityDeletedArgs xonEntityDeletedArgs = args as XOnEntityDeletedArgs;
			this.MiniMapDel(xonEntityDeletedArgs.Id);
			bool flag = xonEntityDeletedArgs.Id == this._charge_entity;
			if (flag)
			{
				this._charge_entity = 0UL;
				this._charge_basic = 0.0;
				DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Charge, false);
			}
			return true;
		}

		public static void MiniMapSetRotation(float rotation)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetMiniMapRotation(rotation);
				}
			}
		}

		private void MiniMapAdd(XEntity e)
		{
			bool flag = e == null || e.Attributes == null;
			if (!flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
					if (flag3)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapAdd(e);
					}
					bool isRole = e.IsRole;
					if (isRole)
					{
						this.FakeTeamAdd(e);
					}
				}
			}
		}

		public void FakeTeamAdd(XEntity e)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			if (sceneType == SceneType.SCENE_PKTWO || sceneType == SceneType.SCENE_CUSTOMPKTWO)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag = specificDocument.bInTeam && specificDocument.MyTeam != null && specificDocument.MyTeam.members.Count == 2;
				if (!flag)
				{
					bool flag2 = !e.IsPlayer && !XSingleton<XEntityMgr>.singleton.IsAlly(e);
					if (!flag2)
					{
						for (int i = 0; i < this.TeamBlood.Count; i++)
						{
							bool flag3 = this.TeamBlood[i].uid == e.Attributes.RoleID;
							if (flag3)
							{
								return;
							}
						}
						XTeamBloodUIData xteamBloodUIData = new XTeamBloodUIData();
						xteamBloodUIData.uid = e.Attributes.RoleID;
						xteamBloodUIData.entityID = e.Attributes.RoleID;
						xteamBloodUIData.level = e.Attributes.Level;
						xteamBloodUIData.name = e.Attributes.Name;
						xteamBloodUIData.bIsLeader = false;
						xteamBloodUIData.profession = (RoleType)e.Attributes.TypeID;
						this.TeamBlood.Add(xteamBloodUIData);
						bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
						if (flag4)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
						}
					}
				}
			}
		}

		private void MiniMapDel(ulong uid)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapDel(uid);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.DelTeamIndicate(uid);
				}
			}
		}

		public static void SetMiniMapElement(ulong id, string spriteName, int width, int height)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetMiniMapElement(id, spriteName, width, height);
				}
			}
		}

		public static void ResetMiniMapElement(ulong id)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.ResetMiniMapElement(id);
				}
			}
		}

		public static void ResetMiniMapAllElement()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.ResetMiniMapAllElement();
				}
			}
		}

		public static void SetMiniMapSize(Vector2 size, float scale = 0f)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetMiniMapSize(size, scale);
				}
			}
		}

		public static uint AddMiniMapFx(Vector3 pos, string fx)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					return DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapFxAdd(pos, fx);
				}
			}
			return 0U;
		}

		public static void DelMiniMapFx(uint token)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapFxDel(token);
				}
			}
		}

		public static uint AddMiniMapPic(Vector3 pos, string fx)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					return DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapPicAdd(pos, fx);
				}
			}
			return 0U;
		}

		public static void DelMiniMapPic(uint token)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapPicDel(token);
				}
			}
		}

		public static void SetTargetTabVisable(bool status)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetTargetTabVisable(status);
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
			bool flag = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.ResetLeftTime(time);
			}
		}

		public void SetCameraLayer(int layer, float time)
		{
			this._layer_backup = XSingleton<XScene>.singleton.GameCamera.GetCameraLayer();
			XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(layer);
			XSingleton<XScene>.singleton.GameCamera.SetSolidBlack(true);
			XSingleton<XTimerMgr>.singleton.SetTimer(time, new XTimerMgr.ElapsedEventHandler(this.CameraLayerReset), null);
		}

		private void CameraLayerReset(object o)
		{
			XSingleton<XScene>.singleton.GameCamera.SetSolidBlack(false);
			XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(this._layer_backup);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BattleDocument");

		private BattleMain _view = null;

		private bool _showStrengthPresevedBar = false;

		private XEntity _strengthPresevedEntity = null;

		private List<BattleLine> _BattleLines = new List<BattleLine>();

		private static string LINEFX = "Effects/FX_Particle/Roles/Lzg_Ty/shuangren_xian";

		private List<int> _notice_buff = new List<int>();

		private List<int> _bind_buff = new List<int>();

		private List<int> _abnormal_buff = new List<int>();

		private ulong _charge_entity = 0UL;

		private double _charge_basic = 0.0;

		private uint _timerID = 0U;

		private int _layer_backup = 0;

		public List<XTeamBloodUIData> TeamBlood = new List<XTeamBloodUIData>();
	}
}
