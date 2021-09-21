using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F0 RID: 1776
	[ProtoContract(Name = "LeagueBattleTeamData")]
	[Serializable]
	public class LeagueBattleTeamData : IExtensible
	{
		// Token: 0x170025B6 RID: 9654
		// (get) Token: 0x06007719 RID: 30489 RVA: 0x000E3D74 File Offset: 0x000E1F74
		// (set) Token: 0x0600771A RID: 30490 RVA: 0x000E3DA1 File Offset: 0x000E1FA1
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

		// Token: 0x170025B7 RID: 9655
		// (get) Token: 0x0600771B RID: 30491 RVA: 0x000E3DB0 File Offset: 0x000E1FB0
		// (set) Token: 0x0600771C RID: 30492 RVA: 0x000E3DD0 File Offset: 0x000E1FD0
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

		// Token: 0x0600771D RID: 30493 RVA: 0x000E3E14 File Offset: 0x000E2014
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x0600771E RID: 30494 RVA: 0x000E3E2C File Offset: 0x000E202C
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x170025B8 RID: 9656
		// (get) Token: 0x0600771F RID: 30495 RVA: 0x000E3E38 File Offset: 0x000E2038
		// (set) Token: 0x06007720 RID: 30496 RVA: 0x000E3E59 File Offset: 0x000E2059
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170025B9 RID: 9657
		// (get) Token: 0x06007721 RID: 30497 RVA: 0x000E3E64 File Offset: 0x000E2064
		// (set) Token: 0x06007722 RID: 30498 RVA: 0x000E3E80 File Offset: 0x000E2080
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007723 RID: 30499 RVA: 0x000E3EB0 File Offset: 0x000E20B0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007724 RID: 30500 RVA: 0x000E3EC8 File Offset: 0x000E20C8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170025BA RID: 9658
		// (get) Token: 0x06007725 RID: 30501 RVA: 0x000E3ED4 File Offset: 0x000E20D4
		// (set) Token: 0x06007726 RID: 30502 RVA: 0x000E3F00 File Offset: 0x000E2100
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

		// Token: 0x170025BB RID: 9659
		// (get) Token: 0x06007727 RID: 30503 RVA: 0x000E3F10 File Offset: 0x000E2110
		// (set) Token: 0x06007728 RID: 30504 RVA: 0x000E3F30 File Offset: 0x000E2130
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

		// Token: 0x06007729 RID: 30505 RVA: 0x000E3F74 File Offset: 0x000E2174
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x0600772A RID: 30506 RVA: 0x000E3F8C File Offset: 0x000E218C
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170025BC RID: 9660
		// (get) Token: 0x0600772B RID: 30507 RVA: 0x000E3F98 File Offset: 0x000E2198
		// (set) Token: 0x0600772C RID: 30508 RVA: 0x000E3FB9 File Offset: 0x000E21B9
		[ProtoMember(4, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
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

		// Token: 0x170025BD RID: 9661
		// (get) Token: 0x0600772D RID: 30509 RVA: 0x000E3FC4 File Offset: 0x000E21C4
		// (set) Token: 0x0600772E RID: 30510 RVA: 0x000E3FE0 File Offset: 0x000E21E0
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

		// Token: 0x0600772F RID: 30511 RVA: 0x000E4010 File Offset: 0x000E2210
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x06007730 RID: 30512 RVA: 0x000E4028 File Offset: 0x000E2228
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170025BE RID: 9662
		// (get) Token: 0x06007731 RID: 30513 RVA: 0x000E4034 File Offset: 0x000E2234
		// (set) Token: 0x06007732 RID: 30514 RVA: 0x000E4060 File Offset: 0x000E2260
		[ProtoMember(5, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170025BF RID: 9663
		// (get) Token: 0x06007733 RID: 30515 RVA: 0x000E4070 File Offset: 0x000E2270
		// (set) Token: 0x06007734 RID: 30516 RVA: 0x000E4090 File Offset: 0x000E2290
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

		// Token: 0x06007735 RID: 30517 RVA: 0x000E40D4 File Offset: 0x000E22D4
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007736 RID: 30518 RVA: 0x000E40EC File Offset: 0x000E22EC
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170025C0 RID: 9664
		// (get) Token: 0x06007737 RID: 30519 RVA: 0x000E40F8 File Offset: 0x000E22F8
		// (set) Token: 0x06007738 RID: 30520 RVA: 0x000E4124 File Offset: 0x000E2324
		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x170025C1 RID: 9665
		// (get) Token: 0x06007739 RID: 30521 RVA: 0x000E4134 File Offset: 0x000E2334
		// (set) Token: 0x0600773A RID: 30522 RVA: 0x000E4154 File Offset: 0x000E2354
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x0600773B RID: 30523 RVA: 0x000E4198 File Offset: 0x000E2398
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600773C RID: 30524 RVA: 0x000E41B0 File Offset: 0x000E23B0
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x170025C2 RID: 9666
		// (get) Token: 0x0600773D RID: 30525 RVA: 0x000E41BC File Offset: 0x000E23BC
		// (set) Token: 0x0600773E RID: 30526 RVA: 0x000E41E8 File Offset: 0x000E23E8
		[ProtoMember(7, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		// Token: 0x170025C3 RID: 9667
		// (get) Token: 0x0600773F RID: 30527 RVA: 0x000E41F8 File Offset: 0x000E23F8
		// (set) Token: 0x06007740 RID: 30528 RVA: 0x000E4218 File Offset: 0x000E2418
		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		// Token: 0x06007741 RID: 30529 RVA: 0x000E425C File Offset: 0x000E245C
		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		// Token: 0x06007742 RID: 30530 RVA: 0x000E4274 File Offset: 0x000E2474
		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		// Token: 0x170025C4 RID: 9668
		// (get) Token: 0x06007743 RID: 30531 RVA: 0x000E4280 File Offset: 0x000E2480
		// (set) Token: 0x06007744 RID: 30532 RVA: 0x000E42AC File Offset: 0x000E24AC
		[ProtoMember(8, IsRequired = false, Name = "total_win", DataFormat = DataFormat.TwosComplement)]
		public uint total_win
		{
			get
			{
				return this._total_win ?? 0U;
			}
			set
			{
				this._total_win = new uint?(value);
			}
		}

		// Token: 0x170025C5 RID: 9669
		// (get) Token: 0x06007745 RID: 30533 RVA: 0x000E42BC File Offset: 0x000E24BC
		// (set) Token: 0x06007746 RID: 30534 RVA: 0x000E42DC File Offset: 0x000E24DC
		[XmlIgnore]
		[Browsable(false)]
		public bool total_winSpecified
		{
			get
			{
				return this._total_win != null;
			}
			set
			{
				bool flag = value == (this._total_win == null);
				if (flag)
				{
					this._total_win = (value ? new uint?(this.total_win) : null);
				}
			}
		}

		// Token: 0x06007747 RID: 30535 RVA: 0x000E4320 File Offset: 0x000E2520
		private bool ShouldSerializetotal_win()
		{
			return this.total_winSpecified;
		}

		// Token: 0x06007748 RID: 30536 RVA: 0x000E4338 File Offset: 0x000E2538
		private void Resettotal_win()
		{
			this.total_winSpecified = false;
		}

		// Token: 0x170025C6 RID: 9670
		// (get) Token: 0x06007749 RID: 30537 RVA: 0x000E4344 File Offset: 0x000E2544
		[ProtoMember(9, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueBattleRoleBrief> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x0600774A RID: 30538 RVA: 0x000E435C File Offset: 0x000E255C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C34 RID: 7220
		private ulong? _league_teamid;

		// Token: 0x04001C35 RID: 7221
		private string _name;

		// Token: 0x04001C36 RID: 7222
		private uint? _serverid;

		// Token: 0x04001C37 RID: 7223
		private string _servername;

		// Token: 0x04001C38 RID: 7224
		private uint? _score;

		// Token: 0x04001C39 RID: 7225
		private uint? _rank;

		// Token: 0x04001C3A RID: 7226
		private uint? _total_num;

		// Token: 0x04001C3B RID: 7227
		private uint? _total_win;

		// Token: 0x04001C3C RID: 7228
		private readonly List<LeagueBattleRoleBrief> _members = new List<LeagueBattleRoleBrief>();

		// Token: 0x04001C3D RID: 7229
		private IExtension extensionObject;
	}
}
