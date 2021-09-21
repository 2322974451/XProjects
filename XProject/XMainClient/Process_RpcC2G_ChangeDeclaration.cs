using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014AB RID: 5291
	internal class Process_RpcC2G_ChangeDeclaration
	{
		// Token: 0x0600E7B8 RID: 59320 RVA: 0x003406C0 File Offset: 0x0033E8C0
		public static void OnReply(ChangeDeclarationArg oArg, ChangeDeclarationRes oRes)
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
					bool flag3 = DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.HomepageHandler != null;
					if (flag3)
					{
						DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.HomepageHandler.SetDeclaration(oRes.declaration);
					}
				}
			}
		}

		// Token: 0x0600E7B9 RID: 59321 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeDeclarationArg oArg)
		{
		}
	}
}
