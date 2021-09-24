using System;

namespace XMainClient
{

	internal struct XAttrPair
	{

		public XAttrPair(XAttributeDefine attr, double value)
		{
			this.AttrID = attr;
			this.AttrValue = value;
		}

		public XAttributeDefine AttrID;

		public double AttrValue;
	}
}
