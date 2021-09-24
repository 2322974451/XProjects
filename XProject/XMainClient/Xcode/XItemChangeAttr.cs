using System;

namespace XMainClient
{

	internal struct XItemChangeAttr : IComparable<XItemChangeAttr>
	{

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

		public uint AttrID;

		public uint AttrValue;
	}
}
