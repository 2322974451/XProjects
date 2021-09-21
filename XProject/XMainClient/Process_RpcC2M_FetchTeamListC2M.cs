using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011DF RID: 4575
	internal class Process_RpcC2M_FetchTeamListC2M
	{
		// Token: 0x0600DC46 RID: 56390 RVA: 0x003301BC File Offset: 0x0032E3BC
		public static void OnReply(FetchTeamListArg oArg, FetchTeamListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					specificDocument.OnGetTeamList(oRes);
				}
			}
		}

		// Token: 0x0600DC47 RID: 56391 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchTeamListArg oArg)
		{
		}
	}
}
