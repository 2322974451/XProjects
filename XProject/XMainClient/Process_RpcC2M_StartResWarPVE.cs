using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001363 RID: 4963
	internal class Process_RpcC2M_StartResWarPVE
	{
		// Token: 0x0600E280 RID: 57984 RVA: 0x00339248 File Offset: 0x00337448
		public static void OnReply(ResWarPVEArg oArg, ResWarPVERes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E281 RID: 57985 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResWarPVEArg oArg)
		{
		}
	}
}
