using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000A99 RID: 2713
	internal class XPrefixAttributes : IComparable<XPrefixAttributes>
	{
		// Token: 0x17002FE2 RID: 12258
		// (get) Token: 0x0600A4FA RID: 42234 RVA: 0x001CAB60 File Offset: 0x001C8D60
		public List<XPrefixAttribute> AttributeList
		{
			get
			{
				return this.m_AttributeList;
			}
		}

		// Token: 0x0600A4FB RID: 42235 RVA: 0x001CAB78 File Offset: 0x001C8D78
		public int CompareTo(XPrefixAttributes other)
		{
			return this.slotIndex.CompareTo(other.slotIndex);
		}

		// Token: 0x04003C21 RID: 15393
		public uint slotIndex = 0U;

		// Token: 0x04003C22 RID: 15394
		private List<XPrefixAttribute> m_AttributeList = new List<XPrefixAttribute>();
	}
}
