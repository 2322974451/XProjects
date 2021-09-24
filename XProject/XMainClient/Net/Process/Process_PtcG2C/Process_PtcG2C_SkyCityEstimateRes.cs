using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SkyCityEstimateRes
	{

		public static void Process(PtcG2C_SkyCityEstimateRes roPtc)
		{
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.SetBattleEndInfo(roPtc);
		}
	}
}
