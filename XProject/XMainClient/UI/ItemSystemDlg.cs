using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemSystemDlg : TabDlgBase<ItemSystemDlg>
	{

		public override string fileName
		{
			get
			{
				return "ItemNew/ItemNewDlg";
			}
		}

		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

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

		protected override void OnHide()
		{
			bool flag = this.m_useItemEffect != null;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(false);
			}
			base.OnHide();
		}

		public override void RegisterEvent()
		{
			this.m_Photo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowScreenShotShare));
			base.RegisterEvent();
		}

		public override void StackRefresh()
		{
			bool flag = this._InfoView != null;
			if (flag)
			{
				this._InfoView.StackRefresh();
			}
			base.StackRefresh();
		}

		public override void LeaveStackTop()
		{
			bool flag = this.m_useItemEffect != null;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(false);
			}
		}

		protected override void OnLoad()
		{
			this.InitItems();
		}

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

		public void PlayUseItemEffect(bool enable)
		{
			bool flag = null != this.m_useItemEffect;
			if (flag)
			{
				this.m_useItemEffect.gameObject.SetActive(enable);
			}
		}

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

		private void InitItems()
		{
			this.BagWindow = new XBagWindow(this.m_items, null, null);
			this.BagWindow.Init();
		}

		private bool OnShowScreenShotShare(IXUIButton btn)
		{
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowCharView();
			return true;
		}

		public CharacterEquipHandler _equipHandler;

		public XCharacterInfoView _InfoView;

		public JadeEquipHandler _JadeEquipHandler;

		public EmblemEquipView _EmblemEquipHandler;

		public ArtifactFrameHandler _ArtifactFrameHandler;

		public CharacterEquipBagHandler _EquipBagHandler;

		public JadeBagHandler _JadeBagHandler;

		public JadeComposeHandler _JadeComposeHandler;

		public JadeComposeFrameHandler _JadeComposeFrameHandler;

		public CharacterItemBagHandler _ItemBagHandler;

		public EmblemBagView _EmblemBagHandler;

		public XDesignationView _DesignationHandler;

		public FashionBagHandler _FashionBagHandler;

		public EquipSetWearingHandler _WearingHandler;

		public XCharacterAttrView<XAttrPlayerFile> _CharacterAttrHandler;

		public EnhanceView _EnhanceHandler;

		public SmeltMainHandler _SmeltMainHandler;

		public EnchantOperateHandler _EnchantHandler;

		public ForgeMainHandler _ForgeMainHandler;

		public ArtifactBagHandler _ArtifactBagHandler;

		public EquipUpgradeHandler _equipUpgradeHandler;

		public EquipFusionHandler _equipFusionHandler;

		private DlgHandlerBase _RightPopHandler;

		private Transform m_leftPanelTra;

		private Transform m_rightPanelTra;

		private Transform m_jadeFrameTra;

		private GameObject m_items;

		private IXUIButton m_Photo;

		private Transform m_useItemEffect;

		public XBagWindow BagWindow;

		public XItemMorePowerfulTipMgr NewItemMgr = new XItemMorePowerfulTipMgr();

		public XItemMorePowerfulTipMgr RedPointMgr = new XItemMorePowerfulTipMgr();
	}
}
