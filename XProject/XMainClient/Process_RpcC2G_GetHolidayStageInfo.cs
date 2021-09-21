using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200148E RID: 5262
	internal class Process_RpcC2G_GetHolidayStageInfo
	{
		// Token: 0x0600E73D RID: 59197 RVA: 0x0033FB80 File Offset: 0x0033DD80
		public static void OnReply(GetHolidayStageInfoArg oArg, GetHolidayStageInfoRes oRes)
		{
			XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
			specificDocument.SetHolidayData(oRes);
		}

		// Token: 0x0600E73E RID: 59198 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetHolidayStageInfoArg oArg)
		{
		}
	}
}
