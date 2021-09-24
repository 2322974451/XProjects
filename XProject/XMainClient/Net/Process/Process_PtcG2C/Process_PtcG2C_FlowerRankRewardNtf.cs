using System;

namespace XMainClient
{

	internal class Process_PtcG2C_FlowerRankRewardNtf
	{

		public static void Process(PtcG2C_FlowerRankRewardNtf roPtc)
		{
			XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			specificDocument.CanGetAwardNtf();
		}
	}
}
