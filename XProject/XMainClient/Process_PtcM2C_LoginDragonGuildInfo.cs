using System;

namespace XMainClient
{
	// Token: 0x02001627 RID: 5671
	internal class Process_PtcM2C_LoginDragonGuildInfo
	{
		// Token: 0x0600EDD9 RID: 60889 RVA: 0x00348EC0 File Offset: 0x003470C0
		public static void Process(PtcM2C_LoginDragonGuildInfo roPtc)
		{
			XDragonGuildDocument.Doc.InitData(roPtc);
		}
	}
}
