using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SuperRiskDlg : DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>
	{

		private XSuperRiskDocument _doc
		{
			get
			{
				return XSuperRiskDocument.Doc;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/SuperRisk/SuperRiskDlg";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
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
			DlgHandlerBase.EnsureCreate<SuperRiskGameHandler>(ref this._GameHandler, base.uiBehaviour.m_RiskMapPanel.transform, false, null);
			DlgHandlerBase.EnsureCreate<SuperRiskSelectMapHandler>(ref this._SelectMapHandler, base.uiBehaviour.m_SelectMapPanel.transform, false, null);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SuperRiskSelectMapHandler>(ref this._SelectMapHandler);
			DlgHandlerBase.EnsureUnload<SuperRiskGameHandler>(ref this._GameHandler);
			base.OnUnload();
		}

		public override void LeaveStackTop()
		{
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.LeaveStackTop();
			}
			base.LeaveStackTop();
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnHide()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SuperRisk, true);
			base.OnHide();
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.OnUpdate();
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this._GameHandler != null && this._GameHandler.IsVisible();
			if (flag)
			{
				this._GameHandler.StackRefresh();
			}
		}

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

		public void ShowGameMap()
		{
			this._SelectMapHandler.SetVisible(false);
			this._GameHandler.SetVisible(true);
		}

		public void ShowSelectMap()
		{
			this._GameHandler.SetVisible(false);
			this._SelectMapHandler.SetVisible(true);
		}

		private SuperRiskSelectMapHandler _SelectMapHandler;

		private SuperRiskGameHandler _GameHandler;
	}
}
