using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_SceneMobaOp
	{

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

		public static void OnTimeout(SceneMobaOpArg oArg)
		{
		}
	}
}
