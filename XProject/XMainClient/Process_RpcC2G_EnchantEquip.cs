using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200147B RID: 5243
	internal class Process_RpcC2G_EnchantEquip
	{
		// Token: 0x0600E6F1 RID: 59121 RVA: 0x0033F4B8 File Offset: 0x0033D6B8
		public static void OnReply(EnchantEquipArg oArg, EnchantEquipRes oRes)
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
					XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
					specificDocument.OnGetEnchant(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E6F2 RID: 59122 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnchantEquipArg oArg)
		{
		}
	}
}
