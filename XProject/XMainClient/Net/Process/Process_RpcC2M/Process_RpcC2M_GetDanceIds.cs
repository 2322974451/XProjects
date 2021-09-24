using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetDanceIds
	{

		public static void OnReply(GetDanceIdsArg oArg, GetDanceIdsRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XDanceDocument.Doc.OnGetDanceIDs(oRes);
			}
		}

		public static void OnTimeout(GetDanceIdsArg oArg)
		{
		}
	}
}
