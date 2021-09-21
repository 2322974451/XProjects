using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200107C RID: 4220
	internal class Process_RpcC2G_StartGuildCard
	{
		// Token: 0x0600D6AB RID: 54955 RVA: 0x00326718 File Offset: 0x00324918
		public static void OnReply(StartGuildCardArg oArg, StartGuildCardRes oRes)
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
					specificDocument.ShowCard(oRes.card, oRes.result, oRes.store);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600D6AC RID: 54956 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(StartGuildCardArg oArg)
		{
		}
	}
}
