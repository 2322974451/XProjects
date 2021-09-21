using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C7 RID: 1735
	[ProtoContract(Name = "Integralunit")]
	[Serializable]
	public class Integralunit : IExtensible
	{
		// Token: 0x17002435 RID: 9269
		// (get) Token: 0x06007261 RID: 29281 RVA: 0x000DAD98 File Offset: 0x000D8F98
		// (set) Token: 0x06007262 RID: 29282 RVA: 0x000DADC5 File Offset: 0x000D8FC5
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

		// Token: 0x17002436 RID: 9270
		// (get) Token: 0x06007263 RID: 29283 RVA: 0x000DADD4 File Offset: 0x000D8FD4
		// (set) Token: 0x06007264 RID: 29284 RVA: 0x000DADF4 File Offset: 0x000D8FF4
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

		// Token: 0x06007265 RID: 29285 RVA: 0x000DAE38 File Offset: 0x000D9038
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06007266 RID: 29286 RVA: 0x000DAE50 File Offset: 0x000D9050
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002437 RID: 9271
		// (get) Token: 0x06007267 RID: 29287 RVA: 0x000DAE5C File Offset: 0x000D905C
		// (set) Token: 0x06007268 RID: 29288 RVA: 0x000DAE88 File Offset: 0x000D9088
		[ProtoMember(2, IsRequired = false, Name = "guildscore", DataFormat = DataFormat.TwosComplement)]
		public uint guildscore
		{
			get
			{
				return this._guildscore ?? 0U;
			}
			set
			{
				this._guildscore = new uint?(value);
			}
		}

		// Token: 0x17002438 RID: 9272
		// (get) Token: 0x06007269 RID: 29289 RVA: 0x000DAE98 File Offset: 0x000D9098
		// (set) Token: 0x0600726A RID: 29290 RVA: 0x000DAEB8 File Offset: 0x000D90B8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildscoreSpecified
		{
			get
			{
				return this._guildscore != null;
			}
			set
			{
				bool flag = value == (this._guildscore == null);
				if (flag)
				{
					this._guildscore = (value ? new uint?(this.guildscore) : null);
				}
			}
		}

		// Token: 0x0600726B RID: 29291 RVA: 0x000DAEFC File Offset: 0x000D90FC
		private bool ShouldSerializeguildscore()
		{
			return this.guildscoreSpecified;
		}

		// Token: 0x0600726C RID: 29292 RVA: 0x000DAF14 File Offset: 0x000D9114
		private void Resetguildscore()
		{
			this.guildscoreSpecified = false;
		}

		// Token: 0x17002439 RID: 9273
		// (get) Token: 0x0600726D RID: 29293 RVA: 0x000DAF20 File Offset: 0x000D9120
		// (set) Token: 0x0600726E RID: 29294 RVA: 0x000DAF41 File Offset: 0x000D9141
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700243A RID: 9274
		// (get) Token: 0x0600726F RID: 29295 RVA: 0x000DAF4C File Offset: 0x000D914C
		// (set) Token: 0x06007270 RID: 29296 RVA: 0x000DAF68 File Offset: 0x000D9168
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

		// Token: 0x06007271 RID: 29297 RVA: 0x000DAF98 File Offset: 0x000D9198
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007272 RID: 29298 RVA: 0x000DAFB0 File Offset: 0x000D91B0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700243B RID: 9275
		// (get) Token: 0x06007273 RID: 29299 RVA: 0x000DAFBC File Offset: 0x000D91BC
		// (set) Token: 0x06007274 RID: 29300 RVA: 0x000DAFE8 File Offset: 0x000D91E8
		[ProtoMember(4, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700243C RID: 9276
		// (get) Token: 0x06007275 RID: 29301 RVA: 0x000DAFF8 File Offset: 0x000D91F8
		// (set) Token: 0x06007276 RID: 29302 RVA: 0x000DB018 File Offset: 0x000D9218
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

		// Token: 0x06007277 RID: 29303 RVA: 0x000DB05C File Offset: 0x000D925C
		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		// Token: 0x06007278 RID: 29304 RVA: 0x000DB074 File Offset: 0x000D9274
		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		// Token: 0x06007279 RID: 29305 RVA: 0x000DB080 File Offset: 0x000D9280
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B41 RID: 6977
		private ulong? _guildid;

		// Token: 0x04001B42 RID: 6978
		private uint? _guildscore;

		// Token: 0x04001B43 RID: 6979
		private string _name;

		// Token: 0x04001B44 RID: 6980
		private uint? _guildicon;

		// Token: 0x04001B45 RID: 6981
		private IExtension extensionObject;
	}
}
