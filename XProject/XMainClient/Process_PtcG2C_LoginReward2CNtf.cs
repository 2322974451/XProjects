using System;

namespace XMainClient
{
	// Token: 0x020011CF RID: 4559
	internal class Process_PtcG2C_LoginReward2CNtf
	{
		// Token: 0x0600DC03 RID: 56323 RVA: 0x0032FC0C File Offset: 0x0032DE0C
		public static void Process(PtcG2C_LoginReward2CNtf roPtc)
		{
			XSevenLoginDocument specificDocument = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
			specificDocument.OnSevenLoginReward(roPtc.Data);
		}
	}
}
