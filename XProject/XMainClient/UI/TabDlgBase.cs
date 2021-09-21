using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001900 RID: 6400
	internal abstract class TabDlgBase<T> : DlgBase<T, TabDlgBehaviour> where T : IXUIDlg, new()
	{
		// Token: 0x17003AAD RID: 15021
		// (get) Token: 0x06010B34 RID: 68404 RVA: 0x00429EC4 File Offset: 0x004280C4
		protected virtual bool bHorizontal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AAE RID: 15022
		// (get) Token: 0x06010B35 RID: 68405 RVA: 0x00429ED8 File Offset: 0x004280D8
		public override string fileName
		{
			get
			{
				return "GameSystem/CharacterDlg";
			}
		}

		// Token: 0x17003AAF RID: 15023
		// (get) Token: 0x06010B36 RID: 68406 RVA: 0x00429EF0 File Offset: 0x004280F0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AB0 RID: 15024
		// (get) Token: 0x06010B37 RID: 68407 RVA: 0x00429F04 File Offset: 0x00428104
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AB1 RID: 15025
		// (get) Token: 0x06010B38 RID: 68408 RVA: 0x00429F18 File Offset: 0x00428118
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AB2 RID: 15026
		// (get) Token: 0x06010B39 RID: 68409 RVA: 0x00429F2C File Offset: 0x0042812C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AB3 RID: 15027
		// (get) Token: 0x06010B3A RID: 68410 RVA: 0x00429F40 File Offset: 0x00428140
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AB4 RID: 15028
		// (get) Token: 0x06010B3B RID: 68411 RVA: 0x00429F54 File Offset: 0x00428154
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AB5 RID: 15029
		// (get) Token: 0x06010B3C RID: 68412 RVA: 0x00429F68 File Offset: 0x00428168
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.mCurrentSys);
			}
		}

		// Token: 0x06010B3D RID: 68413 RVA: 0x00429F85 File Offset: 0x00428185
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x06010B3E RID: 68414 RVA: 0x00429F8F File Offset: 0x0042818F
		protected override void OnUnload()
		{
			this.m_ActiveHandlers.Clear();
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(this.mainSys, null);
			this.mainSys = XSysDefine.XSys_Invalid;
			base.OnUnload();
		}

		// Token: 0x06010B3F RID: 68415 RVA: 0x00429FBE File Offset: 0x004281BE
		protected override void Init()
		{
			this.mCurrentSys = XSysDefine.XSys_Invalid;
		}

		// Token: 0x06010B40 RID: 68416 RVA: 0x00429FC8 File Offset: 0x004281C8
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x06010B41 RID: 68417 RVA: 0x00429FE8 File Offset: 0x004281E8
		protected void RegisterSubSysRedPointMgr(XSysDefine sys)
		{
			this.mainSys = sys;
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(this.mainSys, this.redpointMgr);
		}

		// Token: 0x06010B42 RID: 68418 RVA: 0x0042A009 File Offset: 0x00428209
		public void UpdateSubSysRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		// Token: 0x06010B43 RID: 68419 RVA: 0x0042A018 File Offset: 0x00428218
		public void OnTabChanged(ulong id)
		{
			this.ShowSubGamsSystem((XSysDefine)id);
		}

		// Token: 0x06010B44 RID: 68420 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void SetupHandlers(XSysDefine sys)
		{
		}

		// Token: 0x06010B45 RID: 68421 RVA: 0x0042A024 File Offset: 0x00428224
		protected void _AddActiveHandler(DlgHandlerBase handler)
		{
			this.m_ActiveHandlers.Add(handler);
		}

		// Token: 0x06010B46 RID: 68422 RVA: 0x0042A034 File Offset: 0x00428234
		public void ShowSubGamsSystem(XSysDefine sys)
		{
			bool flag = this.mCurrentSys == sys;
			if (!flag)
			{
				this.mCurrentSys = sys;
				for (int i = 0; i < this.m_ActiveHandlers.Count; i++)
				{
					this.m_ActiveHandlers[i].SetVisible(false);
				}
				this.m_ActiveHandlers.Clear();
				this.SetupHandlers(sys);
				XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
				specificDocument.OnTopUIRefreshed(this);
			}
		}

		// Token: 0x06010B47 RID: 68423 RVA: 0x0042A0AC File Offset: 0x004282AC
		public void ShowWorkGameSystem(XSysDefine sys)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			bool flag2 = sys != XSysDefine.XSys_Invalid;
			if (flag2)
			{
				this.mCurrentSys = XSysDefine.XSys_Invalid;
				List<XSysDefine> list;
				XSysDefine targetSys = XUITabControl.GetTargetSys(sys, out list);
				this.ShowSubGamsSystem(targetSys);
				XSubSysRedPointMgr xsubSysRedPointMgr = this.redpointMgr;
				IXUIObject[] btns = base.uiBehaviour.m_tabcontrol.SetupTabs(sys, new XUITabControl.UITabControlCallback(this.OnTabChanged), this.bHorizontal, 1f);
				xsubSysRedPointMgr.SetupRedPoints(btns);
			}
			this.SetupRedpointEx();
		}

		// Token: 0x06010B48 RID: 68424 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void SetupRedpointEx()
		{
		}

		// Token: 0x06010B49 RID: 68425 RVA: 0x0042A134 File Offset: 0x00428334
		public virtual void Close(bool bWithAnim = true)
		{
			if (bWithAnim)
			{
				this.SetVisibleWithAnimation(false, null);
			}
			else
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x06010B4A RID: 68426 RVA: 0x0042A160 File Offset: 0x00428360
		protected bool OnCloseClick(IXUIButton go)
		{
			this.Close(true);
			return true;
		}

		// Token: 0x06010B4B RID: 68427 RVA: 0x0042A17C File Offset: 0x0042837C
		protected override void OnHide()
		{
			base.OnHide();
			for (int i = 0; i < this.m_ActiveHandlers.Count; i++)
			{
				this.m_ActiveHandlers[i].SetVisible(false);
			}
			this.m_ActiveHandlers.Clear();
			this.redpointMgr.SetupRedPoints(null);
			this.mCurrentSys = XSysDefine.XSys_Invalid;
		}

		// Token: 0x06010B4C RID: 68428 RVA: 0x0042A1E0 File Offset: 0x004283E0
		protected void OnCloseAnimationOver()
		{
			for (int i = 0; i < this.m_ActiveHandlers.Count; i++)
			{
				this.m_ActiveHandlers[i].SetVisible(false);
			}
			this.m_ActiveHandlers.Clear();
		}

		// Token: 0x06010B4D RID: 68429 RVA: 0x0042A228 File Offset: 0x00428428
		public override void StackRefresh()
		{
			bool flag = this.mCurrentSys != XSysDefine.XSys_Invalid;
			if (flag)
			{
				XSubSysRedPointMgr xsubSysRedPointMgr = this.redpointMgr;
				IXUIObject[] btns = base.uiBehaviour.m_tabcontrol.SetupTabs(this.mCurrentSys, new XUITabControl.UITabControlCallback(this.OnTabChanged), this.bHorizontal, 1f);
				xsubSysRedPointMgr.SetupRedPoints(btns);
			}
			this.SetupRedpointEx();
			base.StackRefresh();
		}

		// Token: 0x06010B4E RID: 68430 RVA: 0x0042A290 File Offset: 0x00428490
		public bool CurrentSysIs(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			return !flag && sys == this.mCurrentSys;
		}

		// Token: 0x04007A2D RID: 31277
		protected List<DlgHandlerBase> m_ActiveHandlers = new List<DlgHandlerBase>();

		// Token: 0x04007A2E RID: 31278
		protected XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();

		// Token: 0x04007A2F RID: 31279
		protected XSysDefine mainSys = XSysDefine.XSys_Invalid;

		// Token: 0x04007A30 RID: 31280
		protected XSysDefine mCurrentSys;
	}
}
