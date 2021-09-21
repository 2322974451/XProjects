using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018E0 RID: 6368
	internal class XWeddingInviteView : DlgBase<XWeddingInviteView, XWeddingInviteBehavior>
	{
		// Token: 0x17003A74 RID: 14964
		// (get) Token: 0x06010971 RID: 67953 RVA: 0x00416D08 File Offset: 0x00414F08
		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingInvite";
			}
		}

		// Token: 0x17003A75 RID: 14965
		// (get) Token: 0x06010972 RID: 67954 RVA: 0x00416D20 File Offset: 0x00414F20
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A76 RID: 14966
		// (get) Token: 0x06010973 RID: 67955 RVA: 0x00416D34 File Offset: 0x00414F34
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A77 RID: 14967
		// (get) Token: 0x06010974 RID: 67956 RVA: 0x00416D48 File Offset: 0x00414F48
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010975 RID: 67957 RVA: 0x00416D5B File Offset: 0x00414F5B
		protected override void Init()
		{
			this.InitTabs();
			this.InitProperties();
		}

		// Token: 0x06010976 RID: 67958 RVA: 0x00416D6C File Offset: 0x00414F6C
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06010977 RID: 67959 RVA: 0x00416D76 File Offset: 0x00414F76
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06010978 RID: 67960 RVA: 0x00416D80 File Offset: 0x00414F80
		protected override void OnShow()
		{
			base.OnShow();
			this._curList.Clear();
			this._curTab = 0;
			XWeddingDocument.Doc.GetWeddingInviteInfo();
		}

		// Token: 0x06010979 RID: 67961 RVA: 0x00416DA8 File Offset: 0x00414FA8
		protected override void OnHide()
		{
			bool flag = base.uiBehaviour.AllowStranger.bChecked != XWeddingDocument.Doc.PermitStranger;
			if (flag)
			{
				bool bChecked = base.uiBehaviour.AllowStranger.bChecked;
				if (bChecked)
				{
					XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_PermitStranger, 0UL, 0UL);
				}
				else
				{
					XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_ForbidStranger, 0UL, 0UL);
				}
			}
		}

		// Token: 0x0601097A RID: 67962 RVA: 0x00416E14 File Offset: 0x00415014
		private bool OnCloseClicked(IXUIButton iSp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601097B RID: 67963 RVA: 0x00416E30 File Offset: 0x00415030
		private void ResetSendFlag()
		{
			foreach (List<InviteMemberInfo> list in XActivityInviteDocument.Doc.MemberInfos.Values)
			{
				foreach (InviteMemberInfo inviteMemberInfo in list)
				{
					inviteMemberInfo.bSent = false;
				}
			}
		}

		// Token: 0x0601097C RID: 67964 RVA: 0x00416ECC File Offset: 0x004150CC
		private bool OnAddFriendClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601097D RID: 67965 RVA: 0x00416EF4 File Offset: 0x004150F4
		private void InitTabs()
		{
			this._tabs.Clear();
			int num = 0;
			foreach (object obj in base.uiBehaviour.Tabs)
			{
				Transform transform = (Transform)obj;
				IXUICheckBox ixuicheckBox = transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)num);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.RefreshItems));
				num++;
				this._tabs.Add(ixuicheckBox);
			}
		}

		// Token: 0x0601097E RID: 67966 RVA: 0x00416FAC File Offset: 0x004151AC
		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.AllowStranger.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckAllowStranger));
		}

		// Token: 0x0601097F RID: 67967 RVA: 0x00417030 File Offset: 0x00415230
		private bool OnCheckAllowStranger(IXUICheckBox iXUICheckBox)
		{
			return true;
		}

		// Token: 0x06010980 RID: 67968 RVA: 0x00417044 File Offset: 0x00415244
		public void RefreshUI()
		{
			base.uiBehaviour.ListRedPoint.SetActive(XWeddingDocument.Doc.GetInviteRoleInfoList(WeddingInviteTab.WeddingApplyList).Count > 0);
			base.uiBehaviour.AllowStranger.bChecked = XWeddingDocument.Doc.PermitStranger;
			this._tabs[this._curTab].bChecked = true;
			List<WeddingRoleInfo> inviteRoleInfoList = XWeddingDocument.Doc.GetInviteRoleInfoList(WeddingInviteTab.WeddingInvited);
			int num = (XWeddingDocument.Doc.GetMyWeddingType() == WeddingType.WeddingType_Normal) ? XSingleton<XGlobalConfig>.singleton.GetInt("NormalWeddingInviteNum") : XSingleton<XGlobalConfig>.singleton.GetInt("LuxuryWeddingInviteNum");
			base.uiBehaviour.InviteNum.SetText(inviteRoleInfoList.Count + "/" + num);
			this.RefreshContent();
		}

		// Token: 0x06010981 RID: 67969 RVA: 0x00417118 File Offset: 0x00415318
		public bool RefreshItems(IXUICheckBox go)
		{
			bool bChecked = go.bChecked;
			if (bChecked)
			{
				this._curTab = (int)go.ID;
				this.RefreshContent();
			}
			return true;
		}

		// Token: 0x06010982 RID: 67970 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void WrapContentItemInit(Transform t, int index)
		{
		}

		// Token: 0x06010983 RID: 67971 RVA: 0x0041714C File Offset: 0x0041534C
		private void RefreshContent()
		{
			this._curList = XWeddingDocument.Doc.GetInviteRoleInfoList((WeddingInviteTab)this._curTab);
			base.uiBehaviour.WrapContent.SetContentCount(this._curList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
		}

		// Token: 0x06010984 RID: 67972 RVA: 0x004171A0 File Offset: 0x004153A0
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < this._curList.Count;
			if (flag)
			{
				WeddingRoleInfo weddingRoleInfo = this._curList[index];
				IXUISprite ixuisprite = t.FindChild("head").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = t.FindChild("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				IXUILabelSymbol ixuilabelSymbol = t.Find("name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel = t.Find("name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("guild").GetComponent("XUILabel") as IXUILabel;
				Transform transform = t.Find("friendFlag");
				ixuilabel.SetText(weddingRoleInfo.name);
				ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)weddingRoleInfo.profession);
				ixuisprite2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)weddingRoleInfo.profession);
				ixuilabel3.SetText(weddingRoleInfo.ppt.ToString());
				ixuilabel4.SetText(weddingRoleInfo.guildName);
				ixuilabel2.SetText(weddingRoleInfo.level.ToString());
				IXUIButton ixuibutton = t.Find("Invite").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.SetEnable(true, false);
				ixuibutton.ID = weddingRoleInfo.roleID;
				Transform transform2 = ixuibutton.gameObject.transform.Find("InviteText");
				IXUILabel ixuilabel5 = ixuibutton.gameObject.transform.Find("ComedIn").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton2 = t.Find("Agree").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton3 = t.Find("Refuse").GetComponent("XUIButton") as IXUIButton;
				ixuibutton2.ID = weddingRoleInfo.roleID;
				ixuibutton3.ID = weddingRoleInfo.roleID;
				transform.gameObject.SetActive(this._curTab == 0);
				ixuilabel4.gameObject.SetActive(this._curTab == 1);
				ixuibutton2.gameObject.SetActive(false);
				ixuibutton3.gameObject.SetActive(false);
				switch (this._curTab)
				{
				case 0:
				case 1:
					ixuibutton.gameObject.SetActive(true);
					transform2.gameObject.SetActive(true);
					ixuilabel5.gameObject.SetActive(false);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ToInviteToCome));
					break;
				case 2:
					ixuibutton.gameObject.SetActive(true);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToChat));
					ixuibutton.SetEnable(!weddingRoleInfo.entered, false);
					transform2.gameObject.SetActive(false);
					ixuilabel5.gameObject.SetActive(true);
					ixuilabel5.SetText(weddingRoleInfo.entered ? XSingleton<XStringTable>.singleton.GetString("WeddingAreadyCome") : XSingleton<XStringTable>.singleton.GetString("WeddingInvitedNotCome"));
					break;
				case 3:
					ixuibutton2.gameObject.SetActive(true);
					ixuibutton3.gameObject.SetActive(true);
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToAgree));
					ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToRefuse));
					ixuibutton.gameObject.SetActive(false);
					break;
				}
			}
		}

		// Token: 0x06010985 RID: 67973 RVA: 0x00417560 File Offset: 0x00415760
		private bool ClickToChat(IXUIButton button)
		{
			WeddingRoleInfo weddingRoleInfo = null;
			for (int i = 0; i < this._curList.Count; i++)
			{
				bool flag = this._curList[i].roleID == button.ID;
				if (flag)
				{
					weddingRoleInfo = this._curList[i];
					break;
				}
			}
			bool flag2 = weddingRoleInfo != null;
			if (flag2)
			{
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(weddingRoleInfo.roleID, weddingRoleInfo.name, new List<uint>(), weddingRoleInfo.ppt, weddingRoleInfo.profession);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.PrivateChat(null);
			}
			return true;
		}

		// Token: 0x06010986 RID: 67974 RVA: 0x00417600 File Offset: 0x00415800
		private bool ClickToRefuse(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_DisagreeApply, id, 0UL);
			return true;
		}

		// Token: 0x06010987 RID: 67975 RVA: 0x0041762C File Offset: 0x0041582C
		private bool ClickToAgree(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_AgreeApply, id, 0UL);
			return true;
		}

		// Token: 0x06010988 RID: 67976 RVA: 0x00417658 File Offset: 0x00415858
		private bool ToInviteToCome(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_Invite, id, XWeddingDocument.Doc.MyWeddingID);
			return true;
		}

		// Token: 0x04007879 RID: 30841
		protected List<IXUICheckBox> _tabs = new List<IXUICheckBox>();

		// Token: 0x0400787A RID: 30842
		protected int _curTab;

		// Token: 0x0400787B RID: 30843
		protected List<WeddingRoleInfo> _curList = new List<WeddingRoleInfo>();
	}
}
