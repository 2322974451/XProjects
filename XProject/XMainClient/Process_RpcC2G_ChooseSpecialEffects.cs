using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001668 RID: 5736
	internal class Process_RpcC2G_ChooseSpecialEffects
	{
		// Token: 0x0600EEEB RID: 61163 RVA: 0x0034A728 File Offset: 0x00348928
		public static void OnReply(ChooseSpecialEffectsArg oArg, ChooseSpecialEffectsRes oRes)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SetActiveSuitEffect(oArg, oRes);
		}

		// Token: 0x0600EEEC RID: 61164 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChooseSpecialEffectsArg oArg)
		{
		}
	}
}
