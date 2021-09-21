using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B0 RID: 1712
	[ProtoContract(Name = "GuildLadderRoleRank")]
	[Serializable]
	public class GuildLadderRoleRank : IExtensible
	{
		// Token: 0x1700236A RID: 9066
		// (get) Token: 0x06006FE2 RID: 28642 RVA: 0x000D6160 File Offset: 0x000D4360
		// (set) Token: 0x06006FE3 RID: 28643 RVA: 0x000D618D File Offset: 0x000D438D
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700236B RID: 9067
		// (get) Token: 0x06006FE4 RID: 28644 RVA: 0x000D619C File Offset: 0x000D439C
		// (set) Token: 0x06006FE5 RID: 28645 RVA: 0x000D61BC File Offset: 0x000D43BC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06006FE6 RID: 28646 RVA: 0x000D6200 File Offset: 0x000D4400
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06006FE7 RID: 28647 RVA: 0x000D6218 File Offset: 0x000D4418
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700236C RID: 9068
		// (get) Token: 0x06006FE8 RID: 28648 RVA: 0x000D6224 File Offset: 0x000D4424
		// (set) Token: 0x06006FE9 RID: 28649 RVA: 0x000D6245 File Offset: 0x000D4445
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

		// Token: 0x1700236D RID: 9069
		// (get) Token: 0x06006FEA RID: 28650 RVA: 0x000D6250 File Offset: 0x000D4450
		// (set) Token: 0x06006FEB RID: 28651 RVA: 0x000D626C File Offset: 0x000D446C
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

		// Token: 0x06006FEC RID: 28652 RVA: 0x000D629C File Offset: 0x000D449C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006FED RID: 28653 RVA: 0x000D62B4 File Offset: 0x000D44B4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700236E RID: 9070
		// (get) Token: 0x06006FEE RID: 28654 RVA: 0x000D62C0 File Offset: 0x000D44C0
		// (set) Token: 0x06006FEF RID: 28655 RVA: 0x000D62EC File Offset: 0x000D44EC
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

		// Token: 0x1700236F RID: 9071
		// (get) Token: 0x06006FF0 RID: 28656 RVA: 0x000D62FC File Offset: 0x000D44FC
		// (set) Token: 0x06006FF1 RID: 28657 RVA: 0x000D631C File Offset: 0x000D451C
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

		// Token: 0x06006FF2 RID: 28658 RVA: 0x000D6360 File Offset: 0x000D4560
		private bool ShouldSerializewintimes()
		{
			return this.wintimesSpecified;
		}

		// Token: 0x06006FF3 RID: 28659 RVA: 0x000D6378 File Offset: 0x000D4578
		private void Resetwintimes()
		{
			this.wintimesSpecified = false;
		}

		// Token: 0x17002370 RID: 9072
		// (get) Token: 0x06006FF4 RID: 28660 RVA: 0x000D6384 File Offset: 0x000D4584
		// (set) Token: 0x06006FF5 RID: 28661 RVA: 0x000D63B1 File Offset: 0x000D45B1
		[ProtoMember(4, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002371 RID: 9073
		// (get) Token: 0x06006FF6 RID: 28662 RVA: 0x000D63C0 File Offset: 0x000D45C0
		// (set) Token: 0x06006FF7 RID: 28663 RVA: 0x000D63E0 File Offset: 0x000D45E0
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

		// Token: 0x06006FF8 RID: 28664 RVA: 0x000D6424 File Offset: 0x000D4624
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06006FF9 RID: 28665 RVA: 0x000D643C File Offset: 0x000D463C
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x06006FFA RID: 28666 RVA: 0x000D6448 File Offset: 0x000D4648
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001ABF RID: 6847
		private ulong? _roleid;

		// Token: 0x04001AC0 RID: 6848
		private string _name;

		// Token: 0x04001AC1 RID: 6849
		private uint? _wintimes;

		// Token: 0x04001AC2 RID: 6850
		private ulong? _guildid;

		// Token: 0x04001AC3 RID: 6851
		private IExtension extensionObject;
	}
}
