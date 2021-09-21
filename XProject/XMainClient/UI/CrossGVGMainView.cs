using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F8 RID: 5880
	internal class CrossGVGMainView : TabDlgBase<CrossGVGMainView>
	{
		// Token: 0x17003767 RID: 14183
		// (get) Token: 0x0600F28C RID: 62092 RVA: 0x0035CD74 File Offset: 0x0035AF74
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CrossGVG);
			}
		}

		// Token: 0x17003768 RID: 14184
		// (get) Token: 0x0600F28D RID: 62093 RVA: 0x0035CD90 File Offset: 0x0035AF90
		public override string fileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGArenaDlg";
			}
		}

		// Token: 0x17003769 RID: 14185
		// (get) Token: 0x0600F28E RID: 62094 RVA: 0x0035CDA8 File Offset: 0x0035AFA8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700376A RID: 14186
		// (get) Token: 0x0600F28F RID: 62095 RVA: 0x0035CDBC File Offset: 0x0035AFBC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700376B RID: 14187
		// (get) Token: 0x0600F290 RID: 62096 RVA: 0x0035CDD0 File Offset: 0x0035AFD0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700376C RID: 14188
		// (get) Token: 0x0600F291 RID: 62097 RVA: 0x0035CDE4 File Offset: 0x0035AFE4
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700376D RID: 14189
		// (get) Token: 0x0600F292 RID: 62098 RVA: 0x0035CDF8 File Offset: 0x0035AFF8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700376E RID: 14190
		// (get) Token: 0x0600F293 RID: 62099 RVA: 0x0035CE0C File Offset: 0x0035B00C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F294 RID: 62100 RVA: 0x0035CE20 File Offset: 0x0035B020
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.m_Help = (base.uiBehaviour.m_root.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_maskSprite = (base.uiBehaviour.m_root.FindChild("Mask").GetComponent("XUISprite") as IXUISprite);
			this.RegisterHandler<CrossGVGHallHandle>(GuildArenaTab.Hall);
			this.RegisterHandler<CrossGVGDuelHandler>(GuildArenaTab.Duel);
			this.RegisterHandler<CrossGVGCombatHandler>(GuildArenaTab.Combat);
		}

		// Token: 0x0600F295 RID: 62101 RVA: 0x0035CEB4 File Offset: 0x0035B0B4
		private void RegisterHandler<T>(GuildArenaTab index) where T : DlgHandlerBase, new()
		{
			bool flag = !this.m_handlers.ContainsKey(index);
			if (flag)
			{
				T t = default(T);
				t = DlgHandlerBase.EnsureCreate<T>(ref t, base.uiBehaviour.m_root, false, this);
				this.m_handlers.Add(index, t);
			}
		}

		// Token: 0x0600F296 RID: 62102 RVA: 0x0035CF08 File Offset: 0x0035B108
		private void RemoveHandler(GuildArenaTab index)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(index, out dlgHandlerBase);
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<DlgHandlerBase>(ref dlgHandlerBase);
				this.m_handlers.Remove(index);
			}
		}

		// Token: 0x0600F297 RID: 62103 RVA: 0x0035CF3F File Offset: 0x0035B13F
		protected override void OnUnload()
		{
			this.RemoveHandler(GuildArenaTab.Hall);
			this.RemoveHandler(GuildArenaTab.Duel);
			this.RemoveHandler(GuildArenaTab.Combat);
			base.OnUnload();
		}

		// Token: 0x0600F298 RID: 62104 RVA: 0x0035CF61 File Offset: 0x0035B161
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._CloseClickHandle));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpClick));
		}

		// Token: 0x0600F299 RID: 62105 RVA: 0x0035CFA0 File Offset: 0x0035B1A0
		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabTableControl();
			this._doc.SendCrossGVGData();
		}

		// Token: 0x0600F29A RID: 62106 RVA: 0x0035CFC0 File Offset: 0x0035B1C0
		public void SelectTabIndex(GuildArenaTab tab)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				ulong num = (ulong)((long)XFastEnumIntEqualityComparer<GuildArenaTab>.ToInt(tab));
				IXUICheckBox byCheckBoxId = this.m_uiBehaviour.m_tabcontrol.GetByCheckBoxId(num);
				bool flag2 = byCheckBoxId == null;
				if (!flag2)
				{
					byCheckBoxId.bChecked = true;
					this._OnTabControlUpdate(num);
				}
			}
		}

		// Token: 0x0600F29B RID: 62107 RVA: 0x0035D011 File Offset: 0x0035B211
		protected override void OnHide()
		{
			this.SetHandlerVisible(this._doc.SelectTabIndex, false);
			this._doc.SendCrossGVGOper(CrossGvgOperType.CGOT_LeaveUI, 0UL);
			base.OnHide();
		}

		// Token: 0x0600F29C RID: 62108 RVA: 0x0035D040 File Offset: 0x0035B240
		public void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(this._doc.SelectTabIndex, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		// Token: 0x0600F29D RID: 62109 RVA: 0x0035D080 File Offset: 0x0035B280
		private void InitTabTableControl()
		{
			List<int> list = new List<int>
			{
				1,
				2,
				3
			};
			List<string> list2 = new List<string>();
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				list2.Add(string.Format("CrossGVG_Tab{0}", list[i]));
				i++;
			}
			base.uiBehaviour.m_tabcontrol.SetupTabs(list, list2, new XUITabControl.UITabControlCallback(this._OnTabControlUpdate), true, 1f, -1, true);
		}

		// Token: 0x0600F29E RID: 62110 RVA: 0x0035D114 File Offset: 0x0035B314
		private void SetHandlerVisible(GuildArenaTab handlerID, bool isVisble)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(handlerID, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.SetVisible(isVisble);
				if (isVisble)
				{
					this._doc.SelectTabIndex = handlerID;
				}
			}
		}

		// Token: 0x0600F29F RID: 62111 RVA: 0x0035D150 File Offset: 0x0035B350
		private void _OnTabControlUpdate(ulong handId)
		{
			this.SetHandlerVisible(this._doc.SelectTabIndex, false);
			this.SetHandlerVisible((GuildArenaTab)handId, true);
			this.m_maskSprite.SetAlpha((this._doc.SelectTabIndex == GuildArenaTab.Hall) ? 0f : 1f);
		}

		// Token: 0x0600F2A0 RID: 62112 RVA: 0x0035D1A4 File Offset: 0x0035B3A4
		private bool _OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CrossGVG);
			return true;
		}

		// Token: 0x0600F2A1 RID: 62113 RVA: 0x0035D1C4 File Offset: 0x0035B3C4
		private bool _CloseClickHandle(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x040067F0 RID: 26608
		private XCrossGVGDocument _doc;

		// Token: 0x040067F1 RID: 26609
		private Dictionary<GuildArenaTab, DlgHandlerBase> m_handlers = new Dictionary<GuildArenaTab, DlgHandlerBase>();

		// Token: 0x040067F2 RID: 26610
		private IXUIButton m_Help;

		// Token: 0x040067F3 RID: 26611
		private IXUISprite m_maskSprite;
	}
}
