using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200188C RID: 6284
	internal class ReviveDlg : DlgBase<ReviveDlg, ReviveDlgBehaviour>
	{
		// Token: 0x170039D5 RID: 14805
		// (get) Token: 0x060105BB RID: 67003 RVA: 0x003FB230 File Offset: 0x003F9430
		public override string fileName
		{
			get
			{
				return "Battle/ReviveDlg";
			}
		}

		// Token: 0x170039D6 RID: 14806
		// (get) Token: 0x060105BC RID: 67004 RVA: 0x003FB248 File Offset: 0x003F9448
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039D7 RID: 14807
		// (get) Token: 0x060105BD RID: 67005 RVA: 0x003FB25C File Offset: 0x003F945C
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060105BE RID: 67006 RVA: 0x003FB26F File Offset: 0x003F946F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
			this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
		}

		// Token: 0x060105BF RID: 67007 RVA: 0x003FB299 File Offset: 0x003F9499
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		// Token: 0x060105C0 RID: 67008 RVA: 0x003FB2C0 File Offset: 0x003F94C0
		private bool OnReviveButtonClicked(IXUIButton button)
		{
			this._doc.SendReviveRpc(ReviveType.ReviveItem);
			return true;
		}

		// Token: 0x060105C1 RID: 67009 RVA: 0x003FB2E0 File Offset: 0x003F94E0
		public void ShowSpecialReviveFrame()
		{
			string sprite = "";
			string atlas = "";
			XBagDocument.GetItemSmallIconAndAtlas((int)this._doc.SpecialCostID, out sprite, out atlas, 0U);
			string label = string.Format(XSingleton<XStringTable>.singleton.GetString("REVIVE_COST_NOT_ENOUGH"), string.Format("{0}{1}", XLabelSymbolHelper.FormatImage(atlas, sprite), this._doc.SpecialCostCount));
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSpecialReviveClicked));
		}

		// Token: 0x060105C2 RID: 67010 RVA: 0x003FB374 File Offset: 0x003F9574
		private bool OnSpecialReviveClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.SendReviveRpc(ReviveType.ReviveMoney);
			return true;
		}

		// Token: 0x060105C3 RID: 67011 RVA: 0x003FB3A0 File Offset: 0x003F95A0
		private bool OnVipReviveClicked(IXUIButton button)
		{
			this._doc.SendReviveRpc(ReviveType.ReviveVIP);
			return true;
		}

		// Token: 0x060105C4 RID: 67012 RVA: 0x003FB3C0 File Offset: 0x003F95C0
		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this.ShowReturnFrame();
			return true;
		}

		// Token: 0x060105C5 RID: 67013 RVA: 0x003FB3DA File Offset: 0x003F95DA
		private void ShowReturnFrame()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(this._doc.LeaveSceneTip, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		// Token: 0x060105C6 RID: 67014 RVA: 0x003FB414 File Offset: 0x003F9614
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.SendLeaveScene();
			return true;
		}

		// Token: 0x060105C7 RID: 67015 RVA: 0x003FB440 File Offset: 0x003F9640
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

		// Token: 0x040075EB RID: 30187
		private XReviveDocument _doc = null;

		// Token: 0x040075EC RID: 30188
		private XWelfareDocument _welfareDoc = null;
	}
}
