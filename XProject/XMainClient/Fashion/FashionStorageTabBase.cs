using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class FashionStorageTabBase : IFashionStorageSelect
	{

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

		public virtual bool RedPoint
		{
			get
			{
				return false;
			}
		}

		public virtual bool Active
		{
			get
			{
				return true;
			}
		}

		public virtual bool ActivateAll
		{
			get
			{
				return false;
			}
		}

		public virtual int GetID()
		{
			return 0;
		}

		public virtual int GetCount()
		{
			return 0;
		}

		public virtual List<uint> GetItems()
		{
			bool flag = this.m_items == null;
			if (flag)
			{
				this.m_items = new List<uint>();
			}
			return this.m_items;
		}

		public virtual string GetName()
		{
			return "";
		}

		public virtual uint[] GetFashionList()
		{
			return this.m_fashionList;
		}

		public virtual void SetCount(uint count)
		{
		}

		public virtual List<AttributeCharm> GetAttributeCharm()
		{
			return null;
		}

		public virtual void Refresh()
		{
		}

		public virtual string GetLabel()
		{
			return "";
		}

		private bool m_select = false;

		protected uint[] m_fashionList;

		protected List<uint> m_items;
	}
}
