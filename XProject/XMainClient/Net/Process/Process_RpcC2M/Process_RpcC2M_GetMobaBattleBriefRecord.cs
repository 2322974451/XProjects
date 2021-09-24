using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetMobaBattleBriefRecord
	{

		public static void OnReply(GetMobaBattleBriefRecordArg oArg, GetMobaBattleBriefRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaRecordTotal(oArg, oRes);
			}
		}

		public static void OnTimeout(GetMobaBattleBriefRecordArg oArg)
		{
		}
	}
}
