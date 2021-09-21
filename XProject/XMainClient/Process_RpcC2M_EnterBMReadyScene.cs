using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001559 RID: 5465
	internal class Process_RpcC2M_EnterBMReadyScene
	{
		// Token: 0x0600EA7E RID: 60030 RVA: 0x003445AC File Offset: 0x003427AC
		public static void OnReply(EnterBMReadySceneArg oArg, EnterBMReadySceneRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
					else
					{
						XBigMeleeEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
						specificDocument.GroupID = (int)(oRes.group + 1U);
					}
				}
			}
		}

		// Token: 0x0600EA7F RID: 60031 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnterBMReadySceneArg oArg)
		{
		}
	}
}
