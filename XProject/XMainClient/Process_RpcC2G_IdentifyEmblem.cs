using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001151 RID: 4433
	internal class Process_RpcC2G_IdentifyEmblem
	{
		// Token: 0x0600DA0C RID: 55820 RVA: 0x0032C8CC File Offset: 0x0032AACC
		public static void OnReply(IdentifyEmblemArg oArg, IdentifyEmblemRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
					specificDocument.ShowIdentifySucEffect();
					specificDocument.RefreshTips(oArg.uid);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600DA0D RID: 55821 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(IdentifyEmblemArg oArg)
		{
		}
	}
}
