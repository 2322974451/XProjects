using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FF7 RID: 4087
	internal class Process_PtcT2C_ErrorNotify
	{
		// Token: 0x0600D483 RID: 54403 RVA: 0x00321860 File Offset: 0x0031FA60
		public static void Process(PtcT2C_ErrorNotify roPtc)
		{
			XSingleton<XClientNetwork>.singleton.OnServerErrorNotify(roPtc.Data.errorno, null);
		}
	}
}
