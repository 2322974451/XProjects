using System;

namespace XMainClient
{
	// Token: 0x020010A7 RID: 4263
	internal class Process_PtcG2C_TakeRandomTask
	{
		// Token: 0x0600D75C RID: 55132 RVA: 0x00327C54 File Offset: 0x00325E54
		public static void Process(PtcG2C_TakeRandomTask roPtc)
		{
			XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			specificDocument.OnTaskRandomTask(roPtc.Data.taskid);
		}
	}
}
