using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetMobaBattleInfo
	{

		public static void OnReply(GetMobaBattleInfoArg oArg, GetMobaBattleInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
				specificDocument.SetMobaUIInfo(oArg, oRes);
			}
		}

		public static void OnTimeout(GetMobaBattleInfoArg oArg)
		{
		}
	}
}
