using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_EnhanceTranster
	{

		public static void OnReply(EnhanceTransterArg oArg, EnhanceTransterRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XEquipCreateDocument.Doc.OnReplyEnhanceTransform(oArg, oRes);
			}
		}

		public static void OnTimeout(EnhanceTransterArg oArg)
		{
		}
	}
}
