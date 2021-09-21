using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001833 RID: 6195
	internal class XGuildArenaDlg : DlgBase<XGuildArenaDlg, TabDlgBehaviour>
	{
		// Token: 0x1700392D RID: 14637
		// (get) Token: 0x06010154 RID: 65876 RVA: 0x003D72D0 File Offset: 0x003D54D0
		public override string fileName
		{
			get
			{
				return "Guild/GuildArenaDlg";
			}
		}

		// Token: 0x1700392E RID: 14638
		// (get) Token: 0x06010155 RID: 65877 RVA: 0x003D72E8 File Offset: 0x003D54E8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700392F RID: 14639
		// (get) Token: 0x06010156 RID: 65878 RVA: 0x003D72FC File Offset: 0x003D54FC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003930 RID: 14640
		// (get) Token: 0x06010157 RID: 65879 RVA: 0x003D7310 File Offset: 0x003D5510
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003931 RID: 14641
		// (get) Token: 0x06010158 RID: 65880 RVA: 0x003D7324 File Offset: 0x003D5524
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003932 RID: 14642
		// (get) Token: 0x06010159 RID: 65881 RVA: 0x003D7338 File Offset: 0x003D5538
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003933 RID: 14643
		// (get) Token: 0x0601015A RID: 65882 RVA: 0x003D734C File Offset: 0x003D554C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601015B RID: 65883 RVA: 0x003D7360 File Offset: 0x003D5560
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_Help = (base.uiBehaviour.m_root.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_maskSprite = (base.uiBehaviour.m_root.FindChild("Mask").GetComponent("XUISprite") as IXUISprite);
			this.RegisterHandler<GuildArenaHallHandle>(GuildArenaTab.Hall);
			this.RegisterHandler<GuildArenaDuelHandler>(GuildArenaTab.Duel);
			this.RegisterHandler<GuildArenaCombatHandle>(GuildArenaTab.Combat);
		}

		// Token: 0x0601015C RID: 65884 RVA: 0x003D73F4 File Offset: 0x003D55F4
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

		// Token: 0x0601015D RID: 65885 RVA: 0x003D7448 File Offset: 0x003D5648
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

		// Token: 0x0601015E RID: 65886 RVA: 0x003D747F File Offset: 0x003D567F
		protected override void OnUnload()
		{
			this.RemoveHandler(GuildArenaTab.Hall);
			this.RemoveHandler(GuildArenaTab.Duel);
			this.RemoveHandler(GuildArenaTab.Combat);
			base.OnUnload();
		}

		// Token: 0x0601015F RID: 65887 RVA: 0x003D74A1 File Offset: 0x003D56A1
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._CloseClickHandle));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpClick));
		}

		// Token: 0x06010160 RID: 65888 RVA: 0x003D74E0 File Offset: 0x003D56E0
		protected override void OnShow()
		{
			base.OnShow();
			this.InitTabTableControl();
			this._Doc.SendGuildIntegralInfo();
		}

		// Token: 0x06010161 RID: 65889 RVA: 0x003D7500 File Offset: 0x003D5700
		public void SelectTabIndex(GuildArenaTab tab)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int num = XFastEnumIntEqualityComparer<GuildArenaTab>.ToInt(tab);
				IXUICheckBox byCheckBoxId = this.m_uiBehaviour.m_tabcontrol.GetByCheckBoxId((ulong)((long)num));
				bool flag2 = byCheckBoxId == null;
				if (!flag2)
				{
					byCheckBoxId.bChecked = true;
				}
			}
		}

		// Token: 0x06010162 RID: 65890 RVA: 0x003D7549 File Offset: 0x003D5749
		protected override void OnHide()
		{
			this.SetHandlerVisible(this._Doc.SelectTabIndex, false);
			base.OnHide();
		}

		// Token: 0x06010163 RID: 65891 RVA: 0x003D7568 File Offset: 0x003D5768
		public void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(this._Doc.SelectTabIndex, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		// Token: 0x06010164 RID: 65892 RVA: 0x003D75A8 File Offset: 0x003D57A8
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
				list2.Add(string.Format("GUILD_ARENA_TAB{0}", list[i]));
				i++;
			}
			base.uiBehaviour.m_tabcontrol.SetupTabs(list, list2, new XUITabControl.UITabControlCallback(this._OnTabControlUpdate), true, 1f, -1, true);
		}

		// Token: 0x06010165 RID: 65893 RVA: 0x003D763C File Offset: 0x003D583C
		private void SetHandlerVisible(GuildArenaTab handlerID, bool isVisble)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(handlerID, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.SetVisible(isVisble);
				if (isVisble)
				{
					this._Doc.SelectTabIndex = handlerID;
				}
			}
		}

		// Token: 0x06010166 RID: 65894 RVA: 0x003D7678 File Offset: 0x003D5878
		private void _OnTabControlUpdate(ulong handId)
		{
			this.SetHandlerVisible(this._Doc.SelectTabIndex, false);
			this.SetHandlerVisible((GuildArenaTab)handId, true);
			this.m_maskSprite.SetAlpha((this._Doc.SelectTabIndex == GuildArenaTab.Hall) ? 0f : 1f);
		}

		// Token: 0x06010167 RID: 65895 RVA: 0x003D76CC File Offset: 0x003D58CC
		private bool _OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildPvp);
			return true;
		}

		// Token: 0x06010168 RID: 65896 RVA: 0x003D76EC File Offset: 0x003D58EC
		private bool _CloseClickHandle(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x040072BD RID: 29373
		private XGuildArenaDocument _Doc;

		// Token: 0x040072BE RID: 29374
		private Dictionary<GuildArenaTab, DlgHandlerBase> m_handlers = new Dictionary<GuildArenaTab, DlgHandlerBase>();

		// Token: 0x040072BF RID: 29375
		private IXUIButton m_Help;

		// Token: 0x040072C0 RID: 29376
		private IXUISprite m_maskSprite;
	}
}
