using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_SendFlower
	{

		public static void OnReply(SendFlowerArg oArg, SendFlowerRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFlowerSendDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerSendDocument>(XFlowerSendDocument.uuID);
				specificDocument.OnSendFlower(oArg, oRes);
			}
		}

		public static void OnTimeout(SendFlowerArg oArg)
		{
		}
	}
}
