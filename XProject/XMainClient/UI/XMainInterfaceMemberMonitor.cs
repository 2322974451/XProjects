using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200183C RID: 6204
	internal class XMainInterfaceMemberMonitor
	{
		// Token: 0x060101DE RID: 66014 RVA: 0x003DA480 File Offset: 0x003D8680
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

		// Token: 0x060101DF RID: 66015 RVA: 0x003DA5E8 File Offset: 0x003D87E8
		public void SetActive(bool bActive)
		{
			this.m_bActive = bActive;
			this.m_Go.SetActive(bActive);
		}

		// Token: 0x060101E0 RID: 66016 RVA: 0x003DA5FF File Offset: 0x003D87FF
		public void SetMemberData(XTeamBloodUIData data)
		{
			this.m_MemberData = data;
			this._SetBasicUI();
		}

		// Token: 0x060101E1 RID: 66017 RVA: 0x003DA610 File Offset: 0x003D8810
		private void _OnAddClicked(IXUISprite iSp)
		{
			DlgBase<XTeamInviteView, XTeamInviteBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x060101E2 RID: 66018 RVA: 0x003DA620 File Offset: 0x003D8820
		private void _OnBgClicked(IXUISprite iSp)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (!flag)
			{
				DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
			}
		}

		// Token: 0x060101E3 RID: 66019 RVA: 0x003DA650 File Offset: 0x003D8850
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

		// Token: 0x040072F0 RID: 29424
		private GameObject m_Go;

		// Token: 0x040072F1 RID: 29425
		private bool m_bActive = true;

		// Token: 0x040072F2 RID: 29426
		private GameObject m_InfoFrame;

		// Token: 0x040072F3 RID: 29427
		private GameObject m_EmptyFrame;

		// Token: 0x040072F4 RID: 29428
		private IXUISprite m_uiAvatar;

		// Token: 0x040072F5 RID: 29429
		private IXUILabel m_uiName;

		// Token: 0x040072F6 RID: 29430
		private GameObject m_uiLeader;

		// Token: 0x040072F7 RID: 29431
		private IXUILabel m_uiLevel;

		// Token: 0x040072F8 RID: 29432
		private IXUISprite m_uiAdd;

		// Token: 0x040072F9 RID: 29433
		private IXUISprite m_bg;

		// Token: 0x040072FA RID: 29434
		private XTeamBloodUIData m_MemberData;
	}
}
