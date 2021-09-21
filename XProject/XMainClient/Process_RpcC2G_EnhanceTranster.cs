using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001138 RID: 4408
	internal class Process_RpcC2G_EnhanceTranster
	{
		// Token: 0x0600D9A7 RID: 55719 RVA: 0x0032B688 File Offset: 0x00329888
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

		// Token: 0x0600D9A8 RID: 55720 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnhanceTransterArg oArg)
		{
		}
	}
}
