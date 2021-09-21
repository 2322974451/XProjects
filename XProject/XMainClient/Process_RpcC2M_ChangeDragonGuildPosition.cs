using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001645 RID: 5701
	internal class Process_RpcC2M_ChangeDragonGuildPosition
	{
		// Token: 0x0600EE5B RID: 61019 RVA: 0x00349A20 File Offset: 0x00347C20
		public static void OnReply(ChangeDragonGuildPositionArg oArg, ChangeDragonGuildPositionRes oRes)
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
					XDragonGuildDocument.Doc.OnChangePosition(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EE5C RID: 61020 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeDragonGuildPositionArg oArg)
		{
		}
	}
}
