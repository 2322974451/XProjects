using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013D5 RID: 5077
	internal class Process_RpcC2M_GetMyApplyMasterInfo
	{
		// Token: 0x0600E450 RID: 58448 RVA: 0x0033B8A4 File Offset: 0x00339AA4
		public static void OnReply(GetMyApplyMasterInfoArg oArg, GetMyApplyMasterInfoRes oRes)
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
						XMentorshipDocument.Doc.OnGetMyApplyMasterInfo(oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E451 RID: 58449 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMyApplyMasterInfoArg oArg)
		{
		}
	}
}
