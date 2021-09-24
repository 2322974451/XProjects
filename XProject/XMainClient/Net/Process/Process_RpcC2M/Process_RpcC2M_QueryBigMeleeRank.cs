using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_QueryBigMeleeRank
	{

		public static void OnReply(QueryMayhemRankArg oArg, QueryMayhemRankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.err == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oArg.count == XBigMeleeBattleDocument.BATTLE_SHOW_RANK;
					if (flag3)
					{
						XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
						specificDocument.SetRankData(oArg, oRes);
					}
					else
					{
						bool flag4 = oArg.count == XBigMeleeEntranceDocument.MAX_RANK;
						if (flag4)
						{
							XBigMeleeEntranceDocument specificDocument2 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
							specificDocument2.SetRankData(oArg, oRes);
						}
					}
				}
			}
		}

		public static void OnTimeout(QueryMayhemRankArg oArg)
		{
		}
	}
}
