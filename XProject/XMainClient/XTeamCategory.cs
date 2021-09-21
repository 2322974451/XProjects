using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D3A RID: 3386
	internal class XTeamCategory : IComparable<XTeamCategory>
	{
		// Token: 0x0600BB8C RID: 48012 RVA: 0x0026899C File Offset: 0x00266B9C
		public static string GetCategoryName(int categoryID)
		{
			return XStringDefineProxy.GetString("TeamCategory" + categoryID.ToString());
		}

		// Token: 0x17003305 RID: 13061
		// (get) Token: 0x0600BB8D RID: 48013 RVA: 0x002689C4 File Offset: 0x00266BC4
		public string Name
		{
			get
			{
				return XTeamCategory.GetCategoryName(this.category);
			}
		}

		// Token: 0x0600BB8E RID: 48014 RVA: 0x002689E4 File Offset: 0x00266BE4
		public static int SortExp(ExpeditionTable.RowData left, ExpeditionTable.RowData right)
		{
			return left.SortID.CompareTo(right.SortID);
		}

		// Token: 0x0600BB8F RID: 48015 RVA: 0x00268A08 File Offset: 0x00266C08
		public XTeamCategory(XTeamCategoryMgr mgr)
		{
			this.m_Mgr = mgr;
		}

		// Token: 0x0600BB90 RID: 48016 RVA: 0x00268A5C File Offset: 0x00266C5C
		public int CompareTo(XTeamCategory other)
		{
			return this.category.CompareTo(other.category);
		}

		// Token: 0x0600BB91 RID: 48017 RVA: 0x00268A80 File Offset: 0x00266C80
		public bool HasOpened()
		{
			return this.GetOpenedExpCount() > 0;
		}

		// Token: 0x0600BB92 RID: 48018 RVA: 0x00268A9C File Offset: 0x00266C9C
		public bool IsExpOpened(ExpeditionTable.RowData rowData)
		{
			bool flag = rowData == null || XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				bool flag2 = (ulong)level < (ulong)((long)rowData.RequiredLevel);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this.expDoc == null;
					if (flag3)
					{
						this.expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					}
					bool flag4 = this.guildDoc == null;
					if (flag4)
					{
						this.guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					}
					bool flag5 = this.levelDoc == null;
					if (flag5)
					{
						this.levelDoc = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
					}
					bool flag6 = this.dnDoc == null;
					if (flag6)
					{
						this.dnDoc = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
					}
					bool flag7 = this.levelSealDoc == null;
					if (flag7)
					{
						this.levelSealDoc = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					}
					bool flag8 = this.operatingDoc == null;
					if (flag8)
					{
						this.operatingDoc = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
					}
					bool flag9 = rowData.LevelSealType > 0U && rowData.LevelSealType != this.levelSealDoc.SealType;
					if (flag9)
					{
						result = false;
					}
					else
					{
						TeamLevelType type = (TeamLevelType)rowData.Type;
						TeamLevelType teamLevelType = type;
						if (teamLevelType <= TeamLevelType.TeamLevelFestival)
						{
							switch (teamLevelType)
							{
							case TeamLevelType.TeamLevelNest:
							{
								bool flag10 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Activity_Nest) && this.levelDoc.CanLevelOpen(this.expDoc.GetSceneIDByExpID(rowData.DNExpeditionID)) == SceneRefuseReason.Admit;
								bool flag11 = !flag10;
								if (flag11)
								{
									return false;
								}
								break;
							}
							case TeamLevelType.TeamLevelAbyss:
							{
								bool flag12 = this.levelDoc.CanLevelOpen(this.expDoc.GetSceneIDByExpID(rowData.DNExpeditionID)) == SceneRefuseReason.Admit;
								bool flag13 = !flag12;
								if (flag13)
								{
									return false;
								}
								break;
							}
							case (TeamLevelType)5:
								break;
							case TeamLevelType.TeamLevelDragonNest:
							{
								bool flag14 = !this.dnDoc.CheckCanFightByExpID((uint)rowData.DNExpeditionID);
								if (flag14)
								{
									return false;
								}
								break;
							}
							case TeamLevelType.TeamLevelTeamTower:
							{
								bool flag15 = !this.expDoc.IsTeamTowerOpen(rowData.DNExpeditionID);
								if (flag15)
								{
									return false;
								}
								break;
							}
							default:
								switch (teamLevelType)
								{
								case TeamLevelType.TeamLevelGuildCamp:
								{
									bool flag16 = !this.guildDoc.bInGuild || (ulong)this.guildDoc.Level < (ulong)((long)rowData.GuildLevel);
									if (flag16)
									{
										return false;
									}
									XGuildSmallMonsterDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
									return specificDocument.IsOpen(rowData);
								}
								case TeamLevelType.TeamLevelWeekNest:
								{
									XWeekNestDocument doc = XWeekNestDocument.Doc;
									bool flag17 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_WeekNest);
									if (flag17)
									{
										return false;
									}
									XActivityDocument specificDocument2 = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
									bool flag18 = specificDocument2.ServerOpenDay < XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WeekNest));
									if (flag18)
									{
										return false;
									}
									return rowData.DNExpeditionID == doc.CurDNid;
								}
								case TeamLevelType.TeamLevelTeamLeague:
								{
									XFreeTeamVersusLeagueDocument specificDocument3 = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
									return specificDocument3.IsOpen;
								}
								case TeamLevelType.TeamLevelFestival:
									return this.operatingDoc.CheckFestivalIsOpen(this.expDoc.GetSceneIDByExpID(rowData.DNExpeditionID));
								}
								break;
							}
						}
						else if (teamLevelType != TeamLevelType.TeamLevelWeekendParty)
						{
							if (teamLevelType == TeamLevelType.TeamLevelWedding)
							{
								return false;
							}
							if (teamLevelType == TeamLevelType.TeamLevelWeddingLicense)
							{
								return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Wedding);
							}
						}
						else
						{
							bool flag19 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_MulActivity_WeekendParty);
							if (flag19)
							{
								return false;
							}
							XWeekendPartyDocument specificDocument4 = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
							return specificDocument4.CheckIsOpen(this.expDoc.GetSceneIDByExpID(rowData.DNExpeditionID));
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600BB93 RID: 48019 RVA: 0x00268E9C File Offset: 0x0026709C
		public int GetOpenedExpCount()
		{
			int num = 0;
			bool flag = this.expDoc == null;
			if (flag)
			{
				this.expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			}
			for (int i = 0; i < this.expList.Count; i++)
			{
				bool flag2 = this.IsExpOpened(this.expList[i]);
				if (flag2)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x04004C19 RID: 19481
		private XExpeditionDocument expDoc = null;

		// Token: 0x04004C1A RID: 19482
		private XGuildDocument guildDoc = null;

		// Token: 0x04004C1B RID: 19483
		private XLevelDocument levelDoc = null;

		// Token: 0x04004C1C RID: 19484
		private XDragonNestDocument dnDoc = null;

		// Token: 0x04004C1D RID: 19485
		private XLevelSealDocument levelSealDoc = null;

		// Token: 0x04004C1E RID: 19486
		private XOperatingActivityDocument operatingDoc = null;

		// Token: 0x04004C1F RID: 19487
		public int category;

		// Token: 0x04004C20 RID: 19488
		public List<ExpeditionTable.RowData> expList = new List<ExpeditionTable.RowData>();

		// Token: 0x04004C21 RID: 19489
		private XTeamCategoryMgr m_Mgr;
	}
}
