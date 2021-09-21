using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200108A RID: 4234
	internal class Process_RpcC2G_StageCountReset
	{
		// Token: 0x0600D6EA RID: 55018 RVA: 0x00326EB8 File Offset: 0x003250B8
		public static void OnReply(StageCountResetArg oArg, StageCountResetRes oRes)
		{
			XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			specificDocument.OnResetSceneSucc(oArg.groupid, oRes);
		}

		// Token: 0x0600D6EB RID: 55019 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(StageCountResetArg oArg)
		{
		}
	}
}
