using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildMember : XGuildMemberBasicInfo, IComparable<XGuildMember>
	{

		public void Set(GuildMemberData data)
		{
			this.uid = data.roleid;
			this.name = data.name;
			this.position = (GuildPosition)data.position;
			this.ppt = data.ppt;
			this.contribution = data.contribute;
			this.level = data.level;
			this.profession = XFastEnumIntEqualityComparer<RoleType>.ToInt(data.profession);
			this.time = (int)data.lastlogin;
			this.vip = data.vip;
			this.paymemberid = data.paymemberid;
			this.isOnline = data.isonline;
			this.liveness = data.activity;
			this.taskLuck = data.task_luck;
			this.taskScore = data.task_score;
			this.canRefresh = data.can_refresh;
			bool flag = data.lastlogin == 0U;
			if (flag)
			{
				this.time = XGuildMemberBasicInfo.ONLINE_TIME;
			}
			this.titleID = data.title;
			this.canSend = (((ulong)data.flag & (ulong)((long)XFastEnumIntEqualityComparer<GuildMemberFlag>.ToInt(GuildMemberFlag.SEND_FATIGUE))) > 0UL);
			bool flag2 = ((ulong)data.flag & (ulong)((long)XFastEnumIntEqualityComparer<GuildMemberFlag>.ToInt(GuildMemberFlag.RECV_FATIGUE))) > 0UL;
			if (flag2)
			{
				this.fetchState = FetchState.FS_CAN_FETCH;
			}
			else
			{
				bool flag3 = ((ulong)data.flag & (ulong)((long)XFastEnumIntEqualityComparer<GuildMemberFlag>.ToInt(GuildMemberFlag.RECVED_FATIGUE))) > 0UL;
				if (flag3)
				{
					this.fetchState = FetchState.FS_FETCHED;
				}
				else
				{
					this.fetchState = FetchState.FS_CANNOT_FETCH;
				}
			}
		}

		public int CompareTo(XGuildMember other)
		{
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
			int num = 0;
			GuildMemberSortType sortType = XGuildMemberBasicInfo.sortType;
			if (sortType != GuildMemberSortType.GMST_CONTRIBUTION)
			{
				if (sortType == GuildMemberSortType.GMST_TASKSCORE)
				{
					bool flag4 = this.canRefresh ^ other.canRefresh;
					if (flag4)
					{
						num = (this.canRefresh ? -1 : 1);
					}
					else
					{
						num = (int)(this.taskScore - other.taskScore);
					}
				}
			}
			else
			{
				num = this.contribution.CompareTo(other.contribution);
			}
			bool flag5 = num == 0;
			int result;
			if (flag5)
			{
				result = base.CompareTo(other);
			}
			else
			{
				result = num * XGuildMemberBasicInfo.dir;
			}
			return result;
		}

		public uint contribution;

		public bool canSend;

		public uint taskLuck;

		public uint taskScore;

		public bool canRefresh;

		public FetchState fetchState;
	}
}
