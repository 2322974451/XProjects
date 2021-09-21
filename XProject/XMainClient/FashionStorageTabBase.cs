using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008DF RID: 2271
	internal class FashionStorageTabBase : IFashionStorageSelect
	{
		// Token: 0x17002AE4 RID: 10980
		// (get) Token: 0x060089A2 RID: 35234 RVA: 0x001217E4 File Offset: 0x0011F9E4
		// (set) Token: 0x060089A3 RID: 35235 RVA: 0x001217FC File Offset: 0x0011F9FC
		public bool Select
		{
			get
			{
				return this.m_select;
			}
			set
			{
				this.m_select = value;
			}
		}

		// Token: 0x17002AE5 RID: 10981
		// (get) Token: 0x060089A4 RID: 35236 RVA: 0x00121808 File Offset: 0x0011FA08
		public virtual bool RedPoint
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002AE6 RID: 10982
		// (get) Token: 0x060089A5 RID: 35237 RVA: 0x0012181C File Offset: 0x0011FA1C
		public virtual bool Active
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002AE7 RID: 10983
		// (get) Token: 0x060089A6 RID: 35238 RVA: 0x00121830 File Offset: 0x0011FA30
		public virtual bool ActivateAll
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060089A7 RID: 35239 RVA: 0x00121844 File Offset: 0x0011FA44
		public virtual int GetID()
		{
			return 0;
		}

		// Token: 0x060089A8 RID: 35240 RVA: 0x00121858 File Offset: 0x0011FA58
		public virtual int GetCount()
		{
			return 0;
		}

		// Token: 0x060089A9 RID: 35241 RVA: 0x0012186C File Offset: 0x0011FA6C
		public virtual List<uint> GetItems()
		{
			bool flag = this.m_items == null;
			if (flag)
			{
				this.m_items = new List<uint>();
			}
			return this.m_items;
		}

		// Token: 0x060089AA RID: 35242 RVA: 0x0012189C File Offset: 0x0011FA9C
		public virtual string GetName()
		{
			return "";
		}

		// Token: 0x060089AB RID: 35243 RVA: 0x001218B4 File Offset: 0x0011FAB4
		public virtual uint[] GetFashionList()
		{
			return this.m_fashionList;
		}

		// Token: 0x060089AC RID: 35244 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void SetCount(uint count)
		{
		}

		// Token: 0x060089AD RID: 35245 RVA: 0x001218CC File Offset: 0x0011FACC
		public virtual List<AttributeCharm> GetAttributeCharm()
		{
			return null;
		}

		// Token: 0x060089AE RID: 35246 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Refresh()
		{
		}

		// Token: 0x060089AF RID: 35247 RVA: 0x001218E0 File Offset: 0x0011FAE0
		public virtual string GetLabel()
		{
			return "";
		}

		// Token: 0x04002BB0 RID: 11184
		private bool m_select = false;

		// Token: 0x04002BB1 RID: 11185
		protected uint[] m_fashionList;

		// Token: 0x04002BB2 RID: 11186
		protected List<uint> m_items;
	}
}
