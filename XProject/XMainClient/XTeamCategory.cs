using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamCategory : IComparable<XTeamCategory>
	{

		public static string GetCategoryName(int categoryID)
		{
			return XStringDefineProxy.GetString("TeamCategory" + categoryID.ToString());
		}

		public string Name
		{
			get
			{
				return XTeamCategory.GetCategoryName(this.category);
			}
		}

		public static int SortExp(ExpeditionTable.RowData left, ExpeditionTable.RowData right)
		{
			return left.SortID.CompareTo(right.SortID);
		}

		public XTeamCategory(XTeamCategoryMgr mgr)
		{
			this.m_Mgr = mgr;
		}

		public int CompareTo(XTeamCategory other)
		{
			return this.category.CompareTo(other.category);
		}

		public bool HasOpened()
		{
			return this.GetOpenedExpCount() > 0;
		}

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

		private XExpeditionDocument expDoc = null;

		private XGuildDocument guildDoc = null;

		private XLevelDocument levelDoc = null;

		private XDragonNestDocument dnDoc = null;

		private XLevelSealDocument levelSealDoc = null;

		private XOperatingActivityDocument operatingDoc = null;

		public int category;

		public List<ExpeditionTable.RowData> expList = new List<ExpeditionTable.RowData>();

		private XTeamCategoryMgr m_Mgr;
	}
}
