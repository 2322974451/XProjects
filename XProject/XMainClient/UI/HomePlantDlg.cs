using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomePlantDlg : DlgBase<HomePlantDlg, HomePlantBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Home/PlantDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			DlgHandlerBase.EnsureCreate<HomeSeedBagHandler>(ref this.m_homeSeedBagHandler, base.uiBehaviour.m_handlerTra, false, this);
			DlgHandlerBase.EnsureCreate<HomeCropInfoHandler>(ref this.m_homeCropInfoHandler, base.uiBehaviour.m_handlerTra, false, this);
			this.m_doc = HomePlantDocument.Doc;
			this.m_doc.View = this;
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosed));
			base.RegisterEvent();
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<HomeSeedBagHandler>(ref this.m_homeSeedBagHandler);
			DlgHandlerBase.EnsureUnload<HomeCropInfoHandler>(ref this.m_homeCropInfoHandler);
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.ShowSubHandler();
		}

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

		private void OnClickClosed(IXUISprite spr)
		{
			bool isPlayingAction = this.IsPlayingAction;
			if (!isPlayingAction)
			{
				this.SetVisible(false, true);
			}
		}

		private DlgHandlerBase m_CurrHandler;

		private HomeSeedBagHandler m_homeSeedBagHandler;

		private HomeCropInfoHandler m_homeCropInfoHandler;

		private HomePlantDocument m_doc;

		public bool IsPlayingAction = false;

		private XEntity m_lastNpc = null;
	}
}
