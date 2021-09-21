using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001298 RID: 4760
	internal class Process_RpcC2M_ChangeGuildSettingNew
	{
		// Token: 0x0600DF42 RID: 57154 RVA: 0x003344A0 File Offset: 0x003326A0
		public static void OnReply(ChangeGuildSettingArg oArg, ChangeGuildSettingRes oRes)
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
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						XGuildHallDocument specificDocument = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
						specificDocument.OnEditAnnounceSuccess(oArg.annoucement);
					}
				}
			}
		}

		// Token: 0x0600DF43 RID: 57155 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeGuildSettingArg oArg)
		{
		}
	}
}
