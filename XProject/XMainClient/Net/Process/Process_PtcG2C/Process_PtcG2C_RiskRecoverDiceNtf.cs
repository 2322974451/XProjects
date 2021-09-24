using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_RiskRecoverDiceNtf
	{

		public static void Process(PtcG2C_RiskRecoverDiceNtf roPtc)
		{
			XSuperRiskDocument xsuperRiskDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument;
			xsuperRiskDocument.SetDiceLeftTime(roPtc.Data.diceNum, roPtc.Data.leftDiceTime);
		}
	}
}
