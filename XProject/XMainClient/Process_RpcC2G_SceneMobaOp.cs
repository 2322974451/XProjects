using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001530 RID: 5424
	internal class Process_RpcC2G_SceneMobaOp
	{
		// Token: 0x0600E9DD RID: 59869 RVA: 0x0034357C File Offset: 0x0034177C
		public static void OnReply(SceneMobaOpArg oArg, SceneMobaOpRes oRes)
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
					bool flag3 = oArg.op == MobaOp.MobaOp_Upgrade;
					if (flag3)
					{
						uint param = oArg.param;
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MobaAdditionSuccess" + param.ToString()), oRes.nowparam), "fece00");
					}
				}
			}
		}

		// Token: 0x0600E9DE RID: 59870 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SceneMobaOpArg oArg)
		{
		}
	}
}
