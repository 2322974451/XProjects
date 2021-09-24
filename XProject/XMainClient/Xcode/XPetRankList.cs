using System;

namespace XMainClient
{

	public class XPetRankList : XBaseRankList
	{

		public XPetRankList()
		{
			this.type = XRankType.PetRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XPetRankInfo();
		}
	}
}
