using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200167D RID: 5757
	internal class Process_RpcC2G_RiftFirstPassReward
	{
		// Token: 0x0600EF44 RID: 61252 RVA: 0x0034B03C File Offset: 0x0034923C
		public static void OnReply(RiftFirstPassRewardArg oArg, RiftFirstPassRewardRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
					else
					{
						XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
						bool flag4 = oArg.opType == RiftFirstPassOpType.Rift_FirstPass_Op_GetReward;
						if (flag4)
						{
							specificDocument.SetFirstPassClaim((int)oArg.floor);
						}
						specificDocument.ResFisrtPassRwd(oArg.opType, oRes);
					}
				}
			}
		}

		// Token: 0x0600EF45 RID: 61253 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(RiftFirstPassRewardArg oArg)
		{
		}
	}
}
