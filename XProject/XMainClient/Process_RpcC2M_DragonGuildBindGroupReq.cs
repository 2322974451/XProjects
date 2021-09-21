using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001649 RID: 5705
	internal class Process_RpcC2M_DragonGuildBindGroupReq
	{
		// Token: 0x0600EE6D RID: 61037 RVA: 0x00349BE8 File Offset: 0x00347DE8
		public static void OnReply(DragonGuildBindReq oArg, DragonGuildBindRes oRes)
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
					XDragonGuildDocument.Doc.OnBindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EE6E RID: 61038 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGuildBindReq oArg)
		{
		}
	}
}
