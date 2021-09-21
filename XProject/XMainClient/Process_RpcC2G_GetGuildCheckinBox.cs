using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001086 RID: 4230
	internal class Process_RpcC2G_GetGuildCheckinBox
	{
		// Token: 0x0600D6DA RID: 55002 RVA: 0x00326D54 File Offset: 0x00324F54
		public static void OnReply(GetGuildCheckinBoxArg oArg, GetGuildCheckinBoxRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
				specificDocument.OnFetchBox(oArg, oRes);
			}
		}

		// Token: 0x0600D6DB RID: 55003 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildCheckinBoxArg oArg)
		{
		}
	}
}
