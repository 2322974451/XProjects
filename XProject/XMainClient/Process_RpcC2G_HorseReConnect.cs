using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013F9 RID: 5113
	internal class Process_RpcC2G_HorseReConnect
	{
		// Token: 0x0600E4E9 RID: 58601 RVA: 0x0033C474 File Offset: 0x0033A674
		public static void OnReply(HorseReConnectArg oArg, HorseReConnectRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				else
				{
					XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
					specificDocument.RefreshAllInfo(oRes);
				}
			}
		}

		// Token: 0x0600E4EA RID: 58602 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(HorseReConnectArg oArg)
		{
		}
	}
}
