using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013BA RID: 5050
	internal class Process_RpcC2G_ResWarBuff
	{
		// Token: 0x0600E3E6 RID: 58342 RVA: 0x0033AFA4 File Offset: 0x003391A4
		public static void OnReply(ResWarBuffArg oArg, ResWarBuffRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				else
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowGuildMineBuff(oRes);
				}
			}
		}

		// Token: 0x0600E3E7 RID: 58343 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResWarBuffArg oArg)
		{
		}
	}
}
