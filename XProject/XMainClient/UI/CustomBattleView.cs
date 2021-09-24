using System;
using UILib;
using XMainClient.UI.CustomBattle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CustomBattleView : TabDlgBase<CustomBattleView>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomBattleDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
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
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle);
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
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._help = (base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this._shop = (base.uiBehaviour.transform.Find("Bg/BtnShop").GetComponent("XUIButton") as IXUIButton);
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_CustomBattle);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CustomBattleBountyModeDetailHandler>(ref this._BountyModeDetailHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleBountyModeListHandler>(ref this._BountyModeListHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleBriefHandler>(ref this._CustomModeBriefHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleChestHandler>(ref this._ChestHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleCustomModeCreateHandler>(ref this._CustomModeCreateHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleCustomModeDetailHandler>(ref this._CustomModeDetailHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleCustomModeListHandler>(ref this._CustomModeListHandler);
			DlgHandlerBase.EnsureUnload<CustomBattleMatchingHandler>(ref this._MatchingHandler);
			DlgHandlerBase.EnsureUnload<CustomBattlePasswordSettingHandler>(ref this._PasswordSettingHandler);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this._shop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClicked));
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CustomBattle);
			return true;
		}

		private bool OnShopClicked(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_AllPkMatch, 0UL);
			return true;
		}

		public void ShowBountyModeDetailHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleBountyModeDetailHandler>(ref this._BountyModeDetailHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowBountyModeListHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleBountyModeListHandler>(ref this._BountyModeListHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowCustomModeBriefHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleBriefHandler>(ref this._CustomModeBriefHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowChestHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleChestHandler>(ref this._ChestHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowCustomModeCreateHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeCreateHandler>(ref this._CustomModeCreateHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowCustomModeDetailHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeDetailHandler>(ref this._CustomModeDetailHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowCustomModeListHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeListHandler>(ref this._CustomModeListHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowMatchingHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleMatchingHandler>(ref this._MatchingHandler, base.uiBehaviour.m_root, true, null);
		}

		public void ShowPasswordSettingHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattlePasswordSettingHandler>(ref this._PasswordSettingHandler, base.uiBehaviour.m_root, true, null);
		}

		private void HideHandler(DlgHandlerBase handler)
		{
			bool flag = handler == null;
			if (!flag)
			{
				handler.SetVisible(false);
			}
		}

		private void HideAll()
		{
			this.HideHandler(this._BountyModeDetailHandler);
			this.HideHandler(this._BountyModeListHandler);
			this.HideHandler(this._CustomModeBriefHandler);
			this.HideHandler(this._ChestHandler);
			this.HideHandler(this._CustomModeCreateHandler);
			this.HideHandler(this._CustomModeDetailHandler);
			this.HideHandler(this._CustomModeListHandler);
			this.HideHandler(this._MatchingHandler);
			this.HideHandler(this._PasswordSettingHandler);
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			if (sys != XSysDefine.XSys_CustomBattle_BountyMode)
			{
				if (sys == XSysDefine.XSys_CustomBattle_CustomMode)
				{
					bool flag = this._doc.SelfCustomData != null;
					if (flag)
					{
						this._doc.CurrentCustomData = this._doc.SelfCustomData;
						this.ShowCustomModeDetailHandler();
					}
					else
					{
						this.ShowCustomModeListHandler();
					}
				}
			}
			else
			{
				bool flag2 = this._doc.CurrentBountyData != null && this._doc.CurrentBountyData.gameID == this._doc.CacheGameID;
				if (flag2)
				{
					this.ShowBountyModeListHandler();
					this.ShowBountyModeDetailHandler();
				}
				else
				{
					this.ShowBountyModeListHandler();
				}
			}
			this._doc.CacheGameID = 0UL;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._BountyModeListHandler != null;
			if (flag)
			{
				this._BountyModeListHandler.OnUpdate();
			}
			bool flag2 = this._BountyModeDetailHandler != null;
			if (flag2)
			{
				this._BountyModeDetailHandler.OnUpdate();
			}
			bool flag3 = this._CustomModeDetailHandler != null;
			if (flag3)
			{
				this._CustomModeDetailHandler.OnUpdate();
			}
			bool flag4 = this._ChestHandler != null;
			if (flag4)
			{
				this._ChestHandler.OnUpdate();
			}
			bool flag5 = this._CustomModeBriefHandler != null;
			if (flag5)
			{
				this._CustomModeBriefHandler.OnUpdate();
			}
		}

		private XCustomBattleDocument _doc = null;

		public CustomBattleBountyModeDetailHandler _BountyModeDetailHandler = null;

		public CustomBattleBountyModeListHandler _BountyModeListHandler = null;

		public CustomBattleBriefHandler _CustomModeBriefHandler = null;

		public CustomBattleChestHandler _ChestHandler = null;

		public CustomBattleCustomModeCreateHandler _CustomModeCreateHandler = null;

		public CustomBattleCustomModeDetailHandler _CustomModeDetailHandler = null;

		public CustomBattleCustomModeListHandler _CustomModeListHandler = null;

		public CustomBattleMatchingHandler _MatchingHandler = null;

		public CustomBattlePasswordSettingHandler _PasswordSettingHandler = null;

		private IXUIButton _help;

		private IXUIButton _shop;
	}
}
