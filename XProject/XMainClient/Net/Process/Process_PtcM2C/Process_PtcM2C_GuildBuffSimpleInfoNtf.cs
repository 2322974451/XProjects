using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildBuffSimpleInfoNtf
	{

		public static void Process(PtcM2C_GuildBuffSimpleInfoNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildBuffList(roPtc.Data.buff);
		}
	}
}
