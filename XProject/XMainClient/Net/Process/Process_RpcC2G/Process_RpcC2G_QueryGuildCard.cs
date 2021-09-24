using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryGuildCard
	{

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

		public static void OnTimeout(QueryGuildCardArg oArg)
		{
		}
	}
}
