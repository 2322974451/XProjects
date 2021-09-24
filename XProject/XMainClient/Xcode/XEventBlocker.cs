using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEventBlocker<T> where T : XEventArgs
	{

		public XEventBlocker<T>.XEventHandler EventHandler { get; set; }

		public void AddEvent(T e)
		{
			this.m_EventPool.Add(e);
		}

		public void ClearEvents()
		{
			this.m_EventPool.Clear();
			this.m_bBlockReceiver = false;
			this.m_bBlockSender = false;
		}

		public bool bBlockReceiver
		{
			get
			{
				return this.m_bBlockReceiver;
			}
			set
			{
				this.m_bBlockReceiver = value;
				bool flag = !this.m_bBlockReceiver;
				if (flag)
				{
					for (int i = 0; i < this.m_EventPool.Count; i++)
					{
						bool flag2 = this.EventHandler != null;
						if (flag2)
						{
							this.EventHandler(this.m_EventPool[i]);
						}
						this.m_EventPool[i].Recycle();
					}
					this.m_EventPool.Clear();
				}
			}
		}

		public bool bBlockSender
		{
			get
			{
				return this.m_bBlockSender;
			}
			set
			{
				this.m_bBlockSender = value;
				bool flag = !this.m_bBlockSender;
				if (flag)
				{
					for (int i = 0; i < this.m_EventPool.Count; i++)
					{
						XSingleton<XEventMgr>.singleton.FireEvent(this.m_EventPool[i]);
					}
					this.m_EventPool.Clear();
				}
			}
		}

		private List<T> m_EventPool = new List<T>();

		private bool m_bBlockReceiver = false;

		private bool m_bBlockSender = false;

		public delegate bool XEventHandler(XEventArgs e);
	}
}
