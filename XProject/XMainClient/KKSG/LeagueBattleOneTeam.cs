using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F2 RID: 1778
	[ProtoContract(Name = "LeagueBattleOneTeam")]
	[Serializable]
	public class LeagueBattleOneTeam : IExtensible
	{
		// Token: 0x170025D7 RID: 9687
		// (get) Token: 0x0600777E RID: 30590 RVA: 0x000E4980 File Offset: 0x000E2B80
		// (set) Token: 0x0600777F RID: 30591 RVA: 0x000E49AD File Offset: 0x000E2BAD
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

		// Token: 0x170025D8 RID: 9688
		// (get) Token: 0x06007780 RID: 30592 RVA: 0x000E49BC File Offset: 0x000E2BBC
		// (set) Token: 0x06007781 RID: 30593 RVA: 0x000E49DC File Offset: 0x000E2BDC
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

		// Token: 0x06007782 RID: 30594 RVA: 0x000E4A20 File Offset: 0x000E2C20
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x06007783 RID: 30595 RVA: 0x000E4A38 File Offset: 0x000E2C38
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x170025D9 RID: 9689
		// (get) Token: 0x06007784 RID: 30596 RVA: 0x000E4A44 File Offset: 0x000E2C44
		// (set) Token: 0x06007785 RID: 30597 RVA: 0x000E4A65 File Offset: 0x000E2C65
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

		// Token: 0x170025DA RID: 9690
		// (get) Token: 0x06007786 RID: 30598 RVA: 0x000E4A70 File Offset: 0x000E2C70
		// (set) Token: 0x06007787 RID: 30599 RVA: 0x000E4A8C File Offset: 0x000E2C8C
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

		// Token: 0x06007788 RID: 30600 RVA: 0x000E4ABC File Offset: 0x000E2CBC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007789 RID: 30601 RVA: 0x000E4AD4 File Offset: 0x000E2CD4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170025DB RID: 9691
		// (get) Token: 0x0600778A RID: 30602 RVA: 0x000E4AE0 File Offset: 0x000E2CE0
		// (set) Token: 0x0600778B RID: 30603 RVA: 0x000E4B0C File Offset: 0x000E2D0C
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

		// Token: 0x170025DC RID: 9692
		// (get) Token: 0x0600778C RID: 30604 RVA: 0x000E4B1C File Offset: 0x000E2D1C
		// (set) Token: 0x0600778D RID: 30605 RVA: 0x000E4B3C File Offset: 0x000E2D3C
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

		// Token: 0x0600778E RID: 30606 RVA: 0x000E4B80 File Offset: 0x000E2D80
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x0600778F RID: 30607 RVA: 0x000E4B98 File Offset: 0x000E2D98
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170025DD RID: 9693
		// (get) Token: 0x06007790 RID: 30608 RVA: 0x000E4BA4 File Offset: 0x000E2DA4
		// (set) Token: 0x06007791 RID: 30609 RVA: 0x000E4BD0 File Offset: 0x000E2DD0
		[ProtoMember(4, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170025DE RID: 9694
		// (get) Token: 0x06007792 RID: 30610 RVA: 0x000E4BE0 File Offset: 0x000E2DE0
		// (set) Token: 0x06007793 RID: 30611 RVA: 0x000E4C00 File Offset: 0x000E2E00
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

		// Token: 0x06007794 RID: 30612 RVA: 0x000E4C44 File Offset: 0x000E2E44
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007795 RID: 30613 RVA: 0x000E4C5C File Offset: 0x000E2E5C
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170025DF RID: 9695
		// (get) Token: 0x06007796 RID: 30614 RVA: 0x000E4C68 File Offset: 0x000E2E68
		[ProtoMember(5, Name = "members", DataFormat = DataFormat.Default)]
		public List<LeagueBattleOneRole> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x06007797 RID: 30615 RVA: 0x000E4C80 File Offset: 0x000E2E80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C47 RID: 7239
		private ulong? _league_teamid;

		// Token: 0x04001C48 RID: 7240
		private string _name;

		// Token: 0x04001C49 RID: 7241
		private uint? _serverid;

		// Token: 0x04001C4A RID: 7242
		private uint? _score;

		// Token: 0x04001C4B RID: 7243
		private readonly List<LeagueBattleOneRole> _members = new List<LeagueBattleOneRole>();

		// Token: 0x04001C4C RID: 7244
		private IExtension extensionObject;
	}
}
