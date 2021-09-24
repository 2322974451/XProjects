using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_CustomBattleOp
	{

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

		public static void OnTimeout(CustomBattleOpArg oArg)
		{
		}
	}
}
