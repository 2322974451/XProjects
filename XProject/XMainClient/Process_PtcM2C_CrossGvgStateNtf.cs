using System;

namespace XMainClient
{
	// Token: 0x02001685 RID: 5765
	internal class Process_PtcM2C_CrossGvgStateNtf
	{
		// Token: 0x0600EF65 RID: 61285 RVA: 0x0034B43C File Offset: 0x0034963C
		public static void Process(PtcM2C_CrossGvgStateNtf roPtc)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.SynCrossGVGTimeState(roPtc.Data.state);
		}
	}
}
