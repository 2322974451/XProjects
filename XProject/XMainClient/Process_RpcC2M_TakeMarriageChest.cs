using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015C6 RID: 5574
	internal class Process_RpcC2M_TakeMarriageChest
	{
		// Token: 0x0600EC3F RID: 60479 RVA: 0x00346CDC File Offset: 0x00344EDC
		public static void OnReply(TakeMarriageChestArg oArg, TakeMarriageChestRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument.Doc.OnTakePartnerChestBack((int)oArg.index, oRes);
				}
			}
		}

		// Token: 0x0600EC40 RID: 60480 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TakeMarriageChestArg oArg)
		{
		}
	}
}
