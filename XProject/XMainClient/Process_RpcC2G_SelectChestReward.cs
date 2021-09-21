using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200101C RID: 4124
	internal class Process_RpcC2G_SelectChestReward
	{
		// Token: 0x0600D516 RID: 54550 RVA: 0x00322F28 File Offset: 0x00321128
		public static void OnReply(SelectChestArg oArg, SelectChestRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errcode > ErrorCode.ERR_SUCCESS;
				if (!flag2)
				{
					XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
					specificDocument.SetPlayerSelectChestID((int)oArg.chestIdx);
				}
			}
		}

		// Token: 0x0600D517 RID: 54551 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SelectChestArg oArg)
		{
		}
	}
}
