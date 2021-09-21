using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200127A RID: 4730
	internal class Process_RpcC2M_AskGuildSkillInfoNew
	{
		// Token: 0x0600DEC0 RID: 57024 RVA: 0x003339F0 File Offset: 0x00331BF0
		public static void OnReply(AskGuildSkillInfoArg oArg, AskGuildSkillInfoReq oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildSkillDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
					specificDocument.OnSkillList(oRes);
				}
			}
		}

		// Token: 0x0600DEC1 RID: 57025 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskGuildSkillInfoArg oArg)
		{
		}
	}
}
