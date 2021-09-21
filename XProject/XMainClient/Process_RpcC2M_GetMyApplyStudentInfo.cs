using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013D3 RID: 5075
	internal class Process_RpcC2M_GetMyApplyStudentInfo
	{
		// Token: 0x0600E447 RID: 58439 RVA: 0x0033B79C File Offset: 0x0033999C
		public static void OnReply(GetMyApplyStudentInfoArg oArg, GetMyApplyStudentInfoRes oRes)
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
						XMentorshipDocument.Doc.OnGetMyApplyPupilsInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E448 RID: 58440 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMyApplyStudentInfoArg oArg)
		{
		}
	}
}
