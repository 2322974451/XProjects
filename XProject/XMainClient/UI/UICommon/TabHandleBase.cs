using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI.UICommon
{

	internal class TabHandleBase<T, V> : DlgBase<T, V>, IDlgHandlerMgr where T : IXUIDlg, new() where V : DlgBehaviourBase
	{

		public virtual void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handles.TryGetValue(this.m_select, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		protected void SetHandleVisible(XSysDefine define, bool isVisible)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handles.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.SetVisible(isVisible);
				if (isVisible)
				{
					this.m_select = define;
				}
			}
		}

		protected void RegisterHandler<C>(XSysDefine define, GameObject g, bool show = false) where C : DlgHandlerBase, new()
		{
			bool flag = !this.m_handles.ContainsKey(define);
			if (flag)
			{
				C c = default(C);
				c = DlgHandlerBase.EnsureCreate<C>(ref c, g, this, false);
				this.m_handles.Add(define, c);
			}
		}

		protected void RemoveHandler(XSysDefine define)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handles.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<DlgHandlerBase>(ref dlgHandlerBase);
				this.m_handles.Remove(define);
			}
		}

		private Dictionary<XSysDefine, DlgHandlerBase> m_handles = new Dictionary<XSysDefine, DlgHandlerBase>();

		protected XSysDefine m_select;
	}
}
