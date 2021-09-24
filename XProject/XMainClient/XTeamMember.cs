using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamMember : IComparable<XTeamMember>
	{

		public ulong uid
		{
			get
			{
				return this.briefData.uid;
			}
			set
			{
				this.briefData.uid = value;
			}
		}

		public string name
		{
			get
			{
				return this.briefData.name;
			}
			set
			{
				this.briefData.name = value;
			}
		}

		public RoleType profession
		{
			get
			{
				return this.briefData.profession;
			}
		}

		public int level
		{
			get
			{
				return this.briefData.level;
			}
		}

		public uint ppt
		{
			get
			{
				return this.briefData.ppt;
			}
		}

		public XTeamPosition position
		{
			get
			{
				return this.briefData.position;
			}
			set
			{
				this.briefData.position = value;
			}
		}

		public ulong guildID
		{
			get
			{
				return this.briefData.guildid;
			}
			set
			{
				this.briefData.guildid = value;
			}
		}

		public uint vip
		{
			get
			{
				return this.briefData.vip;
			}
			set
			{
				this.briefData.vip = value;
			}
		}

		public uint paymemberid
		{
			get
			{
				return this.briefData.paymemberid;
			}
			set
			{
				this.briefData.paymemberid = value;
			}
		}

		public XTeamRelation Relation
		{
			get
			{
				return this.briefData.relation;
			}
		}

		public ulong dragonGuildID
		{
			get
			{
				return this.briefData.dragonguildid;
			}
		}

		public bool bIsLeader
		{
			get
			{
				return this.position == XTeamPosition.TP_LEADER;
			}
		}

		public bool bIsHelper
		{
			get
			{
				return this._is_helper;
			}
		}

		public bool bIsTicket
		{
			get
			{
				return this._is_ticket;
			}
		}

		public bool IsTarja
		{
			get
			{
				return this._tarjatime > 0U;
			}
		}

		public uint ServerID
		{
			get
			{
				return this._server_id;
			}
		}

		public void SetData(TeamMember data, string leaderName, int joinindex)
		{
			this.briefData.SetData(data, leaderName);
			this.entityID = this.uid;
			this.joinIndex = joinindex;
			this.state = (ExpTeamMemberState)data.state;
			this.fashion = data.fashion;
			this.outlook = data.outlook;
			this.sceneID = (data.robot ? 1U : data.sceneID);
			this.leftCount = (data.robot ? 1 : data.leftcount);
			this.briefData.vip = data.vipLevel;
			this.bIsRobot = data.robot;
			this._is_helper = (data.membertype == TeamMemberType.TMT_HELPER);
			this._is_ticket = (data.membertype == TeamMemberType.TMT_USETICKET);
			this.briefData.paymemberid = data.paymemberid;
			this._tarjatime = data.tarjatime;
			this._server_id = data.serverid;
			this.regression = data.kingback;
		}

		public int CompareTo(XTeamMember other)
		{
			int num = XFastEnumIntEqualityComparer<XTeamPosition>.ToInt(this.position).CompareTo(XFastEnumIntEqualityComparer<XTeamPosition>.ToInt(other.position));
			bool flag = num == 0;
			if (flag)
			{
				num = this.joinIndex.CompareTo(other.joinIndex);
			}
			return num;
		}

		public static XTeamMember CreateTeamMember(TeamMember data, string leaderName, int joinindex)
		{
			XTeamMember xteamMember = new XTeamMember();
			xteamMember.SetData(data, leaderName, joinindex);
			return xteamMember;
		}

		private XTeamMemberBriefData briefData = new XTeamMemberBriefData();

		public ulong entityID;

		public int joinIndex;

		public ExpTeamMemberState state = ExpTeamMemberState.EXPTEAM_IDLE;

		public List<uint> fashion = null;

		public OutLook outlook = null;

		public uint sceneID;

		public int leftCount;

		public bool regression = false;

		public bool bIsRobot = false;

		private bool _is_helper = false;

		private bool _is_ticket = false;

		private uint _tarjatime = 0U;

		private uint _server_id = 0U;
	}
}
