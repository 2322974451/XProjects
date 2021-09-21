using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013B3 RID: 5043
	internal class Process_RpcC2M_JoinFmRoom
	{
		// Token: 0x0600E3CA RID: 58314 RVA: 0x0033AD24 File Offset: 0x00338F24
		public static void OnReply(JoinLargeRoomArg oArg, JoinLargeRoomRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = specificDocument != null && oRes.data != null;
					if (flag3)
					{
						specificDocument.ProcessJoinBigRoom(oRes.data);
					}
				}
				else
				{
					specificDocument.ProcessTimeOut();
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(oRes.error), "fece00");
				}
			}
		}

		// Token: 0x0600E3CB RID: 58315 RVA: 0x0033ADA0 File Offset: 0x00338FA0
		public static void OnTimeout(JoinLargeRoomArg oArg)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.ProcessTimeOut();
			}
		}
	}
}
