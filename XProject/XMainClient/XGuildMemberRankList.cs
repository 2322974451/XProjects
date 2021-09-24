using System;

namespace XMainClient
{

	public class XGuildMemberRankList : XBaseRankList
	{

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildMemberRankInfo();
		}
	}
}
