using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000725 RID: 1829
	[ProtoContract(Name = "WeddingRoleBrief")]
	[Serializable]
	public class WeddingRoleBrief : IExtensible
	{
		// Token: 0x170027F0 RID: 10224
		// (get) Token: 0x06007DF7 RID: 32247 RVA: 0x000F0E24 File Offset: 0x000EF024
		// (set) Token: 0x06007DF8 RID: 32248 RVA: 0x000F0E51 File Offset: 0x000EF051
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

		// Token: 0x170027F1 RID: 10225
		// (get) Token: 0x06007DF9 RID: 32249 RVA: 0x000F0E60 File Offset: 0x000EF060
		// (set) Token: 0x06007DFA RID: 32250 RVA: 0x000F0E80 File Offset: 0x000EF080
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

		// Token: 0x06007DFB RID: 32251 RVA: 0x000F0EC4 File Offset: 0x000EF0C4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007DFC RID: 32252 RVA: 0x000F0EDC File Offset: 0x000EF0DC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170027F2 RID: 10226
		// (get) Token: 0x06007DFD RID: 32253 RVA: 0x000F0EE8 File Offset: 0x000EF0E8
		// (set) Token: 0x06007DFE RID: 32254 RVA: 0x000F0F09 File Offset: 0x000EF109
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

		// Token: 0x170027F3 RID: 10227
		// (get) Token: 0x06007DFF RID: 32255 RVA: 0x000F0F14 File Offset: 0x000EF114
		// (set) Token: 0x06007E00 RID: 32256 RVA: 0x000F0F30 File Offset: 0x000EF130
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

		// Token: 0x06007E01 RID: 32257 RVA: 0x000F0F60 File Offset: 0x000EF160
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007E02 RID: 32258 RVA: 0x000F0F78 File Offset: 0x000EF178
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170027F4 RID: 10228
		// (get) Token: 0x06007E03 RID: 32259 RVA: 0x000F0F84 File Offset: 0x000EF184
		// (set) Token: 0x06007E04 RID: 32260 RVA: 0x000F0FB0 File Offset: 0x000EF1B0
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x170027F5 RID: 10229
		// (get) Token: 0x06007E05 RID: 32261 RVA: 0x000F0FC0 File Offset: 0x000EF1C0
		// (set) Token: 0x06007E06 RID: 32262 RVA: 0x000F0FE0 File Offset: 0x000EF1E0
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06007E07 RID: 32263 RVA: 0x000F1024 File Offset: 0x000EF224
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007E08 RID: 32264 RVA: 0x000F103C File Offset: 0x000EF23C
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170027F6 RID: 10230
		// (get) Token: 0x06007E09 RID: 32265 RVA: 0x000F1048 File Offset: 0x000EF248
		// (set) Token: 0x06007E0A RID: 32266 RVA: 0x000F1074 File Offset: 0x000EF274
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x170027F7 RID: 10231
		// (get) Token: 0x06007E0B RID: 32267 RVA: 0x000F1084 File Offset: 0x000EF284
		// (set) Token: 0x06007E0C RID: 32268 RVA: 0x000F10A4 File Offset: 0x000EF2A4
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06007E0D RID: 32269 RVA: 0x000F10E8 File Offset: 0x000EF2E8
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007E0E RID: 32270 RVA: 0x000F1100 File Offset: 0x000EF300
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170027F8 RID: 10232
		// (get) Token: 0x06007E0F RID: 32271 RVA: 0x000F110C File Offset: 0x000EF30C
		// (set) Token: 0x06007E10 RID: 32272 RVA: 0x000F1138 File Offset: 0x000EF338
		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x170027F9 RID: 10233
		// (get) Token: 0x06007E11 RID: 32273 RVA: 0x000F1148 File Offset: 0x000EF348
		// (set) Token: 0x06007E12 RID: 32274 RVA: 0x000F1168 File Offset: 0x000EF368
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06007E13 RID: 32275 RVA: 0x000F11AC File Offset: 0x000EF3AC
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06007E14 RID: 32276 RVA: 0x000F11C4 File Offset: 0x000EF3C4
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170027FA RID: 10234
		// (get) Token: 0x06007E15 RID: 32277 RVA: 0x000F11D0 File Offset: 0x000EF3D0
		// (set) Token: 0x06007E16 RID: 32278 RVA: 0x000F11F1 File Offset: 0x000EF3F1
		[ProtoMember(6, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
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

		// Token: 0x170027FB RID: 10235
		// (get) Token: 0x06007E17 RID: 32279 RVA: 0x000F11FC File Offset: 0x000EF3FC
		// (set) Token: 0x06007E18 RID: 32280 RVA: 0x000F1218 File Offset: 0x000EF418
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

		// Token: 0x06007E19 RID: 32281 RVA: 0x000F1248 File Offset: 0x000EF448
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007E1A RID: 32282 RVA: 0x000F1260 File Offset: 0x000EF460
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x06007E1B RID: 32283 RVA: 0x000F126C File Offset: 0x000EF46C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D9A RID: 7578
		private ulong? _roleid;

		// Token: 0x04001D9B RID: 7579
		private string _name;

		// Token: 0x04001D9C RID: 7580
		private uint? _profession;

		// Token: 0x04001D9D RID: 7581
		private uint? _level;

		// Token: 0x04001D9E RID: 7582
		private uint? _ppt;

		// Token: 0x04001D9F RID: 7583
		private string _guildname;

		// Token: 0x04001DA0 RID: 7584
		private IExtension extensionObject;
	}
}
