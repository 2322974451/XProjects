using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A4 RID: 6052
	internal class HomePlantDlg : DlgBase<HomePlantDlg, HomePlantBehaviour>
	{
		// Token: 0x17003863 RID: 14435
		// (get) Token: 0x0600FA28 RID: 64040 RVA: 0x0039C0F0 File Offset: 0x0039A2F0
		public override string fileName
		{
			get
			{
				return "Home/PlantDlg";
			}
		}

		// Token: 0x17003864 RID: 14436
		// (get) Token: 0x0600FA29 RID: 64041 RVA: 0x0039C108 File Offset: 0x0039A308
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003865 RID: 14437
		// (get) Token: 0x0600FA2A RID: 64042 RVA: 0x0039C11C File Offset: 0x0039A31C
		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003866 RID: 14438
		// (get) Token: 0x0600FA2B RID: 64043 RVA: 0x0039C130 File Offset: 0x0039A330
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FA2C RID: 64044 RVA: 0x0039C144 File Offset: 0x0039A344
		protected override void Init()
		{
			DlgHandlerBase.EnsureCreate<HomeSeedBagHandler>(ref this.m_homeSeedBagHandler, base.uiBehaviour.m_handlerTra, false, this);
			DlgHandlerBase.EnsureCreate<HomeCropInfoHandler>(ref this.m_homeCropInfoHandler, base.uiBehaviour.m_handlerTra, false, this);
			this.m_doc = HomePlantDocument.Doc;
			this.m_doc.View = this;
			base.Init();
		}

		// Token: 0x0600FA2D RID: 64045 RVA: 0x0039C1A2 File Offset: 0x0039A3A2
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosed));
			base.RegisterEvent();
		}

		// Token: 0x0600FA2E RID: 64046 RVA: 0x0039C1CC File Offset: 0x0039A3CC
		protected override void OnShow()
		{
			base.OnShow();
			XCameraCloseUpEventArgs @event = XEventPool<XCameraCloseUpEventArgs>.GetEvent();
			@event.Target = XSingleton<XInput>.singleton.LastNpc;
			@event.Firer = XSingleton<XScene>.singleton.GameCamera;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			Farmland farmland = this.m_doc.GetFarmland(this.m_doc.CurFarmlandId);
			bool flag = farmland == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("farm is null!", null, null, null, null, null);
			}
			else
			{
				bool isFree = farmland.IsFree;
				if (isFree)
				{
					this.m_homeCropInfoHandler.SetVisible(false);
					this.m_CurrHandler = this.m_homeSeedBagHandler;
					this.m_CurrHandler.SetVisible(true);
				}
				else
				{
					this.m_homeSeedBagHandler.SetVisible(false);
					this.m_CurrHandler = this.m_homeCropInfoHandler;
					this.m_CurrHandler.SetVisible(true);
				}
			}
		}

		// Token: 0x0600FA2F RID: 64047 RVA: 0x0039C2A8 File Offset: 0x0039A4A8
		public void Show(XEntity npc)
		{
			this.m_lastNpc = npc;
			HomePlantDocument doc = HomePlantDocument.Doc;
			Farmland farmland = doc.GetFarmland(doc.CurFarmlandId);
			HomeTypeEnum homeType = doc.HomeType;
			bool flag = farmland != null;
			if (flag)
			{
				bool isLock = farmland.IsLock;
				if (isLock)
				{
					HomeTypeEnum homeTypeEnum = homeType;
					if (homeTypeEnum != HomeTypeEnum.MyHome)
					{
						if (homeTypeEnum != HomeTypeEnum.GuildHome)
						{
							doc.FetchPlantInfo(doc.CurFarmlandId);
						}
						else
						{
							XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
							bool flag2 = specificDocument.bInGuild && (ulong)specificDocument.Level < (ulong)((long)farmland.BreakLevel);
							if (flag2)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("BreakNewFarmlandLevelNotEnough_Guild"), farmland.BreakLevel), "fece00");
							}
						}
					}
					else
					{
						bool flag3 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)farmland.BreakLevel);
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("BreakNewFarmlandLevelNotEnough"), farmland.BreakLevel), "fece00");
						}
						else
						{
							int cost = 0;
							int num = 0;
							doc.GetBreakHomeFarmlandData(out num, out cost);
							bool flag4 = num == 0;
							if (flag4)
							{
								XSingleton<XDebug>.singleton.AddGreenLog("itemid cannont zero", null, null, null, null, null);
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("BreakNewFarmlandTips"), XLabelSymbolHelper.FormatCostWithIcon(cost, (ItemEnum)num)), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqBreakNewFarmland));
							}
						}
					}
				}
				else
				{
					doc.FetchPlantInfo(doc.CurFarmlandId);
				}
			}
		}

		// Token: 0x0600FA30 RID: 64048 RVA: 0x0039C458 File Offset: 0x0039A658
		protected override void OnHide()
		{
			XCameraCloseUpEndEventArgs @event = XEventPool<XCameraCloseUpEndEventArgs>.GetEvent();
			@event.Firer = XSingleton<XScene>.singleton.GameCamera;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.SetVisible(false);
			}
			base.OnHide();
		}

		// Token: 0x0600FA31 RID: 64049 RVA: 0x0039C4AA File Offset: 0x0039A6AA
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FA32 RID: 64050 RVA: 0x0039C4B4 File Offset: 0x0039A6B4
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<HomeSeedBagHandler>(ref this.m_homeSeedBagHandler);
			DlgHandlerBase.EnsureUnload<HomeCropInfoHandler>(ref this.m_homeCropInfoHandler);
			base.OnUnload();
		}

		// Token: 0x0600FA33 RID: 64051 RVA: 0x0039C4D6 File Offset: 0x0039A6D6
		public void RefreshUI()
		{
			this.ShowSubHandler();
		}

		// Token: 0x0600FA34 RID: 64052 RVA: 0x0039C4E0 File Offset: 0x0039A6E0
		private void ShowSubHandler()
		{
			Farmland farmland = this.m_doc.GetFarmland(this.m_doc.CurFarmlandId);
			bool flag = farmland == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("farm is null!", null, null, null, null, null);
			}
			else
			{
				bool isFree = farmland.IsFree;
				if (isFree)
				{
					bool flag2 = this.m_CurrHandler != this.m_homeSeedBagHandler;
					if (flag2)
					{
						this.m_CurrHandler.SetVisible(false);
						this.m_CurrHandler = this.m_homeSeedBagHandler;
					}
					bool flag3 = this.m_CurrHandler.IsVisible();
					if (flag3)
					{
						this.m_homeSeedBagHandler.RefreshUI();
					}
					else
					{
						this.m_CurrHandler.SetVisible(true);
					}
				}
				else
				{
					bool flag4 = this.m_CurrHandler != this.m_homeCropInfoHandler;
					if (flag4)
					{
						this.m_CurrHandler.SetVisible(false);
						this.m_CurrHandler = this.m_homeCropInfoHandler;
					}
					bool flag5 = this.m_CurrHandler.IsVisible();
					if (flag5)
					{
						this.m_homeCropInfoHandler.RefreshUI();
					}
					else
					{
						this.m_CurrHandler.SetVisible(true);
					}
				}
			}
		}

		// Token: 0x0600FA35 RID: 64053 RVA: 0x0039C5F4 File Offset: 0x0039A7F4
		private bool ReqBreakNewFarmland(IXUIButton btn)
		{
			HomePlantDocument doc = HomePlantDocument.Doc;
			int itemid = 0;
			int num = 0;
			doc.GetBreakHomeFarmlandData(out itemid, out num);
			bool flag = XBagDocument.BagDoc.GetItemCount(itemid) < (ulong)((long)num);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCT_DRAGONCOINLESS"), "fece00");
				result = true;
			}
			else
			{
				doc.ReqBreakNewFarmland(doc.CurFarmlandId);
				XSingleton<UiUtility>.singleton.CloseModalDlg();
				result = true;
			}
			return result;
		}

		// Token: 0x0600FA36 RID: 64054 RVA: 0x0039C66C File Offset: 0x0039A86C
		private void OnClickClosed(IXUISprite spr)
		{
			bool isPlayingAction = this.IsPlayingAction;
			if (!isPlayingAction)
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x04006D93 RID: 28051
		private DlgHandlerBase m_CurrHandler;

		// Token: 0x04006D94 RID: 28052
		private HomeSeedBagHandler m_homeSeedBagHandler;

		// Token: 0x04006D95 RID: 28053
		private HomeCropInfoHandler m_homeCropInfoHandler;

		// Token: 0x04006D96 RID: 28054
		private HomePlantDocument m_doc;

		// Token: 0x04006D97 RID: 28055
		public bool IsPlayingAction = false;

		// Token: 0x04006D98 RID: 28056
		private XEntity m_lastNpc = null;
	}
}
