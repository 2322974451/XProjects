using System;
using KKSG;

namespace XMainClient
{

	internal class XTeamInviteListData : XDataBase, IComparable<XTeamInviteListData>
	{

		public void SetData(TeamInvRoleInfo data, bool bIsFriend, bool bIsGuild, bool bIsPartner)
		{
			this.uid = data.userID;
			this.name = data.userName;
			this.level = data.userLevel;
			this.ppt = data.userPowerPoint;
			this.vip = data.userVip;
			this.guildname = data.guildName;
			this.degree = data.degree;
			this.sameGuild = ((data.teamguildid == 0UL || data.roleguildid == data.teamguildid) ? 1 : 0);
			this.profession = (uint)data.profession;
			this.bSent = false;
			this.state = this._GetInviteState(data.state);
			this.wantHelp = data.wanthelp;
			this.relation.Reset();
			if (bIsGuild)
			{
				this.relation.Append(XTeamRelation.Relation.TR_GUILD, true);
			}
			if (bIsFriend)
			{
				this.relation.Append(XTeamRelation.Relation.TR_FRIEND, true);
			}
			if (bIsPartner)
			{
				this.relation.Append(XTeamRelation.Relation.TR_PARTNER, true);
			}
		}

		public void SetData(PlatFriendRankInfo2Client data)
		{
			this.name = data.platfriendBaseInfo.nickname;
			this.level = data.level;
			this.ppt = data.maxAbility;
			this.profession = (uint)data.profession;
			this.bSent = false;
			this.state = XTeamInviteListData.InviteState.IS_IDLE;
			this.vip = 0U;
			this.guildname = null;
			this.sameGuild = 1;
			this.openid = data.platfriendBaseInfo.openid;
			this.isOnline = data.isOnline;
			this.bigpic = data.platfriendBaseInfo.bigpic;
			this.midpic = data.platfriendBaseInfo.midpic;
			this.smallpic = data.platfriendBaseInfo.smallpic;
			this.relation.Reset();
		}

		public int CompareTo(XTeamInviteListData other)
		{
			int num = this.relation.CompareTo(other.relation);
			bool flag = num != 0;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				bool flag2 = this.sameGuild != other.sameGuild;
				if (flag2)
				{
					result = -this.sameGuild.CompareTo(other.sameGuild);
				}
				else
				{
					bool flag3 = this.wantHelp != other.wantHelp;
					if (flag3)
					{
						result = -this.wantHelp.CompareTo(other.wantHelp);
					}
					else
					{
						bool flag4 = this.state != other.state;
						if (flag4)
						{
							result = this.state.CompareTo(other.state);
						}
						else
						{
							bool flag5 = this.degree != other.degree;
							if (flag5)
							{
								result = -this.degree.CompareTo(other.degree);
							}
							else
							{
								result = -this.ppt.CompareTo(other.ppt);
							}
						}
					}
				}
			}
			return result;
		}

		private XTeamInviteListData.InviteState _GetInviteState(TeamInvRoleState state)
		{
			XTeamInviteListData.InviteState result;
			switch (state)
			{
			case TeamInvRoleState.TIRS_IN_OTHER_TEAM:
				result = XTeamInviteListData.InviteState.IS_OTHER_TEAM;
				break;
			case TeamInvRoleState.TIRS_IN_MY_TEAM:
				result = XTeamInviteListData.InviteState.IS_MY_TEAM;
				break;
			case TeamInvRoleState.TIRS_IN_BATTLE:
				result = XTeamInviteListData.InviteState.IS_FIGHTING;
				break;
			case TeamInvRoleState.TIRS_NORMAL:
				result = XTeamInviteListData.InviteState.IS_IDLE;
				break;
			case TeamInvRoleState.TIRS_NOT_OPEN:
				result = XTeamInviteListData.InviteState.IS_NOT_OPEN;
				break;
			case TeamInvRoleState.TIRS_COUNT_LESS:
				result = XTeamInviteListData.InviteState.IS_NO_COUNT;
				break;
			case TeamInvRoleState.TIRS_FATIGUE_LESS:
				result = XTeamInviteListData.InviteState.IS_NO_FATIGUE;
				break;
			default:
				result = XTeamInviteListData.InviteState.IS_IDLE;
				break;
			}
			return result;
		}

		public override void Recycle()
		{
			XDataPool<XTeamInviteListData>.Recycle(this);
		}

		public XTeamRelation relation = new XTeamRelation();

		public ulong uid;

		public string name;

		public uint ppt;

		public uint level;

		public uint profession = 1U;

		public uint vip;

		public string guildname;

		public uint degree;

		public int sameGuild;

		public bool bSent;

		public XTeamInviteListData.InviteState state;

		public string openid;

		public bool isOnline;

		public string bigpic;

		public string midpic;

		public string smallpic;

		public bool wantHelp;

		public enum InviteState
		{

			IS_IDLE,

			IS_OTHER_TEAM,

			IS_MY_TEAM,

			IS_FIGHTING,

			IS_NO_COUNT,

			IS_NO_FATIGUE,

			IS_NOT_OPEN
		}
	}
}
