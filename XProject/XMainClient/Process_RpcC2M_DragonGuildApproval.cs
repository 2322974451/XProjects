using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200162F RID: 5679
	internal class Process_RpcC2M_DragonGuildApproval
	{
		// Token: 0x0600EDFA RID: 60922 RVA: 0x003491DC File Offset: 0x003473DC
		public static void OnReply(DragonGuildApprovalArg oArg, DragonGuildApprovalRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					XDragonGuildApproveDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildApproveDocument>(XDragonGuildApproveDocument.uuID);
					specificDocument.OnApprove(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EDFB RID: 60923 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGuildApprovalArg oArg)
		{
		}
	}
}
