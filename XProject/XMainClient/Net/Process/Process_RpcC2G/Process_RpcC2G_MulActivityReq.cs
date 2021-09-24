using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_MulActivityReq
	{

		public static void OnReply(MulActivityArg oArg, MulActivityRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XActivityDocument.Doc.SetMulActivityInfo(oRes.actinfo);
			}
		}

		public static void OnTimeout(MulActivityArg oArg)
		{
		}
	}
}
