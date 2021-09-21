using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI.UICommon
{
	// Token: 0x02001929 RID: 6441
	internal class TabHandleBase<T, V> : DlgBase<T, V>, IDlgHandlerMgr where T : IXUIDlg, new() where V : DlgBehaviourBase
	{
		// Token: 0x06010E84 RID: 69252 RVA: 0x00449B18 File Offset: 0x00447D18
		public virtual void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handles.TryGetValue(this.m_select, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		// Token: 0x06010E85 RID: 69253 RVA: 0x00449B54 File Offset: 0x00447D54
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

		// Token: 0x06010E86 RID: 69254 RVA: 0x00449B8C File Offset: 0x00447D8C
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

		// Token: 0x06010E87 RID: 69255 RVA: 0x00449BD8 File Offset: 0x00447DD8
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

		// Token: 0x04007C60 RID: 31840
		private Dictionary<XSysDefine, DlgHandlerBase> m_handles = new Dictionary<XSysDefine, DlgHandlerBase>();

		// Token: 0x04007C61 RID: 31841
		protected XSysDefine m_select;
	}
}
