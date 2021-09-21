using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200175D RID: 5981
	internal class RequestDlg : DlgBase<RequestDlg, RequestBehaviour>
	{
		// Token: 0x17003805 RID: 14341
		// (get) Token: 0x0600F708 RID: 63240 RVA: 0x003828E8 File Offset: 0x00380AE8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003806 RID: 14342
		// (get) Token: 0x0600F709 RID: 63241 RVA: 0x003828FC File Offset: 0x00380AFC
		public override string fileName
		{
			get
			{
				return "Guild/GuildCollect/RequestDlg";
			}
		}

		// Token: 0x0600F70A RID: 63242 RVA: 0x00382913 File Offset: 0x00380B13
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
		}

		// Token: 0x0600F70B RID: 63243 RVA: 0x00382930 File Offset: 0x00380B30
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
			base.uiBehaviour.m_ClearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearBtnClick));
		}

		// Token: 0x0600F70C RID: 63244 RVA: 0x0038299C File Offset: 0x00380B9C
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryRequestList();
		}

		// Token: 0x0600F70D RID: 63245 RVA: 0x003829B2 File Offset: 0x00380BB2
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F70E RID: 63246 RVA: 0x003829BC File Offset: 0x00380BBC
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F70F RID: 63247 RVA: 0x003829C8 File Offset: 0x00380BC8
		public void Refresh(bool resetScrollPos = true)
		{
			base.uiBehaviour.m_WrapContent.SetContentCount(this._doc.List.Count, false);
			if (resetScrollPos)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x0600F710 RID: 63248 RVA: 0x00382A10 File Offset: 0x00380C10
		private void DesWrapListUpdated(Transform t, int index)
		{
			PartyExchangeItemInfo partyExchangeItemInfo = this._doc.List[index];
			IXUISprite ixuisprite = t.FindChild("Head").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.FindChild("Prof").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.FindChild("YesBtn").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = t.FindChild("NoBtn").GetComponent("XUIButton") as IXUIButton;
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)partyExchangeItemInfo.profession_id);
			ixuilabel.SetText(partyExchangeItemInfo.name);
			ixuilabel2.SetText(partyExchangeItemInfo.level.ToString());
			ixuilabel3.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)partyExchangeItemInfo.profession_id));
			ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)partyExchangeItemInfo.time, 3, 0) + XStringDefineProxy.GetString("AGO"));
			ixuibutton.ID = partyExchangeItemInfo.role_id;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnYesBtnClick));
			ixuibutton2.ID = partyExchangeItemInfo.role_id;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNoBtnClick));
		}

		// Token: 0x0600F711 RID: 63249 RVA: 0x00382BB0 File Offset: 0x00380DB0
		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F712 RID: 63250 RVA: 0x00382BCC File Offset: 0x00380DCC
		private bool OnClearBtnClick(IXUIButton btn)
		{
			this._doc.ClearList();
			return true;
		}

		// Token: 0x0600F713 RID: 63251 RVA: 0x00382BEC File Offset: 0x00380DEC
		private bool OnYesBtnClick(IXUIButton btn)
		{
			this._doc.QueryAcceptExchange(btn.ID);
			return true;
		}

		// Token: 0x0600F714 RID: 63252 RVA: 0x00382C14 File Offset: 0x00380E14
		private bool OnNoBtnClick(IXUIButton btn)
		{
			this._doc.QueryRefuseExchange(btn.ID);
			return true;
		}

		// Token: 0x04006B6E RID: 27502
		private XRequestDocument _doc;
	}
}
