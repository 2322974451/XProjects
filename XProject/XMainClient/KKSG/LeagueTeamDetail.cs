using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006EF RID: 1775
	[ProtoContract(Name = "LeagueTeamDetail")]
	[Serializable]
	public class LeagueTeamDetail : IExtensible
	{
		// Token: 0x170025A9 RID: 9641
		// (get) Token: 0x060076F2 RID: 30450 RVA: 0x000E3908 File Offset: 0x000E1B08
		// (set) Token: 0x060076F3 RID: 30451 RVA: 0x000E3935 File Offset: 0x000E1B35
		[ProtoMember(1, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong league_teamid
		{
			get
			{
				return this._league_teamid ?? 0UL;
			}
			set
			{
				this._league_teamid = new ulong?(value);
			}
		}

		// Token: 0x170025AA RID: 9642
		// (get) Token: 0x060076F4 RID: 30452 RVA: 0x000E3944 File Offset: 0x000E1B44
		// (set) Token: 0x060076F5 RID: 30453 RVA: 0x000E3964 File Offset: 0x000E1B64
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamidSpecified
		{
			get
			{
				return this._league_teamid != null;
			}
			set
			{
				bool flag = value == (this._league_teamid == null);
				if (flag)
				{
					this._league_teamid = (value ? new ulong?(this.league_teamid) : null);
				}
			}
		}

		// Token: 0x060076F6 RID: 30454 RVA: 0x000E39A8 File Offset: 0x000E1BA8
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x060076F7 RID: 30455 RVA: 0x000E39C0 File Offset: 0x000E1BC0
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x170025AB RID: 9643
		// (get) Token: 0x060076F8 RID: 30456 RVA: 0x000E39CC File Offset: 0x000E1BCC
		// (set) Token: 0x060076F9 RID: 30457 RVA: 0x000E39ED File Offset: 0x000E1BED
		[ProtoMember(2, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		// Token: 0x170025AC RID: 9644
		// (get) Token: 0x060076FA RID: 30458 RVA: 0x000E39F8 File Offset: 0x000E1BF8
		// (set) Token: 0x060076FB RID: 30459 RVA: 0x000E3A14 File Offset: 0x000E1C14
		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		// Token: 0x060076FC RID: 30460 RVA: 0x000E3A44 File Offset: 0x000E1C44
		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		// Token: 0x060076FD RID: 30461 RVA: 0x000E3A5C File Offset: 0x000E1C5C
		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		// Token: 0x170025AD RID: 9645
		// (get) Token: 0x060076FE RID: 30462 RVA: 0x000E3A68 File Offset: 0x000E1C68
		// (set) Token: 0x060076FF RID: 30463 RVA: 0x000E3A94 File Offset: 0x000E1C94
		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x170025AE RID: 9646
		// (get) Token: 0x06007700 RID: 30464 RVA: 0x000E3AA4 File Offset: 0x000E1CA4
		// (set) Token: 0x06007701 RID: 30465 RVA: 0x000E3AC4 File Offset: 0x000E1CC4
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06007702 RID: 30466 RVA: 0x000E3B08 File Offset: 0x000E1D08
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007703 RID: 30467 RVA: 0x000E3B20 File Offset: 0x000E1D20
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170025AF RID: 9647
		// (get) Token: 0x06007704 RID: 30468 RVA: 0x000E3B2C File Offset: 0x000E1D2C
		// (set) Token: 0x06007705 RID: 30469 RVA: 0x000E3B4D File Offset: 0x000E1D4D
		[ProtoMember(4, IsRequired = false, Name = "zonename", DataFormat = DataFormat.Default)]
		public string zonename
		{
			get
			{
				return this._zonename ?? "";
			}
			set
			{
				this._zonename = value;
			}
		}

		// Token: 0x170025B0 RID: 9648
		// (get) Token: 0x06007706 RID: 30470 RVA: 0x000E3B58 File Offset: 0x000E1D58
		// (set) Token: 0x06007707 RID: 30471 RVA: 0x000E3B74 File Offset: 0x000E1D74
		[XmlIgnore]
		[Browsable(false)]
		public bool zonenameSpecified
		{
			get
			{
				return this._zonename != null;
			}
			set
			{
				bool flag = value == (this._zonename == null);
				if (flag)
				{
					this._zonename = (value ? this.zonename : null);
				}
			}
		}

		// Token: 0x06007708 RID: 30472 RVA: 0x000E3BA4 File Offset: 0x000E1DA4
		private bool ShouldSerializezonename()
		{
			return this.zonenameSpecified;
		}

		// Token: 0x06007709 RID: 30473 RVA: 0x000E3BBC File Offset: 0x000E1DBC
		private void Resetzonename()
		{
			this.zonenameSpecified = false;
		}

		// Token: 0x170025B1 RID: 9649
		// (get) Token: 0x0600770A RID: 30474 RVA: 0x000E3BC8 File Offset: 0x000E1DC8
		// (set) Token: 0x0600770B RID: 30475 RVA: 0x000E3BE9 File Offset: 0x000E1DE9
		[ProtoMember(5, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x170025B2 RID: 9650
		// (get) Token: 0x0600770C RID: 30476 RVA: 0x000E3BF4 File Offset: 0x000E1DF4
		// (set) Token: 0x0600770D RID: 30477 RVA: 0x000E3C10 File Offset: 0x000E1E10
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x0600770E RID: 30478 RVA: 0x000E3C40 File Offset: 0x000E1E40
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x0600770F RID: 30479 RVA: 0x000E3C58 File Offset: 0x000E1E58
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170025B3 RID: 9651
		// (get) Token: 0x06007710 RID: 30480 RVA: 0x000E3C64 File Offset: 0x000E1E64
		[ProtoMember(6, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueTeamMemberDetail> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x170025B4 RID: 9652
		// (get) Token: 0x06007711 RID: 30481 RVA: 0x000E3C7C File Offset: 0x000E1E7C
		// (set) Token: 0x06007712 RID: 30482 RVA: 0x000E3CA8 File Offset: 0x000E1EA8
		[ProtoMember(7, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170025B5 RID: 9653
		// (get) Token: 0x06007713 RID: 30483 RVA: 0x000E3CB8 File Offset: 0x000E1EB8
		// (set) Token: 0x06007714 RID: 30484 RVA: 0x000E3CD8 File Offset: 0x000E1ED8
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06007715 RID: 30485 RVA: 0x000E3D1C File Offset: 0x000E1F1C
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007716 RID: 30486 RVA: 0x000E3D34 File Offset: 0x000E1F34
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06007717 RID: 30487 RVA: 0x000E3D40 File Offset: 0x000E1F40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C2C RID: 7212
		private ulong? _league_teamid;

		// Token: 0x04001C2D RID: 7213
		private string _teamname;

		// Token: 0x04001C2E RID: 7214
		private uint? _serverid;

		// Token: 0x04001C2F RID: 7215
		private string _zonename;

		// Token: 0x04001C30 RID: 7216
		private string _servername;

		// Token: 0x04001C31 RID: 7217
		private readonly List<LeagueTeamMemberDetail> _members = new List<LeagueTeamMemberDetail>();

		// Token: 0x04001C32 RID: 7218
		private uint? _score;

		// Token: 0x04001C33 RID: 7219
		private IExtension extensionObject;
	}
}
