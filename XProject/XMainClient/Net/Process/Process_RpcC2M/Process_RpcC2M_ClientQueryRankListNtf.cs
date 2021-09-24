using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ClientQueryRankListNtf
	{

		public static void OnReply(ClientQueryRankListArg oArg, ClientQueryRankListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					switch (oRes.RankType)
					{
					case 0U:
					case 1U:
						return;
					case 2U:
					case 38U:
					{
						XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
						specificDocument.OnGetLatestRankInfo(oRes);
						return;
					}
					case 3U:
					{
						bool flag3 = oArg.TimeStamp == 1U;
						if (flag3)
						{
							XWorldBossDocument specificDocument2 = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
							specificDocument2.OnGetLatestRankInfo(oRes);
						}
						else
						{
							XRankDocument specificDocument3 = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
							specificDocument3.OnGetRankList(oRes);
						}
						return;
					}
					case 6U:
					case 14U:
					case 15U:
					case 20U:
					case 32U:
					{
						XFlowerRankDocument specificDocument4 = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
						specificDocument4.OnGetRankList(oRes);
						return;
					}
					case 8U:
					{
						XGuildDragonDocument specificDocument5 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
						specificDocument5.OnGuildBossRoleRank(oRes);
						return;
					}
					case 9U:
					case 10U:
					case 31U:
					{
						bool flag4 = oArg.TimeStamp == 1U;
						if (flag4)
						{
							XQualifyingDocument specificDocument6 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument6.OnGetRankInfo(oRes, (int)oArg.profession);
						}
						else
						{
							XRankDocument specificDocument7 = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
							specificDocument7.OnGetRankList(oRes);
						}
						return;
					}
					case 16U:
						FirstPassDocument.Doc.OnGetRankList(oRes);
						return;
					case 21U:
						XWeekNestDocument.Doc.OnGetRankList(oRes, false);
						return;
					case 24U:
					{
						XHeroBattleDocument specificDocument8 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
						specificDocument8.SetRankInfo(oRes, false);
						return;
					}
					case 25U:
					{
						XMilitaryRankDocument specificDocument9 = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
						specificDocument9.OnGetRankInfo(oRes);
						return;
					}
					case 26U:
					{
						XQualifyingDocument specificDocument10 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
						specificDocument10.OnGetLastSeasonRankInfo(oRes);
						return;
					}
					case 27U:
						XWeekNestDocument.Doc.OnGetRankList(oRes, true);
						return;
					case 28U:
					{
						XHeroBattleDocument specificDocument11 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
						specificDocument11.SetRankInfo(oRes, true);
						return;
					}
					case 34U:
					{
						BiochemicalHellDogDocument specificDocument12 = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
						specificDocument12.ReceiveRankList(oRes);
						return;
					}
					case 35U:
					{
						XCompeteDocument specificDocument13 = XDocuments.GetSpecificDocument<XCompeteDocument>(XCompeteDocument.uuID);
						specificDocument13.OnGetRankList(oRes, false);
						return;
					}
					case 39U:
					{
						bool onlySelfData = oArg.onlySelfData;
						if (onlySelfData)
						{
							XRiftDocument specificDocument14 = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
							bool flag5 = oRes.RoleRankData != null;
							if (flag5)
							{
								specificDocument14.ResRank((int)oRes.RoleRankData.Rank);
							}
							else
							{
								specificDocument14.ResRank(-1);
							}
							return;
						}
						break;
					}
					}
					XRankDocument specificDocument15 = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
					specificDocument15.OnGetRankList(oRes);
				}
			}
		}

		public static void OnTimeout(ClientQueryRankListArg oArg)
		{
		}
	}
}
