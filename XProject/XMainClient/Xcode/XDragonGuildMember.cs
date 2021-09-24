using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildMember : IComparable<XDragonGuildMember>
	{

		public string GetLiveness()
		{
			return this.liveness.ToString();
		}

		public int CompareTo(XDragonGuildMember other)
		{
			int num = 0;
			bool flag = XDragonGuildMember.playerID != 0UL && this.uid != other.uid;
			if (flag)
			{
				bool flag2 = this.uid == XDragonGuildMember.playerID;
				if (flag2)
				{
					return -1;
				}
				bool flag3 = other.uid == XDragonGuildMember.playerID;
				if (flag3)
				{
					return 1;
				}
			}
			bool flag4 = this.ppt == 0U && other.ppt > 0U;
			int result;
			if (flag4)
			{
				result = 1;
			}
			else
			{
				bool flag5 = this.ppt != 0U && other.ppt == 0U;
				if (flag5)
				{
					result = -1;
				}
				else
				{
					switch (XDragonGuildMember.sortType)
					{
					case DragonGuildMemberSortType.DGMST_TITLE:
						num = this.titleID.CompareTo(other.titleID);
						break;
					case DragonGuildMemberSortType.DGMST_LEVEL:
						num = this.level.CompareTo(other.level);
						break;
					case DragonGuildMemberSortType.DGMST_POSITION:
						num = -this.position.CompareTo(other.position);
						break;
					case DragonGuildMemberSortType.DGMST_PPT:
						num = this.ppt.CompareTo(other.ppt);
						break;
					case DragonGuildMemberSortType.DGMST_ACTIVE:
						num = this.liveness.CompareTo(other.liveness);
						break;
					case DragonGuildMemberSortType.DGMST_ONLINE:
						num = this.isOnline.CompareTo(other.isOnline);
						break;
					case DragonGuildMemberSortType.DGMST_NAME:
						num = this.name.CompareTo(other.name);
						break;
					case DragonGuildMemberSortType.DGMST_PROFESSION:
						num = this.profession.CompareTo(other.profession);
						break;
					case DragonGuildMemberSortType.DGMST_TIME:
						num = this.time.CompareTo(other.time);
						break;
					}
					bool flag6 = num == 0;
					if (flag6)
					{
						num = this.uid.CompareTo(other.uid);
					}
					result = num * XDragonGuildMember.dir;
				}
			}
			return result;
		}

		public void Set(DragonGuildMembersInfo data)
		{
			this.uid = data.roleid;
			this.name = data.name;
			this.position = (DragonGuildPosition)data.position;
			this.ppt = data.ppt;
			this.level = data.level;
			this.profession = XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession);
			this.time = (int)data.lastlogin;
			this.vip = data.vip;
			this.paymemberid = data.paymemberid;
			this.isOnline = data.isonline;
			this.liveness = data.activity;
			bool flag = data.lastlogin == 0U;
			if (flag)
			{
				this.time = XDragonGuildMember.ONLINE_TIME;
			}
			this.titleID = data.title;
		}

		public static int ONLINE_TIME = -1;

		public ulong uid;

		public string name;

		public int profession = 1;

		public uint ppt;

		public uint level;

		public DragonGuildPosition position;

		public int time;

		public uint vip;

		public bool isOnline;

		public uint liveness;

		public uint paymemberid;

		public uint titleID;

		public static DragonGuildMemberSortType sortType = DragonGuildMemberSortType.DGMST_ID;

		public static ulong playerID = 0UL;

		public static int dir = -1;

		public static int[] DefaultSortDirection = new int[]
		{
			1,
			-1,
			-1,
			-1,
			-1,
			-1,
			1
		};
	}
}
