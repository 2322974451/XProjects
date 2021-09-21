using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E76 RID: 3702
	internal class XEventBlocker<T> where T : XEventArgs
	{
		// Token: 0x1700349A RID: 13466
		// (get) Token: 0x0600C646 RID: 50758 RVA: 0x002BE31B File Offset: 0x002BC51B
		// (set) Token: 0x0600C647 RID: 50759 RVA: 0x002BE323 File Offset: 0x002BC523
		public XEventBlocker<T>.XEventHandler EventHandler { get; set; }

		// Token: 0x0600C648 RID: 50760 RVA: 0x002BE32C File Offset: 0x002BC52C
		public void AddEvent(T e)
		{
			this.m_EventPool.Add(e);
		}

		// Token: 0x0600C649 RID: 50761 RVA: 0x002BE33C File Offset: 0x002BC53C
		public void ClearEvents()
		{
			this.m_EventPool.Clear();
			this.m_bBlockReceiver = false;
			this.m_bBlockSender = false;
		}

		// Token: 0x1700349B RID: 13467
		// (get) Token: 0x0600C64A RID: 50762 RVA: 0x002BE35C File Offset: 0x002BC55C
		// (set) Token: 0x0600C64B RID: 50763 RVA: 0x002BE374 File Offset: 0x002BC574
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

		// Token: 0x1700349C RID: 13468
		// (get) Token: 0x0600C64C RID: 50764 RVA: 0x002BE404 File Offset: 0x002BC604
		// (set) Token: 0x0600C64D RID: 50765 RVA: 0x002BE41C File Offset: 0x002BC61C
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

		// Token: 0x040056F9 RID: 22265
		private List<T> m_EventPool = new List<T>();

		// Token: 0x040056FA RID: 22266
		private bool m_bBlockReceiver = false;

		// Token: 0x040056FB RID: 22267
		private bool m_bBlockSender = false;

		// Token: 0x020019CF RID: 6607
		// (Invoke) Token: 0x06011095 RID: 69781
		public delegate bool XEventHandler(XEventArgs e);
	}
}
