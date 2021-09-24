using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_TitleLevelUp
	{

		public static void OnReply(TitleLevelUpArg oArg, TitleLevelUpRes oRes)
		{
			XTitleDocument specificDocument = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			specificDocument.OnGetTitleLevelUp(oRes);
		}

		public static void OnTimeout(TitleLevelUpArg oArg)
		{
		}
	}
}
