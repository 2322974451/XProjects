using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildLadderStart
	{

		public static void Process(PtcM2C_NoticeGuildLadderStart roPtc)
		{
			XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			specificDocument.bHasAvailableLadderIcon = roPtc.Data.isstart;
		}
	}
}
