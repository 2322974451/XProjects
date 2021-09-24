using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BackFlowActivityOperation
	{

		public static void OnReply(BackFlowActivityOperationArg oArg, BackFlowActivityOperationRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XBackFlowDocument.Doc.OnGetBackFlowOperation(oArg, oRes);
			}
		}

		public static void OnTimeout(BackFlowActivityOperationArg oArg)
		{
		}
	}
}
