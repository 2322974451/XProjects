using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E5 RID: 1765
	[ProtoContract(Name = "CityData")]
	[Serializable]
	public class CityData : IExtensible
	{
		// Token: 0x17002553 RID: 9555
		// (get) Token: 0x060075E2 RID: 30178 RVA: 0x000E18B0 File Offset: 0x000DFAB0
		// (set) Token: 0x060075E3 RID: 30179 RVA: 0x000E18DC File Offset: 0x000DFADC
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17002554 RID: 9556
		// (get) Token: 0x060075E4 RID: 30180 RVA: 0x000E18EC File Offset: 0x000DFAEC
		// (set) Token: 0x060075E5 RID: 30181 RVA: 0x000E190C File Offset: 0x000DFB0C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060075E6 RID: 30182 RVA: 0x000E1950 File Offset: 0x000DFB50
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060075E7 RID: 30183 RVA: 0x000E1968 File Offset: 0x000DFB68
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002555 RID: 9557
		// (get) Token: 0x060075E8 RID: 30184 RVA: 0x000E1974 File Offset: 0x000DFB74
		// (set) Token: 0x060075E9 RID: 30185 RVA: 0x000E19A1 File Offset: 0x000DFBA1
		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002556 RID: 9558
		// (get) Token: 0x060075EA RID: 30186 RVA: 0x000E19B0 File Offset: 0x000DFBB0
		// (set) Token: 0x060075EB RID: 30187 RVA: 0x000E19D0 File Offset: 0x000DFBD0
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

		// Token: 0x060075EC RID: 30188 RVA: 0x000E1A14 File Offset: 0x000DFC14
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x060075ED RID: 30189 RVA: 0x000E1A2C File Offset: 0x000DFC2C
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17002557 RID: 9559
		// (get) Token: 0x060075EE RID: 30190 RVA: 0x000E1A38 File Offset: 0x000DFC38
		// (set) Token: 0x060075EF RID: 30191 RVA: 0x000E1A59 File Offset: 0x000DFC59
		[ProtoMember(3, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002558 RID: 9560
		// (get) Token: 0x060075F0 RID: 30192 RVA: 0x000E1A64 File Offset: 0x000DFC64
		// (set) Token: 0x060075F1 RID: 30193 RVA: 0x000E1A80 File Offset: 0x000DFC80
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

		// Token: 0x060075F2 RID: 30194 RVA: 0x000E1AB0 File Offset: 0x000DFCB0
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x060075F3 RID: 30195 RVA: 0x000E1AC8 File Offset: 0x000DFCC8
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002559 RID: 9561
		// (get) Token: 0x060075F4 RID: 30196 RVA: 0x000E1AD4 File Offset: 0x000DFCD4
		// (set) Token: 0x060075F5 RID: 30197 RVA: 0x000E1B00 File Offset: 0x000DFD00
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x1700255A RID: 9562
		// (get) Token: 0x060075F6 RID: 30198 RVA: 0x000E1B10 File Offset: 0x000DFD10
		// (set) Token: 0x060075F7 RID: 30199 RVA: 0x000E1B30 File Offset: 0x000DFD30
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x060075F8 RID: 30200 RVA: 0x000E1B74 File Offset: 0x000DFD74
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060075F9 RID: 30201 RVA: 0x000E1B8C File Offset: 0x000DFD8C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700255B RID: 9563
		// (get) Token: 0x060075FA RID: 30202 RVA: 0x000E1B98 File Offset: 0x000DFD98
		// (set) Token: 0x060075FB RID: 30203 RVA: 0x000E1BC4 File Offset: 0x000DFDC4
		[ProtoMember(5, IsRequired = false, Name = "isGetToday", DataFormat = DataFormat.Default)]
		public bool isGetToday
		{
			get
			{
				return this._isGetToday ?? false;
			}
			set
			{
				this._isGetToday = new bool?(value);
			}
		}

		// Token: 0x1700255C RID: 9564
		// (get) Token: 0x060075FC RID: 30204 RVA: 0x000E1BD4 File Offset: 0x000DFDD4
		// (set) Token: 0x060075FD RID: 30205 RVA: 0x000E1BF4 File Offset: 0x000DFDF4
		[XmlIgnore]
		[Browsable(false)]
		public bool isGetTodaySpecified
		{
			get
			{
				return this._isGetToday != null;
			}
			set
			{
				bool flag = value == (this._isGetToday == null);
				if (flag)
				{
					this._isGetToday = (value ? new bool?(this.isGetToday) : null);
				}
			}
		}

		// Token: 0x060075FE RID: 30206 RVA: 0x000E1C38 File Offset: 0x000DFE38
		private bool ShouldSerializeisGetToday()
		{
			return this.isGetTodaySpecified;
		}

		// Token: 0x060075FF RID: 30207 RVA: 0x000E1C50 File Offset: 0x000DFE50
		private void ResetisGetToday()
		{
			this.isGetTodaySpecified = false;
		}

		// Token: 0x1700255D RID: 9565
		// (get) Token: 0x06007600 RID: 30208 RVA: 0x000E1C5C File Offset: 0x000DFE5C
		// (set) Token: 0x06007601 RID: 30209 RVA: 0x000E1C88 File Offset: 0x000DFE88
		[ProtoMember(6, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GUILDTERRTYPE type
		{
			get
			{
				return this._type ?? GUILDTERRTYPE.TERR_NOT_OPEN;
			}
			set
			{
				this._type = new GUILDTERRTYPE?(value);
			}
		}

		// Token: 0x1700255E RID: 9566
		// (get) Token: 0x06007602 RID: 30210 RVA: 0x000E1C98 File Offset: 0x000DFE98
		// (set) Token: 0x06007603 RID: 30211 RVA: 0x000E1CB8 File Offset: 0x000DFEB8
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new GUILDTERRTYPE?(this.type) : null);
				}
			}
		}

		// Token: 0x06007604 RID: 30212 RVA: 0x000E1CFC File Offset: 0x000DFEFC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007605 RID: 30213 RVA: 0x000E1D14 File Offset: 0x000DFF14
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06007606 RID: 30214 RVA: 0x000E1D20 File Offset: 0x000DFF20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BF5 RID: 7157
		private uint? _id;

		// Token: 0x04001BF6 RID: 7158
		private ulong? _guildid;

		// Token: 0x04001BF7 RID: 7159
		private string _guildname;

		// Token: 0x04001BF8 RID: 7160
		private uint? _time;

		// Token: 0x04001BF9 RID: 7161
		private bool? _isGetToday;

		// Token: 0x04001BFA RID: 7162
		private GUILDTERRTYPE? _type;

		// Token: 0x04001BFB RID: 7163
		private IExtension extensionObject;
	}
}
