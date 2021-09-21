using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D31 RID: 3377
	internal class XTeamMemberBriefData : XDataBase, IComparable<XTeamMemberBriefData>
	{
		// Token: 0x170032F2 RID: 13042
		// (get) Token: 0x0600BB56 RID: 47958 RVA: 0x002676D8 File Offset: 0x002658D8
		public bool isTarja
		{
			get
			{
				return this.tarjatime > 0U;
			}
		}

		// Token: 0x0600BB57 RID: 47959 RVA: 0x002676F4 File Offset: 0x002658F4
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

		// Token: 0x0600BB58 RID: 47960 RVA: 0x00267792 File Offset: 0x00265992
		public override void Init()
		{
			base.Init();
			this.position = XTeamPosition.TP_MEMBER;
		}

		// Token: 0x0600BB59 RID: 47961 RVA: 0x002677A3 File Offset: 0x002659A3
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XTeamMemberBriefData>.Recycle(this);
		}

		// Token: 0x0600BB5A RID: 47962 RVA: 0x002677B4 File Offset: 0x002659B4
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

		// Token: 0x04004BC7 RID: 19399
		public ulong uid;

		// Token: 0x04004BC8 RID: 19400
		public string name;

		// Token: 0x04004BC9 RID: 19401
		public RoleType profession;

		// Token: 0x04004BCA RID: 19402
		public XTeamPosition position;

		// Token: 0x04004BCB RID: 19403
		public int level;

		// Token: 0x04004BCC RID: 19404
		public uint ppt;

		// Token: 0x04004BCD RID: 19405
		public ulong guildid;

		// Token: 0x04004BCE RID: 19406
		public XTeamRelation relation = new XTeamRelation();

		// Token: 0x04004BCF RID: 19407
		public uint vip;

		// Token: 0x04004BD0 RID: 19408
		public uint paymemberid;

		// Token: 0x04004BD1 RID: 19409
		public bool robot;

		// Token: 0x04004BD2 RID: 19410
		public ulong dragonguildid;

		// Token: 0x04004BD3 RID: 19411
		public bool regression = false;

		// Token: 0x04004BD4 RID: 19412
		private uint tarjatime;
	}
}
