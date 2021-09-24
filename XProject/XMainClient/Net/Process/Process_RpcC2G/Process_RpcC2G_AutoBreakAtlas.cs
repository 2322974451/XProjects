using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_AutoBreakAtlas
	{

		public static void OnReply(AutoBreakAtlasArg oArg, AutoBreakAtlasRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
				specificDocument.OnAutoBreak(oArg, oRes);
			}
		}

		public static void OnTimeout(AutoBreakAtlasArg oArg)
		{
		}
	}
}
