using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001101 RID: 4353
	internal class Process_RpcC2G_GetLevelSealInfo
	{
		// Token: 0x0600D8C3 RID: 55491 RVA: 0x00329FF4 File Offset: 0x003281F4
		public static void OnReply(GetLevelSealInfoArg oArg, GetLevelSealInfoRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					specificDocument.SetShowInfo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600D8C4 RID: 55492 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLevelSealInfoArg oArg)
		{
		}
	}
}
