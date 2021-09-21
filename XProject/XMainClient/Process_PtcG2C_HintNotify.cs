using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200109F RID: 4255
	internal class Process_PtcG2C_HintNotify
	{
		// Token: 0x0600D73E RID: 55102 RVA: 0x00327504 File Offset: 0x00325704
		public static void Process(PtcG2C_HintNotify roPtc)
		{
			int i = 0;
			while (i < roPtc.Data.systemid.Count)
			{
				XSysDefine xsysDefine = (XSysDefine)roPtc.Data.systemid[i];
				XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
				bool flag = specificDocument.IsShop(xsysDefine);
				if (flag)
				{
					XGameMallDocument specificDocument2 = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
					specificDocument2.RefreshShopRedPoint(xsysDefine, !roPtc.Data.isremove);
				}
				XSysDefine xsysDefine2 = xsysDefine;
				if (xsysDefine2 <= XSysDefine.XSys_Welfare_YyMall)
				{
					if (xsysDefine2 <= XSysDefine.XSys_CustomBattle_BountyMode)
					{
						if (xsysDefine2 != XSysDefine.XSys_Qualifying)
						{
							if (xsysDefine2 != XSysDefine.XSys_GuildDragon)
							{
								if (xsysDefine2 != XSysDefine.XSys_CustomBattle_BountyMode)
								{
									goto IL_47F;
								}
								XCustomBattleDocument specificDocument3 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
								specificDocument3.BountyModeRedPoint = !roPtc.Data.isremove;
							}
							else
							{
								XGuildDragonDocument specificDocument4 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
								specificDocument4.bCanFight = !roPtc.Data.isremove;
							}
						}
						else
						{
							XQualifyingDocument specificDocument5 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument5.RedPoint = true;
						}
					}
					else if (xsysDefine2 <= XSysDefine.XSys_Reward_Activity)
					{
						if (xsysDefine2 != XSysDefine.XSys_CustomBattle_CustomMode)
						{
							if (xsysDefine2 != XSysDefine.XSys_Reward_Activity)
							{
								goto IL_47F;
							}
							XDailyActivitiesDocument specificDocument6 = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
							specificDocument6.SeverRedPointNotify = (roPtc.Data.isremove ? -1 : 1);
						}
						else
						{
							XCustomBattleDocument specificDocument7 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
							specificDocument7.CustomModeRedPoint = !roPtc.Data.isremove;
						}
					}
					else if (xsysDefine2 != XSysDefine.XSys_Flower_Rank_Activity)
					{
						switch (xsysDefine2)
						{
						case XSysDefine.XSys_Welfare_GiftBag:
						{
							XWelfareDocument specificDocument8 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument8.RegisterRedPoint(XSysDefine.XSys_Welfare_GiftBag, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_StarFund:
						{
							XWelfareDocument specificDocument9 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument9.RegisterRedPoint(XSysDefine.XSys_Welfare_StarFund, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_FirstRechange:
						{
							XWelfareDocument specificDocument10 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument10.RegisterRedPoint(XSysDefine.XSys_Welfare_FirstRechange, true, true);
							break;
						}
						case XSysDefine.XSyS_Welfare_RewardBack:
						case XSysDefine.XSys_Welfare_KingdomPrivilege:
							goto IL_47F;
						case XSysDefine.XSys_Welfare_MoneyTree:
						{
							XWelfareDocument specificDocument11 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument11.ServerPushMoneyTree = true;
							specificDocument11.RegisterRedPoint(XSysDefine.XSys_Welfare_MoneyTree, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Court:
						{
							XWelfareDocument specificDocument12 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument12.RegisterRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Court, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer:
						{
							XWelfareDocument specificDocument13 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument13.RegisterRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce:
						{
							XWelfareDocument specificDocument14 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument14.RegisterRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_NiceGirl:
						{
							XWelfareDocument specificDocument15 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument15.RegisterRedPoint(XSysDefine.XSys_Welfare_NiceGirl, true, true);
							break;
						}
						case XSysDefine.XSys_Welfare_YyMall:
						{
							XWelfareDocument specificDocument16 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
							specificDocument16.RegisterRedPoint(XSysDefine.XSys_Welfare_YyMall, true, true);
							break;
						}
						default:
							goto IL_47F;
						}
					}
					else
					{
						XFlowerRankDocument specificDocument17 = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
						specificDocument17.CanGetActivityAward = !roPtc.Data.isremove;
					}
				}
				else if (xsysDefine2 <= XSysDefine.XSys_GuildHall_SignIn)
				{
					if (xsysDefine2 != XSysDefine.XSys_Parner_Liveness)
					{
						if (xsysDefine2 != XSysDefine.XSys_Wedding)
						{
							if (xsysDefine2 != XSysDefine.XSys_GuildHall_SignIn)
							{
								goto IL_47F;
							}
							XGuildSignInDocument specificDocument18 = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
							specificDocument18.SignInSelection = 0U;
						}
						else
						{
							XWeddingDocument.Doc.IsHadLivenessRedPoint = !roPtc.Data.isremove;
						}
					}
					else
					{
						XPartnerDocument.Doc.IsHadLivenessRedPoint = !roPtc.Data.isremove;
					}
				}
				else if (xsysDefine2 <= XSysDefine.XSys_QQVIP)
				{
					if (xsysDefine2 != XSysDefine.XSys_SpriteSystem_Shop)
					{
						if (xsysDefine2 != XSysDefine.XSys_QQVIP)
						{
							goto IL_47F;
						}
						XPlatformAbilityDocument specificDocument19 = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
						specificDocument19.QQVipRedPoint = !roPtc.Data.isremove;
					}
					else
					{
						XSpriteSystemDocument specificDocument20 = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
						specificDocument20.QueryBuyEggCD();
					}
				}
				else if (xsysDefine2 != XSysDefine.XSys_DragonGuildLiveness)
				{
					if (xsysDefine2 != XSysDefine.XSys_DragonGuildTask)
					{
						goto IL_47F;
					}
					XDragonGuildDocument.Doc.IsHadRecordRedPoint = !roPtc.Data.isremove;
				}
				else
				{
					XDragonGuildDocument.Doc.IsHadLivenessRedPoint = !roPtc.Data.isremove;
				}
				IL_49B:
				bool flag2 = xsysDefine == XSysDefine.XSys_Mail;
				if (flag2)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.ShowMailRedpoint();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(xsysDefine, true);
				i++;
				continue;
				IL_47F:
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(xsysDefine, !roPtc.Data.isremove);
				goto IL_49B;
			}
		}
	}
}
