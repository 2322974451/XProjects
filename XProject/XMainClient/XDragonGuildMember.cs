using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A10 RID: 2576
	internal class XDragonGuildMember : IComparable<XDragonGuildMember>
	{
		// Token: 0x06009DE1 RID: 40417 RVA: 0x0019CDA8 File Offset: 0x0019AFA8
		public string GetLiveness()
		{
			return this.liveness.ToString();
		}

		// Token: 0x06009DE2 RID: 40418 RVA: 0x0019CDC8 File Offset: 0x0019AFC8
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

		// Token: 0x06009DE3 RID: 40419 RVA: 0x0019CF9C File Offset: 0x0019B19C
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

		// Token: 0x040037C2 RID: 14274
		public static int ONLINE_TIME = -1;

		// Token: 0x040037C3 RID: 14275
		public ulong uid;

		// Token: 0x040037C4 RID: 14276
		public string name;

		// Token: 0x040037C5 RID: 14277
		public int profession = 1;

		// Token: 0x040037C6 RID: 14278
		public uint ppt;

		// Token: 0x040037C7 RID: 14279
		public uint level;

		// Token: 0x040037C8 RID: 14280
		public DragonGuildPosition position;

		// Token: 0x040037C9 RID: 14281
		public int time;

		// Token: 0x040037CA RID: 14282
		public uint vip;

		// Token: 0x040037CB RID: 14283
		public bool isOnline;

		// Token: 0x040037CC RID: 14284
		public uint liveness;

		// Token: 0x040037CD RID: 14285
		public uint paymemberid;

		// Token: 0x040037CE RID: 14286
		public uint titleID;

		// Token: 0x040037CF RID: 14287
		public static DragonGuildMemberSortType sortType = DragonGuildMemberSortType.DGMST_ID;

		// Token: 0x040037D0 RID: 14288
		public static ulong playerID = 0UL;

		// Token: 0x040037D1 RID: 14289
		public static int dir = -1;

		// Token: 0x040037D2 RID: 14290
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
