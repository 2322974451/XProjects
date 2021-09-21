using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001171 RID: 4465
	internal class Process_RpcC2G_SweepTower
	{
		// Token: 0x0600DA98 RID: 55960 RVA: 0x0032DDCC File Offset: 0x0032BFCC
		public static void OnReply(SweepTowerArg oArg, SweepTowerRes oRes)
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
					specificDocument.SweepSingleTowerRes(oArg, oRes);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
			}
		}

		// Token: 0x0600DA99 RID: 55961 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SweepTowerArg oArg)
		{
		}
	}
}
