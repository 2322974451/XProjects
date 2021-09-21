using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013D7 RID: 5079
	internal class Process_RpcC2M_MentorMyBeAppliedMsg
	{
		// Token: 0x0600E459 RID: 58457 RVA: 0x0033B9B0 File Offset: 0x00339BB0
		public static void OnReply(MentorMyBeAppliedMsgArg oArg, MentorMyBeAppliedMsgRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					XMentorshipDocument.Doc.OnGetMyBeenApplyedMsg(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E45A RID: 58458 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MentorMyBeAppliedMsgArg oArg)
		{
		}
	}
}
