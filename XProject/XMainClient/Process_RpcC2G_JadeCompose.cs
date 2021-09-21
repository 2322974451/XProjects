using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001038 RID: 4152
	internal class Process_RpcC2G_JadeCompose
	{
		// Token: 0x0600D58E RID: 54670 RVA: 0x003244B0 File Offset: 0x003226B0
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

		// Token: 0x0600D58F RID: 54671 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(JadeComposeArg oArg)
		{
		}
	}
}
