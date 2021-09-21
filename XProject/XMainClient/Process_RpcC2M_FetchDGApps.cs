using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001629 RID: 5673
	internal class Process_RpcC2M_FetchDGApps
	{
		// Token: 0x0600EDE1 RID: 60897 RVA: 0x00348F50 File Offset: 0x00347150
		public static void OnReply(FetchDGAppArg oArg, FetchDGAppRes oRes)
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
					XDragonGuildApproveDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildApproveDocument>(XDragonGuildApproveDocument.uuID);
					specificDocument.OnGetApproveList(oRes);
				}
			}
		}

		// Token: 0x0600EDE2 RID: 60898 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchDGAppArg oArg)
		{
		}
	}
}
