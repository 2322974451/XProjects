using System;

namespace XMainClient
{
	// Token: 0x0200125A RID: 4698
	internal class Process_PtcG2C_PlayDiceNtf
	{
		// Token: 0x0600DE3E RID: 56894 RVA: 0x00333000 File Offset: 0x00331200
		public static void Process(PtcG2C_PlayDiceNtf roPtc)
		{
			XSuperRiskDocument.Doc.PlayDiceNtfBack(roPtc);
		}
	}
}
