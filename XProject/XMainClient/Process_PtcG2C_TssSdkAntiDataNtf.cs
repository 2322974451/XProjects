using System;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200111E RID: 4382
	internal class Process_PtcG2C_TssSdkAntiDataNtf
	{
		// Token: 0x0600D93D RID: 55613 RVA: 0x0032ABB4 File Offset: 0x00328DB4
		public static void Process(PtcG2C_TssSdkAntiDataNtf roPtc)
		{
			XSingleton<XUpdater.XUpdater>.singleton.XTssSdk.OnRcvWhichNeedToSendClientSdk(roPtc.Data.anti_data, roPtc.Data.anti_data_len);
		}
	}
}
