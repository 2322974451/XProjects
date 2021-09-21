using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013D1 RID: 5073
	internal class Process_RpcC2M_GetMyMentorInfo
	{
		// Token: 0x0600E43E RID: 58430 RVA: 0x0033B694 File Offset: 0x00339894
		public static void OnReply(GetMyMentorInfoArg oArg, GetMyMentorInfoRes oRes)
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
					bool flag3 = oRes.error == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XMentorshipDocument.Doc.OnGetMyMentorInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E43F RID: 58431 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMyMentorInfoArg oArg)
		{
		}
	}
}
