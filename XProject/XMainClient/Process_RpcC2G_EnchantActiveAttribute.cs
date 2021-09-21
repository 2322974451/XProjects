using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200150B RID: 5387
	internal class Process_RpcC2G_EnchantActiveAttribute
	{
		// Token: 0x0600E944 RID: 59716 RVA: 0x00342750 File Offset: 0x00340950
		public static void OnReply(EnchantActiveAttributeArg oArg, EnchantActiveAttributeRes oRes)
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
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
						specificDocument.OnGetEnchantActiveAttr(oArg, oRes);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E945 RID: 59717 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnchantActiveAttributeArg oArg)
		{
		}
	}
}
