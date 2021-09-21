using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CE RID: 1742
	[ProtoContract(Name = "GuildMemberDonateRankItem")]
	[Serializable]
	public class GuildMemberDonateRankItem : IExtensible
	{
		// Token: 0x17002485 RID: 9349
		// (get) Token: 0x0600735C RID: 29532 RVA: 0x000DCB74 File Offset: 0x000DAD74
		// (set) Token: 0x0600735D RID: 29533 RVA: 0x000DCBA1 File Offset: 0x000DADA1
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

		// Token: 0x17002486 RID: 9350
		// (get) Token: 0x0600735E RID: 29534 RVA: 0x000DCBB0 File Offset: 0x000DADB0
		// (set) Token: 0x0600735F RID: 29535 RVA: 0x000DCBD0 File Offset: 0x000DADD0
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

		// Token: 0x06007360 RID: 29536 RVA: 0x000DCC14 File Offset: 0x000DAE14
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007361 RID: 29537 RVA: 0x000DCC2C File Offset: 0x000DAE2C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002487 RID: 9351
		// (get) Token: 0x06007362 RID: 29538 RVA: 0x000DCC38 File Offset: 0x000DAE38
		// (set) Token: 0x06007363 RID: 29539 RVA: 0x000DCC64 File Offset: 0x000DAE64
		[ProtoMember(2, IsRequired = false, Name = "todaycount", DataFormat = DataFormat.TwosComplement)]
		public uint todaycount
		{
			get
			{
				return this._todaycount ?? 0U;
			}
			set
			{
				this._todaycount = new uint?(value);
			}
		}

		// Token: 0x17002488 RID: 9352
		// (get) Token: 0x06007364 RID: 29540 RVA: 0x000DCC74 File Offset: 0x000DAE74
		// (set) Token: 0x06007365 RID: 29541 RVA: 0x000DCC94 File Offset: 0x000DAE94
		[XmlIgnore]
		[Browsable(false)]
		public bool todaycountSpecified
		{
			get
			{
				return this._todaycount != null;
			}
			set
			{
				bool flag = value == (this._todaycount == null);
				if (flag)
				{
					this._todaycount = (value ? new uint?(this.todaycount) : null);
				}
			}
		}

		// Token: 0x06007366 RID: 29542 RVA: 0x000DCCD8 File Offset: 0x000DAED8
		private bool ShouldSerializetodaycount()
		{
			return this.todaycountSpecified;
		}

		// Token: 0x06007367 RID: 29543 RVA: 0x000DCCF0 File Offset: 0x000DAEF0
		private void Resettodaycount()
		{
			this.todaycountSpecified = false;
		}

		// Token: 0x17002489 RID: 9353
		// (get) Token: 0x06007368 RID: 29544 RVA: 0x000DCCFC File Offset: 0x000DAEFC
		// (set) Token: 0x06007369 RID: 29545 RVA: 0x000DCD28 File Offset: 0x000DAF28
		[ProtoMember(3, IsRequired = false, Name = "totalcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalcount
		{
			get
			{
				return this._totalcount ?? 0U;
			}
			set
			{
				this._totalcount = new uint?(value);
			}
		}

		// Token: 0x1700248A RID: 9354
		// (get) Token: 0x0600736A RID: 29546 RVA: 0x000DCD38 File Offset: 0x000DAF38
		// (set) Token: 0x0600736B RID: 29547 RVA: 0x000DCD58 File Offset: 0x000DAF58
		[XmlIgnore]
		[Browsable(false)]
		public bool totalcountSpecified
		{
			get
			{
				return this._totalcount != null;
			}
			set
			{
				bool flag = value == (this._totalcount == null);
				if (flag)
				{
					this._totalcount = (value ? new uint?(this.totalcount) : null);
				}
			}
		}

		// Token: 0x0600736C RID: 29548 RVA: 0x000DCD9C File Offset: 0x000DAF9C
		private bool ShouldSerializetotalcount()
		{
			return this.totalcountSpecified;
		}

		// Token: 0x0600736D RID: 29549 RVA: 0x000DCDB4 File Offset: 0x000DAFB4
		private void Resettotalcount()
		{
			this.totalcountSpecified = false;
		}

		// Token: 0x1700248B RID: 9355
		// (get) Token: 0x0600736E RID: 29550 RVA: 0x000DCDC0 File Offset: 0x000DAFC0
		// (set) Token: 0x0600736F RID: 29551 RVA: 0x000DCDEC File Offset: 0x000DAFEC
		[ProtoMember(4, IsRequired = false, Name = "lasttime", DataFormat = DataFormat.TwosComplement)]
		public uint lasttime
		{
			get
			{
				return this._lasttime ?? 0U;
			}
			set
			{
				this._lasttime = new uint?(value);
			}
		}

		// Token: 0x1700248C RID: 9356
		// (get) Token: 0x06007370 RID: 29552 RVA: 0x000DCDFC File Offset: 0x000DAFFC
		// (set) Token: 0x06007371 RID: 29553 RVA: 0x000DCE1C File Offset: 0x000DB01C
		[XmlIgnore]
		[Browsable(false)]
		public bool lasttimeSpecified
		{
			get
			{
				return this._lasttime != null;
			}
			set
			{
				bool flag = value == (this._lasttime == null);
				if (flag)
				{
					this._lasttime = (value ? new uint?(this.lasttime) : null);
				}
			}
		}

		// Token: 0x06007372 RID: 29554 RVA: 0x000DCE60 File Offset: 0x000DB060
		private bool ShouldSerializelasttime()
		{
			return this.lasttimeSpecified;
		}

		// Token: 0x06007373 RID: 29555 RVA: 0x000DCE78 File Offset: 0x000DB078
		private void Resetlasttime()
		{
			this.lasttimeSpecified = false;
		}

		// Token: 0x1700248D RID: 9357
		// (get) Token: 0x06007374 RID: 29556 RVA: 0x000DCE84 File Offset: 0x000DB084
		// (set) Token: 0x06007375 RID: 29557 RVA: 0x000DCEA5 File Offset: 0x000DB0A5
		[ProtoMember(5, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700248E RID: 9358
		// (get) Token: 0x06007376 RID: 29558 RVA: 0x000DCEB0 File Offset: 0x000DB0B0
		// (set) Token: 0x06007377 RID: 29559 RVA: 0x000DCECC File Offset: 0x000DB0CC
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

		// Token: 0x06007378 RID: 29560 RVA: 0x000DCEFC File Offset: 0x000DB0FC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007379 RID: 29561 RVA: 0x000DCF14 File Offset: 0x000DB114
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700248F RID: 9359
		// (get) Token: 0x0600737A RID: 29562 RVA: 0x000DCF20 File Offset: 0x000DB120
		// (set) Token: 0x0600737B RID: 29563 RVA: 0x000DCF4C File Offset: 0x000DB14C
		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002490 RID: 9360
		// (get) Token: 0x0600737C RID: 29564 RVA: 0x000DCF5C File Offset: 0x000DB15C
		// (set) Token: 0x0600737D RID: 29565 RVA: 0x000DCF7C File Offset: 0x000DB17C
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

		// Token: 0x0600737E RID: 29566 RVA: 0x000DCFC0 File Offset: 0x000DB1C0
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600737F RID: 29567 RVA: 0x000DCFD8 File Offset: 0x000DB1D8
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002491 RID: 9361
		// (get) Token: 0x06007380 RID: 29568 RVA: 0x000DCFE4 File Offset: 0x000DB1E4
		// (set) Token: 0x06007381 RID: 29569 RVA: 0x000DD010 File Offset: 0x000DB210
		[ProtoMember(7, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002492 RID: 9362
		// (get) Token: 0x06007382 RID: 29570 RVA: 0x000DD020 File Offset: 0x000DB220
		// (set) Token: 0x06007383 RID: 29571 RVA: 0x000DD040 File Offset: 0x000DB240
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

		// Token: 0x06007384 RID: 29572 RVA: 0x000DD084 File Offset: 0x000DB284
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007385 RID: 29573 RVA: 0x000DD09C File Offset: 0x000DB29C
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x06007386 RID: 29574 RVA: 0x000DD0A8 File Offset: 0x000DB2A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B71 RID: 7025
		private ulong? _roleid;

		// Token: 0x04001B72 RID: 7026
		private uint? _todaycount;

		// Token: 0x04001B73 RID: 7027
		private uint? _totalcount;

		// Token: 0x04001B74 RID: 7028
		private uint? _lasttime;

		// Token: 0x04001B75 RID: 7029
		private string _name;

		// Token: 0x04001B76 RID: 7030
		private uint? _level;

		// Token: 0x04001B77 RID: 7031
		private uint? _profession;

		// Token: 0x04001B78 RID: 7032
		private IExtension extensionObject;
	}
}
