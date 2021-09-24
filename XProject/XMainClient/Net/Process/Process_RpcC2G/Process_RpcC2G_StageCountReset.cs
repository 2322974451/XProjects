using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_StageCountReset
	{

		public static void OnReply(StageCountResetArg oArg, StageCountResetRes oRes)
		{
			XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			specificDocument.OnResetSceneSucc(oArg.groupid, oRes);
		}

		public static void OnTimeout(StageCountResetArg oArg)
		{
		}
	}
}
