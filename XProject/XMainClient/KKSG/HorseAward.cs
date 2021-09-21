using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D7 RID: 1495
	[ProtoContract(Name = "HorseAward")]
	[Serializable]
	public class HorseAward : IExtensible
	{
		// Token: 0x17001A9A RID: 6810
		// (get) Token: 0x060055B8 RID: 21944 RVA: 0x000A32A4 File Offset: 0x000A14A4
		// (set) Token: 0x060055B9 RID: 21945 RVA: 0x000A32D0 File Offset: 0x000A14D0
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001A9B RID: 6811
		// (get) Token: 0x060055BA RID: 21946 RVA: 0x000A32E0 File Offset: 0x000A14E0
		// (set) Token: 0x060055BB RID: 21947 RVA: 0x000A3300 File Offset: 0x000A1500
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

		// Token: 0x060055BC RID: 21948 RVA: 0x000A3344 File Offset: 0x000A1544
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060055BD RID: 21949 RVA: 0x000A335C File Offset: 0x000A155C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17001A9C RID: 6812
		// (get) Token: 0x060055BE RID: 21950 RVA: 0x000A3368 File Offset: 0x000A1568
		// (set) Token: 0x060055BF RID: 21951 RVA: 0x000A3394 File Offset: 0x000A1594
		[ProtoMember(2, IsRequired = false, Name = "horse", DataFormat = DataFormat.TwosComplement)]
		public uint horse
		{
			get
			{
				return this._horse ?? 0U;
			}
			set
			{
				this._horse = new uint?(value);
			}
		}

		// Token: 0x17001A9D RID: 6813
		// (get) Token: 0x060055C0 RID: 21952 RVA: 0x000A33A4 File Offset: 0x000A15A4
		// (set) Token: 0x060055C1 RID: 21953 RVA: 0x000A33C4 File Offset: 0x000A15C4
		[XmlIgnore]
		[Browsable(false)]
		public bool horseSpecified
		{
			get
			{
				return this._horse != null;
			}
			set
			{
				bool flag = value == (this._horse == null);
				if (flag)
				{
					this._horse = (value ? new uint?(this.horse) : null);
				}
			}
		}

		// Token: 0x060055C2 RID: 21954 RVA: 0x000A3408 File Offset: 0x000A1608
		private bool ShouldSerializehorse()
		{
			return this.horseSpecified;
		}

		// Token: 0x060055C3 RID: 21955 RVA: 0x000A3420 File Offset: 0x000A1620
		private void Resethorse()
		{
			this.horseSpecified = false;
		}

		// Token: 0x17001A9E RID: 6814
		// (get) Token: 0x060055C4 RID: 21956 RVA: 0x000A342C File Offset: 0x000A162C
		// (set) Token: 0x060055C5 RID: 21957 RVA: 0x000A3458 File Offset: 0x000A1658
		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17001A9F RID: 6815
		// (get) Token: 0x060055C6 RID: 21958 RVA: 0x000A3468 File Offset: 0x000A1668
		// (set) Token: 0x060055C7 RID: 21959 RVA: 0x000A3488 File Offset: 0x000A1688
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x060055C8 RID: 21960 RVA: 0x000A34CC File Offset: 0x000A16CC
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060055C9 RID: 21961 RVA: 0x000A34E4 File Offset: 0x000A16E4
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x060055CA RID: 21962 RVA: 0x000A34F0 File Offset: 0x000A16F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014E2 RID: 5346
		private uint? _time;

		// Token: 0x040014E3 RID: 5347
		private uint? _horse;

		// Token: 0x040014E4 RID: 5348
		private uint? _rank;

		// Token: 0x040014E5 RID: 5349
		private IExtension extensionObject;
	}
}
