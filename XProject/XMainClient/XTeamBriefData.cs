using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D34 RID: 3380
	internal class XTeamBriefData : XDataBase, IComparable<XTeamBriefData>
	{
		// Token: 0x0600BB66 RID: 47974 RVA: 0x00267D64 File Offset: 0x00265F64
		public static string GetStrTeamPPT(double teamPPT, double myPPT)
		{
			bool flag = teamPPT == 0.0;
			string result;
			if (flag)
			{
				result = XStringDefineProxy.GetString("NONE");
			}
			else
			{
				bool flag2 = myPPT == 0.0;
				if (flag2)
				{
					myPPT = XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
				}
				bool flag3 = myPPT < teamPPT;
				if (flag3)
				{
					result = XSingleton<XCommon>.singleton.StringCombine("[ff0000]", teamPPT.ToString(), "[-]");
				}
				else
				{
					result = teamPPT.ToString();
				}
			}
			return result;
		}

		// Token: 0x0600BB67 RID: 47975 RVA: 0x00267DE8 File Offset: 0x00265FE8
		public XTeamBriefData()
		{
			this.goldGroup.teamBrief = this;
		}

		// Token: 0x0600BB68 RID: 47976 RVA: 0x00267E80 File Offset: 0x00266080
		public string GetStrTeamPPT(double myPPT = 0.0)
		{
			return XTeamBriefData.GetStrTeamPPT(this.teamPPT, myPPT);
		}

		// Token: 0x0600BB69 RID: 47977 RVA: 0x00267EA0 File Offset: 0x002660A0
		private void _UpdateRelation()
		{
			this.relation.Reset();
			for (int i = 0; i < this.members.Count; i++)
			{
				XTeamMemberBriefData xteamMemberBriefData = this.members[i];
				bool flag = xteamMemberBriefData.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					xteamMemberBriefData.relation.Reset();
				}
				else
				{
					xteamMemberBriefData.relation.UpdateRelation(xteamMemberBriefData.uid, xteamMemberBriefData.guildid, xteamMemberBriefData.dragonguildid);
					this.relation.Append(xteamMemberBriefData.relation.ActualRelation, true);
				}
			}
		}

		// Token: 0x0600BB6A RID: 47978 RVA: 0x00267F48 File Offset: 0x00266148
		public void SetMembers(List<TeamMember> memberDatas)
		{
			this.isTarja = false;
			this.regression = false;
			for (int i = 0; i < memberDatas.Count; i++)
			{
				XTeamMemberBriefData data = XDataPool<XTeamMemberBriefData>.GetData();
				data.SetData(memberDatas[i], this.leaderName);
				this.members.Add(data);
				this.regression = (this.regression || data.regression);
				this.isTarja = (this.isTarja || (data.isTarja && XTeamDocument.InTarja(this.dungeonID, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession))));
			}
			this.members.Sort();
			this._UpdateRelation();
		}

		// Token: 0x0600BB6B RID: 47979 RVA: 0x00268004 File Offset: 0x00266204
		public void SetData(TeamBrief brief, XExpeditionDocument expDoc)
		{
			bool flag = this.dungeonID != brief.expID;
			if (flag)
			{
				this.dungeonID = brief.expID;
				this.category = expDoc.TeamCategoryMgr.GetCategoryByExpID((int)this.dungeonID);
				this.rowData = expDoc.GetExpeditionDataByID((int)this.dungeonID);
				bool flag2 = this.rowData != null;
				if (flag2)
				{
					this.dungeonLevel = this.rowData.DisplayLevel;
					this.dungeonName = XExpeditionDocument.GetFullName(this.rowData);
					this.totalMemberCount = this.rowData.PlayerNumber;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("cant find exp id: " + this.dungeonID.ToString(), null, null, null, null, null);
				}
			}
			this.leaderName = brief.leaderName;
			this.teamID = brief.teamID;
			this.leaderLevel = (int)brief.leaderLevel;
			this.leaderPPT = brief.leaderPowerPoint;
			this.leaderProfession = brief.leaderProfession;
			this.currentMemberCount = brief.teamMemberCount;
			this.password = brief.password;
			this.hasPwd = brief.haspassword;
			this.actualState = (TeamState)brief.teamState;
			this.matchType = brief.matchtype;
			this.teamName = XStringDefineProxy.GetString("TEAM_NAME", new object[]
			{
				this.leaderName
			});
			this.regression = brief.kingback;
			TeamState teamState = this.actualState;
			if (teamState != TeamState.TEAM_IN_BATTLE)
			{
				if (teamState != TeamState.TEAM_VOTE)
				{
					bool flag3 = this.currentMemberCount < this.totalMemberCount;
					if (flag3)
					{
						this.state = XTeamState.TS_NOT_FULL;
					}
					else
					{
						this.state = XTeamState.TS_FULL;
					}
				}
				else
				{
					this.state = XTeamState.TS_VOTING;
				}
			}
			else
			{
				this.state = XTeamState.TS_FIGHTING;
			}
			bool flag4 = brief.extrainfo != null;
			if (flag4)
			{
				this.teamPPT = brief.extrainfo.pptlimit;
				this.goldGroup.SetData(brief.extrainfo, this.rowData);
				bool flag5 = brief.extrainfo.rift != null;
				if (flag5)
				{
					bool flag6 = this.rift == null;
					if (flag6)
					{
						this.rift = XDataPool<XTeamRift>.GetData();
					}
					this.rift.SetData(brief.extrainfo.rift, this.rowData);
				}
				else
				{
					bool flag7 = this.rift != null;
					if (flag7)
					{
						this.rift.Recycle();
						this.rift = null;
					}
				}
			}
			else
			{
				this.teamPPT = 0U;
				this.goldGroup.bActive = false;
			}
		}

		// Token: 0x0600BB6C RID: 47980 RVA: 0x00268284 File Offset: 0x00266484
		public static int CompareToAccordingToRelation(XTeamBriefData left, XTeamBriefData right)
		{
			int num = XFastEnumIntEqualityComparer<XTeamState>.ToInt(left.state).CompareTo(XFastEnumIntEqualityComparer<XTeamState>.ToInt(right.state));
			bool flag = num == 0;
			if (flag)
			{
				num = left.relation.CompareTo(right.relation);
			}
			bool flag2 = num == 0;
			int result;
			if (flag2)
			{
				result = left.CompareTo(right);
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600BB6D RID: 47981 RVA: 0x002682E8 File Offset: 0x002664E8
		public int CompareTo(XTeamBriefData other)
		{
			int num = 0;
			switch (XTeamBriefData.sortType)
			{
			case TeamBriefSortType.TBST_TEAM_NAME:
				num = this.teamName.CompareTo(other.teamName);
				break;
			case TeamBriefSortType.TBST_DUNGEON_LEVEL:
				num = -this.dungeonLevel.CompareTo(other.dungeonLevel);
				break;
			case TeamBriefSortType.TBST_MEMBER_COUNT:
				num = this.currentMemberCount.CompareTo(other.currentMemberCount);
				break;
			case TeamBriefSortType.TBST_CATEGORY:
				num = this.category.category.CompareTo(other.category.category);
				break;
			case TeamBriefSortType.TBST_DUNGEON_ID:
				num = this.dungeonID.CompareTo(other.dungeonID);
				break;
			}
			bool flag = num == 0;
			if (flag)
			{
				num = XFastEnumIntEqualityComparer<XTeamState>.ToInt(this.state).CompareTo(XFastEnumIntEqualityComparer<XTeamState>.ToInt(other.state));
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				num = this.relation.CompareTo(other.relation) * XTeamBriefData.dir;
			}
			bool flag3 = num == 0;
			if (flag3)
			{
				double attr = XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
				bool flag4 = attr >= this.teamPPT;
				bool value = attr >= other.teamPPT;
				num = -flag4.CompareTo(value);
			}
			bool flag5 = num == 0;
			if (flag5)
			{
				num = this.hasPwd.CompareTo(other.hasPwd);
			}
			bool flag6 = num == 0;
			if (flag6)
			{
				bool flag7 = this.rift != null && other.rift != null;
				if (flag7)
				{
					num = -this.rift.floor.CompareTo(other.rift.floor);
				}
			}
			bool flag8 = num == 0;
			if (flag8)
			{
				num = this.teamID.CompareTo(other.teamID);
			}
			return num * XTeamBriefData.dir;
		}

		// Token: 0x0600BB6E RID: 47982 RVA: 0x002684B0 File Offset: 0x002666B0
		public override void Recycle()
		{
			base.Recycle();
			for (int i = 0; i < this.members.Count; i++)
			{
				this.members[i].Recycle();
			}
			this.members.Clear();
			bool flag = this.rift != null;
			if (flag)
			{
				this.rift.Recycle();
				this.rift = null;
			}
			XDataPool<XTeamBriefData>.Recycle(this);
		}

		// Token: 0x04004BDE RID: 19422
		public ExpeditionTable.RowData rowData;

		// Token: 0x04004BDF RID: 19423
		public int currentMemberCount;

		// Token: 0x04004BE0 RID: 19424
		public int totalMemberCount;

		// Token: 0x04004BE1 RID: 19425
		public XTeamCategory category;

		// Token: 0x04004BE2 RID: 19426
		public uint dungeonID = 0U;

		// Token: 0x04004BE3 RID: 19427
		public int teamID;

		// Token: 0x04004BE4 RID: 19428
		public string leaderName;

		// Token: 0x04004BE5 RID: 19429
		public int leaderLevel = 44;

		// Token: 0x04004BE6 RID: 19430
		public uint leaderPPT = 555U;

		// Token: 0x04004BE7 RID: 19431
		public RoleType leaderProfession = RoleType.Role_Warrior;

		// Token: 0x04004BE8 RID: 19432
		public XTeamState state = XTeamState.TS_NOT_FULL;

		// Token: 0x04004BE9 RID: 19433
		public TeamState actualState = TeamState.TEAM_WAITING;

		// Token: 0x04004BEA RID: 19434
		public KMatchType matchType = KMatchType.KMT_NONE;

		// Token: 0x04004BEB RID: 19435
		public bool hasPwd;

		// Token: 0x04004BEC RID: 19436
		public string password;

		// Token: 0x04004BED RID: 19437
		public string dungeonName;

		// Token: 0x04004BEE RID: 19438
		public string teamName;

		// Token: 0x04004BEF RID: 19439
		public uint dungeonLevel;

		// Token: 0x04004BF0 RID: 19440
		public List<XTeamMemberBriefData> members = new List<XTeamMemberBriefData>();

		// Token: 0x04004BF1 RID: 19441
		public XTeamRelation relation = new XTeamRelation();

		// Token: 0x04004BF2 RID: 19442
		public uint teamPPT = 0U;

		// Token: 0x04004BF3 RID: 19443
		public bool isTarja = false;

		// Token: 0x04004BF4 RID: 19444
		public XGoldGroupData goldGroup = default(XGoldGroupData);

		// Token: 0x04004BF5 RID: 19445
		public XTeamRift rift = null;

		// Token: 0x04004BF6 RID: 19446
		public bool regression = false;

		// Token: 0x04004BF7 RID: 19447
		public static int[] DefaultSortDirection = new int[]
		{
			1,
			1,
			-1,
			1,
			1,
			1
		};

		// Token: 0x04004BF8 RID: 19448
		public static TeamBriefSortType sortType = TeamBriefSortType.TBST_TEAM_ID;

		// Token: 0x04004BF9 RID: 19449
		public static int dir = 1;
	}
}
