using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_JadeCompose
	{

		public static void OnReply(JadeComposeArg oArg, JadeComposeRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XJadeDocument xjadeDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XJadeDocument.uuID) as XJadeDocument;
				xjadeDocument.OnComposeJade(oArg, oRes);
			}
		}

		public static void OnTimeout(JadeComposeArg oArg)
		{
		}
	}
}
