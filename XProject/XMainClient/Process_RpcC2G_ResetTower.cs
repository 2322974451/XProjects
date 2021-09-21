using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001173 RID: 4467
	internal class Process_RpcC2G_ResetTower
	{
		// Token: 0x0600DAA1 RID: 55969 RVA: 0x0032DECC File Offset: 0x0032C0CC
		public static void OnReply(ResetTowerArg oArg, ResetTowerRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					specificDocument.ResetSingleTowerRes();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
			}
		}

		// Token: 0x0600DAA2 RID: 55970 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResetTowerArg oArg)
		{
		}
	}
}
