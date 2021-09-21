using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001815 RID: 6165
	internal class SuperRiskDlg : DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>
	{
		// Token: 0x17003902 RID: 14594
		// (get) Token: 0x0600FFC1 RID: 65473 RVA: 0x003C8704 File Offset: 0x003C6904
		private XSuperRiskDocument _doc
		{
			get
			{
				return XSuperRiskDocument.Doc;
			}
		}

		// Token: 0x17003903 RID: 14595
		// (get) Token: 0x0600FFC2 RID: 65474 RVA: 0x003C871C File Offset: 0x003C691C
		public override string fileName
		{
			get
			{
				return "GameSystem/SuperRisk/SuperRiskDlg";
			}
		}

		// Token: 0x17003904 RID: 14596
		// (get) Token: 0x0600FFC3 RID: 65475 RVA: 0x003C8734 File Offset: 0x003C6934
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003905 RID: 14597
		// (get) Token: 0x0600FFC4 RID: 65476 RVA: 0x003C8748 File Offset: 0x003C6948
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003906 RID: 14598
		// (get) Token: 0x0600FFC5 RID: 65477 RVA: 0x003C875C File Offset: 0x003C695C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003907 RID: 14599
		// (get) Token: 0x0600FFC6 RID: 65478 RVA: 0x003C8770 File Offset: 0x003C6970
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FFC7 RID: 65479 RVA: 0x003C8783 File Offset: 0x003C6983
		protected override void Init()
		{
			DlgHandlerBase.EnsureCreate<SuperRiskGameHandler>(ref this._GameHandler, base.uiBehaviour.m_RiskMapPanel.transform, false, null);
			DlgHandlerBase.EnsureCreate<SuperRiskSelectMapHandler>(ref this._SelectMapHandler, base.uiBehaviour.m_SelectMapPanel.transform, false, null);
		}

		// Token: 0x0600FFC8 RID: 65480 RVA: 0x003C87C2 File Offset: 0x003C69C2
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600FFC9 RID: 65481 RVA: 0x003C87CC File Offset: 0x003C69CC
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SuperRiskSelectMapHandler>(ref this._SelectMapHandler);
			DlgHandlerBase.EnsureUnload<SuperRiskGameHandler>(ref this._GameHandler);
			base.OnUnload();
		}

		// Token: 0x0600FFCA RID: 65482 RVA: 0x003C87F0 File Offset: 0x003C69F0
		public override void LeaveStackTop()
		{
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.LeaveStackTop();
			}
			base.LeaveStackTop();
		}

		// Token: 0x0600FFCB RID: 65483 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600FFCC RID: 65484 RVA: 0x003C882B File Offset: 0x003C6A2B
		protected override void OnHide()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SuperRisk, true);
			base.OnHide();
		}

		// Token: 0x0600FFCD RID: 65485 RVA: 0x003C8844 File Offset: 0x003C6A44
		protected override void OnShow()
		{
			bool isNeedEnterMainGame = this._doc.IsNeedEnterMainGame;
			if (isNeedEnterMainGame)
			{
				this.ShowGameMap();
				XSuperRiskDocument.Doc.IsNeedEnterMainGame = false;
			}
			else
			{
				this.ShowSelectMap();
			}
		}

		// Token: 0x0600FFCE RID: 65486 RVA: 0x003C8880 File Offset: 0x003C6A80
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.OnUpdate();
			}
		}

		// Token: 0x0600FFCF RID: 65487 RVA: 0x003C88BC File Offset: 0x003C6ABC
		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.StackRefresh();
			}
		}

		// Token: 0x0600FFD0 RID: 65488 RVA: 0x003C88F8 File Offset: 0x003C6AF8
		public void Show(bool isNeedEnterMainGame, int mapId = 0)
		{
			this._doc.CurrentMapID = mapId;
			bool flag = !this._doc.IsNeedEnterMainGame;
			if (flag)
			{
				this._doc.IsNeedEnterMainGame = isNeedEnterMainGame;
			}
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600FFD1 RID: 65489 RVA: 0x003C893A File Offset: 0x003C6B3A
		public void ShowGameMap()
		{
			this._SelectMapHandler.SetVisible(false);
			this._GameHandler.SetVisible(true);
		}

		// Token: 0x0600FFD2 RID: 65490 RVA: 0x003C8957 File Offset: 0x003C6B57
		public void ShowSelectMap()
		{
			this._GameHandler.SetVisible(false);
			this._SelectMapHandler.SetVisible(true);
		}

		// Token: 0x04007152 RID: 29010
		private SuperRiskSelectMapHandler _SelectMapHandler;

		// Token: 0x04007153 RID: 29011
		private SuperRiskGameHandler _GameHandler;
	}
}
