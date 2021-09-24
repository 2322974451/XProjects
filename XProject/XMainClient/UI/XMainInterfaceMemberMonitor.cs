using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMainInterfaceMemberMonitor
	{

		public void SetGo(GameObject go)
		{
			this.m_Go = go;
			this.m_InfoFrame = go.transform.Find("Info").gameObject;
			this.m_EmptyFrame = go.transform.Find("Empty").gameObject;
			this.m_uiAvatar = (this.m_InfoFrame.transform.Find("AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_uiName = (this.m_InfoFrame.transform.Find("PlayerName").GetComponent("XUILabel") as IXUILabel);
			this.m_uiLeader = this.m_InfoFrame.transform.Find("TeamLeader").gameObject;
			this.m_uiLevel = (this.m_InfoFrame.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_uiAdd = (this.m_EmptyFrame.transform.Find("Add").GetComponent("XUISprite") as IXUISprite);
			this.m_uiAdd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAddClicked));
			this.m_bg = (go.transform.Find("BackDrop").GetComponent("XUISprite") as IXUISprite);
			this.m_bg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBgClicked));
		}

		public void SetActive(bool bActive)
		{
			this.m_bActive = bActive;
			this.m_Go.SetActive(bActive);
		}

		public void SetMemberData(XTeamBloodUIData data)
		{
			this.m_MemberData = data;
			this._SetBasicUI();
		}

		private void _OnAddClicked(IXUISprite iSp)
		{
			DlgBase<XTeamInviteView, XTeamInviteBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		private void _OnBgClicked(IXUISprite iSp)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (!flag)
			{
				DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
			}
		}

		private void _SetBasicUI()
		{
			this.m_InfoFrame.SetActive(this.m_MemberData != null);
			this.m_EmptyFrame.SetActive(this.m_MemberData == null);
			bool flag = this.m_MemberData != null;
			if (flag)
			{
				this.m_uiName.SetText(this.m_MemberData.name);
				int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(this.m_MemberData.profession);
				this.m_uiAvatar.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID);
				this.m_uiLeader.SetActive(this.m_MemberData.bIsLeader);
				bool flag2 = this.m_uiLevel != null;
				if (flag2)
				{
					this.m_uiLevel.SetText("Lv." + this.m_MemberData.level.ToString());
				}
			}
		}

		private GameObject m_Go;

		private bool m_bActive = true;

		private GameObject m_InfoFrame;

		private GameObject m_EmptyFrame;

		private IXUISprite m_uiAvatar;

		private IXUILabel m_uiName;

		private GameObject m_uiLeader;

		private IXUILabel m_uiLevel;

		private IXUISprite m_uiAdd;

		private IXUISprite m_bg;

		private XTeamBloodUIData m_MemberData;
	}
}
