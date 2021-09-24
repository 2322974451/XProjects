using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ItemCircleDrawResult
	{

		public static void Process(PtcG2C_ItemCircleDrawResult roPtc)
		{
			XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			specificDocument.ShowLotteryResult((int)roPtc.Data.index);
		}
	}
}
