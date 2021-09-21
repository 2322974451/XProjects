using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200127C RID: 4732
	internal class Process_RpcC2M_StudyGuildSkillNew
	{
		// Token: 0x0600DEC9 RID: 57033 RVA: 0x00333ADC File Offset: 0x00331CDC
		public static void OnReply(StudyGuildSkillArg oArg, StudyGuildSkillRes oRes)
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
					specificDocument.OnStudyGuildSkill(oRes);
				}
			}
		}

		// Token: 0x0600DECA RID: 57034 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(StudyGuildSkillArg oArg)
		{
		}
	}
}
