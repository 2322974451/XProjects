using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001367 RID: 4967
	internal class Process_RpcC2M_applyguildarena
	{
		// Token: 0x0600E290 RID: 58000 RVA: 0x003393C4 File Offset: 0x003375C4
		public static void OnReply(applyguildarenaarg oArg, applyguildarenares oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
					specificDocument.ReceiveApplyGuildArena(oRes);
				}
			}
		}

		// Token: 0x0600E291 RID: 58001 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(applyguildarenaarg oArg)
		{
		}
	}
}
