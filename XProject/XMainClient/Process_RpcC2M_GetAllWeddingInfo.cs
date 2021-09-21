using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001599 RID: 5529
	internal class Process_RpcC2M_GetAllWeddingInfo
	{
		// Token: 0x0600EB8A RID: 60298 RVA: 0x00345EC4 File Offset: 0x003440C4
		public static void OnReply(GetAllWeddingInfoArg oArg, GetAllWeddingInfoRes oRes)
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
					doc.OnGetAllWeddingInfo(oRes);
				}
			}
		}

		// Token: 0x0600EB8B RID: 60299 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAllWeddingInfoArg oArg)
		{
		}
	}
}
