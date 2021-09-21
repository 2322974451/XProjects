using System;

namespace XMainClient
{
	// Token: 0x02000F38 RID: 3896
	internal struct XAttrPair
	{
		// Token: 0x0600CEE7 RID: 52967 RVA: 0x00300673 File Offset: 0x002FE873
		public XAttrPair(XAttributeDefine attr, double value)
		{
			this.AttrID = attr;
			this.AttrValue = value;
		}

		// Token: 0x04005D05 RID: 23813
		public XAttributeDefine AttrID;

		// Token: 0x04005D06 RID: 23814
		public double AttrValue;
	}
}
