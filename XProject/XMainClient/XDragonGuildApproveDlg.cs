using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A4C RID: 2636
	internal class XDragonGuildApproveDlg : DlgBase<XDragonGuildApproveDlg, XDragonGuildApproveBehaviour>
	{
		// Token: 0x17002EE7 RID: 12007
		// (get) Token: 0x06009FDC RID: 40924 RVA: 0x001A8FF0 File Offset: 0x001A71F0
		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopApproveDlg";
			}
		}

		// Token: 0x17002EE8 RID: 12008
		// (get) Token: 0x06009FDD RID: 40925 RVA: 0x001A9008 File Offset: 0x001A7208
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002EE9 RID: 12009
		// (get) Token: 0x06009FDE RID: 40926 RVA: 0x001A901C File Offset: 0x001A721C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002EEA RID: 12010
		// (get) Token: 0x06009FDF RID: 40927 RVA: 0x001A9030 File Offset: 0x001A7230
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06009FE0 RID: 40928 RVA: 0x001A9044 File Offset: 0x001A7244
		protected override void Init()
		{
			this._ApproveDoc = XDocuments.GetSpecificDocument<XDragonGuildApproveDocument>(XDragonGuildApproveDocument.uuID);
			this._ApproveDoc.DragonGuildApproveView = this;
			this._DragonGuildDoc = XDragonGuildDocument.Doc;
			DlgHandlerBase.EnsureCreate<XDragonGuildApproveSettingView>(ref this._SettingView, base.uiBehaviour.m_SettingPanel, null, true);
		}

		// Token: 0x06009FE1 RID: 40929 RVA: 0x001A9093 File Offset: 0x001A7293
		protected override void OnUnload()
		{
			this._ApproveDoc.DragonGuildApproveView = null;
			DlgHandlerBase.EnsureUnload<XDragonGuildApproveSettingView>(ref this._SettingView);
			base.OnUnload();
		}

		// Token: 0x06009FE2 RID: 40930 RVA: 0x001A90B8 File Offset: 0x001A72B8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnOneKeyCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOneKeyCancelBtnClick));
			base.uiBehaviour.m_BtnSetting.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSettingBtnClick));
			base.uiBehaviour.m_BtnSendMessage.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSendMessageBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentInit));
		}

		// Token: 0x06009FE3 RID: 40931 RVA: 0x001A917B File Offset: 0x001A737B
		protected override void OnShow()
		{
			this._ApproveDoc.ReqApproveList();
			this._SettingView.SetVisible(false);
			this.RefreshSetting();
			this.RefreshMember();
		}

		// Token: 0x06009FE4 RID: 40932 RVA: 0x001A91A8 File Offset: 0x001A73A8
		public void RefreshSetting()
		{
			DragonGuildApproveSetting approveSetting = this._ApproveDoc.ApproveSetting;
			bool flag = approveSetting.PPT == 0U;
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

		// Token: 0x06009FE5 RID: 40933 RVA: 0x001A9234 File Offset: 0x001A7434
		public void RefreshMember()
		{
			this.m_ApproveStatu = false;
			base.uiBehaviour.m_MemberCount.SetText(string.Format("{0}/{1}", this._DragonGuildDoc.BaseData.memberCount, this._DragonGuildDoc.BaseData.maxMemberCount));
		}

		// Token: 0x06009FE6 RID: 40934 RVA: 0x001A9290 File Offset: 0x001A7490
		public void RefreshList(bool bResetPosition)
		{
			List<XDragonGuildMember> approveList = this._ApproveDoc.ApproveList;
			int count = approveList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x06009FE7 RID: 40935 RVA: 0x001A92DC File Offset: 0x001A74DC
		private void _WrapContentInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = t.FindChild("BtnCancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		// Token: 0x06009FE8 RID: 40936 RVA: 0x001A9348 File Offset: 0x001A7548
		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._ApproveDoc.ApproveList.Count;
			if (!flag)
			{
				XDragonGuildMember xdragonGuildMember = this._ApproveDoc.ApproveList[index];
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("ApplyTime").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.FindChild("Portrait").GetComponent("XUISprite") as IXUISprite;
				IXUIButton ixuibutton = t.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = t.FindChild("BtnCancel").GetComponent("XUIButton") as IXUIButton;
				IXUISprite ixuisprite2 = t.FindChild("Profession").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetText(xdragonGuildMember.name);
				ixuilabel2.SetText("Lv." + xdragonGuildMember.level);
				ixuilabel3.SetText(xdragonGuildMember.ppt.ToString());
				ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString(xdragonGuildMember.time));
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(xdragonGuildMember.profession));
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(xdragonGuildMember.profession));
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton2.ID = (ulong)((long)index);
			}
		}

		// Token: 0x06009FE9 RID: 40937 RVA: 0x001A9504 File Offset: 0x001A7704
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06009FEA RID: 40938 RVA: 0x001A9520 File Offset: 0x001A7720
		private bool _OnOneKeyCancelBtnClick(IXUIButton go)
		{
			bool flag = !this._DragonGuildDoc.IsInDragonGuild();
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

		// Token: 0x06009FEB RID: 40939 RVA: 0x001A9580 File Offset: 0x001A7780
		private bool _OnOneKeyCancel(IXUIButton go)
		{
			this._ApproveDoc.ReqRejectAll();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x06009FEC RID: 40940 RVA: 0x001A95AC File Offset: 0x001A77AC
		private bool _OnSettingBtnClick(IXUIButton btn)
		{
			this._SettingView.SetVisible(true);
			return true;
		}

		// Token: 0x06009FED RID: 40941 RVA: 0x001A95CC File Offset: 0x001A77CC
		private bool _OnSendMessageBtnClick(IXUIButton btn)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendDragonGuildInvitation();
			return true;
		}

		// Token: 0x06009FEE RID: 40942 RVA: 0x001A95F4 File Offset: 0x001A77F4
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

		// Token: 0x06009FEF RID: 40943 RVA: 0x001A9630 File Offset: 0x001A7830
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

		// Token: 0x04003931 RID: 14641
		private XDragonGuildDocument _DragonGuildDoc;

		// Token: 0x04003932 RID: 14642
		private XDragonGuildApproveDocument _ApproveDoc;

		// Token: 0x04003933 RID: 14643
		private XDragonGuildApproveSettingView _SettingView;

		// Token: 0x04003934 RID: 14644
		private bool m_ApproveStatu = false;
	}
}
