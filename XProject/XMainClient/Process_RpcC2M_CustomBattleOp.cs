using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014DE RID: 5342
	internal class Process_RpcC2M_CustomBattleOp
	{
		// Token: 0x0600E885 RID: 59525 RVA: 0x00341638 File Offset: 0x0033F838
		public static void OnReply(CustomBattleOpArg oArg, CustomBattleOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XCustomBattleDocument specificDocument = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
					specificDocument.RecvCustomBattleOp(oArg.op, oArg.uid, oRes.info, oArg);
				}
				else
				{
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SYS_NOTOPEN;
					if (!flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
						XCustomBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
						specificDocument2.DoErrorOp(oArg.op, oArg.uid);
					}
				}
			}
		}

		// Token: 0x0600E886 RID: 59526 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CustomBattleOpArg oArg)
		{
		}
	}
}
