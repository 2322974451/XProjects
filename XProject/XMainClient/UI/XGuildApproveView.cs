using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildApproveView : DlgBase<XGuildApproveView, XGuildApproveBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildApproveDlg";
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._ApproveDoc = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
			this._ApproveDoc.GuildApproveView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._HallDoc = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			DlgHandlerBase.EnsureCreate<XGuildApproveSettingView>(ref this._SettingView, base.uiBehaviour.m_SettingPanel, null, true);
		}

		protected override void OnUnload()
		{
			this._ApproveDoc.GuildApproveView = null;
			DlgHandlerBase.EnsureUnload<XGuildApproveSettingView>(ref this._SettingView);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnOneKeyCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOneKeyCancelBtnClick));
			base.uiBehaviour.m_BtnSetting.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSettingBtnClick));
			base.uiBehaviour.m_BtnSendMessage.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSendMessageBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentInit));
		}

		protected override void OnShow()
		{
			this._ApproveDoc.ReqApproveList();
			this._SettingView.SetVisible(false);
			this.RefreshSetting();
			this.RefreshMember();
		}

		public void RefreshSetting()
		{
			GuildApproveSetting approveSetting = this._ApproveDoc.ApproveSetting;
			bool flag = approveSetting.PPT == 0;
			if (flag)
			{
				base.uiBehaviour.m_RequiredPPT.SetText(XStringDefineProxy.GetString("NONE"));
			}
			else
			{
				base.uiBehaviour.m_RequiredPPT.SetText(approveSetting.GetStrPPT());
			}
			base.uiBehaviour.m_NeedApprove.SetText(approveSetting.autoApprove ? XStringDefineProxy.GetString("GUILD_APPROVE_NEEDNT") : XStringDefineProxy.GetString("GUILD_APPROVE_NEED"));
		}

		public void RefreshMember()
		{
			this.m_ApproveStatu = false;
			base.uiBehaviour.m_MemberCount.SetText(string.Format("{0}/{1}", this._GuildDoc.BasicData.memberCount, this._GuildDoc.BasicData.maxMemberCount));
		}

		public void RefreshList(bool bResetPosition)
		{
			List<XGuildApplyInfo> approveList = this._ApproveDoc.ApproveList;
			int count = approveList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		private void _WrapContentInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = t.FindChild("BtnCancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._ApproveDoc.ApproveList.Count;
			if (!flag)
			{
				XGuildApplyInfo xguildApplyInfo = this._ApproveDoc.ApproveList[index];
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("ApplyTime").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.FindChild("Portrait").GetComponent("XUISprite") as IXUISprite;
				IXUIButton ixuibutton = t.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = t.FindChild("BtnCancel").GetComponent("XUIButton") as IXUIButton;
				IXUISprite ixuisprite2 = t.FindChild("Profession").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetText(xguildApplyInfo.name);
				ixuilabel2.SetText("Lv." + xguildApplyInfo.level);
				ixuilabel3.SetText(xguildApplyInfo.ppt.ToString());
				ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString(xguildApplyInfo.time));
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(xguildApplyInfo.profession));
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(xguildApplyInfo.profession));
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton2.ID = (ulong)((long)index);
			}
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnOneKeyCancelBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.bInGuild;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_APPROVE_REJECT_ALL_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnOneKeyCancel));
				result = true;
			}
			return result;
		}

		private bool _OnOneKeyCancel(IXUIButton go)
		{
			this._ApproveDoc.ReqRejectAll();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _OnSettingBtnClick(IXUIButton btn)
		{
			this._SettingView.SetVisible(true);
			return true;
		}

		private bool _OnSendMessageBtnClick(IXUIButton btn)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendGuildInvitation();
			return true;
		}

		private bool _OnOKBtnClick(IXUIButton btn)
		{
			bool approveStatu = this.m_ApproveStatu;
			bool result;
			if (approveStatu)
			{
				result = false;
			}
			else
			{
				this.m_ApproveStatu = true;
				this._ApproveDoc.ReqApprove(true, (int)btn.ID);
				result = true;
			}
			return result;
		}

		private bool _OnCancelBtnClick(IXUIButton btn)
		{
			bool approveStatu = this.m_ApproveStatu;
			bool result;
			if (approveStatu)
			{
				result = false;
			}
			else
			{
				this.m_ApproveStatu = true;
				this._ApproveDoc.ReqApprove(false, (int)btn.ID);
				result = true;
			}
			return result;
		}

		private XGuildApproveDocument _ApproveDoc;

		private XGuildDocument _GuildDoc;

		private XGuildHallDocument _HallDoc;

		private XGuildApproveSettingView _SettingView;

		private bool m_ApproveStatu = false;
	}
}
