using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class DlgHandlerMgr
	{

		public void Add(DlgHandlerBase handler)
		{
			this.m_ListHandler.Add(handler);
		}

		public void Remove(DlgHandlerBase handler)
		{
			this.m_ListHandler.Remove(handler);
		}

		public void Unload()
		{
			for (int i = 0; i < this.m_ListHandler.Count; i++)
			{
				this.m_ListHandler[i].UnLoad();
			}
			this.m_ListHandler.Clear();
		}

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

		private List<DlgHandlerBase> m_ListHandler = new List<DlgHandlerBase>();
	}
}
