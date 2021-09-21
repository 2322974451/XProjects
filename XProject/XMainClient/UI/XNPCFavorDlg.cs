using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D2 RID: 6098
	internal class XNPCFavorDlg : DlgBase<XNPCFavorDlg, XNPCFavorBehaviour>
	{
		// Token: 0x170038A3 RID: 14499
		// (get) Token: 0x0600FC91 RID: 64657 RVA: 0x003AF028 File Offset: 0x003AD228
		public override string fileName
		{
			get
			{
				return "GameSystem/NpcBlessing/NpcBlessingDlg";
			}
		}

		// Token: 0x170038A4 RID: 14500
		// (get) Token: 0x0600FC92 RID: 64658 RVA: 0x003AF040 File Offset: 0x003AD240
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_NPCFavor);
			}
		}

		// Token: 0x170038A5 RID: 14501
		// (get) Token: 0x0600FC93 RID: 64659 RVA: 0x003AF05C File Offset: 0x003AD25C
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600FC94 RID: 64660 RVA: 0x003AF070 File Offset: 0x003AD270
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.m_doc.View = this;
			this.m_uiBehaviour.m_Tab0.ID = 0UL;
			this.m_uiBehaviour.m_Tab0.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
			this.m_uiBehaviour.m_Tab1.ID = 1UL;
			this.m_uiBehaviour.m_Tab1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
			this.m_uiBehaviour.m_Tab2.ID = 2UL;
			this.m_uiBehaviour.m_Tab2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
			DlgHandlerBase.EnsureCreate<XNPCFavorHandler>(ref this.m_favorHandler, this.m_uiBehaviour.m_handlersTra, false, this);
			DlgHandlerBase.EnsureCreate<XNPCUnionHandler>(ref this.m_unionHandler, this.m_uiBehaviour.m_handlersTra, false, this);
			DlgHandlerBase.EnsureCreate<XNpcAttrHandler>(ref this.m_attrHandler, this.m_uiBehaviour.m_handlersTra, false, this);
		}

		// Token: 0x0600FC95 RID: 64661 RVA: 0x003AF17C File Offset: 0x003AD37C
		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.ReqNPCFavorUnionInfo();
			this.RefreshData();
			this.CheckPlayFx();
			this.m_uiBehaviour.m_Tab0.ForceSetFlag(true);
			this._ApplyTabData(this.m_CurrentTabIndex);
		}

		// Token: 0x0600FC96 RID: 64662 RVA: 0x003AF1CC File Offset: 0x003AD3CC
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHelp));
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBtn));
			base.uiBehaviour.m_SendTimesBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickSendTimes));
		}

		// Token: 0x0600FC97 RID: 64663 RVA: 0x003AF250 File Offset: 0x003AD450
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XNPCFavorHandler>(ref this.m_favorHandler);
			DlgHandlerBase.EnsureUnload<XNPCUnionHandler>(ref this.m_unionHandler);
			DlgHandlerBase.EnsureUnload<XNpcAttrHandler>(ref this.m_attrHandler);
			bool flag = this.m_doc != null;
			if (flag)
			{
				this.m_doc.View = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600FC98 RID: 64664 RVA: 0x003AF2A4 File Offset: 0x003AD4A4
		protected override void OnHide()
		{
			bool flag = this.m_doc != null;
			if (flag)
			{
				this.m_doc.RemoveAllNewTags();
			}
			base.OnHide();
		}

		// Token: 0x0600FC99 RID: 64665 RVA: 0x003AF2D4 File Offset: 0x003AD4D4
		private void CheckPlayFx()
		{
			bool hasNewNpcActive = this.m_doc.HasNewNpcActive;
			if (hasNewNpcActive)
			{
				bool flag = this.uiFx == null;
				if (flag)
				{
					this.uiFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_swjs_Clip01", base.uiBehaviour.m_effect, false);
				}
				this.uiFx.Play();
			}
		}

		// Token: 0x0600FC9A RID: 64666 RVA: 0x003AF330 File Offset: 0x003AD530
		public void Close(bool bWithAnim = true)
		{
			if (bWithAnim)
			{
				this.SetVisibleWithAnimation(false, null);
			}
			else
			{
				this.SetVisible(false, true);
			}
			bool flag = this.uiFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.uiFx, true);
			}
			this.uiFx = null;
		}

		// Token: 0x0600FC9B RID: 64667 RVA: 0x003AF380 File Offset: 0x003AD580
		protected bool OnCloseClick(IXUIButton go)
		{
			this.Close(true);
			return true;
		}

		// Token: 0x0600FC9C RID: 64668 RVA: 0x003AF39C File Offset: 0x003AD59C
		protected bool OnClickHelp(IXUIButton go)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_NPCFavor);
			return true;
		}

		// Token: 0x0600FC9D RID: 64669 RVA: 0x003AF3C0 File Offset: 0x003AD5C0
		protected bool OnClickAddBtn(IXUIButton go)
		{
			this.ShowPurchase();
			return true;
		}

		// Token: 0x0600FC9E RID: 64670 RVA: 0x003AF3DA File Offset: 0x003AD5DA
		protected void OnClickSendTimes(IXUISprite go)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NPCPrivilegeHint"), new ButtonClickEventHandler(this.OnClickConfirm));
		}

		// Token: 0x0600FC9F RID: 64671 RVA: 0x003AF400 File Offset: 0x003AD600
		private bool OnClickConfirm(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = !specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
			if (flag)
			{
				this.Close(true);
				XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_KingdomPrivilege, 0UL);
			}
			return true;
		}

		// Token: 0x0600FCA0 RID: 64672 RVA: 0x003AF458 File Offset: 0x003AD658
		private bool OnClickTab(IXUICheckBox cbx)
		{
			bool bChecked = cbx.bChecked;
			if (bChecked)
			{
				this.m_CurrentTabIndex = (XNPCFavorDlg.TabIndex)cbx.ID;
				this._ApplyTabData(this.m_CurrentTabIndex);
			}
			return true;
		}

		// Token: 0x0600FCA1 RID: 64673 RVA: 0x003AF494 File Offset: 0x003AD694
		private void _ApplyTabData(XNPCFavorDlg.TabIndex tab)
		{
			bool flag = base.IsVisible();
			bool flag2 = flag;
			if (flag2)
			{
				switch (this.m_CurrentTabIndex)
				{
				case XNPCFavorDlg.TabIndex.Relics:
					this.m_favorHandler.SetVisible(true);
					this.m_unionHandler.SetVisible(false);
					this.m_attrHandler.SetVisible(false);
					break;
				case XNPCFavorDlg.TabIndex.Union:
					this.m_favorHandler.SetVisible(false);
					this.m_unionHandler.SetVisible(true);
					this.m_attrHandler.SetVisible(false);
					break;
				case XNPCFavorDlg.TabIndex.Addition:
					this.m_favorHandler.SetVisible(false);
					this.m_unionHandler.SetVisible(false);
					this.m_attrHandler.SetVisible(true);
					break;
				}
			}
		}

		// Token: 0x0600FCA2 RID: 64674 RVA: 0x003AF554 File Offset: 0x003AD754
		public void RefreshData()
		{
			this.RefreshRedPoint();
			this.RefreshPrivilege();
			this.RefreshGiftTimesInfo();
			bool flag = this.m_favorHandler.IsVisible();
			if (flag)
			{
				this.m_favorHandler.RefreshData();
			}
			bool flag2 = this.m_unionHandler.IsVisible();
			if (flag2)
			{
				this.m_unionHandler.RefreshData();
			}
			bool flag3 = this.m_attrHandler.IsVisible();
			if (flag3)
			{
				this.m_attrHandler.RefreshData();
			}
		}

		// Token: 0x0600FCA3 RID: 64675 RVA: 0x003AF5C8 File Offset: 0x003AD7C8
		public void RefreshPrivilege()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_uiBehaviour.m_PrivilegeSpr.SetColor(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court) ? Color.white : Color.black);
		}

		// Token: 0x0600FCA4 RID: 64676 RVA: 0x003AF608 File Offset: 0x003AD808
		public void RefreshGiftTimesInfo()
		{
			base.uiBehaviour.m_SendTimesLabel.SetText(this.m_doc.GiveLeftCount.ToString());
		}

		// Token: 0x0600FCA5 RID: 64677 RVA: 0x003AF63C File Offset: 0x003AD83C
		public void RefreshRedPoint()
		{
			this.m_uiBehaviour.m_Tab0_Redpoint.SetActive(this.m_doc.HasNewNpcActive || this.m_doc.HasCanLevelUpNpc);
			this.m_uiBehaviour.m_Tab1_Redpoint.SetActive(this.m_doc.HasNewUnionActive);
			this.m_uiBehaviour.m_Tab2_Redpoint.SetActive(false);
		}

		// Token: 0x0600FCA6 RID: 64678 RVA: 0x003AF6A4 File Offset: 0x003AD8A4
		public void SetTabRedpoint(XNPCFavorDlg.TabIndex tabIndex, bool flag)
		{
			switch (tabIndex)
			{
			case XNPCFavorDlg.TabIndex.Relics:
				this.m_uiBehaviour.m_Tab0_Redpoint.SetActive(flag);
				break;
			case XNPCFavorDlg.TabIndex.Union:
				this.m_uiBehaviour.m_Tab1_Redpoint.SetActive(flag);
				break;
			case XNPCFavorDlg.TabIndex.Addition:
				this.m_uiBehaviour.m_Tab2_Redpoint.SetActive(flag);
				break;
			}
		}

		// Token: 0x0600FCA7 RID: 64679 RVA: 0x003AF704 File Offset: 0x003AD904
		public void SkipToNpc(uint npcId)
		{
			this.m_uiBehaviour.m_Tab0.ForceSetFlag(true);
			this.m_CurrentTabIndex = XNPCFavorDlg.TabIndex.Relics;
			this._ApplyTabData(this.m_CurrentTabIndex);
			bool flag = this.m_favorHandler.IsVisible();
			if (flag)
			{
				this.m_favorHandler.SkipToNpc(npcId);
			}
		}

		// Token: 0x0600FCA8 RID: 64680 RVA: 0x003AF754 File Offset: 0x003AD954
		public void ShowPurchase()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NPCBuyCountHintTitle"), XStringDefineProxy.GetReplaceString("NPCBuyCountHint", new object[]
			{
				XLabelSymbolHelper.FormatCostWithIcon((int)this.m_doc.BuyCost, ItemEnum.DRAGON_COIN),
				this.m_doc.BuyLeftCount.ToString()
			}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ConfirmBuyGiftCount), new ButtonClickEventHandler(this.CancelBuy), false, XTempTipDefine.OD_START, 50);
		}

		// Token: 0x0600FCA9 RID: 64681 RVA: 0x003AF7E4 File Offset: 0x003AD9E4
		private bool ConfirmBuyGiftCount(IXUIButton btn)
		{
			bool flag = this.m_doc.BuyLeftCount <= 0U;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCHasNoBuyCount"), "fece00");
			}
			else
			{
				this.m_doc.ReqSrvBuyGiftCount();
			}
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FCAA RID: 64682 RVA: 0x003AF848 File Offset: 0x003ADA48
		private bool CancelBuy(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x04006F11 RID: 28433
		private XNPCFavorDocument m_doc;

		// Token: 0x04006F12 RID: 28434
		private XNPCFavorDlg.TabIndex m_CurrentTabIndex = XNPCFavorDlg.TabIndex.Relics;

		// Token: 0x04006F13 RID: 28435
		private XNPCFavorHandler m_favorHandler = null;

		// Token: 0x04006F14 RID: 28436
		private XNPCUnionHandler m_unionHandler = null;

		// Token: 0x04006F15 RID: 28437
		private XNpcAttrHandler m_attrHandler = null;

		// Token: 0x04006F16 RID: 28438
		private XFx uiFx = null;

		// Token: 0x04006F17 RID: 28439
		private const string FX_HasNewActiveNPC = "Effects/FX_Particle/UIfx/UI_swjs_Clip01";

		// Token: 0x02001A0C RID: 6668
		public enum TabIndex
		{
			// Token: 0x04008216 RID: 33302
			Relics,
			// Token: 0x04008217 RID: 33303
			Union,
			// Token: 0x04008218 RID: 33304
			Addition
		}
	}
}
