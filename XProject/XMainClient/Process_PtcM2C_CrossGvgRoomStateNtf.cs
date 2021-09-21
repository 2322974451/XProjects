using System;

namespace XMainClient
{
	// Token: 0x02001699 RID: 5785
	internal class Process_PtcM2C_CrossGvgRoomStateNtf
	{
		// Token: 0x0600EFBD RID: 61373 RVA: 0x0034BD5C File Offset: 0x00349F5C
		public static void Process(PtcM2C_CrossGvgRoomStateNtf roPtc)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.NotifyCrossGVGRoomState(roPtc.Data.room, roPtc.Data.record);
		}
	}
}
