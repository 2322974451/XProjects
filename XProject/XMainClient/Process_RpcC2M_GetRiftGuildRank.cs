using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200167B RID: 5755
	internal class Process_RpcC2M_GetRiftGuildRank
	{
		// Token: 0x0600EF3B RID: 61243 RVA: 0x0034AF20 File Offset: 0x00349120
		public static void OnReply(GetRiftGuildRankArg oArg, GetRiftGuildRankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
					else
					{
						XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
						specificDocument.ResGuildRank(oRes);
					}
				}
			}
		}

		// Token: 0x0600EF3C RID: 61244 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetRiftGuildRankArg oArg)
		{
		}
	}
}
