using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D39 RID: 3385
	internal class XTeamMember : IComparable<XTeamMember>
	{
		// Token: 0x170032F5 RID: 13045
		// (get) Token: 0x0600BB72 RID: 47986 RVA: 0x002685AC File Offset: 0x002667AC
		// (set) Token: 0x0600BB73 RID: 47987 RVA: 0x002685C9 File Offset: 0x002667C9
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

		// Token: 0x170032F6 RID: 13046
		// (get) Token: 0x0600BB74 RID: 47988 RVA: 0x002685D8 File Offset: 0x002667D8
		// (set) Token: 0x0600BB75 RID: 47989 RVA: 0x002685F5 File Offset: 0x002667F5
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

		// Token: 0x170032F7 RID: 13047
		// (get) Token: 0x0600BB76 RID: 47990 RVA: 0x00268604 File Offset: 0x00266804
		public RoleType profession
		{
			get
			{
				return this.briefData.profession;
			}
		}

		// Token: 0x170032F8 RID: 13048
		// (get) Token: 0x0600BB77 RID: 47991 RVA: 0x00268624 File Offset: 0x00266824
		public int level
		{
			get
			{
				return this.briefData.level;
			}
		}

		// Token: 0x170032F9 RID: 13049
		// (get) Token: 0x0600BB78 RID: 47992 RVA: 0x00268644 File Offset: 0x00266844
		public uint ppt
		{
			get
			{
				return this.briefData.ppt;
			}
		}

		// Token: 0x170032FA RID: 13050
		// (get) Token: 0x0600BB79 RID: 47993 RVA: 0x00268664 File Offset: 0x00266864
		// (set) Token: 0x0600BB7A RID: 47994 RVA: 0x00268681 File Offset: 0x00266881
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

		// Token: 0x170032FB RID: 13051
		// (get) Token: 0x0600BB7B RID: 47995 RVA: 0x00268690 File Offset: 0x00266890
		// (set) Token: 0x0600BB7C RID: 47996 RVA: 0x002686AD File Offset: 0x002668AD
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

		// Token: 0x170032FC RID: 13052
		// (get) Token: 0x0600BB7D RID: 47997 RVA: 0x002686BC File Offset: 0x002668BC
		// (set) Token: 0x0600BB7E RID: 47998 RVA: 0x002686D9 File Offset: 0x002668D9
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

		// Token: 0x170032FD RID: 13053
		// (get) Token: 0x0600BB7F RID: 47999 RVA: 0x002686E8 File Offset: 0x002668E8
		// (set) Token: 0x0600BB80 RID: 48000 RVA: 0x00268705 File Offset: 0x00266905
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

		// Token: 0x170032FE RID: 13054
		// (get) Token: 0x0600BB81 RID: 48001 RVA: 0x00268714 File Offset: 0x00266914
		public XTeamRelation Relation
		{
			get
			{
				return this.briefData.relation;
			}
		}

		// Token: 0x170032FF RID: 13055
		// (get) Token: 0x0600BB82 RID: 48002 RVA: 0x00268734 File Offset: 0x00266934
		public ulong dragonGuildID
		{
			get
			{
				return this.briefData.dragonguildid;
			}
		}

		// Token: 0x17003300 RID: 13056
		// (get) Token: 0x0600BB83 RID: 48003 RVA: 0x00268754 File Offset: 0x00266954
		public bool bIsLeader
		{
			get
			{
				return this.position == XTeamPosition.TP_LEADER;
			}
		}

		// Token: 0x17003301 RID: 13057
		// (get) Token: 0x0600BB84 RID: 48004 RVA: 0x00268770 File Offset: 0x00266970
		public bool bIsHelper
		{
			get
			{
				return this._is_helper;
			}
		}

		// Token: 0x17003302 RID: 13058
		// (get) Token: 0x0600BB85 RID: 48005 RVA: 0x00268788 File Offset: 0x00266988
		public bool bIsTicket
		{
			get
			{
				return this._is_ticket;
			}
		}

		// Token: 0x17003303 RID: 13059
		// (get) Token: 0x0600BB86 RID: 48006 RVA: 0x002687A0 File Offset: 0x002669A0
		public bool IsTarja
		{
			get
			{
				return this._tarjatime > 0U;
			}
		}

		// Token: 0x17003304 RID: 13060
		// (get) Token: 0x0600BB87 RID: 48007 RVA: 0x002687BC File Offset: 0x002669BC
		public uint ServerID
		{
			get
			{
				return this._server_id;
			}
		}

		// Token: 0x0600BB88 RID: 48008 RVA: 0x002687D4 File Offset: 0x002669D4
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

		// Token: 0x0600BB89 RID: 48009 RVA: 0x002688C8 File Offset: 0x00266AC8
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

		// Token: 0x0600BB8A RID: 48010 RVA: 0x00268918 File Offset: 0x00266B18
		public static XTeamMember CreateTeamMember(TeamMember data, string leaderName, int joinindex)
		{
			XTeamMember xteamMember = new XTeamMember();
			xteamMember.SetData(data, leaderName, joinindex);
			return xteamMember;
		}

		// Token: 0x04004C0B RID: 19467
		private XTeamMemberBriefData briefData = new XTeamMemberBriefData();

		// Token: 0x04004C0C RID: 19468
		public ulong entityID;

		// Token: 0x04004C0D RID: 19469
		public int joinIndex;

		// Token: 0x04004C0E RID: 19470
		public ExpTeamMemberState state = ExpTeamMemberState.EXPTEAM_IDLE;

		// Token: 0x04004C0F RID: 19471
		public List<uint> fashion = null;

		// Token: 0x04004C10 RID: 19472
		public OutLook outlook = null;

		// Token: 0x04004C11 RID: 19473
		public uint sceneID;

		// Token: 0x04004C12 RID: 19474
		public int leftCount;

		// Token: 0x04004C13 RID: 19475
		public bool regression = false;

		// Token: 0x04004C14 RID: 19476
		public bool bIsRobot = false;

		// Token: 0x04004C15 RID: 19477
		private bool _is_helper = false;

		// Token: 0x04004C16 RID: 19478
		private bool _is_ticket = false;

		// Token: 0x04004C17 RID: 19479
		private uint _tarjatime = 0U;

		// Token: 0x04004C18 RID: 19480
		private uint _server_id = 0U;
	}
}
