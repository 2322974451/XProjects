using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildBuffSimpleItemNtf
	{

		public static void Process(PtcM2C_GuildBuffSimpleItemNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetOwnedGuildBuffList(roPtc);
		}
	}
}
