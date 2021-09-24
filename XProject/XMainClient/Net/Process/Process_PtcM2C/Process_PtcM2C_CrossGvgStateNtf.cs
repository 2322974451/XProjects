using System;

namespace XMainClient
{

	internal class Process_PtcM2C_CrossGvgStateNtf
	{

		public static void Process(PtcM2C_CrossGvgStateNtf roPtc)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.SynCrossGVGTimeState(roPtc.Data.state);
		}
	}
}
