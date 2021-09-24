using System;
using KKSG;

namespace XMainClient
{

	public class BagExpandData
	{

		public BagExpandData(BagType type)
		{
			this.Type = type;
		}

		public uint ExpandNum = 0U;

		public uint ExpandTimes = 0U;

		public BagType Type = BagType.ItemBag;
	}
}
