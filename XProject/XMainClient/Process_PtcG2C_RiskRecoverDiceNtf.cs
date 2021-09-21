using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001283 RID: 4739
	internal class Process_PtcG2C_RiskRecoverDiceNtf
	{
		// Token: 0x0600DEE6 RID: 57062 RVA: 0x00333CE0 File Offset: 0x00331EE0
		public static void Process(PtcG2C_RiskRecoverDiceNtf roPtc)
		{
			XSuperRiskDocument xsuperRiskDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument;
			xsuperRiskDocument.SetDiceLeftTime(roPtc.Data.diceNum, roPtc.Data.leftDiceTime);
		}
	}
}
