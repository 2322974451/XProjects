using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamBriefData : XDataBase, IComparable<XTeamBriefData>
	{

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

		public XTeamBriefData()
		{
			this.goldGroup.teamBrief = this;
		}

		public string GetStrTeamPPT(double myPPT = 0.0)
		{
			return XTeamBriefData.GetStrTeamPPT(this.teamPPT, myPPT);
		}

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

		public ExpeditionTable.RowData rowData;

		public int currentMemberCount;

		public int totalMemberCount;

		public XTeamCategory category;

		public uint dungeonID = 0U;

		public int teamID;

		public string leaderName;

		public int leaderLevel = 44;

		public uint leaderPPT = 555U;

		public RoleType leaderProfession = RoleType.Role_Warrior;

		public XTeamState state = XTeamState.TS_NOT_FULL;

		public TeamState actualState = TeamState.TEAM_WAITING;

		public KMatchType matchType = KMatchType.KMT_NONE;

		public bool hasPwd;

		public string password;

		public string dungeonName;

		public string teamName;

		public uint dungeonLevel;

		public List<XTeamMemberBriefData> members = new List<XTeamMemberBriefData>();

		public XTeamRelation relation = new XTeamRelation();

		public uint teamPPT = 0U;

		public bool isTarja = false;

		public XGoldGroupData goldGroup = default(XGoldGroupData);

		public XTeamRift rift = null;

		public bool regression = false;

		public static int[] DefaultSortDirection = new int[]
		{
			1,
			1,
			-1,
			1,
			1,
			1
		};

		public static TeamBriefSortType sortType = TeamBriefSortType.TBST_TEAM_ID;

		public static int dir = 1;
	}
}
