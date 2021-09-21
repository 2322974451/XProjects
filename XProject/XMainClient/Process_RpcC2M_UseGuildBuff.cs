using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B73 RID: 2931
	internal class Process_RpcC2M_UseGuildBuff
	{
		// Token: 0x0600A936 RID: 43318 RVA: 0x001E1C50 File Offset: 0x001DFE50
		public static void OnReply(UseGuildBuffArg oArg, UseGuildBuffRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildResContentionBuffDocument.Doc.OnGetUseGuildBuffResult(oArg, oRes);
				}
			}
		}

		// Token: 0x0600A937 RID: 43319 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UseGuildBuffArg oArg)
		{
		}
	}
}
