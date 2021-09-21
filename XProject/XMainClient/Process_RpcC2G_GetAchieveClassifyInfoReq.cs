using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010F8 RID: 4344
	internal class Process_RpcC2G_GetAchieveClassifyInfoReq
	{
		// Token: 0x0600D89C RID: 55452 RVA: 0x00329D1C File Offset: 0x00327F1C
		public static void OnReply(GetAchieveClassifyInfoReq oArg, GetAchieveClassifyInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				specificDocument.OnResAchieveType(oRes);
			}
		}

		// Token: 0x0600D89D RID: 55453 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAchieveClassifyInfoReq oArg)
		{
		}
	}
}
