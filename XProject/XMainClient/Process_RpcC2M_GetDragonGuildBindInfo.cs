using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001647 RID: 5703
	internal class Process_RpcC2M_GetDragonGuildBindInfo
	{
		// Token: 0x0600EE64 RID: 61028 RVA: 0x00349B04 File Offset: 0x00347D04
		public static void OnReply(GetDragonGuildBindInfoArg oArg, GetDragonGuildBindInfoRes oRes)
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
					XDragonGuildDocument.Doc.OnGetQQGroupBindInfo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EE65 RID: 61029 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonGuildBindInfoArg oArg)
		{
		}
	}
}
