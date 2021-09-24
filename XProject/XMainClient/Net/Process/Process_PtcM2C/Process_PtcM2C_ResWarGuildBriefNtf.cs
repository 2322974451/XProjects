using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarGuildBriefNtf
	{

		public static void Process(PtcM2C_ResWarGuildBriefNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.SetNewInfo(roPtc);
		}
	}
}
