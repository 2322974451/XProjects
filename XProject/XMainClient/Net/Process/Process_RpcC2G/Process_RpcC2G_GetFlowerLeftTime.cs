using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetFlowerLeftTime
	{

		public static void OnReply(GetFlowerLeftTimeArg oArg, GetFlowerLeftTimeRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				specificDocument.OnGetFlowerLeftTime(oRes);
			}
		}

		public static void OnTimeout(GetFlowerLeftTimeArg oArg)
		{
		}
	}
}
