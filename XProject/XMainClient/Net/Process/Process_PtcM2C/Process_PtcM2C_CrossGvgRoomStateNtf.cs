using System;

namespace XMainClient
{

	internal class Process_PtcM2C_CrossGvgRoomStateNtf
	{

		public static void Process(PtcM2C_CrossGvgRoomStateNtf roPtc)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.NotifyCrossGVGRoomState(roPtc.Data.room, roPtc.Data.record);
		}
	}
}
