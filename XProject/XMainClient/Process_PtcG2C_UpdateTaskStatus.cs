using System;

namespace XMainClient
{
	// Token: 0x020012CB RID: 4811
	internal class Process_PtcG2C_UpdateTaskStatus
	{
		// Token: 0x0600E011 RID: 57361 RVA: 0x00335844 File Offset: 0x00333A44
		public static void Process(PtcG2C_UpdateTaskStatus roPtc)
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			specificDocument.OnTaskStatusUpdate(roPtc.Data);
		}
	}
}
