using System;

namespace XMainClient
{

	internal class Process_PtcG2C_RiskBuyNtf
	{

		public static void Process(PtcG2C_RiskBuyNtf roPtc)
		{
			XSuperRiskDocument.Doc.RiskBuyNtfBack(roPtc);
		}
	}
}
