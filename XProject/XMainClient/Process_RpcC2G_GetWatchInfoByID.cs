using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001159 RID: 4441
	internal class Process_RpcC2G_GetWatchInfoByID
	{
		// Token: 0x0600DA30 RID: 55856 RVA: 0x0032CCAC File Offset: 0x0032AEAC
		public static void OnReply(GetWatchInfoByIDArg oArg, GetWatchInfoByIDRes oRes)
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
					XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
					specificDocument.SetSpectateInfo(oRes.curTime, oRes.liveRecords);
				}
			}
		}

		// Token: 0x0600DA31 RID: 55857 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetWatchInfoByIDArg oArg)
		{
		}
	}
}
