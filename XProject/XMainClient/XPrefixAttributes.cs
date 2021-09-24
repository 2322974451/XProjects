using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XPrefixAttributes : IComparable<XPrefixAttributes>
	{

		public List<XPrefixAttribute> AttributeList
		{
			get
			{
				return this.m_AttributeList;
			}
		}

		public int CompareTo(XPrefixAttributes other)
		{
			return this.slotIndex.CompareTo(other.slotIndex);
		}

		public uint slotIndex = 0U;

		private List<XPrefixAttribute> m_AttributeList = new List<XPrefixAttribute>();
	}
}
