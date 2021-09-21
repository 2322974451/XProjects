using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200164D RID: 5709
	internal class Process_RpcC2M_DragonGuildUnBindGroup
	{
		// Token: 0x0600EE7F RID: 61055 RVA: 0x00349DB0 File Offset: 0x00347FB0
		public static void OnReply(DragonGuildUnBindGroupArg oArg, DragonGuildUnBindGroupRes oRes)
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
					XDragonGuildDocument.Doc.OnUnbindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EE80 RID: 61056 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGuildUnBindGroupArg oArg)
		{
		}
	}
}
