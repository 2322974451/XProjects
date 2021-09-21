using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C6 RID: 1478
	[ProtoContract(Name = "PkRoleRec")]
	[Serializable]
	public class PkRoleRec : IExtensible
	{
		// Token: 0x170019B0 RID: 6576
		// (get) Token: 0x06005304 RID: 21252 RVA: 0x0009DE78 File Offset: 0x0009C078
		// (set) Token: 0x06005305 RID: 21253 RVA: 0x0009DEA4 File Offset: 0x0009C0A4
		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x170019B1 RID: 6577
		// (get) Token: 0x06005306 RID: 21254 RVA: 0x0009DEB4 File Offset: 0x0009C0B4
		// (set) Token: 0x06005307 RID: 21255 RVA: 0x0009DED4 File Offset: 0x0009C0D4
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06005308 RID: 21256 RVA: 0x0009DF18 File Offset: 0x0009C118
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005309 RID: 21257 RVA: 0x0009DF30 File Offset: 0x0009C130
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x170019B2 RID: 6578
		// (get) Token: 0x0600530A RID: 21258 RVA: 0x0009DF3C File Offset: 0x0009C13C
		// (set) Token: 0x0600530B RID: 21259 RVA: 0x0009DF68 File Offset: 0x0009C168
		[ProtoMember(2, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		// Token: 0x170019B3 RID: 6579
		// (get) Token: 0x0600530C RID: 21260 RVA: 0x0009DF78 File Offset: 0x0009C178
		// (set) Token: 0x0600530D RID: 21261 RVA: 0x0009DF98 File Offset: 0x0009C198
		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		// Token: 0x0600530E RID: 21262 RVA: 0x0009DFDC File Offset: 0x0009C1DC
		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		// Token: 0x0600530F RID: 21263 RVA: 0x0009DFF4 File Offset: 0x0009C1F4
		private void Resetwin()
		{
			this.winSpecified = false;
		}

		// Token: 0x170019B4 RID: 6580
		// (get) Token: 0x06005310 RID: 21264 RVA: 0x0009E000 File Offset: 0x0009C200
		// (set) Token: 0x06005311 RID: 21265 RVA: 0x0009E02C File Offset: 0x0009C22C
		[ProtoMember(3, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		// Token: 0x170019B5 RID: 6581
		// (get) Token: 0x06005312 RID: 21266 RVA: 0x0009E03C File Offset: 0x0009C23C
		// (set) Token: 0x06005313 RID: 21267 RVA: 0x0009E05C File Offset: 0x0009C25C
		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		// Token: 0x06005314 RID: 21268 RVA: 0x0009E0A0 File Offset: 0x0009C2A0
		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		// Token: 0x06005315 RID: 21269 RVA: 0x0009E0B8 File Offset: 0x0009C2B8
		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		// Token: 0x170019B6 RID: 6582
		// (get) Token: 0x06005316 RID: 21270 RVA: 0x0009E0C4 File Offset: 0x0009C2C4
		// (set) Token: 0x06005317 RID: 21271 RVA: 0x0009E0F0 File Offset: 0x0009C2F0
		[ProtoMember(4, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		// Token: 0x170019B7 RID: 6583
		// (get) Token: 0x06005318 RID: 21272 RVA: 0x0009E100 File Offset: 0x0009C300
		// (set) Token: 0x06005319 RID: 21273 RVA: 0x0009E120 File Offset: 0x0009C320
		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		// Token: 0x0600531A RID: 21274 RVA: 0x0009E164 File Offset: 0x0009C364
		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		// Token: 0x0600531B RID: 21275 RVA: 0x0009E17C File Offset: 0x0009C37C
		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		// Token: 0x170019B8 RID: 6584
		// (get) Token: 0x0600531C RID: 21276 RVA: 0x0009E188 File Offset: 0x0009C388
		[ProtoMember(5, Name = "records", DataFormat = DataFormat.TwosComplement)]
		public List<uint> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x0600531D RID: 21277 RVA: 0x0009E1A0 File Offset: 0x0009C3A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400144C RID: 5196
		private uint? _point;

		// Token: 0x0400144D RID: 5197
		private uint? _win;

		// Token: 0x0400144E RID: 5198
		private uint? _lose;

		// Token: 0x0400144F RID: 5199
		private uint? _draw;

		// Token: 0x04001450 RID: 5200
		private readonly List<uint> _records = new List<uint>();

		// Token: 0x04001451 RID: 5201
		private IExtension extensionObject;
	}
}
