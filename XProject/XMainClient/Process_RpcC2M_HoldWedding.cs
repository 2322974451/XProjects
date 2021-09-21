using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001593 RID: 5523
	internal class Process_RpcC2M_HoldWedding
	{
		// Token: 0x0600EB6F RID: 60271 RVA: 0x00345C00 File Offset: 0x00343E00
		public static void OnReply(HoldWeddingReq oArg, HoldWeddingRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument doc = XWeddingDocument.Doc;
					doc.OnHoldWedding(oRes);
				}
			}
		}

		// Token: 0x0600EB70 RID: 60272 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(HoldWeddingReq oArg)
		{
		}
	}
}
