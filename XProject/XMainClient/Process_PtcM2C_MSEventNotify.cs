using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001234 RID: 4660
	internal class Process_PtcM2C_MSEventNotify
	{
		// Token: 0x0600DD9D RID: 56733 RVA: 0x00332228 File Offset: 0x00330428
		public static void Process(PtcM2C_MSEventNotify roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.notify, "fece00");
		}
	}
}
