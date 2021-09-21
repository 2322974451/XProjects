using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CE6 RID: 3302
	internal class GameMallDlg : TabDlgBase<GameMallDlg>
	{
		// Token: 0x17003286 RID: 12934
		// (get) Token: 0x0600B8D7 RID: 47319 RVA: 0x00255D24 File Offset: 0x00253F24
		public XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		// Token: 0x17003287 RID: 12935
		// (get) Token: 0x0600B8D8 RID: 47320 RVA: 0x00255D40 File Offset: 0x00253F40
		public override string fileName
		{
			get
			{
				return "GameSystem/GameMall";
			}
		}

		// Token: 0x17003288 RID: 12936
		// (get) Token: 0x0600B8D9 RID: 47321 RVA: 0x00255D58 File Offset: 0x00253F58
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003289 RID: 12937
		// (get) Token: 0x0600B8DA RID: 47322 RVA: 0x00255D6C File Offset: 0x00253F6C
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GameMall);
			}
		}

		// Token: 0x1700328A RID: 12938
		// (get) Token: 0x0600B8DB RID: 47323 RVA: 0x00255D88 File Offset: 0x00253F88
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B8DC RID: 47324 RVA: 0x00255D9B File Offset: 0x00253F9B
		protected override void Init()
		{
			base.Init();
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_GameMall);
			this.m_lblTitle = (base.uiBehaviour.transform.Find("Bg/T").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600B8DD RID: 47325 RVA: 0x00255DD8 File Offset: 0x00253FD8
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600B8DE RID: 47326 RVA: 0x00255DE4 File Offset: 0x00253FE4
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

		// Token: 0x0600B8DF RID: 47327 RVA: 0x00255F24 File Offset: 0x00254124
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

		// Token: 0x0600B8E0 RID: 47328 RVA: 0x00255F81 File Offset: 0x00254181
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshShopRedPoint();
		}

		// Token: 0x0600B8E1 RID: 47329 RVA: 0x00255F94 File Offset: 0x00254194
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

		// Token: 0x0600B8E2 RID: 47330 RVA: 0x00256008 File Offset: 0x00254208
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

		// Token: 0x0600B8E3 RID: 47331 RVA: 0x002561AC File Offset: 0x002543AC
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

		// Token: 0x0600B8E4 RID: 47332 RVA: 0x00256239 File Offset: 0x00254439
		public void Refresh(int itemid)
		{
			this.doc.currItemID = itemid;
			this._gameBuyCardHander.Refresh();
			this._gameDescMallHander.Refresh();
		}

		// Token: 0x0600B8E5 RID: 47333 RVA: 0x00256260 File Offset: 0x00254460
		public void RefreshDiamondPay()
		{
			bool flag = this._gamePayDiaMallHander != null;
			if (flag)
			{
				this._gamePayDiaMallHander.RefreshDatas();
			}
		}

		// Token: 0x0600B8E6 RID: 47334 RVA: 0x00256287 File Offset: 0x00254487
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

		// Token: 0x0600B8E7 RID: 47335 RVA: 0x002562C8 File Offset: 0x002544C8
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

		// Token: 0x0600B8E8 RID: 47336 RVA: 0x00256358 File Offset: 0x00254558
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

		// Token: 0x0600B8E9 RID: 47337 RVA: 0x00256430 File Offset: 0x00254630
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

		// Token: 0x0600B8EA RID: 47338 RVA: 0x0025649B File Offset: 0x0025469B
		public void QueryItemsInfo()
		{
			this.doc.SendQueryItems(this.mallType);
		}

		// Token: 0x0600B8EB RID: 47339 RVA: 0x002564B0 File Offset: 0x002546B0
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

		// Token: 0x0400496C RID: 18796
		public uint privilegeID = 93U;

		// Token: 0x0400496D RID: 18797
		public GameBuyCardHander _gameBuyCardHander;

		// Token: 0x0400496E RID: 18798
		public GameDescMallHander _gameDescMallHander;

		// Token: 0x0400496F RID: 18799
		public GameItemsMallHander _gameItemsMallHander;

		// Token: 0x04004970 RID: 18800
		public GamePayDiaMallHander _gamePayDiaMallHander;

		// Token: 0x04004971 RID: 18801
		public GameMallTabsHandler _gameTabsHander;

		// Token: 0x04004972 RID: 18802
		public GameMallShopHandler _gameShopHander;

		// Token: 0x04004973 RID: 18803
		public GameObject _gameBuyCardPanel;

		// Token: 0x04004974 RID: 18804
		public GameObject _gameDescMallPanel;

		// Token: 0x04004975 RID: 18805
		public GameObject _gameItemsMallPanel;

		// Token: 0x04004976 RID: 18806
		public GameObject _gamePayDiaMallPanel;

		// Token: 0x04004977 RID: 18807
		public GameObject _gameTabsPanel;

		// Token: 0x04004978 RID: 18808
		public GameObject _gameShopPanel;

		// Token: 0x04004979 RID: 18809
		private Transform _tabPerent = null;

		// Token: 0x0400497A RID: 18810
		private IXUILabel m_lblTitle;

		// Token: 0x0400497B RID: 18811
		public ItemEnum item = ItemEnum.DIAMOND;

		// Token: 0x0400497C RID: 18812
		public XSysDefine currSys = XSysDefine.XSys_GameMall_Diamond;

		// Token: 0x0400497D RID: 18813
		public MallType mallType = MallType.WEEK;
	}
}
