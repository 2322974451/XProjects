using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001082 RID: 4226
	internal class Process_RpcC2G_EndGuildCard
	{
		// Token: 0x0600D6C6 RID: 54982 RVA: 0x00326A4C File Offset: 0x00324C4C
		public static void OnReply(EndGuildCardArg oArg, EndGuildCardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
					specificDocument.EndCardGame(oRes.result);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600D6C7 RID: 54983 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EndGuildCardArg oArg)
		{
		}
	}
}
