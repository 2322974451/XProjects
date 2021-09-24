using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GameMallDlg : TabDlgBase<GameMallDlg>
	{

		public XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/GameMall";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GameMall);
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
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_GameMall);
			this.m_lblTitle = (base.uiBehaviour.transform.Find("Bg/T").GetComponent("XUILabel") as IXUILabel);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this._gameBuyCardPanel = base.uiBehaviour.transform.FindChild("Bg/BuycardFrame").gameObject;
			this._gameBuyCardPanel.SetActive(false);
			this._gameItemsMallPanel = base.uiBehaviour.transform.FindChild("Bg/ItemsFrame").gameObject;
			this._gameItemsMallPanel.SetActive(false);
			this._gameDescMallPanel = base.uiBehaviour.transform.FindChild("Bg/DescFrame").gameObject;
			this._gameDescMallPanel.SetActive(false);
			this._gamePayDiaMallPanel = base.uiBehaviour.transform.FindChild("Bg/DiamondFrame").gameObject;
			this._gamePayDiaMallPanel.SetActive(false);
			this._gameTabsPanel = base.uiBehaviour.transform.FindChild("Bg/TabsFrame").gameObject;
			this._gameTabsPanel.SetActive(false);
			this._gameShopPanel = base.uiBehaviour.transform.FindChild("Bg/ShopFrame").gameObject;
			this._gameShopPanel.SetActive(false);
			this._tabPerent = base.uiBehaviour.transform.FindChild("Bg");
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<GameBuyCardHander>(ref this._gameBuyCardHander);
			DlgHandlerBase.EnsureUnload<GameDescMallHander>(ref this._gameDescMallHander);
			DlgHandlerBase.EnsureUnload<GameItemsMallHander>(ref this._gameItemsMallHander);
			DlgHandlerBase.EnsureUnload<GamePayDiaMallHander>(ref this._gamePayDiaMallHander);
			DlgHandlerBase.EnsureUnload<GameMallTabsHandler>(ref this._gameTabsHander);
			DlgHandlerBase.EnsureUnload<GameMallShopHandler>(ref this._gameShopHander);
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshShopRedPoint();
		}

		protected override void OnHide()
		{
			this.doc.hotGoods.Clear();
			this.doc.isNewWeekly = false;
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GameMall, this.doc.shopRedPoint.Count != 0);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameMall, true);
			PtcC2G_RemoveIBShopIcon proto = new PtcC2G_RemoveIBShopIcon();
			XSingleton<XClientNetwork>.singleton.Send(proto);
			base.OnHide();
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			this.currSys = sys;
			this.m_lblTitle.SetText(XStringDefineProxy.GetString(sys.ToString()));
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_Mall)
			{
				switch (xsysDefine)
				{
				case XSysDefine.XSys_GameMall_Diamond:
					this.item = ItemEnum.DIAMOND;
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameBuyCardHander>(ref this._gameBuyCardHander, this._gameBuyCardPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameDescMallHander>(ref this._gameDescMallHander, this._gameDescMallPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameItemsMallHander>(ref this._gameItemsMallHander, this._gameItemsMallPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameMallTabsHandler>(ref this._gameTabsHander, this._gameTabsPanel, this, true));
					break;
				case XSysDefine.XSys_GameMall_Dragon:
					this.item = ItemEnum.DRAGON_COIN;
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameBuyCardHander>(ref this._gameBuyCardHander, this._gameBuyCardPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameDescMallHander>(ref this._gameDescMallHander, this._gameDescMallPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameItemsMallHander>(ref this._gameItemsMallHander, this._gameItemsMallPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameMallTabsHandler>(ref this._gameTabsHander, this._gameTabsPanel, this, true));
					break;
				case XSysDefine.XSys_GameMall_Pay:
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GamePayDiaMallHander>(ref this._gamePayDiaMallHander, this._gamePayDiaMallPanel, this, true));
					break;
				default:
					XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
					break;
				}
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<GameMallShopHandler>(ref this._gameShopHander, this._gameShopPanel, this, true));
			}
		}

		public void Refresh()
		{
			bool flag = this._gameTabsHander != null;
			if (flag)
			{
				this._gameTabsHander.Refresh();
			}
			bool flag2 = this._gameBuyCardHander != null;
			if (flag2)
			{
				this._gameBuyCardHander.Refresh();
			}
			bool flag3 = this._gameItemsMallHander != null;
			if (flag3)
			{
				this._gameItemsMallHander.Refresh();
			}
			bool flag4 = this._gameDescMallHander != null;
			if (flag4)
			{
				this._gameDescMallHander.Refresh();
			}
			bool flag5 = this._gameShopHander != null;
			if (flag5)
			{
				this._gameShopHander.Refresh();
			}
		}

		public void Refresh(int itemid)
		{
			this.doc.currItemID = itemid;
			this._gameBuyCardHander.Refresh();
			this._gameDescMallHander.Refresh();
		}

		public void RefreshDiamondPay()
		{
			bool flag = this._gamePayDiaMallHander != null;
			if (flag)
			{
				this._gamePayDiaMallHander.RefreshDatas();
			}
		}

		public void ShowMalltype(XSysDefine def, ulong xx)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
			{
				"def: ",
				def,
				"  long is: ",
				xx
			}), null, null, null, null, null);
		}

		public void ShowMall(XSysDefine def, MallType type, ulong itemID)
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			List<uint> uintList = XSingleton<XGlobalConfig>.singleton.GetUIntList("MallTabLevel");
			bool flag = level < uintList[type - MallType.WEEK];
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_ERR_SCENE_LEVELREQ", new object[]
				{
					string.Empty
				}), "fece00");
			}
			else
			{
				XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				specificDocument.currItemID = (int)itemID;
				this.mallType = type;
				base.ShowWorkGameSystem(def);
			}
		}

		public void ShowBuyItem(int itemid)
		{
			uint num;
			uint num2;
			this.doc.FindItem(itemid, out num, out num2);
			List<uint> uintList = XSingleton<XGlobalConfig>.singleton.GetUIntList("MallTabLevel");
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			bool flag = num <= 0U || num2 <= 0U;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip("not sail the item", "fece00");
			}
			else
			{
				bool flag2 = level < uintList[(int)(num2 - 1U)];
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_ERR_SCENE_LEVELREQ", new object[]
					{
						string.Empty
					}), "fece00");
				}
				else
				{
					XSysDefine def = (num == 9U) ? XSysDefine.XSys_GameMall_Diamond : XSysDefine.XSys_GameMall_Dragon;
					this.mallType = (MallType)num2;
					this.ShowMall(def, this.mallType, (ulong)((long)itemid));
				}
			}
		}

		public void ShowPurchase(ItemEnum _item)
		{
			this.item = _item;
			bool flag = ItemEnum.DIAMOND == _item;
			if (flag)
			{
				bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GameMall_Pay);
				if (flag2)
				{
					base.ShowWorkGameSystem(XSysDefine.XSys_GameMall_Pay);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_RECHARGE_NOT_OPEN"), "fece00");
				}
			}
			else
			{
				DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(_item);
			}
		}

		public void QueryItemsInfo()
		{
			this.doc.SendQueryItems(this.mallType);
		}

		public void RefreshShopRedPoint()
		{
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GameMall, this.doc.shopRedPoint.Count != 0);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameMall, true);
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Mall, this.doc.shopRedPoint.Count != 0);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Mall, true);
			bool flag = this._gameShopHander != null && this._gameShopHander.IsVisible();
			if (flag)
			{
				this._gameShopHander.RefreshRedPoint();
			}
		}

		public uint privilegeID = 93U;

		public GameBuyCardHander _gameBuyCardHander;

		public GameDescMallHander _gameDescMallHander;

		public GameItemsMallHander _gameItemsMallHander;

		public GamePayDiaMallHander _gamePayDiaMallHander;

		public GameMallTabsHandler _gameTabsHander;

		public GameMallShopHandler _gameShopHander;

		public GameObject _gameBuyCardPanel;

		public GameObject _gameDescMallPanel;

		public GameObject _gameItemsMallPanel;

		public GameObject _gamePayDiaMallPanel;

		public GameObject _gameTabsPanel;

		public GameObject _gameShopPanel;

		private Transform _tabPerent = null;

		private IXUILabel m_lblTitle;

		public ItemEnum item = ItemEnum.DIAMOND;

		public XSysDefine currSys = XSysDefine.XSys_GameMall_Diamond;

		public MallType mallType = MallType.WEEK;
	}
}
