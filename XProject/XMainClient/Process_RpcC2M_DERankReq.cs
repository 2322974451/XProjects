using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001254 RID: 4692
	internal class Process_RpcC2M_DERankReq
	{
		// Token: 0x0600DE24 RID: 56868 RVA: 0x00332E1C File Offset: 0x0033101C
		public static void OnReply(DERankArg oArg, DERankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
				specificDocument.OnDERankReq(oRes);
			}
		}

		// Token: 0x0600DE25 RID: 56869 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DERankArg oArg)
		{
		}
	}
}
