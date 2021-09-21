using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001030 RID: 4144
	internal class Process_RpcC2G_DecomposeEquipment
	{
		// Token: 0x0600D56E RID: 54638 RVA: 0x00324028 File Offset: 0x00322228
		public static void OnReply(DecomposeEquipmentArg oArg, DecomposeEquipmentRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XRecycleItemDocument specificDocument = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
				specificDocument.OnRecycle(oRes);
			}
		}

		// Token: 0x0600D56F RID: 54639 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DecomposeEquipmentArg oArg)
		{
		}
	}
}
