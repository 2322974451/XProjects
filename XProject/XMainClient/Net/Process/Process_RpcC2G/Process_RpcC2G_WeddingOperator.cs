using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_WeddingOperator
	{

		public static void OnReply(WeddingOperatorArg oArg, WeddingOperatorRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XWeddingDocument.Doc.OnWeddingSceneOperator(oArg, oRes);
			}
		}

		public static void OnTimeout(WeddingOperatorArg oArg)
		{
		}
	}
}
