using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001911 RID: 6417
	internal class ItemSystemDlg : TabDlgBase<ItemSystemDlg>
	{
		// Token: 0x17003ADB RID: 15067
		// (get) Token: 0x06010C81 RID: 68737 RVA: 0x0043674C File Offset: 0x0043494C
		public override string fileName
		{
			get
			{
				return "ItemNew/ItemNewDlg";
			}
		}

		// Token: 0x17003ADC RID: 15068
		// (get) Token: 0x06010C82 RID: 68738 RVA: 0x00436764 File Offset: 0x00434964
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06010C83 RID: 68739 RVA: 0x00436778 File Offset: 0x00434978
		protected override void Init()
		{
			base.Init();
			this.m_leftPanelTra = base.uiBehaviour.transform.FindChild("Bg/LeftPanel");
			this.m_rightPanelTra = base.uiBehaviour.transform.FindChild("Bg/RightPanel");
			this.m_jadeFrameTra = this.m_leftPanelTra.FindChild("JadeFrame");
			this.m_useItemEffect = base.uiBehaviour.transform.Find("Bg/UseItemEffect");
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_Item);
			this.NewItemMgr.Load("New");
			this.NewItemMgr.SetupPool(this.m_rightPanelTra.gameObject);
			this.RedPointMgr.Load("ItemMorePowerfulTip2");
			this.RedPointMgr.SetupPool(this.m_rightPanelTra.gameObject);
			this.m_items = this.m_rightPanelTra.FindChild("Items").gameObject;
			this.m_Photo = (base.uiBehaviour.transform.FindChild("Bg/SysAPhoto").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06010C84 RID: 68740 RVA: 0x00436894 File Offset: 0x00434A94
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = null != this.m_useItemEffect;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(false);
			}
			this._RightPopHandler = null;
			this.m_Photo.SetVisible(true);
		}

		// Token: 0x06010C85 RID: 68741 RVA: 0x004368E0 File Offset: 0x00434AE0
		protected override void OnHide()
		{
			bool flag = this.m_useItemEffect != null;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(false);
			}
			base.OnHide();
		}

		// Token: 0x06010C86 RID: 68742 RVA: 0x00436917 File Offset: 0x00434B17
		public override void RegisterEvent()
		{
			this.m_Photo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowScreenShotShare));
			base.RegisterEvent();
		}

		// Token: 0x06010C87 RID: 68743 RVA: 0x0043693C File Offset: 0x00434B3C
		public override void StackRefresh()
		{
			bool flag = this._InfoView != null;
			if (flag)
			{
				this._InfoView.StackRefresh();
			}
			base.StackRefresh();
		}

		// Token: 0x06010C88 RID: 68744 RVA: 0x0043696C File Offset: 0x00434B6C
		public override void LeaveStackTop()
		{
			bool flag = this.m_useItemEffect != null;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(false);
			}
		}

		// Token: 0x06010C89 RID: 68745 RVA: 0x0043699C File Offset: 0x00434B9C
		protected override void OnLoad()
		{
			this.InitItems();
		}

		// Token: 0x06010C8A RID: 68746 RVA: 0x004369A8 File Offset: 0x00434BA8
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CharacterEquipBagHandler>(ref this._EquipBagHandler);
			DlgHandlerBase.EnsureUnload<XCharacterInfoView>(ref this._InfoView);
			DlgHandlerBase.EnsureUnload<CharacterEquipHandler>(ref this._equipHandler);
			DlgHandlerBase.EnsureUnload<JadeBagHandler>(ref this._JadeBagHandler);
			DlgHandlerBase.EnsureUnload<JadeEquipHandler>(ref this._JadeEquipHandler);
			DlgHandlerBase.EnsureUnload<JadeComposeHandler>(ref this._JadeComposeHandler);
			DlgHandlerBase.EnsureUnload<JadeComposeFrameHandler>(ref this._JadeComposeFrameHandler);
			DlgHandlerBase.EnsureUnload<CharacterItemBagHandler>(ref this._ItemBagHandler);
			DlgHandlerBase.EnsureUnload<EmblemBagView>(ref this._EmblemBagHandler);
			DlgHandlerBase.EnsureUnload<EmblemEquipView>(ref this._EmblemEquipHandler);
			DlgHandlerBase.EnsureUnload<XDesignationView>(ref this._DesignationHandler);
			DlgHandlerBase.EnsureUnload<FashionBagHandler>(ref this._FashionBagHandler);
			DlgHandlerBase.EnsureUnload<EquipSetWearingHandler>(ref this._WearingHandler);
			DlgHandlerBase.EnsureUnload<XCharacterAttrView<XAttrPlayerFile>>(ref this._CharacterAttrHandler);
			DlgHandlerBase.EnsureUnload<SmeltMainHandler>(ref this._SmeltMainHandler);
			DlgHandlerBase.EnsureUnload<EnhanceView>(ref this._EnhanceHandler);
			DlgHandlerBase.EnsureUnload<EnchantOperateHandler>(ref this._EnchantHandler);
			DlgHandlerBase.EnsureUnload<ForgeMainHandler>(ref this._ForgeMainHandler);
			DlgHandlerBase.EnsureUnload<ArtifactFrameHandler>(ref this._ArtifactFrameHandler);
			DlgHandlerBase.EnsureUnload<ArtifactBagHandler>(ref this._ArtifactBagHandler);
			DlgHandlerBase.EnsureUnload<EquipUpgradeHandler>(ref this._equipUpgradeHandler);
			DlgHandlerBase.EnsureUnload<EquipFusionHandler>(ref this._equipFusionHandler);
			this.BagWindow = null;
			this.NewItemMgr.Unload();
			this.RedPointMgr.Unload();
			base.OnUnload();
		}

		// Token: 0x06010C8B RID: 68747 RVA: 0x00436AE4 File Offset: 0x00434CE4
		public override void SetupHandlers(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine <= XSysDefine.XSys_Item_Jade)
			{
				if (xsysDefine == XSysDefine.XSys_Fashion)
				{
					this.m_items.SetActive(false);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<FashionBagHandler>(ref this._FashionBagHandler, this.m_rightPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XCharacterInfoView>(ref this._InfoView, this.m_leftPanelTra, true, this));
					goto IL_3B1;
				}
				if (xsysDefine == XSysDefine.XSys_Item_Equip)
				{
					this.m_items.SetActive(true);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<CharacterEquipHandler>(ref this._equipHandler, this.m_leftPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<CharacterEquipBagHandler>(ref this._EquipBagHandler, this.m_rightPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XCharacterInfoView>(ref this._InfoView, this.m_leftPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EquipSetWearingHandler>(ref this._WearingHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XCharacterAttrView<XAttrPlayerFile>>(ref this._CharacterAttrHandler, this.m_leftPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EnhanceView>(ref this._EnhanceHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SmeltMainHandler>(ref this._SmeltMainHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EnchantOperateHandler>(ref this._EnchantHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ForgeMainHandler>(ref this._ForgeMainHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EquipUpgradeHandler>(ref this._equipUpgradeHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EquipFusionHandler>(ref this._equipFusionHandler, this.m_rightPanelTra, false, this));
					this._CharacterAttrHandler.SetAttributes(XSingleton<XAttributeMgr>.singleton.XPlayerData);
					goto IL_3B1;
				}
				if (xsysDefine == XSysDefine.XSys_Item_Jade)
				{
					this.m_items.SetActive(false);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<JadeBagHandler>(ref this._JadeBagHandler, this.m_rightPanelTra, false, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<JadeEquipHandler>(ref this._JadeEquipHandler, this.m_jadeFrameTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<JadeComposeFrameHandler>(ref this._JadeComposeFrameHandler, this.m_rightPanelTra, false, this));
					goto IL_3B1;
				}
			}
			else if (xsysDefine <= XSysDefine.XSys_Bag_Item)
			{
				if (xsysDefine == XSysDefine.XSys_Char_Emblem)
				{
					this.m_items.SetActive(true);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EmblemBagView>(ref this._EmblemBagHandler, this.m_rightPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<EmblemEquipView>(ref this._EmblemEquipHandler, this.m_leftPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SmeltMainHandler>(ref this._SmeltMainHandler, this.m_rightPanelTra, false, this));
					goto IL_3B1;
				}
				if (xsysDefine == XSysDefine.XSys_Bag_Item)
				{
					this.m_items.SetActive(false);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<CharacterItemBagHandler>(ref this._ItemBagHandler, this.m_rightPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XCharacterInfoView>(ref this._InfoView, this.m_leftPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<JadeComposeFrameHandler>(ref this._JadeComposeFrameHandler, this.m_rightPanelTra, false, this));
					goto IL_3B1;
				}
			}
			else
			{
				if (xsysDefine == XSysDefine.XSys_Design_Designation)
				{
					this.m_items.SetActive(false);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XDesignationView>(ref this._DesignationHandler, this.m_rightPanelTra, true, this));
					goto IL_3B1;
				}
				if (xsysDefine == XSysDefine.XSys_Artifact)
				{
					this.m_items.SetActive(false);
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactBagHandler>(ref this._ArtifactBagHandler, this.m_rightPanelTra, true, this));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<ArtifactFrameHandler>(ref this._ArtifactFrameHandler, this.m_leftPanelTra, true, this));
					goto IL_3B1;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
			return;
			IL_3B1:
			bool flag = sys == XSysDefine.XSys_Fashion_Fashion;
			if (flag)
			{
				XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
				bool flag2 = specificDocument.HasOneFashionSuit() && XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_Guest && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Photo);
				if (flag2)
				{
					this.m_Photo.SetVisible(true);
				}
				else
				{
					this.m_Photo.SetVisible(false);
				}
			}
			else
			{
				this.m_Photo.SetVisible(false);
			}
		}

		// Token: 0x06010C8C RID: 68748 RVA: 0x00436F14 File Offset: 0x00435114
		public void PlayUseItemEffect(bool enable)
		{
			bool flag = null != this.m_useItemEffect;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(enable);
			}
		}

		// Token: 0x06010C8D RID: 68749 RVA: 0x00436F44 File Offset: 0x00435144
		public void OnLevelChange()
		{
			bool flag = this._equipHandler != null && this._equipHandler.active;
			if (flag)
			{
				this._equipHandler.ShowEquipments();
			}
			bool flag2 = this._ArtifactFrameHandler != null && this._ArtifactFrameHandler.IsVisible();
			if (flag2)
			{
				this._ArtifactFrameHandler.ShowArtifacts();
			}
		}

		// Token: 0x06010C8E RID: 68750 RVA: 0x00436FA0 File Offset: 0x004351A0
		public void ShowRightPopView(DlgHandlerBase toOpenHandler)
		{
			bool flag = toOpenHandler == null;
			if (!flag)
			{
				this.OnPopHandlerSetVisible(true, toOpenHandler);
				bool flag2 = !toOpenHandler.IsVisible();
				if (flag2)
				{
					toOpenHandler.SetVisible(true);
				}
				else
				{
					toOpenHandler.RefreshData();
				}
			}
		}

		// Token: 0x06010C8F RID: 68751 RVA: 0x00436FE0 File Offset: 0x004351E0
		public void OnPopHandlerSetVisible(bool bVisible, DlgHandlerBase toOpenHandler = null)
		{
			if (bVisible)
			{
				bool flag = this._RightPopHandler != toOpenHandler && this._RightPopHandler != null;
				if (flag)
				{
					this._RightPopHandler.SetVisible(false);
				}
				this._RightPopHandler = toOpenHandler;
			}
			else
			{
				this._RightPopHandler = null;
			}
		}

		// Token: 0x06010C90 RID: 68752 RVA: 0x0043702D File Offset: 0x0043522D
		private void InitItems()
		{
			this.BagWindow = new XBagWindow(this.m_items, null, null);
			this.BagWindow.Init();
		}

		// Token: 0x06010C91 RID: 68753 RVA: 0x00437050 File Offset: 0x00435250
		private bool OnShowScreenShotShare(IXUIButton btn)
		{
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowCharView();
			return true;
		}

		// Token: 0x04007B01 RID: 31489
		public CharacterEquipHandler _equipHandler;

		// Token: 0x04007B02 RID: 31490
		public XCharacterInfoView _InfoView;

		// Token: 0x04007B03 RID: 31491
		public JadeEquipHandler _JadeEquipHandler;

		// Token: 0x04007B04 RID: 31492
		public EmblemEquipView _EmblemEquipHandler;

		// Token: 0x04007B05 RID: 31493
		public ArtifactFrameHandler _ArtifactFrameHandler;

		// Token: 0x04007B06 RID: 31494
		public CharacterEquipBagHandler _EquipBagHandler;

		// Token: 0x04007B07 RID: 31495
		public JadeBagHandler _JadeBagHandler;

		// Token: 0x04007B08 RID: 31496
		public JadeComposeHandler _JadeComposeHandler;

		// Token: 0x04007B09 RID: 31497
		public JadeComposeFrameHandler _JadeComposeFrameHandler;

		// Token: 0x04007B0A RID: 31498
		public CharacterItemBagHandler _ItemBagHandler;

		// Token: 0x04007B0B RID: 31499
		public EmblemBagView _EmblemBagHandler;

		// Token: 0x04007B0C RID: 31500
		public XDesignationView _DesignationHandler;

		// Token: 0x04007B0D RID: 31501
		public FashionBagHandler _FashionBagHandler;

		// Token: 0x04007B0E RID: 31502
		public EquipSetWearingHandler _WearingHandler;

		// Token: 0x04007B0F RID: 31503
		public XCharacterAttrView<XAttrPlayerFile> _CharacterAttrHandler;

		// Token: 0x04007B10 RID: 31504
		public EnhanceView _EnhanceHandler;

		// Token: 0x04007B11 RID: 31505
		public SmeltMainHandler _SmeltMainHandler;

		// Token: 0x04007B12 RID: 31506
		public EnchantOperateHandler _EnchantHandler;

		// Token: 0x04007B13 RID: 31507
		public ForgeMainHandler _ForgeMainHandler;

		// Token: 0x04007B14 RID: 31508
		public ArtifactBagHandler _ArtifactBagHandler;

		// Token: 0x04007B15 RID: 31509
		public EquipUpgradeHandler _equipUpgradeHandler;

		// Token: 0x04007B16 RID: 31510
		public EquipFusionHandler _equipFusionHandler;

		// Token: 0x04007B17 RID: 31511
		private DlgHandlerBase _RightPopHandler;

		// Token: 0x04007B18 RID: 31512
		private Transform m_leftPanelTra;

		// Token: 0x04007B19 RID: 31513
		private Transform m_rightPanelTra;

		// Token: 0x04007B1A RID: 31514
		private Transform m_jadeFrameTra;

		// Token: 0x04007B1B RID: 31515
		private GameObject m_items;

		// Token: 0x04007B1C RID: 31516
		private IXUIButton m_Photo;

		// Token: 0x04007B1D RID: 31517
		private Transform m_useItemEffect;

		// Token: 0x04007B1E RID: 31518
		public XBagWindow BagWindow;

		// Token: 0x04007B1F RID: 31519
		public XItemMorePowerfulTipMgr NewItemMgr = new XItemMorePowerfulTipMgr();

		// Token: 0x04007B20 RID: 31520
		public XItemMorePowerfulTipMgr RedPointMgr = new XItemMorePowerfulTipMgr();
	}
}
