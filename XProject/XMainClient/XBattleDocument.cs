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
	// Token: 0x02000994 RID: 2452
	internal class XBattleDocument : XDocComponent
	{
		// Token: 0x17002CC7 RID: 11463
		// (get) Token: 0x0600937E RID: 37758 RVA: 0x00158E50 File Offset: 0x00157050
		public override uint ID
		{
			get
			{
				return XBattleDocument.uuID;
			}
		}

		// Token: 0x17002CC8 RID: 11464
		// (get) Token: 0x0600937F RID: 37759 RVA: 0x00158E68 File Offset: 0x00157068
		// (set) Token: 0x06009380 RID: 37760 RVA: 0x00158E80 File Offset: 0x00157080
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

		// Token: 0x17002CC9 RID: 11465
		// (get) Token: 0x06009381 RID: 37761 RVA: 0x00158E8C File Offset: 0x0015708C
		public bool ShowStrengthPresevedBar
		{
			get
			{
				return this._showStrengthPresevedBar;
			}
		}

		// Token: 0x17002CCA RID: 11466
		// (get) Token: 0x06009382 RID: 37762 RVA: 0x00158EA4 File Offset: 0x001570A4
		// (set) Token: 0x06009383 RID: 37763 RVA: 0x00158EAC File Offset: 0x001570AC
		public int BindBuffID { get; set; }

		// Token: 0x17002CCB RID: 11467
		// (get) Token: 0x06009384 RID: 37764 RVA: 0x00158EB5 File Offset: 0x001570B5
		// (set) Token: 0x06009385 RID: 37765 RVA: 0x00158EBD File Offset: 0x001570BD
		public int AbnormalBuffID { get; set; }

		// Token: 0x17002CCC RID: 11468
		// (get) Token: 0x06009386 RID: 37766 RVA: 0x00158EC6 File Offset: 0x001570C6
		// (set) Token: 0x06009387 RID: 37767 RVA: 0x00158ECE File Offset: 0x001570CE
		public bool ShowTeamMemberDamageHUD { get; set; }

		// Token: 0x17002CCD RID: 11469
		// (get) Token: 0x06009388 RID: 37768 RVA: 0x00158ED7 File Offset: 0x001570D7
		// (set) Token: 0x06009389 RID: 37769 RVA: 0x00158EDF File Offset: 0x001570DF
		public bool ShowMobDamageHUD { get; set; }

		// Token: 0x17002CCE RID: 11470
		// (get) Token: 0x0600938A RID: 37770 RVA: 0x00158EE8 File Offset: 0x001570E8
		// (set) Token: 0x0600938B RID: 37771 RVA: 0x00158EF0 File Offset: 0x001570F0
		public bool IsCrossServerBattle { get; set; }

		// Token: 0x0600938C RID: 37772 RVA: 0x00158EFC File Offset: 0x001570FC
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("ShowDamageHUD");
			this.ShowTeamMemberDamageHUD = (intList.Count > 0 && intList[0] == 1);
			this.ShowMobDamageHUD = (intList.Count > 1 && intList[1] == 1);
			this.LoadGlobalConfig();
		}

		// Token: 0x0600938D RID: 37773 RVA: 0x00158F63 File Offset: 0x00157163
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this._BattleLines.Clear();
		}

		// Token: 0x0600938E RID: 37774 RVA: 0x00158F7C File Offset: 0x0015717C
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

		// Token: 0x0600938F RID: 37775 RVA: 0x00159020 File Offset: 0x00157220
		public override void OnSceneStarted()
		{
			base.OnSceneStarted();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_PromptFrame.gameObject.SetActive(false);
			}
		}

		// Token: 0x06009390 RID: 37776 RVA: 0x0015906F File Offset: 0x0015726F
		public override void OnLeaveScene()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerID);
			this.TeamBlood.Clear();
			base.OnLeaveScene();
		}

		// Token: 0x06009391 RID: 37777 RVA: 0x00159098 File Offset: 0x00157298
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

		// Token: 0x06009392 RID: 37778 RVA: 0x0015919C File Offset: 0x0015739C
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

		// Token: 0x06009393 RID: 37779 RVA: 0x0015921C File Offset: 0x0015741C
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

		// Token: 0x06009394 RID: 37780 RVA: 0x0015937C File Offset: 0x0015757C
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

		// Token: 0x06009395 RID: 37781 RVA: 0x001593D0 File Offset: 0x001575D0
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

		// Token: 0x06009396 RID: 37782 RVA: 0x00159424 File Offset: 0x00157624
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

		// Token: 0x06009397 RID: 37783 RVA: 0x00159478 File Offset: 0x00157678
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

		// Token: 0x06009398 RID: 37784 RVA: 0x001594B8 File Offset: 0x001576B8
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

		// Token: 0x06009399 RID: 37785 RVA: 0x001594F8 File Offset: 0x001576F8
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

		// Token: 0x0600939A RID: 37786 RVA: 0x00159548 File Offset: 0x00157748
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

		// Token: 0x0600939B RID: 37787 RVA: 0x001595C0 File Offset: 0x001577C0
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

		// Token: 0x0600939C RID: 37788 RVA: 0x00159604 File Offset: 0x00157804
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

		// Token: 0x0600939D RID: 37789 RVA: 0x001596C0 File Offset: 0x001578C0
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

		// Token: 0x0600939E RID: 37790 RVA: 0x001597B4 File Offset: 0x001579B4
		private bool OnDoodadCreate(XEventArgs args)
		{
			XDoodadCreateArgs xdoodadCreateArgs = args as XDoodadCreateArgs;
			this.MiniMapAddDoodad(xdoodadCreateArgs.doo);
			return true;
		}

		// Token: 0x0600939F RID: 37791 RVA: 0x001597DC File Offset: 0x001579DC
		private bool OnDoodadDelete(XEventArgs args)
		{
			XDoodadDeleteArgs xdoodadDeleteArgs = args as XDoodadDeleteArgs;
			this.MiniMapDelDoodad(xdoodadDeleteArgs.doo);
			return true;
		}

		// Token: 0x060093A0 RID: 37792 RVA: 0x00159804 File Offset: 0x00157A04
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

		// Token: 0x060093A1 RID: 37793 RVA: 0x00159848 File Offset: 0x00157A48
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

		// Token: 0x060093A2 RID: 37794 RVA: 0x00159898 File Offset: 0x00157A98
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

		// Token: 0x060093A3 RID: 37795 RVA: 0x001598E8 File Offset: 0x00157AE8
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

		// Token: 0x060093A4 RID: 37796 RVA: 0x0015999C File Offset: 0x00157B9C
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

		// Token: 0x060093A5 RID: 37797 RVA: 0x00159A38 File Offset: 0x00157C38
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

		// Token: 0x060093A6 RID: 37798 RVA: 0x00159AE8 File Offset: 0x00157CE8
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

		// Token: 0x060093A7 RID: 37799 RVA: 0x00159B7C File Offset: 0x00157D7C
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

		// Token: 0x060093A8 RID: 37800 RVA: 0x00159CD8 File Offset: 0x00157ED8
		public void RefreshTowerSceneInfo(PtcG2C_TowerSceneInfoNtf infoNtf)
		{
			bool flag = this.BattleMainView.IsLoaded();
			if (flag)
			{
				this.BattleMainView.TeamTowerHandler.OnRefreshTowerInfo(infoNtf);
			}
		}

		// Token: 0x060093A9 RID: 37801 RVA: 0x00159D0C File Offset: 0x00157F0C
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

		// Token: 0x060093AA RID: 37802 RVA: 0x00159DA8 File Offset: 0x00157FA8
		private bool OnEntityCreate(XEventArgs args)
		{
			XOnEntityCreatedArgs xonEntityCreatedArgs = args as XOnEntityCreatedArgs;
			this.MiniMapAdd(xonEntityCreatedArgs.entity);
			return true;
		}

		// Token: 0x060093AB RID: 37803 RVA: 0x00159DD0 File Offset: 0x00157FD0
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

		// Token: 0x060093AC RID: 37804 RVA: 0x00159E30 File Offset: 0x00158030
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

		// Token: 0x060093AD RID: 37805 RVA: 0x00159E74 File Offset: 0x00158074
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

		// Token: 0x060093AE RID: 37806 RVA: 0x00159EE0 File Offset: 0x001580E0
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

		// Token: 0x060093AF RID: 37807 RVA: 0x0015A060 File Offset: 0x00158260
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

		// Token: 0x060093B0 RID: 37808 RVA: 0x0015A0B4 File Offset: 0x001582B4
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

		// Token: 0x060093B1 RID: 37809 RVA: 0x0015A0F8 File Offset: 0x001582F8
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

		// Token: 0x060093B2 RID: 37810 RVA: 0x0015A138 File Offset: 0x00158338
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

		// Token: 0x060093B3 RID: 37811 RVA: 0x0015A178 File Offset: 0x00158378
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

		// Token: 0x060093B4 RID: 37812 RVA: 0x0015A1BC File Offset: 0x001583BC
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

		// Token: 0x060093B5 RID: 37813 RVA: 0x0015A204 File Offset: 0x00158404
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

		// Token: 0x060093B6 RID: 37814 RVA: 0x0015A244 File Offset: 0x00158444
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

		// Token: 0x060093B7 RID: 37815 RVA: 0x0015A28C File Offset: 0x0015848C
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

		// Token: 0x060093B8 RID: 37816 RVA: 0x0015A2CC File Offset: 0x001584CC
		public static void SetTargetTabVisable(bool status)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetTargetTabVisable(status);
			}
		}

		// Token: 0x060093B9 RID: 37817 RVA: 0x0015A2F8 File Offset: 0x001584F8
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			for (int i = 0; i < this._BattleLines.Count; i++)
			{
				this._BattleLines[i].fx.Position = (this._BattleLines[i].xe1.EngineObject.Position + this._BattleLines[i].xe2.EngineObject.Position) / 2f + new Vector3(0f, this._BattleLines[i].xe1.Height / 2f, 0f);
				this._BattleLines[i].fx.Rotation = Quaternion.FromToRotation(this._BattleLines[i].xe1.EngineObject.Position - this._BattleLines[i].xe2.EngineObject.Position, Vector3.right);
			}
		}

		// Token: 0x060093BA RID: 37818 RVA: 0x0015A418 File Offset: 0x00158618
		public void SendCheckTime()
		{
			bool sceneStarted = XSingleton<XScene>.singleton.SceneStarted;
			if (sceneStarted)
			{
				RpcC2G_QuerySceneTime rpc = new RpcC2G_QuerySceneTime();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x060093BB RID: 37819 RVA: 0x0015A448 File Offset: 0x00158648
		public void ResetSceneTime(int time)
		{
			bool flag = !DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.ResetLeftTime(time);
			}
		}

		// Token: 0x060093BC RID: 37820 RVA: 0x0015A478 File Offset: 0x00158678
		public void SetCameraLayer(int layer, float time)
		{
			this._layer_backup = XSingleton<XScene>.singleton.GameCamera.GetCameraLayer();
			XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(layer);
			XSingleton<XScene>.singleton.GameCamera.SetSolidBlack(true);
			XSingleton<XTimerMgr>.singleton.SetTimer(time, new XTimerMgr.ElapsedEventHandler(this.CameraLayerReset), null);
		}

		// Token: 0x060093BD RID: 37821 RVA: 0x0015A4D6 File Offset: 0x001586D6
		private void CameraLayerReset(object o)
		{
			XSingleton<XScene>.singleton.GameCamera.SetSolidBlack(false);
			XSingleton<XScene>.singleton.GameCamera.SetCameraLayer(this._layer_backup);
		}

		// Token: 0x04003198 RID: 12696
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BattleDocument");

		// Token: 0x04003199 RID: 12697
		private BattleMain _view = null;

		// Token: 0x0400319A RID: 12698
		private bool _showStrengthPresevedBar = false;

		// Token: 0x0400319B RID: 12699
		private XEntity _strengthPresevedEntity = null;

		// Token: 0x0400319C RID: 12700
		private List<BattleLine> _BattleLines = new List<BattleLine>();

		// Token: 0x0400319D RID: 12701
		private static string LINEFX = "Effects/FX_Particle/Roles/Lzg_Ty/shuangren_xian";

		// Token: 0x0400319E RID: 12702
		private List<int> _notice_buff = new List<int>();

		// Token: 0x0400319F RID: 12703
		private List<int> _bind_buff = new List<int>();

		// Token: 0x040031A0 RID: 12704
		private List<int> _abnormal_buff = new List<int>();

		// Token: 0x040031A1 RID: 12705
		private ulong _charge_entity = 0UL;

		// Token: 0x040031A2 RID: 12706
		private double _charge_basic = 0.0;

		// Token: 0x040031A8 RID: 12712
		private uint _timerID = 0U;

		// Token: 0x040031A9 RID: 12713
		private int _layer_backup = 0;

		// Token: 0x040031AA RID: 12714
		public List<XTeamBloodUIData> TeamBlood = new List<XTeamBloodUIData>();
	}
}
