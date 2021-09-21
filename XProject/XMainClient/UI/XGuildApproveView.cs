using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018AB RID: 6315
	internal class XGuildApproveView : DlgBase<XGuildApproveView, XGuildApproveBehaviour>
	{
		// Token: 0x17003A19 RID: 14873
		// (get) Token: 0x06010746 RID: 67398 RVA: 0x00406A68 File Offset: 0x00404C68
		public override string fileName
		{
			get
			{
				return "Guild/GuildApproveDlg";
			}
		}

		// Token: 0x17003A1A RID: 14874
		// (get) Token: 0x06010747 RID: 67399 RVA: 0x00406A80 File Offset: 0x00404C80
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A1B RID: 14875
		// (get) Token: 0x06010748 RID: 67400 RVA: 0x00406A94 File Offset: 0x00404C94
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A1C RID: 14876
		// (get) Token: 0x06010749 RID: 67401 RVA: 0x00406AA8 File Offset: 0x00404CA8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A1D RID: 14877
		// (get) Token: 0x0601074A RID: 67402 RVA: 0x00406ABC File Offset: 0x00404CBC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A1E RID: 14878
		// (get) Token: 0x0601074B RID: 67403 RVA: 0x00406AD0 File Offset: 0x00404CD0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601074C RID: 67404 RVA: 0x00406AE4 File Offset: 0x00404CE4
		protected override void Init()
		{
			this._ApproveDoc = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
			this._ApproveDoc.GuildApproveView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._HallDoc = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			DlgHandlerBase.EnsureCreate<XGuildApproveSettingView>(ref this._SettingView, base.uiBehaviour.m_SettingPanel, null, true);
		}

		// Token: 0x0601074D RID: 67405 RVA: 0x00406B48 File Offset: 0x00404D48
		protected override void OnUnload()
		{
			this._ApproveDoc.GuildApproveView = null;
			DlgHandlerBase.EnsureUnload<XGuildApproveSettingView>(ref this._SettingView);
			base.OnUnload();
		}

		// Token: 0x0601074E RID: 67406 RVA: 0x00406B6C File Offset: 0x00404D6C
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnOneKeyCancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOneKeyCancelBtnClick));
			base.uiBehaviour.m_BtnSetting.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSettingBtnClick));
			base.uiBehaviour.m_BtnSendMessage.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSendMessageBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentInit));
		}

		// Token: 0x0601074F RID: 67407 RVA: 0x00406C28 File Offset: 0x00404E28
		protected override void OnShow()
		{
			this._ApproveDoc.ReqApproveList();
			this._SettingView.SetVisible(false);
			this.RefreshSetting();
			this.RefreshMember();
		}

		// Token: 0x06010750 RID: 67408 RVA: 0x00406C54 File Offset: 0x00404E54
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

		// Token: 0x06010751 RID: 67409 RVA: 0x00406CE0 File Offset: 0x00404EE0
		public void RefreshMember()
		{
			this.m_ApproveStatu = false;
			base.uiBehaviour.m_MemberCount.SetText(string.Format("{0}/{1}", this._GuildDoc.BasicData.memberCount, this._GuildDoc.BasicData.maxMemberCount));
		}

		// Token: 0x06010752 RID: 67410 RVA: 0x00406D3C File Offset: 0x00404F3C
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

		// Token: 0x06010753 RID: 67411 RVA: 0x00406D88 File Offset: 0x00404F88
		private void _WrapContentInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = t.FindChild("BtnCancel").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		// Token: 0x06010754 RID: 67412 RVA: 0x00406DF4 File Offset: 0x00404FF4
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

		// Token: 0x06010755 RID: 67413 RVA: 0x00406FB0 File Offset: 0x004051B0
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010756 RID: 67414 RVA: 0x00406FCC File Offset: 0x004051CC
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

		// Token: 0x06010757 RID: 67415 RVA: 0x0040702C File Offset: 0x0040522C
		private bool _OnOneKeyCancel(IXUIButton go)
		{
			this._ApproveDoc.ReqRejectAll();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x06010758 RID: 67416 RVA: 0x00407058 File Offset: 0x00405258
		private bool _OnSettingBtnClick(IXUIButton btn)
		{
			this._SettingView.SetVisible(true);
			return true;
		}

		// Token: 0x06010759 RID: 67417 RVA: 0x00407078 File Offset: 0x00405278
		private bool _OnSendMessageBtnClick(IXUIButton btn)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendGuildInvitation();
			return true;
		}

		// Token: 0x0601075A RID: 67418 RVA: 0x004070A0 File Offset: 0x004052A0
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

		// Token: 0x0601075B RID: 67419 RVA: 0x004070DC File Offset: 0x004052DC
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

		// Token: 0x040076E5 RID: 30437
		private XGuildApproveDocument _ApproveDoc;

		// Token: 0x040076E6 RID: 30438
		private XGuildDocument _GuildDoc;

		// Token: 0x040076E7 RID: 30439
		private XGuildHallDocument _HallDoc;

		// Token: 0x040076E8 RID: 30440
		private XGuildApproveSettingView _SettingView;

		// Token: 0x040076E9 RID: 30441
		private bool m_ApproveStatu = false;
	}
}
