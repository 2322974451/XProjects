using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildBuffCDParamNtf
	{

		public static void Process(PtcM2C_GuildBuffCDParamNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildBuffCD(roPtc.Data);
		}
	}
}
