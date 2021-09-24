using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemFilter
	{

		public ulong FilterValue
		{
			get
			{
				return this._FilterValue;
			}
		}

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

		public void AddItemID(int id)
		{
			bool flag = this._IDs == null;
			if (flag)
			{
				this._IDs = new HashSet<int>(default(XFastEnumIntEqualityComparer<int>));
			}
			this._IDs.Add(id);
		}

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

		private HashSet<ItemType> _Types = null;

		private HashSet<int> _IDs = null;

		private ulong _FilterValue = 0UL;

		private bool m_bExclusive = false;
	}
}
