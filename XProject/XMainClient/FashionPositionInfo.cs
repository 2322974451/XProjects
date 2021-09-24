using System;

namespace XMainClient
{

	public struct FashionPositionInfo
	{

		public FashionPositionInfo(int id)
		{
			this.fasionID = id;
			this.itemID = id;
			this.fashionName = "";
			this.fashionDir = "";
			this.presentID = 0U;
			this.replace = false;
		}

		public void Reset()
		{
			this.fasionID = 0;
			this.itemID = 0;
			this.fashionName = "";
			this.fashionDir = "";
			this.presentID = 0U;
			this.replace = false;
		}

		public bool Equals(ref FashionPositionInfo fpi)
		{
			return this.fasionID == fpi.fasionID && this.fashionName == fpi.fashionName && this.presentID == fpi.presentID && this.itemID == fpi.itemID;
		}

		public int fasionID;

		public int itemID;

		public string fashionName;

		public string fashionDir;

		public uint presentID;

		public bool replace;
	}
}
