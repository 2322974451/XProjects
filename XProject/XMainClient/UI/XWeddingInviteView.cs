using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWeddingInviteView : DlgBase<XWeddingInviteView, XWeddingInviteBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingInvite";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.InitTabs();
			this.InitProperties();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._curList.Clear();
			this._curTab = 0;
			XWeddingDocument.Doc.GetWeddingInviteInfo();
		}

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

		private bool OnCloseClicked(IXUIButton iSp)
		{
			this.SetVisible(false, true);
			return true;
		}

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

		private bool OnAddFriendClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			this.SetVisible(false, true);
			return true;
		}

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

		private void InitProperties()
		{
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.AllowStranger.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckAllowStranger));
		}

		private bool OnCheckAllowStranger(IXUICheckBox iXUICheckBox)
		{
			return true;
		}

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

		private void WrapContentItemInit(Transform t, int index)
		{
		}

		private void RefreshContent()
		{
			this._curList = XWeddingDocument.Doc.GetInviteRoleInfoList((WeddingInviteTab)this._curTab);
			base.uiBehaviour.WrapContent.SetContentCount(this._curList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
		}

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

		private bool ClickToRefuse(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_DisagreeApply, id, 0UL);
			return true;
		}

		private bool ClickToAgree(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_AgreeApply, id, 0UL);
			return true;
		}

		private bool ToInviteToCome(IXUIButton button)
		{
			ulong id = button.ID;
			XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_Invite, id, XWeddingDocument.Doc.MyWeddingID);
			return true;
		}

		protected List<IXUICheckBox> _tabs = new List<IXUICheckBox>();

		protected int _curTab;

		protected List<WeddingRoleInfo> _curList = new List<WeddingRoleInfo>();
	}
}
