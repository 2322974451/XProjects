using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetAncientTimesAward
	{

		public static void OnReply(AncientTimesArg oArg, AncientTimesRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
			}
			bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag2)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag3 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag3)
				{
					XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
					specificDocument.ResPoint(oRes.reward);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
				}
			}
		}

		public static void OnTimeout(AncientTimesArg oArg)
		{
		}
	}
}
