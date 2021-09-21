using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001653 RID: 5715
	internal class Process_RpcC2G_PeerBox
	{
		// Token: 0x0600EE98 RID: 61080 RVA: 0x00349FD4 File Offset: 0x003481D4
		public static void OnReply(PeerBoxArg oArg, PeerBoxRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
					specificDocument.SetPeerChest(oArg.index - 1U, oRes.item, oRes.type);
				}
			}
		}

		// Token: 0x0600EE99 RID: 61081 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PeerBoxArg oArg)
		{
		}
	}
}
