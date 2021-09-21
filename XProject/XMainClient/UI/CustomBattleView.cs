using System;
using UILib;
using XMainClient.UI.CustomBattle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001735 RID: 5941
	internal class CustomBattleView : TabDlgBase<CustomBattleView>
	{
		// Token: 0x170037BC RID: 14268
		// (get) Token: 0x0600F556 RID: 62806 RVA: 0x00376248 File Offset: 0x00374448
		public override string fileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomBattleDlg";
			}
		}

		// Token: 0x170037BD RID: 14269
		// (get) Token: 0x0600F557 RID: 62807 RVA: 0x00376260 File Offset: 0x00374460
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037BE RID: 14270
		// (get) Token: 0x0600F558 RID: 62808 RVA: 0x00376274 File Offset: 0x00374474
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037BF RID: 14271
		// (get) Token: 0x0600F559 RID: 62809 RVA: 0x00376288 File Offset: 0x00374488
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle);
			}
		}

		// Token: 0x170037C0 RID: 14272
		// (get) Token: 0x0600F55A RID: 62810 RVA: 0x003762A4 File Offset: 0x003744A4
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600F55B RID: 62811 RVA: 0x003762B8 File Offset: 0x003744B8
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._help = (base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this._shop = (base.uiBehaviour.transform.Find("Bg/BtnShop").GetComponent("XUIButton") as IXUIButton);
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_CustomBattle);
		}

		// Token: 0x0600F55C RID: 62812 RVA: 0x00376340 File Offset: 0x00374540
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

		// Token: 0x0600F55D RID: 62813 RVA: 0x003763C1 File Offset: 0x003745C1
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this._shop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClicked));
		}

		// Token: 0x0600F55E RID: 62814 RVA: 0x003763FC File Offset: 0x003745FC
		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F55F RID: 62815 RVA: 0x00376418 File Offset: 0x00374618
		private bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CustomBattle);
			return true;
		}

		// Token: 0x0600F560 RID: 62816 RVA: 0x0037643C File Offset: 0x0037463C
		private bool OnShopClicked(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_AllPkMatch, 0UL);
			return true;
		}

		// Token: 0x0600F561 RID: 62817 RVA: 0x00376461 File Offset: 0x00374661
		public void ShowBountyModeDetailHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleBountyModeDetailHandler>(ref this._BountyModeDetailHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F562 RID: 62818 RVA: 0x0037647D File Offset: 0x0037467D
		public void ShowBountyModeListHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleBountyModeListHandler>(ref this._BountyModeListHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F563 RID: 62819 RVA: 0x003764A0 File Offset: 0x003746A0
		public void ShowCustomModeBriefHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleBriefHandler>(ref this._CustomModeBriefHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F564 RID: 62820 RVA: 0x003764BC File Offset: 0x003746BC
		public void ShowChestHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleChestHandler>(ref this._ChestHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F565 RID: 62821 RVA: 0x003764D8 File Offset: 0x003746D8
		public void ShowCustomModeCreateHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeCreateHandler>(ref this._CustomModeCreateHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F566 RID: 62822 RVA: 0x003764F4 File Offset: 0x003746F4
		public void ShowCustomModeDetailHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeDetailHandler>(ref this._CustomModeDetailHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F567 RID: 62823 RVA: 0x00376517 File Offset: 0x00374717
		public void ShowCustomModeListHandler()
		{
			this.HideAll();
			DlgHandlerBase.EnsureCreate<CustomBattleCustomModeListHandler>(ref this._CustomModeListHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F568 RID: 62824 RVA: 0x0037653A File Offset: 0x0037473A
		public void ShowMatchingHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattleMatchingHandler>(ref this._MatchingHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F569 RID: 62825 RVA: 0x00376556 File Offset: 0x00374756
		public void ShowPasswordSettingHandler()
		{
			DlgHandlerBase.EnsureCreate<CustomBattlePasswordSettingHandler>(ref this._PasswordSettingHandler, base.uiBehaviour.m_root, true, null);
		}

		// Token: 0x0600F56A RID: 62826 RVA: 0x00376574 File Offset: 0x00374774
		private void HideHandler(DlgHandlerBase handler)
		{
			bool flag = handler == null;
			if (!flag)
			{
				handler.SetVisible(false);
			}
		}

		// Token: 0x0600F56B RID: 62827 RVA: 0x00376594 File Offset: 0x00374794
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

		// Token: 0x0600F56C RID: 62828 RVA: 0x00376618 File Offset: 0x00374818
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

		// Token: 0x0600F56D RID: 62829 RVA: 0x003766E0 File Offset: 0x003748E0
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

		// Token: 0x04006A48 RID: 27208
		private XCustomBattleDocument _doc = null;

		// Token: 0x04006A49 RID: 27209
		public CustomBattleBountyModeDetailHandler _BountyModeDetailHandler = null;

		// Token: 0x04006A4A RID: 27210
		public CustomBattleBountyModeListHandler _BountyModeListHandler = null;

		// Token: 0x04006A4B RID: 27211
		public CustomBattleBriefHandler _CustomModeBriefHandler = null;

		// Token: 0x04006A4C RID: 27212
		public CustomBattleChestHandler _ChestHandler = null;

		// Token: 0x04006A4D RID: 27213
		public CustomBattleCustomModeCreateHandler _CustomModeCreateHandler = null;

		// Token: 0x04006A4E RID: 27214
		public CustomBattleCustomModeDetailHandler _CustomModeDetailHandler = null;

		// Token: 0x04006A4F RID: 27215
		public CustomBattleCustomModeListHandler _CustomModeListHandler = null;

		// Token: 0x04006A50 RID: 27216
		public CustomBattleMatchingHandler _MatchingHandler = null;

		// Token: 0x04006A51 RID: 27217
		public CustomBattlePasswordSettingHandler _PasswordSettingHandler = null;

		// Token: 0x04006A52 RID: 27218
		private IXUIButton _help;

		// Token: 0x04006A53 RID: 27219
		private IXUIButton _shop;
	}
}
