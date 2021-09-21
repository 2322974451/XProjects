using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E6B RID: 3691
	internal class XTeamMemberMonitor
	{
		// Token: 0x1700348A RID: 13450
		// (get) Token: 0x0600C5AE RID: 50606 RVA: 0x002BAD00 File Offset: 0x002B8F00
		public XTeamBloodUIData Data
		{
			get
			{
				return this.m_MemberData;
			}
		}

		// Token: 0x1700348B RID: 13451
		// (get) Token: 0x0600C5AF RID: 50607 RVA: 0x002BAD18 File Offset: 0x002B8F18
		public XEntity Entity
		{
			get
			{
				return this.m_Entity;
			}
		}

		// Token: 0x1700348C RID: 13452
		// (get) Token: 0x0600C5B0 RID: 50608 RVA: 0x002BAD30 File Offset: 0x002B8F30
		public ulong ID
		{
			get
			{
				return this.m_MemberData.uid;
			}
		}

		// Token: 0x1700348D RID: 13453
		// (get) Token: 0x0600C5B1 RID: 50609 RVA: 0x002BAD50 File Offset: 0x002B8F50
		public ulong EntityID
		{
			get
			{
				return this.m_MemberData.entityID;
			}
		}

		// Token: 0x0600C5B2 RID: 50610 RVA: 0x002BAD6D File Offset: 0x002B8F6D
		public XTeamMemberMonitor(XTeamMonitorStateMgr stateMgr)
		{
			this.m_StateMgr = stateMgr;
		}

		// Token: 0x0600C5B3 RID: 50611 RVA: 0x002BAD88 File Offset: 0x002B8F88
		public void SetGo(GameObject go)
		{
			this.m_Go = go;
			this.m_uiAvatar = (go.transform.FindChild("AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_uiName = (go.transform.FindChild("PlayerName").GetComponent("XUILabel") as IXUILabel);
			this.m_uiLeader = go.transform.FindChild("TeamLeader").gameObject;
			this.m_HeroIcon = (go.transform.FindChild("Frame/HeroIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_HeroUnSelect = (go.transform.FindChild("Frame/UnSelect").GetComponent("XUISprite") as IXUISprite);
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this.m_sprVoice = (go.transform.FindChild("VoiceInfo/voice").GetComponent("XUISprite") as IXUISprite);
				this.m_sprSpeak = (go.transform.FindChild("VoiceInfo/speak").GetComponent("XUISprite") as IXUISprite);
			}
			Transform transform = go.transform.FindChild("HpBar");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.m_uiHpBar = (transform.GetComponent("XUIProgress") as IXUIProgress);
			}
			else
			{
				this.m_uiHpBar = null;
			}
			transform = go.transform.FindChild("MpBar");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.m_uiMpBar = (transform.GetComponent("XUIProgress") as IXUIProgress);
			}
			else
			{
				this.m_uiMpBar = null;
			}
			transform = go.transform.FindChild("BuffFrame");
			bool flag4 = transform != null;
			if (flag4)
			{
				bool flag5 = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE || !XSingleton<XScene>.singleton.bSpectator;
				if (flag5)
				{
					transform.gameObject.SetActive(true);
					DlgHandlerBase.EnsureCreate<XBuffMonitorHandler>(ref this.m_BuffMonitor, transform.gameObject, null, true);
				}
				else
				{
					transform.gameObject.SetActive(false);
				}
			}
			transform = go.transform.FindChild("Dead");
			bool flag6 = transform != null;
			if (flag6)
			{
				this.m_uiDead = transform.gameObject;
			}
			transform = go.transform.FindChild("Leave");
			bool flag7 = transform != null;
			if (flag7)
			{
				this.m_uiLeave = transform.gameObject;
			}
			transform = go.transform.FindChild("Loading");
			bool flag8 = transform != null;
			if (flag8)
			{
				this.m_uiLoading = transform.gameObject;
			}
			transform = go.transform.FindChild("Level");
			bool flag9 = transform != null;
			if (flag9)
			{
				this.m_uiLevel = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.m_uiLevel = null;
			}
			bool flag10 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag10)
			{
				this.m_uiCheckBox = (go.GetComponent("XUICheckBox") as IXUICheckBox);
			}
		}

		// Token: 0x0600C5B4 RID: 50612 RVA: 0x002BB077 File Offset: 0x002B9277
		public void SetActive(bool bActive)
		{
			this.m_bActive = bActive;
			this.m_Go.SetActive(bActive);
		}

		// Token: 0x0600C5B5 RID: 50613 RVA: 0x002BB090 File Offset: 0x002B9290
		public void PlaySound(int state)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this.m_sprVoice.SetVisible(state == 1);
				this.m_sprSpeak.SetVisible(state == 2);
			}
		}

		// Token: 0x0600C5B6 RID: 50614 RVA: 0x002BB0CE File Offset: 0x002B92CE
		public void SetMemberData(XTeamBloodUIData data)
		{
			this.m_MemberData = data;
			this.m_Entity = null;
			this.PlaySound(0);
			this._SetBasicUI();
			this.Update();
		}

		// Token: 0x0600C5B7 RID: 50615 RVA: 0x002BB0F8 File Offset: 0x002B92F8
		private bool OnSpectateChangeClick(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(checkBox.ID);
				bool flag2 = entityConsiderDeath != null && entityConsiderDeath.IsRole;
				if (flag2)
				{
					XSingleton<XEntityMgr>.singleton.Player.WatchIt(entityConsiderDeath as XRole);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600C5B8 RID: 50616 RVA: 0x002BB154 File Offset: 0x002B9354
		private void _SetBasicUI()
		{
			bool flag = this.m_MemberData != null;
			if (flag)
			{
				this.m_uiName.SetText(this.m_MemberData.name);
				bool flag2 = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE;
				if (flag2)
				{
					this.m_uiAvatar.SetVisible(true);
					this.m_uiLevel.gameObject.SetActive(true);
					this.m_HeroIcon.gameObject.transform.parent.gameObject.SetActive(false);
					int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(this.m_MemberData.profession);
					this.m_uiAvatar.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID);
					this.m_uiLeader.SetActive(this.m_MemberData.bIsLeader);
					bool flag3 = this.m_uiLevel != null;
					if (flag3)
					{
						this.m_uiLevel.SetText("Lv." + this.m_MemberData.level.ToString());
					}
				}
				else
				{
					this.m_uiAvatar.SetVisible(false);
					this.m_uiLeader.SetActive(false);
					this.m_uiLevel.gameObject.SetActive(false);
					this.m_HeroIcon.gameObject.transform.parent.gameObject.SetActive(true);
					uint num = 0U;
					XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument.heroIDIndex.TryGetValue(this.m_MemberData.uid, out num);
					bool flag4 = num == 0U;
					if (flag4)
					{
						this.m_HeroIcon.SetAlpha(0f);
						this.m_HeroUnSelect.SetAlpha(1f);
					}
					else
					{
						this.m_HeroIcon.SetAlpha(1f);
						OverWatchTable.RowData byHeroID = specificDocument.OverWatchReader.GetByHeroID(num);
						bool flag5 = byHeroID != null;
						if (flag5)
						{
							this.m_HeroIcon.SetSprite(byHeroID.Icon, byHeroID.IconAtlas, false);
						}
						else
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Error heroID on TeamMonitor. heroID = ", num.ToString(), null, null, null, null);
						}
						this.m_HeroUnSelect.SetAlpha(0f);
					}
				}
			}
			else
			{
				this.m_HeroIcon.gameObject.transform.parent.gameObject.SetActive(false);
				this.m_uiName.SetText("");
				this.m_uiLeader.SetActive(false);
				this.m_uiAvatar.spriteName = "zd_wh";
				bool flag6 = this.m_uiLevel != null;
				if (flag6)
				{
					this.m_uiLevel.SetText("");
				}
			}
			this.m_uiAvatar.SetEnabled(true);
			bool flag7 = this.m_uiDead != null;
			if (flag7)
			{
				this.m_uiDead.SetActive(false);
			}
			bool flag8 = this.m_uiHpBar != null;
			if (flag8)
			{
				this.m_uiHpBar.value = 0f;
			}
			bool flag9 = !XSingleton<XScene>.singleton.bSpectator && this.m_uiMpBar != null;
			if (flag9)
			{
				this.m_uiMpBar.value = 0f;
			}
			bool flag10 = this.m_BuffMonitor != null;
			if (flag10)
			{
				this.m_BuffMonitor.InitMonitor(XSingleton<XGlobalConfig>.singleton.BuffMaxDisplayCountTeam, this.m_MemberData != null && this.m_MemberData.isLeft, false);
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag11 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && this.m_MemberData != null && this.m_MemberData.uid == XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID;
				if (flag11)
				{
					this.m_uiCheckBox.ForceSetFlag(true);
				}
				else
				{
					this.m_uiCheckBox.ForceSetFlag(false);
				}
				this.m_uiCheckBox.ID = this.m_MemberData.uid;
				this.m_uiCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSpectateChangeClick));
			}
		}

		// Token: 0x0600C5B9 RID: 50617 RVA: 0x002BB55C File Offset: 0x002B975C
		private void _SetState()
		{
			XTeamMonitorState state = this.m_StateMgr.GetState(this.m_MemberData.uid);
			bool flag = this.m_uiLeave != null;
			if (flag)
			{
				this.m_uiLeave.SetActive(this.m_Entity == null && state != XTeamMonitorState.TMS_Loading);
			}
			bool flag2 = this.m_uiLoading != null;
			if (flag2)
			{
				this.m_uiLoading.SetActive(this.m_Entity == null && state == XTeamMonitorState.TMS_Loading);
			}
		}

		// Token: 0x0600C5BA RID: 50618 RVA: 0x002BB5DC File Offset: 0x002B97DC
		public void Update()
		{
			bool flag = !this.m_bActive;
			if (!flag)
			{
				bool flag2 = this.m_Entity == null && this.m_MemberData != null;
				if (flag2)
				{
					this.m_Entity = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this.m_MemberData.entityID);
					bool flag3 = this.m_Entity == null;
					if (flag3)
					{
						this._SetState();
						return;
					}
					bool flag4 = !this.m_Entity.Deprecated;
					if (flag4)
					{
						bool flag5 = this.m_BuffMonitor != null;
						if (flag5)
						{
							this.m_BuffMonitor.OnBuffChanged(this.m_Entity.Buffs.GetUIBuffList());
						}
						this.m_StateMgr.SetState(this.m_MemberData.uid, XTeamMonitorState.TMS_Normal);
					}
				}
				bool flag6 = this.m_Entity == null || this.m_Entity.Deprecated;
				if (flag6)
				{
					this.m_Entity = null;
					this._SetBasicUI();
					this._SetState();
				}
				else
				{
					bool flag7 = this.m_BuffMonitor != null;
					if (flag7)
					{
						this.m_BuffMonitor.OnUpdate();
					}
					this._SetState();
					bool flag8 = this.m_uiHpBar != null;
					if (flag8)
					{
						int num = (int)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
						int num2 = (int)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
						bool flag9 = num2 < 0;
						if (flag9)
						{
							num2 = 0;
						}
						this.m_uiHpBar.value = (float)num2 / (float)num;
					}
					bool flag10 = !XSingleton<XScene>.singleton.bSpectator && this.m_uiMpBar != null;
					if (flag10)
					{
						int num3 = (int)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxMP_Total);
						int num4 = (int)this.m_Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
						bool flag11 = num4 < 0;
						if (flag11)
						{
							num4 = 0;
						}
						this.m_uiMpBar.value = (float)num4 / (float)num3;
					}
					bool flag12 = this.m_uiDead != null;
					if (flag12)
					{
						this.m_uiDead.SetActive(!XEntity.ValideEntity(this.m_Entity));
						this.m_uiAvatar.SetEnabled(XEntity.ValideEntity(this.m_Entity));
					}
				}
			}
		}

		// Token: 0x0600C5BB RID: 50619 RVA: 0x002BB810 File Offset: 0x002B9A10
		public void OnBuffChange(List<UIBuffInfo> buffList)
		{
			bool flag = this.m_BuffMonitor != null;
			if (flag)
			{
				this.m_BuffMonitor.OnBuffChanged(buffList);
			}
		}

		// Token: 0x0600C5BC RID: 50620 RVA: 0x002BB838 File Offset: 0x002B9A38
		public void CheckToggleState()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && this.m_MemberData.uid == XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID;
			if (flag)
			{
				this.m_uiCheckBox.bChecked = true;
			}
			else
			{
				this.m_uiCheckBox.bChecked = false;
			}
		}

		// Token: 0x0600C5BD RID: 50621 RVA: 0x002BB8A7 File Offset: 0x002B9AA7
		public void Unload()
		{
			DlgHandlerBase.EnsureUnload<XBuffMonitorHandler>(ref this.m_BuffMonitor);
		}

		// Token: 0x0400569C RID: 22172
		private GameObject m_Go;

		// Token: 0x0400569D RID: 22173
		private bool m_bActive = true;

		// Token: 0x0400569E RID: 22174
		private XTeamBloodUIData m_MemberData;

		// Token: 0x0400569F RID: 22175
		private XTeamMonitorStateMgr m_StateMgr;

		// Token: 0x040056A0 RID: 22176
		private XEntity m_Entity;

		// Token: 0x040056A1 RID: 22177
		private IXUISprite m_uiAvatar;

		// Token: 0x040056A2 RID: 22178
		private IXUILabel m_uiName;

		// Token: 0x040056A3 RID: 22179
		private GameObject m_uiLeader;

		// Token: 0x040056A4 RID: 22180
		private IXUIProgress m_uiHpBar;

		// Token: 0x040056A5 RID: 22181
		private IXUIProgress m_uiMpBar;

		// Token: 0x040056A6 RID: 22182
		private GameObject m_uiDead;

		// Token: 0x040056A7 RID: 22183
		private IXUISprite m_HeroIcon;

		// Token: 0x040056A8 RID: 22184
		private IXUISprite m_HeroUnSelect;

		// Token: 0x040056A9 RID: 22185
		private IXUILabel m_uiLevel;

		// Token: 0x040056AA RID: 22186
		public IXUISprite m_sprVoice;

		// Token: 0x040056AB RID: 22187
		public IXUISprite m_sprSpeak;

		// Token: 0x040056AC RID: 22188
		private GameObject m_uiLeave;

		// Token: 0x040056AD RID: 22189
		private GameObject m_uiLoading;

		// Token: 0x040056AE RID: 22190
		private IXUICheckBox m_uiCheckBox;

		// Token: 0x040056AF RID: 22191
		private XBuffMonitorHandler m_BuffMonitor;
	}
}
