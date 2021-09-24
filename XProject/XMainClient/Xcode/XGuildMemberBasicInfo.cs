using System;

namespace XMainClient
{

	internal class XGuildMemberBasicInfo : IComparable<XGuildMemberBasicInfo>
	{

		public string GetLiveness()
		{
			return this.liveness.ToString();
		}

		public int CompareTo(XGuildMemberBasicInfo other)
		{
			int num = 0;
			bool flag = XGuildMemberBasicInfo.playerID != 0UL && this.uid != other.uid;
			if (flag)
			{
				bool flag2 = this.uid == XGuildMemberBasicInfo.playerID;
				if (flag2)
				{
					return -1;
				}
				bool flag3 = other.uid == XGuildMemberBasicInfo.playerID;
				if (flag3)
				{
					return 1;
				}
			}
			switch (XGuildMemberBasicInfo.sortType)
			{
			case GuildMemberSortType.GMST_NAME:
				num = this.name.CompareTo(other.name);
				break;
			case GuildMemberSortType.GMST_PROFESSION:
				num = this.profession.CompareTo(other.profession);
				break;
			case GuildMemberSortType.GMST_TITLE:
				num = this.titleID.CompareTo(other.titleID);
				break;
			case GuildMemberSortType.GMST_LEVEL:
				num = this.level.CompareTo(other.level);
				break;
			case GuildMemberSortType.GMST_POSITION:
				num = -this.position.CompareTo(other.position);
				break;
			case GuildMemberSortType.GMST_TIME:
				num = this.time.CompareTo(other.time);
				break;
			case GuildMemberSortType.GMST_ACTIVE:
				num = this.liveness.CompareTo(other.liveness);
				break;
			case GuildMemberSortType.GMST_INHERIT:
				num = this.isInherit.CompareTo(other.isInherit);
				break;
			case GuildMemberSortType.GMST_ONLINE:
				num = this.isOnline.CompareTo(other.isOnline);
				break;
			case GuildMemberSortType.GMST_PPT:
				num = this.ppt.CompareTo(other.ppt);
				break;
			}
			bool flag4 = num == 0;
			if (flag4)
			{
				num = this.uid.CompareTo(other.uid);
			}
			return num * XGuildMemberBasicInfo.dir;
		}

		public static int ONLINE_TIME = -1;

		public ulong uid;

		public string name;

		public int profession = 1;

		public uint ppt;

		public uint level;

		public GuildPosition position;

		public int time;

		public uint vip;

		public bool isOnline;

		public uint liveness;

		public uint paymemberid;

		public uint titleID;

		public bool isInherit;

		public static GuildMemberSortType sortType = GuildMemberSortType.GMST_ID;

		public static ulong playerID = 0UL;

		public static int dir = -1;

		public static int[] DefaultSortDirection = new int[]
		{
			1,
			1,
			1,
			-1,
			-1,
			-1,
			1,
			-1,
			1,
			-1,
			1
		};
	}
}
