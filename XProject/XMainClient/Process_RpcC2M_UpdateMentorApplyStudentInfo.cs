using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013D9 RID: 5081
	internal class Process_RpcC2M_UpdateMentorApplyStudentInfo
	{
		// Token: 0x0600E462 RID: 58466 RVA: 0x0033BA94 File Offset: 0x00339C94
		public static void OnReply(UpdateMentorApplyStudentInfoArg oArg, UpdateMentorApplyStudentInfoRes oRes)
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
						XMentorshipDocument.Doc.OnGetMentorshipSetting(oArg, oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E463 RID: 58467 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UpdateMentorApplyStudentInfoArg oArg)
		{
		}
	}
}
