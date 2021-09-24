using System;
using KKSG;

namespace XMainClient.UI
{

	internal interface IRankSource
	{

		void ReqRankData(RankeType type, bool inFight);

		XBaseRankList GetRankList(RankeType type);
	}
}
