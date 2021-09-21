using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014A9 RID: 5289
	internal class Process_RpcC2G_PersonalCareer
	{
		// Token: 0x0600E7AF RID: 59311 RVA: 0x003405CC File Offset: 0x0033E7CC
		public static void OnReply(PersonalCareerArg oArg, PersonalCareerRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.SetCareer(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E7B0 RID: 59312 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PersonalCareerArg oArg)
		{
		}
	}
}
