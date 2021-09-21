using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012BA RID: 4794
	internal class Process_RpcC2M_ChangeMemberPositionNew
	{
		// Token: 0x0600DFC9 RID: 57289 RVA: 0x003351D8 File Offset: 0x003333D8
		public static void OnReply(ChangeGuildPositionArg oArg, ChangeGuildPositionRes oRes)
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
					XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
					specificDocument.OnChangePosition(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DFCA RID: 57290 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeGuildPositionArg oArg)
		{
		}
	}
}
