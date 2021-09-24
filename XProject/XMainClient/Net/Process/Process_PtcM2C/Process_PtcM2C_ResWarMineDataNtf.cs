using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarMineDataNtf
	{

		public static void Process(PtcM2C_ResWarMineDataNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildResUpdate(roPtc.Data);
		}
	}
}
