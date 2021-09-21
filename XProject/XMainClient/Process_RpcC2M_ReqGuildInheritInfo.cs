using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013A0 RID: 5024
	internal class Process_RpcC2M_ReqGuildInheritInfo
	{
		// Token: 0x0600E37C RID: 58236 RVA: 0x0033A6F8 File Offset: 0x003388F8
		public static void OnReply(ReqGuildInheritInfoArg oArg, ReqGuildInheritInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				specificDocument.ReceiveInheritList(oArg, oRes);
			}
		}

		// Token: 0x0600E37D RID: 58237 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildInheritInfoArg oArg)
		{
		}
	}
}
