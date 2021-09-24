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

	internal class XTeamMemberMonitor
	{

		public XTeamBloodUIData Data
		{
			get
			{
				return this.m_MemberData;
			}
		}

		public XEntity Entity
		{
			get
			{
				return this.m_Entity;
			}
		}

		public ulong ID
		{
			get
			{
				return this.m_MemberData.uid;
			}
		}

		public ulong EntityID
		{
			get
			{
				return this.m_MemberData.entityID;
			}
		}

		public XTeamMemberMonitor(XTeamMonitorStateMgr stateMgr)
		{
			this.m_StateMgr = stateMgr;
		}

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

		public void SetActive(bool bActive)
		{
			this.m_bActive = bActive;
			this.m_Go.SetActive(bActive);
		}

		public void PlaySound(int state)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this.m_sprVoice.SetVisible(state == 1);
				this.m_sprSpeak.SetVisible(state == 2);
			}
		}

		public void SetMemberData(XTeamBloodUIData data)
		{
			this.m_MemberData = data;
			this.m_Entity = null;
			this.PlaySound(0);
			this._SetBasicUI();
			this.Update();
		}

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

		public void OnBuffChange(List<UIBuffInfo> buffList)
		{
			bool flag = this.m_BuffMonitor != null;
			if (flag)
			{
				this.m_BuffMonitor.OnBuffChanged(buffList);
			}
		}

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

		public void Unload()
		{
			DlgHandlerBase.EnsureUnload<XBuffMonitorHandler>(ref this.m_BuffMonitor);
		}

		private GameObject m_Go;

		private bool m_bActive = true;

		private XTeamBloodUIData m_MemberData;

		private XTeamMonitorStateMgr m_StateMgr;

		private XEntity m_Entity;

		private IXUISprite m_uiAvatar;

		private IXUILabel m_uiName;

		private GameObject m_uiLeader;

		private IXUIProgress m_uiHpBar;

		private IXUIProgress m_uiMpBar;

		private GameObject m_uiDead;

		private IXUISprite m_HeroIcon;

		private IXUISprite m_HeroUnSelect;

		private IXUILabel m_uiLevel;

		public IXUISprite m_sprVoice;

		public IXUISprite m_sprSpeak;

		private GameObject m_uiLeave;

		private GameObject m_uiLoading;

		private IXUICheckBox m_uiCheckBox;

		private XBuffMonitorHandler m_BuffMonitor;
	}
}
