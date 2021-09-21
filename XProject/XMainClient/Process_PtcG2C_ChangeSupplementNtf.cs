using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010CC RID: 4300
	internal class Process_PtcG2C_ChangeSupplementNtf
	{
		// Token: 0x0600D7E8 RID: 55272 RVA: 0x00328C9C File Offset: 0x00326E9C
		public static void Process(PtcG2C_ChangeSupplementNtf roPtc)
		{
			bool flag = roPtc.Data.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.errorcode, "fece00");
			}
		}
	}
}
