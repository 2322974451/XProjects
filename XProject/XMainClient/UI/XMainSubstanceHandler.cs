using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200178D RID: 6029
	public class XMainSubstanceHandler : DlgHandlerBase
	{
		// Token: 0x0600F8BC RID: 63676 RVA: 0x0038EA84 File Offset: 0x0038CC84
		private XMainSubstance GetSubstance()
		{
			bool flag = this._stack == null;
			if (flag)
			{
				this._stack = new Stack<XMainSubstance>();
			}
			bool flag2 = this._stack.Count == 0;
			XMainSubstance result;
			if (flag2)
			{
				result = this.CreateSubStance();
			}
			else
			{
				result = this._stack.Pop();
			}
			return result;
		}

		// Token: 0x0600F8BD RID: 63677 RVA: 0x0038EADC File Offset: 0x0038CCDC
		public override void OnUnload()
		{
			this._tempPool = null;
			bool flag = this._stack != null;
			if (flag)
			{
				while (this._stack.Count > 0)
				{
					XMainSubstance xmainSubstance = this._stack.Pop();
					xmainSubstance.Release();
				}
			}
			bool flag2 = this._ShowSubStance != null;
			if (flag2)
			{
				foreach (KeyValuePair<XSysDefine, XMainSubstance> keyValuePair in this._ShowSubStance)
				{
					keyValuePair.Value.Release();
				}
				this._ShowSubStance.Clear();
				this._ShowSubStance = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600F8BE RID: 63678 RVA: 0x0038EBA8 File Offset: 0x0038CDA8
		private void Release(XMainSubstance substance)
		{
			bool flag = substance != null;
			if (flag)
			{
				substance.Recycle();
				this._stack.Push(substance);
			}
		}

		// Token: 0x0600F8BF RID: 63679 RVA: 0x0038EBD4 File Offset: 0x0038CDD4
		private XMainSubstance CreateSubStance()
		{
			XMainSubstance xmainSubstance = new XMainSubstance();
			xmainSubstance.Setup(this._tempPool.FetchGameObject(false));
			return xmainSubstance;
		}

		// Token: 0x0600F8C0 RID: 63680 RVA: 0x0038EC00 File Offset: 0x0038CE00
		protected override void Init()
		{
			base.Init();
			this._ShowSubStance = new Dictionary<XSysDefine, XMainSubstance>();
			this.m_substanceList = (base.transform.GetComponent("XUIList") as IXUIList);
			Transform transform = base.transform.Find("Temp");
			this._tempPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this._tempPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this._ShowSubStance = new Dictionary<XSysDefine, XMainSubstance>();
		}

		// Token: 0x0600F8C1 RID: 63681 RVA: 0x0038EC8C File Offset: 0x0038CE8C
		public void RefreshMainSubStance(XSysDefine define, bool refreshList = true)
		{
			int index = 0;
			int showCount = 0;
			bool flag = this.TryCheckInShow(define, out index, out showCount);
			if (flag)
			{
				XMainSubstance substance;
				bool flag2 = !this._ShowSubStance.TryGetValue(define, out substance);
				if (flag2)
				{
					substance = this.GetSubstance();
					this._ShowSubStance.Add(define, substance);
				}
				substance.SetupSubstance(define, showCount, index);
				XSingleton<XDebug>.singleton.AddGreenLog("OnShow:" + define.ToString(), null, null, null, null, null);
			}
			else
			{
				XMainSubstance substance;
				bool flag3 = this._ShowSubStance.TryGetValue(define, out substance);
				if (flag3)
				{
					this.Release(substance);
					this._ShowSubStance.Remove(define);
				}
			}
			if (refreshList)
			{
				this.Sort();
			}
		}

		// Token: 0x0600F8C2 RID: 63682 RVA: 0x0038ED4C File Offset: 0x0038CF4C
		public void Sort()
		{
			bool flag = this.m_substanceList != null;
			if (flag)
			{
				this.m_substanceList.Refresh();
			}
		}

		// Token: 0x0600F8C3 RID: 63683 RVA: 0x0038ED74 File Offset: 0x0038CF74
		private bool TryCheckInShow(XSysDefine define, out int index, out int showCount)
		{
			showCount = 0;
			index = 0;
			bool flag = false;
			bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(define);
			bool result;
			if (flag2)
			{
				result = flag;
			}
			else
			{
				if (define <= XSysDefine.Xsys_TaJieHelp)
				{
					if (define <= XSysDefine.XSys_Rank_WorldBoss)
					{
						if (define <= XSysDefine.XSys_PK)
						{
							if (define != XSysDefine.XSys_SuperRisk)
							{
								if (define != XSysDefine.XSys_ExcellentLive)
								{
									if (define == XSysDefine.XSys_PK)
									{
										XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
										flag = (specificDocument.InvitationCount > 0U);
										bool flag3 = flag;
										if (flag3)
										{
											showCount = (int)specificDocument.InvitationCount;
										}
									}
								}
								else
								{
									XSpectateDocument specificDocument2 = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
									flag = specificDocument2.MainInterfaceState;
								}
							}
							else
							{
								flag = XSuperRiskDocument.Doc.IsShowMainUiTips();
							}
						}
						else if (define <= XSysDefine.XSys_Pet_Pairs)
						{
							if (define != XSysDefine.XSys_CrossGVG)
							{
								if (define == XSysDefine.XSys_Pet_Pairs)
								{
									XPetDocument specificDocument3 = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
									flag = specificDocument3.BeInvited;
									bool flag4 = flag;
									if (flag4)
									{
										showCount = (int)specificDocument3.BeInvitedCount;
									}
								}
							}
							else
							{
								XCrossGVGDocument specificDocument4 = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
								flag = specificDocument4.InterfaceState;
							}
						}
						else if (define != XSysDefine.XSys_WeekEndNest)
						{
							if (define == XSysDefine.XSys_Rank_WorldBoss)
							{
								XWorldBossDocument specificDocument5 = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
								flag = specificDocument5.MainInterfaceState;
							}
						}
						else
						{
							WeekEndNestDocument doc = WeekEndNestDocument.Doc;
							flag = (doc.GetStatus == 1U || (doc.NeedLoginShow && doc.GetStatus == 0U));
						}
					}
					else if (define <= XSysDefine.XSys_Activity_WorldBoss)
					{
						if (define != XSysDefine.XSys_LevelSeal_Tip)
						{
							if (define != XSysDefine.XSys_MentorshipMsg_Tip)
							{
								if (define == XSysDefine.XSys_Activity_WorldBoss)
								{
									flag = (XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Activity_WorldBoss) && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Activity_WorldBoss));
								}
							}
							else
							{
								flag = XMentorshipDocument.Doc.HasApplyMsg;
							}
						}
						else
						{
							XLevelSealDocument specificDocument6 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
							uint status = specificDocument6.Status;
							bool flag5 = status >= 3U;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("LevelSealStatus Error: status = ", status.ToString(), null, null, null, null);
							}
							else
							{
								bool flag6 = status > 0U;
								if (flag6)
								{
									flag = true;
									bool flag7 = status == 1U;
									if (flag7)
									{
										index = 0;
									}
									else
									{
										bool flag8 = status == 2U;
										if (flag8)
										{
											index = 1;
										}
									}
								}
							}
						}
					}
					else if (define <= XSysDefine.XSys_MulActivity_SkyArenaEnd)
					{
						switch (define)
						{
						case XSysDefine.XSys_Activity_CaptainPVP:
						{
							XCaptainPVPDocument specificDocument7 = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
							flag = specificDocument7.MainInterfaceState;
							break;
						}
						case XSysDefine.XSys_Activity_GoddessTrial:
						case XSysDefine.XSys_Activity_TeamTowerSingle:
							break;
						case XSysDefine.XSys_BigMelee:
						{
							XBigMeleeEntranceDocument specificDocument8 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
							flag = specificDocument8.MainInterfaceState;
							break;
						}
						case XSysDefine.XSys_BigMeleeEnd:
						{
							XBigMeleeEntranceDocument specificDocument9 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
							flag = specificDocument9.MainInterfaceStateEnd;
							break;
						}
						case XSysDefine.XSys_Battlefield:
							flag = XBattleFieldEntranceDocument.Doc.MainInterfaceState;
							break;
						default:
							switch (define)
							{
							case XSysDefine.XSys_MulActivity_SkyArena:
							{
								XSkyArenaEntranceDocument specificDocument10 = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
								flag = specificDocument10.MainInterfaceState;
								break;
							}
							case XSysDefine.XSys_MulActivity_Race:
								flag = DlgBase<RaceEntranceView, RaceEntranceBehaviour>.singleton.MainInterfaceState;
								break;
							case XSysDefine.XSys_MulActivity_WeekendParty:
							{
								XWeekendPartyDocument specificDocument11 = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
								flag = specificDocument11.MainInterfaceState;
								break;
							}
							case XSysDefine.XSys_MulActivity_SkyArenaEnd:
								flag = XSkyArenaEntranceDocument.Doc.MainInterfaceStateEnd;
								break;
							}
							break;
						}
					}
					else if (define != XSysDefine.XSys_Welfare_NiceGirl)
					{
						if (define == XSysDefine.Xsys_TaJieHelp)
						{
							flag = TaJieHelpDocument.Doc.ShowHallBtn;
						}
					}
					else
					{
						flag = (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(define, XSingleton<XAttributeMgr>.singleton.XPlayerData) && XWelfareDocument.Doc.ArgentaMainInterfaceState && !XWelfareDocument.Doc.IsNiceGirlTasksFinished());
					}
				}
				else if (define <= XSysDefine.XSys_GuildInherit)
				{
					if (define <= XSysDefine.XSys_GuildRelax_JokerMatch)
					{
						if (define != XSysDefine.XSys_GroupRecruitAuthorize)
						{
							if (define != XSysDefine.XSys_GuildRelax_VoiceQA)
							{
								if (define == XSysDefine.XSys_GuildRelax_JokerMatch)
								{
									XGuildJockerMatchDocument specificDocument12 = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
									flag = specificDocument12.bAvaiableIconWhenShow;
								}
							}
							else
							{
								XVoiceQADocument specificDocument13 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
								flag = specificDocument13.MainInterFaceBtnState;
								bool flag9 = flag;
								if (flag9)
								{
									XVoiceQADocument specificDocument14 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
									index = (int)specificDocument14.TempType;
								}
							}
						}
						else
						{
							GroupChatDocument specificDocument15 = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
							flag = specificDocument15.bShowMotion;
						}
					}
					else if (define <= XSysDefine.XSys_GuildQualifier)
					{
						if (define != XSysDefine.XSys_GuildBoon_RedPacket)
						{
							if (define == XSysDefine.XSys_GuildQualifier)
							{
								XGuildQualifierDocument specificDocument16 = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
								flag = specificDocument16.bHasAvailableLadderIcon;
							}
						}
						else
						{
							XGuildRedPacketDocument specificDocument17 = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
							flag = (specificDocument17.bHasShowIconRedPacket > 0);
							bool flag10 = flag;
							if (flag10)
							{
								showCount = specificDocument17.bHasShowIconRedPacket;
							}
						}
					}
					else if (define != XSysDefine.XSys_GuildDailyTask)
					{
						if (define == XSysDefine.XSys_GuildInherit)
						{
							XGuildInheritDocument specificDocument18 = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
							flag = (specificDocument18.bHasAvailableIconShow > 0U);
							bool flag11 = flag;
							if (flag11)
							{
								showCount = (int)specificDocument18.bHasAvailableIconShow;
							}
						}
					}
					else
					{
						flag = XGuildDailyTaskDocument.Doc.DailyTaskBeenRefreshIcon;
					}
				}
				else if (define <= XSysDefine.XSys_IDIP_ZeroReward)
				{
					if (define <= XSysDefine.XSys_Team_Invited)
					{
						if (define != XSysDefine.XSys_JockerKing)
						{
							if (define == XSysDefine.XSys_Team_Invited)
							{
								XTeamInviteDocument specificDocument19 = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
								flag = (specificDocument19.m_InvitedCount > 0);
								bool flag12 = flag;
								if (flag12)
								{
									showCount = specificDocument19.m_InvitedCount;
								}
							}
						}
						else
						{
							XJokerKingDocument specificDocument20 = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
							flag = specificDocument20.bAvaiableIconWhenShow;
						}
					}
					else if (define != XSysDefine.XSys_GuildDailyRequest)
					{
						if (define == XSysDefine.XSys_IDIP_ZeroReward)
						{
							XIDIPDocument specificDocument21 = XDocuments.GetSpecificDocument<XIDIPDocument>(XIDIPDocument.uuID);
							flag = specificDocument21.ZeroRewardBtnState;
						}
					}
					else
					{
						flag = XGuildDailyTaskDocument.Doc.DailyTaskHelpRefreshIcon;
					}
				}
				else if (define <= XSysDefine.XSys_GuildTerritoryMessageInterface)
				{
					switch (define)
					{
					case XSysDefine.XSys_HeroBattle:
					{
						XHeroBattleDocument specificDocument22 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
						flag = specificDocument22.MaininterfaceState;
						break;
					}
					case XSysDefine.XSys_GuildBossMainInterface:
						flag = (XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildDragon) && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildDragon));
						break;
					case XSysDefine.XSys_GuildMineMainInterface:
					{
						XGuildMineEntranceDocument specificDocument23 = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
						flag = specificDocument23.MainInterfaceState;
						break;
					}
					case XSysDefine.XSys_GuildPvpMainInterface:
						flag = XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildPvp);
						break;
					case XSysDefine.XSys_TeamLeague:
					{
						XFreeTeamVersusLeagueDocument specificDocument24 = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
						flag = specificDocument24.MainInterfaceState;
						break;
					}
					case XSysDefine.XSys_ProfessionChange:
					case XSysDefine.XSys_Questionnaire:
						break;
					case XSysDefine.XSys_GuildMineEnd:
					{
						XGuildMineEntranceDocument specificDocument25 = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
						flag = specificDocument25.MainInterfaceStateEnd;
						break;
					}
					default:
						switch (define)
						{
						case XSysDefine.XSys_GuildTerritoryIconInterface:
						{
							XGuildTerritoryDocument specificDocument26 = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
							flag = (specificDocument26.TerritoryStyle > XGuildTerritoryDocument.GuildTerritoryStyle.NONE);
							break;
						}
						case XSysDefine.XSys_GuildTerritoryAllianceInterface:
						{
							XGuildTerritoryDocument specificDocument27 = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
							flag = (specificDocument27.bHavaTerritoryRecCount > 0U);
							bool flag13 = flag;
							if (flag13)
							{
								showCount = (int)specificDocument27.bHavaTerritoryRecCount;
							}
							break;
						}
						case XSysDefine.XSys_GuildTerritoryMessageInterface:
						{
							XGuildTerritoryDocument specificDocument28 = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
							flag = specificDocument28.bHavaShowMessageIcon;
							break;
						}
						}
						break;
					}
				}
				else if (define != XSysDefine.XSys_Exchange)
				{
					if (define == XSysDefine.XSys_GuildCollectMainInterface)
					{
						XGuildCollectDocument specificDocument29 = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
						flag = specificDocument29.MainInterfaceBtnState;
					}
				}
				else
				{
					XRequestDocument specificDocument30 = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
					flag = (specificDocument30.MainInterfaceNum != 0);
					bool flag14 = flag;
					if (flag14)
					{
						showCount = specificDocument30.MainInterfaceNum;
					}
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x04006C8E RID: 27790
		private IXUIList m_substanceList;

		// Token: 0x04006C8F RID: 27791
		private XUIPool _tempPool;

		// Token: 0x04006C90 RID: 27792
		private Stack<XMainSubstance> _stack;

		// Token: 0x04006C91 RID: 27793
		private Dictionary<XSysDefine, XMainSubstance> _ShowSubStance;
	}
}
