using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000BD8 RID: 3032
	public class GroupMember : IComparable<GroupMember>
	{
		// Token: 0x0600AD0F RID: 44303 RVA: 0x002009EC File Offset: 0x001FEBEC
		public void Setup(GroupChatFindRoleInfo info)
		{
			this.userID = info.roleid;
			this.profession = (int)info.roleprofession;
			this.userName = info.rolename;
			this.groupID = info.groupchatID;
			this.groupName = info.groupchatName;
			this.stageID = info.stageID;
			this.type = info.type;
			this.fightValue = info.fighting;
			this.timeIndex = info.time;
			this.state = info.state;
			this.createTime = info.issuetime;
			this.issueIndex = info.issueIndex;
			this.isselfingroup = false;
		}

		// Token: 0x0600AD10 RID: 44304 RVA: 0x00200A94 File Offset: 0x001FEC94
		public void Setup(GroupChatFindTeamInfo info)
		{
			this.userID = info.leaderroleid;
			this.userName = "";
			this.profession = 1;
			this.groupID = info.groupchatID;
			this.groupName = info.groupchatName;
			this.stageID = info.stageID;
			this.type = info.type;
			this.fightValue = info.fighting;
			this.timeIndex = info.time;
			this.state = info.state;
			this.createTime = info.issuetime;
			this.issueIndex = info.issueIndex;
			this.isselfingroup = info.isselfingroup;
		}

		// Token: 0x0600AD11 RID: 44305 RVA: 0x00200B38 File Offset: 0x001FED38
		public void Release()
		{
			GroupMemberPool.Release(this);
		}

		// Token: 0x0600AD12 RID: 44306 RVA: 0x00200B44 File Offset: 0x001FED44
		public static GroupMember Get()
		{
			return GroupMemberPool.Get();
		}

		// Token: 0x0600AD13 RID: 44307 RVA: 0x00200B5C File Offset: 0x001FED5C
		public int CompareTo(GroupMember other)
		{
			int num = 0;
			switch (GroupMember.sortSeletor)
			{
			case TitleSelector.Stage:
				num = this.stageID.CompareTo(other.stageID);
				break;
			case TitleSelector.Fight:
				num = this.fightValue.CompareTo(other.fightValue);
				break;
			case TitleSelector.Time:
				num = this.timeIndex.CompareTo(other.timeIndex);
				break;
			}
			bool flag = num == 0;
			if (flag)
			{
				num = this.createTime.CompareTo(other.createTime);
			}
			return num * GroupMember.dir;
		}

		// Token: 0x0400411D RID: 16669
		public int profession = 1;

		// Token: 0x0400411E RID: 16670
		public string userName;

		// Token: 0x0400411F RID: 16671
		public uint stageID;

		// Token: 0x04004120 RID: 16672
		public ulong userID;

		// Token: 0x04004121 RID: 16673
		public ulong groupID;

		// Token: 0x04004122 RID: 16674
		public string groupName;

		// Token: 0x04004123 RID: 16675
		public uint fightValue;

		// Token: 0x04004124 RID: 16676
		public uint type;

		// Token: 0x04004125 RID: 16677
		public uint timeIndex;

		// Token: 0x04004126 RID: 16678
		public uint state;

		// Token: 0x04004127 RID: 16679
		public uint createTime;

		// Token: 0x04004128 RID: 16680
		public bool isselfingroup = false;

		// Token: 0x04004129 RID: 16681
		public ulong issueIndex = 0UL;

		// Token: 0x0400412A RID: 16682
		public static TitleSelector sortSeletor = TitleSelector.Nomal;

		// Token: 0x0400412B RID: 16683
		public static int dir = -1;
	}
}
