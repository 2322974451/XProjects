using System;

namespace XMainClient
{
	// Token: 0x02000DDC RID: 3548
	internal struct XItemChangeAttr : IComparable<XItemChangeAttr>
	{
		// Token: 0x0600C0C3 RID: 49347 RVA: 0x0028D384 File Offset: 0x0028B584
		public int CompareTo(XItemChangeAttr other)
		{
			bool flag = this.AttrID == other.AttrID;
			int result;
			if (flag)
			{
				result = this.AttrValue.CompareTo(other.AttrValue);
			}
			else
			{
				result = this.AttrID.CompareTo(other.AttrID);
			}
			return result;
		}

		// Token: 0x040050ED RID: 20717
		public uint AttrID;

		// Token: 0x040050EE RID: 20718
		public uint AttrValue;
	}
}
