using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200160A RID: 5642
	internal class Process_RpcC2G_GetLuckyActivityInfo
	{
		// Token: 0x0600ED5B RID: 60763 RVA: 0x00348354 File Offset: 0x00346554
		public static void OnReply(GetLuckyActivityInfoArg oArg, GetLuckyActivityInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
				specificDocument.OnReceiveGetLuckyTurntableData(oRes);
			}
		}

		// Token: 0x0600ED5C RID: 60764 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLuckyActivityInfoArg oArg)
		{
		}
	}
}
