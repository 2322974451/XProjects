using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200154C RID: 5452
	internal class Process_RpcC2G_PetOperationOther
	{
		// Token: 0x0600EA4B RID: 59979 RVA: 0x00344004 File Offset: 0x00342204
		public static void OnReply(PetOperationOtherArg oArg, PetOperationOtherRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
				specificDocument.OnPetPetOperationOtherBack(oArg, oRes);
			}
		}

		// Token: 0x0600EA4C RID: 59980 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PetOperationOtherArg oArg)
		{
		}
	}
}
