using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCFavorDlg : DlgBase<XNPCFavorDlg, XNPCFavorBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/NpcBlessing/NpcBlessingDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_NPCFavor);
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.ReqNPCFavorUnionInfo();
			this.RefreshData();
			this.CheckPlayFx();
			this.m_uiBehaviour.m_Tab0.ForceSetFlag(true);
			this._ApplyTabData(this.m_CurrentTabIndex);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHelp));
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBtn));
			base.uiBehaviour.m_SendTimesBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickSendTimes));
		}

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

		protected override void OnHide()
		{
			bool flag = this.m_doc != null;
			if (flag)
			{
				this.m_doc.RemoveAllNewTags();
			}
			base.OnHide();
		}

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

		protected bool OnCloseClick(IXUIButton go)
		{
			this.Close(true);
			return true;
		}

		protected bool OnClickHelp(IXUIButton go)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_NPCFavor);
			return true;
		}

		protected bool OnClickAddBtn(IXUIButton go)
		{
			this.ShowPurchase();
			return true;
		}

		protected void OnClickSendTimes(IXUISprite go)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NPCPrivilegeHint"), new ButtonClickEventHandler(this.OnClickConfirm));
		}

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

		public void RefreshPrivilege()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_uiBehaviour.m_PrivilegeSpr.SetColor(specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court) ? Color.white : Color.black);
		}

		public void RefreshGiftTimesInfo()
		{
			base.uiBehaviour.m_SendTimesLabel.SetText(this.m_doc.GiveLeftCount.ToString());
		}

		public void RefreshRedPoint()
		{
			this.m_uiBehaviour.m_Tab0_Redpoint.SetActive(this.m_doc.HasNewNpcActive || this.m_doc.HasCanLevelUpNpc);
			this.m_uiBehaviour.m_Tab1_Redpoint.SetActive(this.m_doc.HasNewUnionActive);
			this.m_uiBehaviour.m_Tab2_Redpoint.SetActive(false);
		}

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

		public void ShowPurchase()
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NPCBuyCountHintTitle"), XStringDefineProxy.GetReplaceString("NPCBuyCountHint", new object[]
			{
				XLabelSymbolHelper.FormatCostWithIcon((int)this.m_doc.BuyCost, ItemEnum.DRAGON_COIN),
				this.m_doc.BuyLeftCount.ToString()
			}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ConfirmBuyGiftCount), new ButtonClickEventHandler(this.CancelBuy), false, XTempTipDefine.OD_START, 50);
		}

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

		private bool CancelBuy(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private XNPCFavorDocument m_doc;

		private XNPCFavorDlg.TabIndex m_CurrentTabIndex = XNPCFavorDlg.TabIndex.Relics;

		private XNPCFavorHandler m_favorHandler = null;

		private XNPCUnionHandler m_unionHandler = null;

		private XNpcAttrHandler m_attrHandler = null;

		private XFx uiFx = null;

		private const string FX_HasNewActiveNPC = "Effects/FX_Particle/UIfx/UI_swjs_Clip01";

		public enum TabIndex
		{

			Relics,

			Union,

			Addition
		}
	}
}
