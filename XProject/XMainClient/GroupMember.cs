using System;
using KKSG;

namespace XMainClient
{

	public class GroupMember : IComparable<GroupMember>
	{

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

		public void Release()
		{
			GroupMemberPool.Release(this);
		}

		public static GroupMember Get()
		{
			return GroupMemberPool.Get();
		}

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

		public int profession = 1;

		public string userName;

		public uint stageID;

		public ulong userID;

		public ulong groupID;

		public string groupName;

		public uint fightValue;

		public uint type;

		public uint timeIndex;

		public uint state;

		public uint createTime;

		public bool isselfingroup = false;

		public ulong issueIndex = 0UL;

		public static TitleSelector sortSeletor = TitleSelector.Nomal;

		public static int dir = -1;
	}
}
