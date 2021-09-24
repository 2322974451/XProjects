using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ReviveDlg : DlgBase<ReviveDlg, ReviveDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/ReviveDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
			this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		private bool OnReviveButtonClicked(IXUIButton button)
		{
			this._doc.SendReviveRpc(ReviveType.ReviveItem);
			return true;
		}

		public void ShowSpecialReviveFrame()
		{
			string sprite = "";
			string atlas = "";
			XBagDocument.GetItemSmallIconAndAtlas((int)this._doc.SpecialCostID, out sprite, out atlas, 0U);
			string label = string.Format(XSingleton<XStringTable>.singleton.GetString("REVIVE_COST_NOT_ENOUGH"), string.Format("{0}{1}", XLabelSymbolHelper.FormatImage(atlas, sprite), this._doc.SpecialCostCount));
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSpecialReviveClicked));
		}

		private bool OnSpecialReviveClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.SendReviveRpc(ReviveType.ReviveMoney);
			return true;
		}

		private bool OnVipReviveClicked(IXUIButton button)
		{
			this._doc.SendReviveRpc(ReviveType.ReviveVIP);
			return true;
		}

		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this.ShowReturnFrame();
			return true;
		}

		private void ShowReturnFrame()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(this._doc.LeaveSceneTip, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.SendLeaveScene();
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_ReviveBuff.SetText(this._doc.BuffStringTip);
			string strSprite = "";
			string strAtlas = "";
			int payMemberReviveLeftCount = this._welfareDoc.GetPayMemberReviveLeftCount();
			bool flag = payMemberReviveLeftCount > 0 && this._doc.CanVipRevive && this._doc.VipReviveCount > 0U;
			if (flag)
			{
				base.uiBehaviour.m_ReviveCostIcon.SetSprite(this._welfareDoc.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Adventurer), XWelfareDocument.MEMBER_PRIVILEGE_ATLAS, false);
				base.uiBehaviour.m_ReviveCost.SetText(this._doc.VipReviveCount.ToString());
				base.uiBehaviour.m_ReviveButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnVipReviveClicked));
			}
			else
			{
				XBagDocument.GetItemSmallIconAndAtlas((int)this._doc.NormalCostID, out strSprite, out strAtlas, 0U);
				base.uiBehaviour.m_ReviveCostIcon.SetSprite(strSprite, strAtlas, false);
				base.uiBehaviour.m_ReviveCost.SetText(this._doc.NormalCostCount.ToString());
				base.uiBehaviour.m_ReviveButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReviveButtonClicked));
			}
			base.uiBehaviour.m_ReviveLeftTime.SetText(XStringDefineProxy.GetString("LEFT_REVIVE_COUNT", new object[]
			{
				this._doc.ReviveMaxTime - this._doc.ReviveUsedTime,
				this._doc.ReviveMaxTime
			}));
			base.uiBehaviour.m_ReviveFrameTween.PlayTween(true, -1f);
		}

		private XReviveDocument _doc = null;

		private XWelfareDocument _welfareDoc = null;
	}
}
