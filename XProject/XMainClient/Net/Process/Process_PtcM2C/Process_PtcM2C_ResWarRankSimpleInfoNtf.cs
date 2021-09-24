using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarRankSimpleInfoNtf
	{

		public static void Process(PtcM2C_ResWarRankSimpleInfoNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildInfoList(roPtc.Data);
		}
	}
}
