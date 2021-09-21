using System;

namespace XMainClient
{
	// Token: 0x02000D1E RID: 3358
	internal class XGuildMemberBasicInfo : IComparable<XGuildMemberBasicInfo>
	{
		// Token: 0x0600BB21 RID: 47905 RVA: 0x00266B74 File Offset: 0x00264D74
		public string GetLiveness()
		{
			return this.liveness.ToString();
		}

		// Token: 0x0600BB22 RID: 47906 RVA: 0x00266B94 File Offset: 0x00264D94
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

		// Token: 0x04004B78 RID: 19320
		public static int ONLINE_TIME = -1;

		// Token: 0x04004B79 RID: 19321
		public ulong uid;

		// Token: 0x04004B7A RID: 19322
		public string name;

		// Token: 0x04004B7B RID: 19323
		public int profession = 1;

		// Token: 0x04004B7C RID: 19324
		public uint ppt;

		// Token: 0x04004B7D RID: 19325
		public uint level;

		// Token: 0x04004B7E RID: 19326
		public GuildPosition position;

		// Token: 0x04004B7F RID: 19327
		public int time;

		// Token: 0x04004B80 RID: 19328
		public uint vip;

		// Token: 0x04004B81 RID: 19329
		public bool isOnline;

		// Token: 0x04004B82 RID: 19330
		public uint liveness;

		// Token: 0x04004B83 RID: 19331
		public uint paymemberid;

		// Token: 0x04004B84 RID: 19332
		public uint titleID;

		// Token: 0x04004B85 RID: 19333
		public bool isInherit;

		// Token: 0x04004B86 RID: 19334
		public static GuildMemberSortType sortType = GuildMemberSortType.GMST_ID;

		// Token: 0x04004B87 RID: 19335
		public static ulong playerID = 0UL;

		// Token: 0x04004B88 RID: 19336
		public static int dir = -1;

		// Token: 0x04004B89 RID: 19337
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
