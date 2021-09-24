using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarTimeNtf
	{

		public static void Process(PtcM2C_ResWarTimeNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.ActivityStatusChange(roPtc);
		}
	}
}
