using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001623 RID: 5667
	internal class Process_RpcC2M_CreateOrJoinDragonGuild
	{
		// Token: 0x0600EDC8 RID: 60872 RVA: 0x00348D28 File Offset: 0x00346F28
		public static void OnReply(CreateOrJoinDragonGuildArg oArg, CreateOrJoinDragonGuildRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool iscreate = oArg.iscreate;
					if (iscreate)
					{
						XDragonGuildListDocument.Doc.OnCreateDragonGuild(oArg, oRes);
					}
					else
					{
						XDragonGuildListDocument.Doc.OnApplyDragonGuild(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600EDC9 RID: 60873 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CreateOrJoinDragonGuildArg oArg)
		{
		}
	}
}
