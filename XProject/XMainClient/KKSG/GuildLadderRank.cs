using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B1 RID: 1713
	[ProtoContract(Name = "GuildLadderRank")]
	[Serializable]
	public class GuildLadderRank : IExtensible
	{
		// Token: 0x17002372 RID: 9074
		// (get) Token: 0x06006FFC RID: 28668 RVA: 0x000D6468 File Offset: 0x000D4668
		// (set) Token: 0x06006FFD RID: 28669 RVA: 0x000D6495 File Offset: 0x000D4695
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17002373 RID: 9075
		// (get) Token: 0x06006FFE RID: 28670 RVA: 0x000D64A4 File Offset: 0x000D46A4
		// (set) Token: 0x06006FFF RID: 28671 RVA: 0x000D64C4 File Offset: 0x000D46C4
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06007000 RID: 28672 RVA: 0x000D6508 File Offset: 0x000D4708
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06007001 RID: 28673 RVA: 0x000D6520 File Offset: 0x000D4720
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002374 RID: 9076
		// (get) Token: 0x06007002 RID: 28674 RVA: 0x000D652C File Offset: 0x000D472C
		// (set) Token: 0x06007003 RID: 28675 RVA: 0x000D654D File Offset: 0x000D474D
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x17002375 RID: 9077
		// (get) Token: 0x06007004 RID: 28676 RVA: 0x000D6558 File Offset: 0x000D4758
		// (set) Token: 0x06007005 RID: 28677 RVA: 0x000D6574 File Offset: 0x000D4774
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06007006 RID: 28678 RVA: 0x000D65A4 File Offset: 0x000D47A4
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007007 RID: 28679 RVA: 0x000D65BC File Offset: 0x000D47BC
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002376 RID: 9078
		// (get) Token: 0x06007008 RID: 28680 RVA: 0x000D65C8 File Offset: 0x000D47C8
		// (set) Token: 0x06007009 RID: 28681 RVA: 0x000D65F4 File Offset: 0x000D47F4
		[ProtoMember(3, IsRequired = false, Name = "wintimes", DataFormat = DataFormat.TwosComplement)]
		public uint wintimes
		{
			get
			{
				return this._wintimes ?? 0U;
			}
			set
			{
				this._wintimes = new uint?(value);
			}
		}

		// Token: 0x17002377 RID: 9079
		// (get) Token: 0x0600700A RID: 28682 RVA: 0x000D6604 File Offset: 0x000D4804
		// (set) Token: 0x0600700B RID: 28683 RVA: 0x000D6624 File Offset: 0x000D4824
		[XmlIgnore]
		[Browsable(false)]
		public bool wintimesSpecified
		{
			get
			{
				return this._wintimes != null;
			}
			set
			{
				bool flag = value == (this._wintimes == null);
				if (flag)
				{
					this._wintimes = (value ? new uint?(this.wintimes) : null);
				}
			}
		}

		// Token: 0x0600700C RID: 28684 RVA: 0x000D6668 File Offset: 0x000D4868
		private bool ShouldSerializewintimes()
		{
			return this.wintimesSpecified;
		}

		// Token: 0x0600700D RID: 28685 RVA: 0x000D6680 File Offset: 0x000D4880
		private void Resetwintimes()
		{
			this.wintimesSpecified = false;
		}

		// Token: 0x17002378 RID: 9080
		// (get) Token: 0x0600700E RID: 28686 RVA: 0x000D668C File Offset: 0x000D488C
		// (set) Token: 0x0600700F RID: 28687 RVA: 0x000D66B8 File Offset: 0x000D48B8
		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x17002379 RID: 9081
		// (get) Token: 0x06007010 RID: 28688 RVA: 0x000D66C8 File Offset: 0x000D48C8
		// (set) Token: 0x06007011 RID: 28689 RVA: 0x000D66E8 File Offset: 0x000D48E8
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x06007012 RID: 28690 RVA: 0x000D672C File Offset: 0x000D492C
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x06007013 RID: 28691 RVA: 0x000D6744 File Offset: 0x000D4944
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x06007014 RID: 28692 RVA: 0x000D6750 File Offset: 0x000D4950
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AC4 RID: 6852
		private ulong? _guildid;

		// Token: 0x04001AC5 RID: 6853
		private string _guildname;

		// Token: 0x04001AC6 RID: 6854
		private uint? _wintimes;

		// Token: 0x04001AC7 RID: 6855
		private uint? _icon;

		// Token: 0x04001AC8 RID: 6856
		private IExtension extensionObject;
	}
}
