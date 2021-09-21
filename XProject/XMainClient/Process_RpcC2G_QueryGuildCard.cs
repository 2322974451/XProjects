using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200107E RID: 4222
	internal class Process_RpcC2G_QueryGuildCard
	{
		// Token: 0x0600D6B4 RID: 54964 RVA: 0x00326828 File Offset: 0x00324A28
		public static void OnReply(QueryGuildCardArg oArg, QueryGuildCardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
				specificDocument.SetGameCount(oRes.playcount, oRes.changecount, oRes.buychangcount);
				specificDocument.SetBestCard(oRes.bestcards, oRes.bestrole);
			}
		}

		// Token: 0x0600D6B5 RID: 54965 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryGuildCardArg oArg)
		{
		}
	}
}
