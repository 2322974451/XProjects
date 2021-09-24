using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetLuckyActivityInfo
	{

		public static void OnReply(GetLuckyActivityInfoArg oArg, GetLuckyActivityInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
				specificDocument.OnReceiveGetLuckyTurntableData(oRes);
			}
		}

		public static void OnTimeout(GetLuckyActivityInfoArg oArg)
		{
		}
	}
}
