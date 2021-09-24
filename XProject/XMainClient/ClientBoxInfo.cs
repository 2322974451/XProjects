using System;
using KKSG;

namespace XMainClient
{

	internal class ClientBoxInfo
	{

		public ClientBoxInfo(RiskBoxInfo r)
		{
			this.Apply(r);
		}

		public void Apply(RiskBoxInfo r)
		{
			this.slot = r.slot;
			this.itemID = r.item.itemID;
			this.itemCount = r.item.itemCount;
			this.state = r.state;
			this.leftTime = (float)r.leftTime;
		}

		public int slot;

		public uint itemID;

		public uint itemCount;

		public RiskBoxState state;

		public float leftTime;
	}
}
