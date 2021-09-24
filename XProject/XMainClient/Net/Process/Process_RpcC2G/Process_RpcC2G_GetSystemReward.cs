using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetSystemReward
	{

		public static void OnReply(GetSystemRewardArg oArg, GetSystemRewardRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSystemRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSystemRewardDocument>(XSystemRewardDocument.uuID);
				specificDocument.OnFetchReward(oRes);
			}
		}

		public static void OnTimeout(GetSystemRewardArg oArg)
		{
		}
	}
}
