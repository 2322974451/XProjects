using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal abstract class TabDlgBase<T> : DlgBase<T, TabDlgBehaviour> where T : IXUIDlg, new()
	{

		protected virtual bool bHorizontal
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/CharacterDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
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

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.mCurrentSys);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnUnload()
		{
			this.m_ActiveHandlers.Clear();
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(this.mainSys, null);
			this.mainSys = XSysDefine.XSys_Invalid;
			base.OnUnload();
		}

		protected override void Init()
		{
			this.mCurrentSys = XSysDefine.XSys_Invalid;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		protected void RegisterSubSysRedPointMgr(XSysDefine sys)
		{
			this.mainSys = sys;
			XSingleton<XGameSysMgr>.singleton.RegisterSubSysRedPointMgr(this.mainSys, this.redpointMgr);
		}

		public void UpdateSubSysRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		public void OnTabChanged(ulong id)
		{
			this.ShowSubGamsSystem((XSysDefine)id);
		}

		public virtual void SetupHandlers(XSysDefine sys)
		{
		}

		protected void _AddActiveHandler(DlgHandlerBase handler)
		{
			this.m_ActiveHandlers.Add(handler);
		}

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

		public virtual void SetupRedpointEx()
		{
		}

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

		protected bool OnCloseClick(IXUIButton go)
		{
			this.Close(true);
			return true;
		}

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

		protected void OnCloseAnimationOver()
		{
			for (int i = 0; i < this.m_ActiveHandlers.Count; i++)
			{
				this.m_ActiveHandlers[i].SetVisible(false);
			}
			this.m_ActiveHandlers.Clear();
		}

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

		public bool CurrentSysIs(XSysDefine sys)
		{
			bool flag = !base.IsLoaded();
			return !flag && sys == this.mCurrentSys;
		}

		protected List<DlgHandlerBase> m_ActiveHandlers = new List<DlgHandlerBase>();

		protected XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();

		protected XSysDefine mainSys = XSysDefine.XSys_Invalid;

		protected XSysDefine mCurrentSys;
	}
}
