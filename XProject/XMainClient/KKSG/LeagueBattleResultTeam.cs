using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F4 RID: 1780
	[ProtoContract(Name = "LeagueBattleResultTeam")]
	[Serializable]
	public class LeagueBattleResultTeam : IExtensible
	{
		// Token: 0x170025E5 RID: 9701
		// (get) Token: 0x060077A9 RID: 30633 RVA: 0x000E4E90 File Offset: 0x000E3090
		// (set) Token: 0x060077AA RID: 30634 RVA: 0x000E4EBD File Offset: 0x000E30BD
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

		// Token: 0x170025E6 RID: 9702
		// (get) Token: 0x060077AB RID: 30635 RVA: 0x000E4ECC File Offset: 0x000E30CC
		// (set) Token: 0x060077AC RID: 30636 RVA: 0x000E4EEC File Offset: 0x000E30EC
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

		// Token: 0x060077AD RID: 30637 RVA: 0x000E4F30 File Offset: 0x000E3130
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x060077AE RID: 30638 RVA: 0x000E4F48 File Offset: 0x000E3148
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x170025E7 RID: 9703
		// (get) Token: 0x060077AF RID: 30639 RVA: 0x000E4F54 File Offset: 0x000E3154
		// (set) Token: 0x060077B0 RID: 30640 RVA: 0x000E4F75 File Offset: 0x000E3175
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

		// Token: 0x170025E8 RID: 9704
		// (get) Token: 0x060077B1 RID: 30641 RVA: 0x000E4F80 File Offset: 0x000E3180
		// (set) Token: 0x060077B2 RID: 30642 RVA: 0x000E4F9C File Offset: 0x000E319C
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

		// Token: 0x060077B3 RID: 30643 RVA: 0x000E4FCC File Offset: 0x000E31CC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060077B4 RID: 30644 RVA: 0x000E4FE4 File Offset: 0x000E31E4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170025E9 RID: 9705
		// (get) Token: 0x060077B5 RID: 30645 RVA: 0x000E4FF0 File Offset: 0x000E31F0
		// (set) Token: 0x060077B6 RID: 30646 RVA: 0x000E501C File Offset: 0x000E321C
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

		// Token: 0x170025EA RID: 9706
		// (get) Token: 0x060077B7 RID: 30647 RVA: 0x000E502C File Offset: 0x000E322C
		// (set) Token: 0x060077B8 RID: 30648 RVA: 0x000E504C File Offset: 0x000E324C
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

		// Token: 0x060077B9 RID: 30649 RVA: 0x000E5090 File Offset: 0x000E3290
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x060077BA RID: 30650 RVA: 0x000E50A8 File Offset: 0x000E32A8
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170025EB RID: 9707
		// (get) Token: 0x060077BB RID: 30651 RVA: 0x000E50B4 File Offset: 0x000E32B4
		// (set) Token: 0x060077BC RID: 30652 RVA: 0x000E50D5 File Offset: 0x000E32D5
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

		// Token: 0x170025EC RID: 9708
		// (get) Token: 0x060077BD RID: 30653 RVA: 0x000E50E0 File Offset: 0x000E32E0
		// (set) Token: 0x060077BE RID: 30654 RVA: 0x000E50FC File Offset: 0x000E32FC
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

		// Token: 0x060077BF RID: 30655 RVA: 0x000E512C File Offset: 0x000E332C
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x060077C0 RID: 30656 RVA: 0x000E5144 File Offset: 0x000E3344
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170025ED RID: 9709
		// (get) Token: 0x060077C1 RID: 30657 RVA: 0x000E5150 File Offset: 0x000E3350
		[ProtoMember(5, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueBattleResultRole> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x170025EE RID: 9710
		// (get) Token: 0x060077C2 RID: 30658 RVA: 0x000E5168 File Offset: 0x000E3368
		// (set) Token: 0x060077C3 RID: 30659 RVA: 0x000E5194 File Offset: 0x000E3394
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

		// Token: 0x170025EF RID: 9711
		// (get) Token: 0x060077C4 RID: 30660 RVA: 0x000E51A4 File Offset: 0x000E33A4
		// (set) Token: 0x060077C5 RID: 30661 RVA: 0x000E51C4 File Offset: 0x000E33C4
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

		// Token: 0x060077C6 RID: 30662 RVA: 0x000E5208 File Offset: 0x000E3408
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060077C7 RID: 30663 RVA: 0x000E5220 File Offset: 0x000E3420
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x170025F0 RID: 9712
		// (get) Token: 0x060077C8 RID: 30664 RVA: 0x000E522C File Offset: 0x000E342C
		// (set) Token: 0x060077C9 RID: 30665 RVA: 0x000E5258 File Offset: 0x000E3458
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

		// Token: 0x170025F1 RID: 9713
		// (get) Token: 0x060077CA RID: 30666 RVA: 0x000E5268 File Offset: 0x000E3468
		// (set) Token: 0x060077CB RID: 30667 RVA: 0x000E5288 File Offset: 0x000E3488
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

		// Token: 0x060077CC RID: 30668 RVA: 0x000E52CC File Offset: 0x000E34CC
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060077CD RID: 30669 RVA: 0x000E52E4 File Offset: 0x000E34E4
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170025F2 RID: 9714
		// (get) Token: 0x060077CE RID: 30670 RVA: 0x000E52F0 File Offset: 0x000E34F0
		// (set) Token: 0x060077CF RID: 30671 RVA: 0x000E531C File Offset: 0x000E351C
		[ProtoMember(8, IsRequired = false, Name = "score_change", DataFormat = DataFormat.TwosComplement)]
		public int score_change
		{
			get
			{
				return this._score_change ?? 0;
			}
			set
			{
				this._score_change = new int?(value);
			}
		}

		// Token: 0x170025F3 RID: 9715
		// (get) Token: 0x060077D0 RID: 30672 RVA: 0x000E532C File Offset: 0x000E352C
		// (set) Token: 0x060077D1 RID: 30673 RVA: 0x000E534C File Offset: 0x000E354C
		[XmlIgnore]
		[Browsable(false)]
		public bool score_changeSpecified
		{
			get
			{
				return this._score_change != null;
			}
			set
			{
				bool flag = value == (this._score_change == null);
				if (flag)
				{
					this._score_change = (value ? new int?(this.score_change) : null);
				}
			}
		}

		// Token: 0x060077D2 RID: 30674 RVA: 0x000E5390 File Offset: 0x000E3590
		private bool ShouldSerializescore_change()
		{
			return this.score_changeSpecified;
		}

		// Token: 0x060077D3 RID: 30675 RVA: 0x000E53A8 File Offset: 0x000E35A8
		private void Resetscore_change()
		{
			this.score_changeSpecified = false;
		}

		// Token: 0x170025F4 RID: 9716
		// (get) Token: 0x060077D4 RID: 30676 RVA: 0x000E53B4 File Offset: 0x000E35B4
		// (set) Token: 0x060077D5 RID: 30677 RVA: 0x000E53E0 File Offset: 0x000E35E0
		[ProtoMember(9, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		// Token: 0x170025F5 RID: 9717
		// (get) Token: 0x060077D6 RID: 30678 RVA: 0x000E53F0 File Offset: 0x000E35F0
		// (set) Token: 0x060077D7 RID: 30679 RVA: 0x000E5410 File Offset: 0x000E3610
		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		// Token: 0x060077D8 RID: 30680 RVA: 0x000E5454 File Offset: 0x000E3654
		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		// Token: 0x060077D9 RID: 30681 RVA: 0x000E546C File Offset: 0x000E366C
		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		// Token: 0x170025F6 RID: 9718
		// (get) Token: 0x060077DA RID: 30682 RVA: 0x000E5478 File Offset: 0x000E3678
		// (set) Token: 0x060077DB RID: 30683 RVA: 0x000E54A4 File Offset: 0x000E36A4
		[ProtoMember(10, IsRequired = false, Name = "rank_change", DataFormat = DataFormat.TwosComplement)]
		public int rank_change
		{
			get
			{
				return this._rank_change ?? 0;
			}
			set
			{
				this._rank_change = new int?(value);
			}
		}

		// Token: 0x170025F7 RID: 9719
		// (get) Token: 0x060077DC RID: 30684 RVA: 0x000E54B4 File Offset: 0x000E36B4
		// (set) Token: 0x060077DD RID: 30685 RVA: 0x000E54D4 File Offset: 0x000E36D4
		[XmlIgnore]
		[Browsable(false)]
		public bool rank_changeSpecified
		{
			get
			{
				return this._rank_change != null;
			}
			set
			{
				bool flag = value == (this._rank_change == null);
				if (flag)
				{
					this._rank_change = (value ? new int?(this.rank_change) : null);
				}
			}
		}

		// Token: 0x060077DE RID: 30686 RVA: 0x000E5518 File Offset: 0x000E3718
		private bool ShouldSerializerank_change()
		{
			return this.rank_changeSpecified;
		}

		// Token: 0x060077DF RID: 30687 RVA: 0x000E5530 File Offset: 0x000E3730
		private void Resetrank_change()
		{
			this.rank_changeSpecified = false;
		}

		// Token: 0x060077E0 RID: 30688 RVA: 0x000E553C File Offset: 0x000E373C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C51 RID: 7249
		private ulong? _league_teamid;

		// Token: 0x04001C52 RID: 7250
		private string _name;

		// Token: 0x04001C53 RID: 7251
		private uint? _serverid;

		// Token: 0x04001C54 RID: 7252
		private string _servername;

		// Token: 0x04001C55 RID: 7253
		private readonly List<LeagueBattleResultRole> _members = new List<LeagueBattleResultRole>();

		// Token: 0x04001C56 RID: 7254
		private uint? _rank;

		// Token: 0x04001C57 RID: 7255
		private uint? _score;

		// Token: 0x04001C58 RID: 7256
		private int? _score_change;

		// Token: 0x04001C59 RID: 7257
		private uint? _honorpoint;

		// Token: 0x04001C5A RID: 7258
		private int? _rank_change;

		// Token: 0x04001C5B RID: 7259
		private IExtension extensionObject;
	}
}
