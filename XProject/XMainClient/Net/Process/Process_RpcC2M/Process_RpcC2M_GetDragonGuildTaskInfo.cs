using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetDragonGuildTaskInfo
	{

		public static void OnReply(GetDragonGuildTaskInfoArg oArg, GetDragonGuildTaskInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XDragonGuildTaskDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildTaskDocument>(XDragonGuildTaskDocument.uuID);
				specificDocument.OnGetInfo(oRes);
			}
		}

		public static void OnTimeout(GetDragonGuildTaskInfoArg oArg)
		{
		}
	}
}
