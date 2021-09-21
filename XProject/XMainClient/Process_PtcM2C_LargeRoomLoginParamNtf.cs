using System;

namespace XMainClient
{
	// Token: 0x020013B8 RID: 5048
	internal class Process_PtcM2C_LargeRoomLoginParamNtf
	{
		// Token: 0x0600E3DE RID: 58334 RVA: 0x0033AEF8 File Offset: 0x003390F8
		public static void Process(PtcM2C_LargeRoomLoginParamNtf roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.isHost = roPtc.Data.speaker;
		}
	}
}
