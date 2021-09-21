using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001563 RID: 5475
	internal class Process_RpcC2M_QueryBigMeleeRank
	{
		// Token: 0x0600EAA3 RID: 60067 RVA: 0x003448B4 File Offset: 0x00342AB4
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

		// Token: 0x0600EAA4 RID: 60068 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryMayhemRankArg oArg)
		{
		}
	}
}
