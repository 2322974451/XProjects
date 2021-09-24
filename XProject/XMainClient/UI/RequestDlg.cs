using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RequestDlg : DlgBase<RequestDlg, RequestBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildCollect/RequestDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
			base.uiBehaviour.m_ClearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryRequestList();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public void Refresh(bool resetScrollPos = true)
		{
			base.uiBehaviour.m_WrapContent.SetContentCount(this._doc.List.Count, false);
			if (resetScrollPos)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

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

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClearBtnClick(IXUIButton btn)
		{
			this._doc.ClearList();
			return true;
		}

		private bool OnYesBtnClick(IXUIButton btn)
		{
			this._doc.QueryAcceptExchange(btn.ID);
			return true;
		}

		private bool OnNoBtnClick(IXUIButton btn)
		{
			this._doc.QueryRefuseExchange(btn.ID);
			return true;
		}

		private XRequestDocument _doc;
	}
}
