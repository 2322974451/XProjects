using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012A8 RID: 4776
	internal class Process_RpcC2M_GetGuildCheckinRecordsNew
	{
		// Token: 0x0600DF7E RID: 57214 RVA: 0x00334A90 File Offset: 0x00332C90
		public static void OnReply(GetGuildCheckinRecordsArg oArg, GetGuildCheckinRecordsRes oRes)
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
					XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
					specificDocument.onGetLogList(oRes);
				}
			}
		}

		// Token: 0x0600DF7F RID: 57215 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildCheckinRecordsArg oArg)
		{
		}
	}
}
