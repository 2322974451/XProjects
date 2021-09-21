using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C1 RID: 1473
	[ProtoContract(Name = "BattleFailedData")]
	[Serializable]
	public class BattleFailedData : IExtensible
	{
		// Token: 0x17001993 RID: 6547
		// (get) Token: 0x060052A6 RID: 21158 RVA: 0x0009D360 File Offset: 0x0009B560
		// (set) Token: 0x060052A7 RID: 21159 RVA: 0x0009D38C File Offset: 0x0009B58C
		[ProtoMember(1, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public uint timespan
		{
			get
			{
				return this._timespan ?? 0U;
			}
			set
			{
				this._timespan = new uint?(value);
			}
		}

		// Token: 0x17001994 RID: 6548
		// (get) Token: 0x060052A8 RID: 21160 RVA: 0x0009D39C File Offset: 0x0009B59C
		// (set) Token: 0x060052A9 RID: 21161 RVA: 0x0009D3BC File Offset: 0x0009B5BC
		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new uint?(this.timespan) : null);
				}
			}
		}

		// Token: 0x060052AA RID: 21162 RVA: 0x0009D400 File Offset: 0x0009B600
		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		// Token: 0x060052AB RID: 21163 RVA: 0x0009D418 File Offset: 0x0009B618
		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		// Token: 0x17001995 RID: 6549
		// (get) Token: 0x060052AC RID: 21164 RVA: 0x0009D424 File Offset: 0x0009B624
		// (set) Token: 0x060052AD RID: 21165 RVA: 0x0009D450 File Offset: 0x0009B650
		[ProtoMember(2, IsRequired = false, Name = "hppercent", DataFormat = DataFormat.TwosComplement)]
		public uint hppercent
		{
			get
			{
				return this._hppercent ?? 0U;
			}
			set
			{
				this._hppercent = new uint?(value);
			}
		}

		// Token: 0x17001996 RID: 6550
		// (get) Token: 0x060052AE RID: 21166 RVA: 0x0009D460 File Offset: 0x0009B660
		// (set) Token: 0x060052AF RID: 21167 RVA: 0x0009D480 File Offset: 0x0009B680
		[XmlIgnore]
		[Browsable(false)]
		public bool hppercentSpecified
		{
			get
			{
				return this._hppercent != null;
			}
			set
			{
				bool flag = value == (this._hppercent == null);
				if (flag)
				{
					this._hppercent = (value ? new uint?(this.hppercent) : null);
				}
			}
		}

		// Token: 0x060052B0 RID: 21168 RVA: 0x0009D4C4 File Offset: 0x0009B6C4
		private bool ShouldSerializehppercent()
		{
			return this.hppercentSpecified;
		}

		// Token: 0x060052B1 RID: 21169 RVA: 0x0009D4DC File Offset: 0x0009B6DC
		private void Resethppercent()
		{
			this.hppercentSpecified = false;
		}

		// Token: 0x17001997 RID: 6551
		// (get) Token: 0x060052B2 RID: 21170 RVA: 0x0009D4E8 File Offset: 0x0009B6E8
		// (set) Token: 0x060052B3 RID: 21171 RVA: 0x0009D514 File Offset: 0x0009B714
		[ProtoMember(3, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		// Token: 0x17001998 RID: 6552
		// (get) Token: 0x060052B4 RID: 21172 RVA: 0x0009D524 File Offset: 0x0009B724
		// (set) Token: 0x060052B5 RID: 21173 RVA: 0x0009D544 File Offset: 0x0009B744
		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		// Token: 0x060052B6 RID: 21174 RVA: 0x0009D588 File Offset: 0x0009B788
		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		// Token: 0x060052B7 RID: 21175 RVA: 0x0009D5A0 File Offset: 0x0009B7A0
		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		// Token: 0x060052B8 RID: 21176 RVA: 0x0009D5AC File Offset: 0x0009B7AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001437 RID: 5175
		private uint? _timespan;

		// Token: 0x04001438 RID: 5176
		private uint? _hppercent;

		// Token: 0x04001439 RID: 5177
		private uint? _deathcount;

		// Token: 0x0400143A RID: 5178
		private IExtension extensionObject;
	}
}
