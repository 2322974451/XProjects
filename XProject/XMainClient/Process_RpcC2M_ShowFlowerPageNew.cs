using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011DB RID: 4571
	internal class Process_RpcC2M_ShowFlowerPageNew
	{
		// Token: 0x0600DC36 RID: 56374 RVA: 0x00330054 File Offset: 0x0032E254
		public static void OnReply(ShowFlowerPageArg oArg, ShowFlowerPageRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
					specificDocument.OnGetMyFlowers(oRes);
				}
			}
		}

		// Token: 0x0600DC37 RID: 56375 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ShowFlowerPageArg oArg)
		{
		}
	}
}
