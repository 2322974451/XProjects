using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001157 RID: 4439
	internal class Process_RpcC2G_MulActivityReq
	{
		// Token: 0x0600DA27 RID: 55847 RVA: 0x0032CBD8 File Offset: 0x0032ADD8
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

		// Token: 0x0600DA28 RID: 55848 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MulActivityArg oArg)
		{
		}
	}
}
