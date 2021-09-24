using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_JoinFmRoom
	{

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
