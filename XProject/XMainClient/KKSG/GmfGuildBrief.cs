using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000695 RID: 1685
	[ProtoContract(Name = "GmfGuildBrief")]
	[Serializable]
	public class GmfGuildBrief : IExtensible
	{
		// Token: 0x17002291 RID: 8849
		// (get) Token: 0x06006D38 RID: 27960 RVA: 0x000D0F9C File Offset: 0x000CF19C
		// (set) Token: 0x06006D39 RID: 27961 RVA: 0x000D0FC9 File Offset: 0x000CF1C9
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

		// Token: 0x17002292 RID: 8850
		// (get) Token: 0x06006D3A RID: 27962 RVA: 0x000D0FD8 File Offset: 0x000CF1D8
		// (set) Token: 0x06006D3B RID: 27963 RVA: 0x000D0FF8 File Offset: 0x000CF1F8
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

		// Token: 0x06006D3C RID: 27964 RVA: 0x000D103C File Offset: 0x000CF23C
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06006D3D RID: 27965 RVA: 0x000D1054 File Offset: 0x000CF254
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002293 RID: 8851
		// (get) Token: 0x06006D3E RID: 27966 RVA: 0x000D1060 File Offset: 0x000CF260
		// (set) Token: 0x06006D3F RID: 27967 RVA: 0x000D1081 File Offset: 0x000CF281
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

		// Token: 0x17002294 RID: 8852
		// (get) Token: 0x06006D40 RID: 27968 RVA: 0x000D108C File Offset: 0x000CF28C
		// (set) Token: 0x06006D41 RID: 27969 RVA: 0x000D10A8 File Offset: 0x000CF2A8
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

		// Token: 0x06006D42 RID: 27970 RVA: 0x000D10D8 File Offset: 0x000CF2D8
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06006D43 RID: 27971 RVA: 0x000D10F0 File Offset: 0x000CF2F0
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002295 RID: 8853
		// (get) Token: 0x06006D44 RID: 27972 RVA: 0x000D10FC File Offset: 0x000CF2FC
		// (set) Token: 0x06006D45 RID: 27973 RVA: 0x000D1128 File Offset: 0x000CF328
		[ProtoMember(3, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		// Token: 0x17002296 RID: 8854
		// (get) Token: 0x06006D46 RID: 27974 RVA: 0x000D1138 File Offset: 0x000CF338
		// (set) Token: 0x06006D47 RID: 27975 RVA: 0x000D1158 File Offset: 0x000CF358
		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		// Token: 0x06006D48 RID: 27976 RVA: 0x000D119C File Offset: 0x000CF39C
		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		// Token: 0x06006D49 RID: 27977 RVA: 0x000D11B4 File Offset: 0x000CF3B4
		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		// Token: 0x17002297 RID: 8855
		// (get) Token: 0x06006D4A RID: 27978 RVA: 0x000D11C0 File Offset: 0x000CF3C0
		// (set) Token: 0x06006D4B RID: 27979 RVA: 0x000D11EC File Offset: 0x000CF3EC
		[ProtoMember(4, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002298 RID: 8856
		// (get) Token: 0x06006D4C RID: 27980 RVA: 0x000D11FC File Offset: 0x000CF3FC
		// (set) Token: 0x06006D4D RID: 27981 RVA: 0x000D121C File Offset: 0x000CF41C
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

		// Token: 0x06006D4E RID: 27982 RVA: 0x000D1260 File Offset: 0x000CF460
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06006D4F RID: 27983 RVA: 0x000D1278 File Offset: 0x000CF478
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x06006D50 RID: 27984 RVA: 0x000D1284 File Offset: 0x000CF484
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A30 RID: 6704
		private ulong? _guildid;

		// Token: 0x04001A31 RID: 6705
		private string _guildname;

		// Token: 0x04001A32 RID: 6706
		private uint? _guildicon;

		// Token: 0x04001A33 RID: 6707
		private uint? _serverid;

		// Token: 0x04001A34 RID: 6708
		private IExtension extensionObject;
	}
}
