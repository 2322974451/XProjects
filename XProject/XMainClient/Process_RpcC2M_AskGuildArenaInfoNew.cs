using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012C1 RID: 4801
	internal class Process_RpcC2M_AskGuildArenaInfoNew
	{
		// Token: 0x0600DFE7 RID: 57319 RVA: 0x00335480 File Offset: 0x00333680
		public static void OnReply(AskGuildArenaInfoArg oArg, AskGuildArenaInfoReq oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
					specificDocument.OnGuildArenaInfo(oRes);
				}
			}
		}

		// Token: 0x0600DFE8 RID: 57320 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskGuildArenaInfoArg oArg)
		{
		}
	}
}
