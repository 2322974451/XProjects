using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200148C RID: 5260
	internal class Process_PtcM2C_MidasExceptionNtf
	{
		// Token: 0x0600E735 RID: 59189 RVA: 0x0033FAC0 File Offset: 0x0033DCC0
		public static void Process(PtcM2C_MidasExceptionNtf roPtc)
		{
			bool flag = roPtc.Data.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.result, "fece00");
			}
		}
	}
}
