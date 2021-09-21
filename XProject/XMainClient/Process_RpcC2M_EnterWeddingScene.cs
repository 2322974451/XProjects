using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001597 RID: 5527
	internal class Process_RpcC2M_EnterWeddingScene
	{
		// Token: 0x0600EB81 RID: 60289 RVA: 0x00345DD8 File Offset: 0x00343FD8
		public static void OnReply(EnterWeddingSceneArg oArg, EnterWeddingSceneRes oRes)
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
					doc.OnEnterWedding(oRes);
				}
			}
		}

		// Token: 0x0600EB82 RID: 60290 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnterWeddingSceneArg oArg)
		{
		}
	}
}
