using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LoginDragonGuildInfo
	{

		public static void Process(PtcM2C_LoginDragonGuildInfo roPtc)
		{
			XDragonGuildDocument.Doc.InitData(roPtc);
		}
	}
}
