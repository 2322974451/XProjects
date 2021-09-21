using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018BD RID: 6333
	internal class RecycleSystemDlg : TabDlgBase<RecycleSystemDlg>
	{
		// Token: 0x17003A44 RID: 14916
		// (get) Token: 0x0601082B RID: 67627 RVA: 0x0040CB5C File Offset: 0x0040AD5C
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

		// Token: 0x17003A45 RID: 14917
		// (get) Token: 0x0601082C RID: 67628 RVA: 0x0040CB98 File Offset: 0x0040AD98
		public override string fileName
		{
			get
			{
				return "GameSystem/RecycleDlg";
			}
		}

		// Token: 0x0601082D RID: 67629 RVA: 0x0040CBB0 File Offset: 0x0040ADB0
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

		// Token: 0x0601082E RID: 67630 RVA: 0x0040CCE7 File Offset: 0x0040AEE7
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0601082F RID: 67631 RVA: 0x0040CCF4 File Offset: 0x0040AEF4
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

		// Token: 0x06010830 RID: 67632 RVA: 0x0040CD49 File Offset: 0x0040AF49
		protected override void OnShow()
		{
			base.OnShow();
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.ShowRecycleTips();
		}

		// Token: 0x06010831 RID: 67633 RVA: 0x0040CD60 File Offset: 0x0040AF60
		private bool ShowHelp(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Recycle_Equip);
			return false;
		}

		// Token: 0x06010832 RID: 67634 RVA: 0x0040CD84 File Offset: 0x0040AF84
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

		// Token: 0x06010833 RID: 67635 RVA: 0x0040CE56 File Offset: 0x0040B056
		public void ToggleInputBlocker(bool bBlock)
		{
			this.m_InputBlocker.SetActive(bBlock);
		}

		// Token: 0x04007778 RID: 30584
		public RecycleItemBagView _RecycleItemBagView;

		// Token: 0x04007779 RID: 30585
		public RecycleItemOperateView _RecycleItemOperateView;

		// Token: 0x0400777A RID: 30586
		public GameObject m_RecycleItemBagPanel;

		// Token: 0x0400777B RID: 30587
		public GameObject m_RecycleItemOperatePanel;

		// Token: 0x0400777C RID: 30588
		public GameObject m_InputBlocker;

		// Token: 0x0400777D RID: 30589
		public IXUIButton m_helpBtn;

		// Token: 0x0400777E RID: 30590
		private XFx m_fx;

		// Token: 0x0400777F RID: 30591
		private string m_effectPath = string.Empty;
	}
}
