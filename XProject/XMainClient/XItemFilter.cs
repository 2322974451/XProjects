using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E74 RID: 3700
	internal class XItemFilter
	{
		// Token: 0x17003495 RID: 13461
		// (get) Token: 0x0600C62D RID: 50733 RVA: 0x002BDDF4 File Offset: 0x002BBFF4
		public ulong FilterValue
		{
			get
			{
				return this._FilterValue;
			}
		}

		// Token: 0x0600C62E RID: 50734 RVA: 0x002BDE0C File Offset: 0x002BC00C
		public void AddItemType(ItemType type)
		{
			bool flag = this._Types == null;
			if (flag)
			{
				this._Types = new HashSet<ItemType>(default(XFastEnumIntEqualityComparer<ItemType>));
			}
			this._Types.Add(type);
			this._FilterValue |= 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(type);
		}

		// Token: 0x0600C62F RID: 50735 RVA: 0x002BDE68 File Offset: 0x002BC068
		public void AddItemID(int id)
		{
			bool flag = this._IDs == null;
			if (flag)
			{
				this._IDs = new HashSet<int>(default(XFastEnumIntEqualityComparer<int>));
			}
			this._IDs.Add(id);
		}

		// Token: 0x0600C630 RID: 50736 RVA: 0x002BDEAC File Offset: 0x002BC0AC
		public void ExcludeItemType(ItemType type)
		{
			bool flag = this._Types == null;
			if (flag)
			{
				this._Types = new HashSet<ItemType>(default(XFastEnumIntEqualityComparer<ItemType>));
			}
			bool flag2 = !this.m_bExclusive;
			if (flag2)
			{
				this.m_bExclusive = true;
				this._FilterValue = ulong.MaxValue;
			}
			this._Types.Add(type);
			this._FilterValue &= ~(1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(type));
		}

		// Token: 0x0600C631 RID: 50737 RVA: 0x002BDF28 File Offset: 0x002BC128
		public void ExcludeItemID(int id)
		{
			bool flag = this._IDs == null;
			if (flag)
			{
				this._IDs = new HashSet<int>(default(XFastEnumIntEqualityComparer<int>));
			}
			bool flag2 = !this.m_bExclusive;
			if (flag2)
			{
				this.m_bExclusive = true;
			}
			this._IDs.Add(id);
		}

		// Token: 0x0600C632 RID: 50738 RVA: 0x002BDF80 File Offset: 0x002BC180
		public void Clear()
		{
			bool flag = this._Types != null;
			if (flag)
			{
				this._Types.Clear();
			}
			bool flag2 = this._IDs != null;
			if (flag2)
			{
				this._IDs.Clear();
			}
			this._FilterValue = 0UL;
			this.m_bExclusive = false;
		}

		// Token: 0x0600C633 RID: 50739 RVA: 0x002BDFD0 File Offset: 0x002BC1D0
		public bool Contains(ItemType type)
		{
			bool bExclusive = this.m_bExclusive;
			bool result;
			if (bExclusive)
			{
				result = (this._Types == null || !this._Types.Contains(type));
			}
			else
			{
				result = (this._Types != null && this._Types.Contains(type));
			}
			return result;
		}

		// Token: 0x0600C634 RID: 50740 RVA: 0x002BE024 File Offset: 0x002BC224
		public bool Contains(int id)
		{
			bool bExclusive = this.m_bExclusive;
			bool result;
			if (bExclusive)
			{
				result = (this._IDs == null || !this._IDs.Contains(id));
			}
			else
			{
				result = (this._IDs != null && this._IDs.Contains(id));
			}
			return result;
		}

		// Token: 0x0600C635 RID: 50741 RVA: 0x002BE078 File Offset: 0x002BC278
		public bool Contains(List<ItemType> types)
		{
			for (int i = 0; i < types.Count; i++)
			{
				bool flag = this.Contains(types[i]);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C636 RID: 50742 RVA: 0x002BE0B8 File Offset: 0x002BC2B8
		public bool Contains(List<int> ids)
		{
			for (int i = 0; i < ids.Count; i++)
			{
				bool flag = this.Contains(ids[i]);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040056F2 RID: 22258
		private HashSet<ItemType> _Types = null;

		// Token: 0x040056F3 RID: 22259
		private HashSet<int> _IDs = null;

		// Token: 0x040056F4 RID: 22260
		private ulong _FilterValue = 0UL;

		// Token: 0x040056F5 RID: 22261
		private bool m_bExclusive = false;
	}
}
