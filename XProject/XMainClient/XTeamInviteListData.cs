using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000A94 RID: 2708
	internal class XTeamInviteListData : XDataBase, IComparable<XTeamInviteListData>
	{
		// Token: 0x0600A4CE RID: 42190 RVA: 0x001C9500 File Offset: 0x001C7700
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

		// Token: 0x0600A4CF RID: 42191 RVA: 0x001C95FC File Offset: 0x001C77FC
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

		// Token: 0x0600A4D0 RID: 42192 RVA: 0x001C96C0 File Offset: 0x001C78C0
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

		// Token: 0x0600A4D1 RID: 42193 RVA: 0x001C97C0 File Offset: 0x001C79C0
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

		// Token: 0x0600A4D2 RID: 42194 RVA: 0x001C9817 File Offset: 0x001C7A17
		public override void Recycle()
		{
			XDataPool<XTeamInviteListData>.Recycle(this);
		}

		// Token: 0x04003BF3 RID: 15347
		public XTeamRelation relation = new XTeamRelation();

		// Token: 0x04003BF4 RID: 15348
		public ulong uid;

		// Token: 0x04003BF5 RID: 15349
		public string name;

		// Token: 0x04003BF6 RID: 15350
		public uint ppt;

		// Token: 0x04003BF7 RID: 15351
		public uint level;

		// Token: 0x04003BF8 RID: 15352
		public uint profession = 1U;

		// Token: 0x04003BF9 RID: 15353
		public uint vip;

		// Token: 0x04003BFA RID: 15354
		public string guildname;

		// Token: 0x04003BFB RID: 15355
		public uint degree;

		// Token: 0x04003BFC RID: 15356
		public int sameGuild;

		// Token: 0x04003BFD RID: 15357
		public bool bSent;

		// Token: 0x04003BFE RID: 15358
		public XTeamInviteListData.InviteState state;

		// Token: 0x04003BFF RID: 15359
		public string openid;

		// Token: 0x04003C00 RID: 15360
		public bool isOnline;

		// Token: 0x04003C01 RID: 15361
		public string bigpic;

		// Token: 0x04003C02 RID: 15362
		public string midpic;

		// Token: 0x04003C03 RID: 15363
		public string smallpic;

		// Token: 0x04003C04 RID: 15364
		public bool wantHelp;

		// Token: 0x02001990 RID: 6544
		public enum InviteState
		{
			// Token: 0x04007EF7 RID: 32503
			IS_IDLE,
			// Token: 0x04007EF8 RID: 32504
			IS_OTHER_TEAM,
			// Token: 0x04007EF9 RID: 32505
			IS_MY_TEAM,
			// Token: 0x04007EFA RID: 32506
			IS_FIGHTING,
			// Token: 0x04007EFB RID: 32507
			IS_NO_COUNT,
			// Token: 0x04007EFC RID: 32508
			IS_NO_FATIGUE,
			// Token: 0x04007EFD RID: 32509
			IS_NOT_OPEN
		}
	}
}
