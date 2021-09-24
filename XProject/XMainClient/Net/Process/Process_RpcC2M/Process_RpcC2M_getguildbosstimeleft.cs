using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_getguildbosstimeleft
	{

		public static void OnReply(getguildbosstimeleftArg oArg, getguildbosstimeleftRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
				specificDocument.OnGetBattleInfo(oRes);
			}
		}

		public static void OnTimeout(getguildbosstimeleftArg oArg)
		{
		}
	}
}
