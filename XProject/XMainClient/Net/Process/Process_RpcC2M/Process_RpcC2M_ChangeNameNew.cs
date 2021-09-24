using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ChangeNameNew
	{

		public static void OnReply(ChangeNameArg oArg, ChangeNameRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
				specificDocument.ReceivePlayerCostRename(oArg, oRes);
			}
		}

		public static void OnTimeout(ChangeNameArg oArg)
		{
		}
	}
}
