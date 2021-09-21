using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001658 RID: 5720
	internal class Process_PtcG2C_WordNotify
	{
		// Token: 0x0600EEAE RID: 61102 RVA: 0x0034A228 File Offset: 0x00348428
		public static void Process(PtcG2C_WordNotify roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.hint, "fece00");
		}
	}
}
