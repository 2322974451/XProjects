using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001153 RID: 4435
	internal class Process_RpcC2G_OpenGuildQAReq
	{
		// Token: 0x0600DA15 RID: 55829 RVA: 0x0032C9D4 File Offset: 0x0032ABD4
		public static void OnReply(OpenGuildQAReq oArg, OpenGuildQARes oRes)
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
					XGuildRelaxGameDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
					specificDocument.GetGuildVoiceInfo();
				}
			}
		}

		// Token: 0x0600DA16 RID: 55830 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(OpenGuildQAReq oArg)
		{
		}
	}
}
