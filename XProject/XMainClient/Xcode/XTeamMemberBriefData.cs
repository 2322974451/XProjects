using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamMemberBriefData : XDataBase, IComparable<XTeamMemberBriefData>
	{

		public bool isTarja
		{
			get
			{
				return this.tarjatime > 0U;
			}
		}

		public void SetData(TeamMember data, string leaderName)
		{
			this.uid = data.memberID;
			this.name = data.name;
			this.profession = data.profession;
			this.level = data.level;
			this.ppt = data.powerpoint;
			this.position = ((this.name == leaderName) ? XTeamPosition.TP_LEADER : XTeamPosition.TP_MEMBER);
			this.guildid = data.guildid;
			this.robot = data.robot;
			this.tarjatime = data.tarjatime;
			this.dragonguildid = data.dragonguildid;
			this.regression = data.kingback;
		}

		public override void Init()
		{
			base.Init();
			this.position = XTeamPosition.TP_MEMBER;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XTeamMemberBriefData>.Recycle(this);
		}

		public int CompareTo(XTeamMemberBriefData other)
		{
			bool flag = this.position == XTeamPosition.TP_LEADER;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = this.uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					result = -this.level.CompareTo(other.level);
				}
			}
			return result;
		}

		public ulong uid;

		public string name;

		public RoleType profession;

		public XTeamPosition position;

		public int level;

		public uint ppt;

		public ulong guildid;

		public XTeamRelation relation = new XTeamRelation();

		public uint vip;

		public uint paymemberid;

		public bool robot;

		public ulong dragonguildid;

		public bool regression = false;

		private uint tarjatime;
	}
}
