using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarStateNtf
	{

		public static void Process(PtcM2C_ResWarStateNtf roPtc)
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.TeamLeaderOperate(roPtc);
		}
	}
}
