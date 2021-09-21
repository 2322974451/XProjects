using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000F13 RID: 3859
	public class DlgHandlerMgr
	{
		// Token: 0x0600CCDA RID: 52442 RVA: 0x002F36AD File Offset: 0x002F18AD
		public void Add(DlgHandlerBase handler)
		{
			this.m_ListHandler.Add(handler);
		}

		// Token: 0x0600CCDB RID: 52443 RVA: 0x002F36BD File Offset: 0x002F18BD
		public void Remove(DlgHandlerBase handler)
		{
			this.m_ListHandler.Remove(handler);
		}

		// Token: 0x0600CCDC RID: 52444 RVA: 0x002F36D0 File Offset: 0x002F18D0
		public void Unload()
		{
			for (int i = 0; i < this.m_ListHandler.Count; i++)
			{
				this.m_ListHandler[i].UnLoad();
			}
			this.m_ListHandler.Clear();
		}

		// Token: 0x0600CCDD RID: 52445 RVA: 0x002F3718 File Offset: 0x002F1918
		public void StackRefresh()
		{
			for (int i = 0; i < this.m_ListHandler.Count; i++)
			{
				bool flag = this.m_ListHandler[i].IsVisible();
				if (flag)
				{
					this.m_ListHandler[i].StackRefresh();
				}
			}
		}

		// Token: 0x0600CCDE RID: 52446 RVA: 0x002F376C File Offset: 0x002F196C
		public void LeaveStackTop()
		{
			for (int i = 0; i < this.m_ListHandler.Count; i++)
			{
				bool flag = this.m_ListHandler[i].IsVisible();
				if (flag)
				{
					this.m_ListHandler[i].LeaveStackTop();
				}
			}
		}

		// Token: 0x0600CCDF RID: 52447 RVA: 0x002F37C0 File Offset: 0x002F19C0
		public void OnUpdate()
		{
			for (int i = 0; i < this.m_ListHandler.Count; i++)
			{
				bool flag = this.m_ListHandler[i].IsVisible();
				if (flag)
				{
					this.m_ListHandler[i].OnUpdate();
				}
			}
		}

		// Token: 0x04005B18 RID: 23320
		private List<DlgHandlerBase> m_ListHandler = new List<DlgHandlerBase>();
	}
}
