using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200130E RID: 4878
	internal class Process_RpcC2M_GetGuildBindInfo
	{
		// Token: 0x0600E124 RID: 57636 RVA: 0x0033714C File Offset: 0x0033534C
		public static void OnReply(GetGuildBindInfoReq oArg, GetGuildBindInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					specificDocument.OnGetQQGroupBindInfo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E125 RID: 57637 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBindInfoReq oArg)
		{
		}
	}
}
