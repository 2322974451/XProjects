using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RecycleSystemDlg : TabDlgBase<RecycleSystemDlg>
	{

		public string EffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_effectPath);
				if (flag)
				{
					this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("RecycleEffectPath");
				}
				return this.m_effectPath;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/RecycleDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_RecycleItemBagPanel = base.uiBehaviour.transform.FindChild("Bg/ItemListPanel").gameObject;
			this.m_RecycleItemBagPanel.SetActive(false);
			this.m_RecycleItemOperatePanel = base.uiBehaviour.transform.FindChild("Bg/LeftPanel/ItemOperateFrame").gameObject;
			this.m_RecycleItemOperatePanel.SetActive(false);
			this.m_InputBlocker = base.uiBehaviour.transform.FindChild("Bg/BlockerPanel/InputBlocker").gameObject;
			this.m_helpBtn = (base.uiBehaviour.transform.FindChild("Bg/LeftPanel/T/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ShowHelp));
			bool flag = this.m_fx == null;
			if (flag)
			{
				this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.EffectPath, null, true);
			}
			else
			{
				this.m_fx.SetActive(true);
			}
			this.m_fx.Play(base.uiBehaviour.transform.FindChild("Bg/p"), Vector3.zero, Vector3.one, 1f, true, false);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		protected override void OnUnload()
		{
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			DlgHandlerBase.EnsureUnload<RecycleItemBagView>(ref this._RecycleItemBagView);
			DlgHandlerBase.EnsureUnload<RecycleItemOperateView>(ref this._RecycleItemOperateView);
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.ShowRecycleTips();
		}

		private bool ShowHelp(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Recycle_Equip);
			return false;
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			XRecycleItemDocument specificDocument = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
			specificDocument.CurrentSys = sys;
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_Recycle_Equip)
			{
				if (xsysDefine != XSysDefine.XSys_Recycle_Jade)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
					return;
				}
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<RecycleItemBagView>(ref this._RecycleItemBagView, this.m_RecycleItemBagPanel, this, true));
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<RecycleItemOperateView>(ref this._RecycleItemOperateView, this.m_RecycleItemOperatePanel, this, true));
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<RecycleItemBagView>(ref this._RecycleItemBagView, this.m_RecycleItemBagPanel, this, true));
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<RecycleItemOperateView>(ref this._RecycleItemOperateView, this.m_RecycleItemOperatePanel, this, true));
			}
			this.ToggleInputBlocker(false);
		}

		public void ToggleInputBlocker(bool bBlock)
		{
			this.m_InputBlocker.SetActive(bBlock);
		}

		public RecycleItemBagView _RecycleItemBagView;

		public RecycleItemOperateView _RecycleItemOperateView;

		public GameObject m_RecycleItemBagPanel;

		public GameObject m_RecycleItemOperatePanel;

		public GameObject m_InputBlocker;

		public IXUIButton m_helpBtn;

		private XFx m_fx;

		private string m_effectPath = string.Empty;
	}
}
