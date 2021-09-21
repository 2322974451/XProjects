using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014A3 RID: 5283
	internal class Process_RpcC2G_ChangeSkillSet
	{
		// Token: 0x0600E796 RID: 59286 RVA: 0x00340368 File Offset: 0x0033E568
		public static void OnReply(ChangeSkillSetArg oArg, ChangeSkillSetRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
					specificDocument.OnSwitchSkillPageSuccess(oArg.index, oRes.record);
				}
			}
		}

		// Token: 0x0600E797 RID: 59287 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeSkillSetArg oArg)
		{
		}
	}
}
