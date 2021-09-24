using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetMobaBattleGameRecord
	{

		public static void OnReply(GetMobaBattleGameRecordArg oArg, GetMobaBattleGameRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaRecordRound(oArg, oRes);
			}
		}

		public static void OnTimeout(GetMobaBattleGameRecordArg oArg)
		{
		}
	}
}
