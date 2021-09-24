using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_PvpAllReq
	{

		public static void OnReply(PvpArg oArg, PvpRes oRes)
		{
			bool flag = oRes.err == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.err == ErrorCode.ERR_CAN_INGORE;
				if (!flag2)
				{
					bool flag3 = oRes.err > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.err, "fece00");
					}
					else
					{
						XCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
						bool flag4 = oArg.type == PvpReqType.PVP_REQ_BASE_DATA;
						if (flag4)
						{
							specificDocument.SetShowInfo(oArg, oRes);
						}
						bool flag5 = oArg.type == PvpReqType.PVP_REQ_HISTORY_REC;
						if (flag5)
						{
							specificDocument.SetBattleRecord(oRes);
						}
						bool flag6 = oArg.type == PvpReqType.PVP_REQ_GET_WEEKREWARD;
						if (flag6)
						{
							specificDocument.SetWeekReward(oArg, oRes);
						}
					}
				}
			}
		}

		public static void OnTimeout(PvpArg oArg)
		{
		}
	}
}
