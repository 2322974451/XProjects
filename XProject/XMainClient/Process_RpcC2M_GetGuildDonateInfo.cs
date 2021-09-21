using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001394 RID: 5012
	internal class Process_RpcC2M_GetGuildDonateInfo
	{
		// Token: 0x0600E34A RID: 58186 RVA: 0x0033A24C File Offset: 0x0033844C
		public static void OnReply(GetGuildDonateInfoArg oArg, GetGuildDonateInfoRes oRes)
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
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XGuildDonateDocument.Doc.OnGetDonateInfo(oRes);
					}
				}
			}
		}

		// Token: 0x0600E34B RID: 58187 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildDonateInfoArg oArg)
		{
		}
	}
}
