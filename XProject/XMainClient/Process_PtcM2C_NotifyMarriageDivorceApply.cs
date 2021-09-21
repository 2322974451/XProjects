using System;

namespace XMainClient
{
	// Token: 0x020015B6 RID: 5558
	internal class Process_PtcM2C_NotifyMarriageDivorceApply
	{
		// Token: 0x0600EBFE RID: 60414 RVA: 0x0034679C File Offset: 0x0034499C
		public static void Process(PtcM2C_NotifyMarriageDivorceApply roPtc)
		{
			XWeddingDocument.Doc.OnGetMarriageDivorceNotify(roPtc);
		}
	}
}
