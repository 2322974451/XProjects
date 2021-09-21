using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200159D RID: 5533
	internal class Process_RpcC2M_MarriageRelationOp
	{
		// Token: 0x0600EB9C RID: 60316 RVA: 0x003460A4 File Offset: 0x003442A4
		public static void OnReply(MarriageRelationOpArg oArg, MarriageRelationOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument.Doc.OnGetMarriageRelationOp(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EB9D RID: 60317 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MarriageRelationOpArg oArg)
		{
		}
	}
}
