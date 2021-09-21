using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001155 RID: 4437
	internal class Process_RpcC2G_GetGuildQADataReq
	{
		// Token: 0x0600DA1E RID: 55838 RVA: 0x0032CAD0 File Offset: 0x0032ACD0
		public static void OnReply(GetGuildQADataReq oArg, GetGuildQADataRes oRes)
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
					specificDocument.SetGuildVoiceInfo(oRes.status, oRes.time);
				}
			}
		}

		// Token: 0x0600DA1F RID: 55839 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildQADataReq oArg)
		{
		}
	}
}
