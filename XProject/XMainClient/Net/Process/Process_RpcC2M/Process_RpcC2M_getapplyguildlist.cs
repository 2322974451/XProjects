using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_getapplyguildlist
	{

		public static void OnReply(getapplyguildlistarg oArg, getapplyguildlistres oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				specificDocument.ReceiveApplyGuildList(oRes);
			}
		}

		public static void OnTimeout(getapplyguildlistarg oArg)
		{
		}
	}
}
