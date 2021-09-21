using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010F0 RID: 4336
	internal class Process_RpcC2G_GetClassifyDesignationReq
	{
		// Token: 0x0600D87C RID: 55420 RVA: 0x00329A24 File Offset: 0x00327C24
		public static void OnReply(GetClassifyDesignationReq oArg, GetClassifyDesignationRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
					specificDocument.SetDesignationListData(oRes.dataList, (int)(oArg.type - 1U));
				}
			}
		}

		// Token: 0x0600D87D RID: 55421 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetClassifyDesignationReq oArg)
		{
		}
	}
}
