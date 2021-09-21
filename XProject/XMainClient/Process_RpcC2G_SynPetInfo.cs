using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011FF RID: 4607
	internal class Process_RpcC2G_SynPetInfo
	{
		// Token: 0x0600DCC1 RID: 56513 RVA: 0x00330CD4 File Offset: 0x0032EED4
		public static void OnReply(SynPetInfoArg oArg, SynPetInfoRes oRes)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetInfo(oArg, oRes);
		}

		// Token: 0x0600DCC2 RID: 56514 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SynPetInfoArg oArg)
		{
		}
	}
}
