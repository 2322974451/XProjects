using System;

namespace XMainClient
{

	internal class AuctionSaleItem : AuctionItem
	{

		public bool isOutTime
		{
			get
			{
				return this.duelefttime == 0U;
			}
		}

		public uint duelefttime;
	}
}
