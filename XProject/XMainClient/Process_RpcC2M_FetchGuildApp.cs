using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001294 RID: 4756
	internal class Process_RpcC2M_FetchGuildApp
	{
		// Token: 0x0600DF30 RID: 57136 RVA: 0x003342C8 File Offset: 0x003324C8
		public static void OnReply(FetchGAPPArg oArg, FetchGAPPRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildApproveDocument specificDocument = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
					specificDocument.OnGetApproveList(oRes);
				}
			}
		}

		// Token: 0x0600DF31 RID: 57137 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchGAPPArg oArg)
		{
		}
	}
}
