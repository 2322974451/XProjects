using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200164B RID: 5707
	internal class Process_RpcC2M_DragonGuildJoinBindGroup
	{
		// Token: 0x0600EE76 RID: 61046 RVA: 0x00349CCC File Offset: 0x00347ECC
		public static void OnReply(DragonGuildJoinBindGroupArg oArg, DragonGuildJoinBindGroupRes oRes)
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
					XDragonGuildDocument.Doc.OnJoinBindQQGroup(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EE77 RID: 61047 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGuildJoinBindGroupArg oArg)
		{
		}
	}
}
