using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001036 RID: 4150
	internal class Process_RpcC2G_JadeOperation
	{
		// Token: 0x0600D585 RID: 54661 RVA: 0x003243D8 File Offset: 0x003225D8
		public static void OnReply(JadeOperationArg oArg, JadeOperationRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				specificDocument.OnOperateJade(oArg, oRes);
			}
		}

		// Token: 0x0600D586 RID: 54662 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(JadeOperationArg oArg)
		{
		}
	}
}
