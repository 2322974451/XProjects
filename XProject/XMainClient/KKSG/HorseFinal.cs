using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000304 RID: 772
	[ProtoContract(Name = "HorseFinal")]
	[Serializable]
	public class HorseFinal : IExtensible
	{
		// Token: 0x17000D13 RID: 3347
		// (get) Token: 0x06002A30 RID: 10800 RVA: 0x00051C84 File Offset: 0x0004FE84
		// (set) Token: 0x06002A31 RID: 10801 RVA: 0x00051CB0 File Offset: 0x0004FEB0
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

		// Token: 0x17000D14 RID: 3348
		// (get) Token: 0x06002A32 RID: 10802 RVA: 0x00051CC0 File Offset: 0x0004FEC0
		// (set) Token: 0x06002A33 RID: 10803 RVA: 0x00051CE0 File Offset: 0x0004FEE0
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

		// Token: 0x06002A34 RID: 10804 RVA: 0x00051D24 File Offset: 0x0004FF24
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06002A35 RID: 10805 RVA: 0x00051D3C File Offset: 0x0004FF3C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17000D15 RID: 3349
		// (get) Token: 0x06002A36 RID: 10806 RVA: 0x00051D48 File Offset: 0x0004FF48
		// (set) Token: 0x06002A37 RID: 10807 RVA: 0x00051D74 File Offset: 0x0004FF74
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000D16 RID: 3350
		// (get) Token: 0x06002A38 RID: 10808 RVA: 0x00051D84 File Offset: 0x0004FF84
		// (set) Token: 0x06002A39 RID: 10809 RVA: 0x00051DA4 File Offset: 0x0004FFA4
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

		// Token: 0x06002A3A RID: 10810 RVA: 0x00051DE8 File Offset: 0x0004FFE8
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06002A3B RID: 10811 RVA: 0x00051E00 File Offset: 0x00050000
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000D17 RID: 3351
		// (get) Token: 0x06002A3C RID: 10812 RVA: 0x00051E0C File Offset: 0x0005000C
		// (set) Token: 0x06002A3D RID: 10813 RVA: 0x00051E38 File Offset: 0x00050038
		[ProtoMember(3, IsRequired = false, Name = "turns", DataFormat = DataFormat.TwosComplement)]
		public uint turns
		{
			get
			{
				return this._turns ?? 0U;
			}
			set
			{
				this._turns = new uint?(value);
			}
		}

		// Token: 0x17000D18 RID: 3352
		// (get) Token: 0x06002A3E RID: 10814 RVA: 0x00051E48 File Offset: 0x00050048
		// (set) Token: 0x06002A3F RID: 10815 RVA: 0x00051E68 File Offset: 0x00050068
		[XmlIgnore]
		[Browsable(false)]
		public bool turnsSpecified
		{
			get
			{
				return this._turns != null;
			}
			set
			{
				bool flag = value == (this._turns == null);
				if (flag)
				{
					this._turns = (value ? new uint?(this.turns) : null);
				}
			}
		}

		// Token: 0x06002A40 RID: 10816 RVA: 0x00051EAC File Offset: 0x000500AC
		private bool ShouldSerializeturns()
		{
			return this.turnsSpecified;
		}

		// Token: 0x06002A41 RID: 10817 RVA: 0x00051EC4 File Offset: 0x000500C4
		private void Resetturns()
		{
			this.turnsSpecified = false;
		}

		// Token: 0x06002A42 RID: 10818 RVA: 0x00051ED0 File Offset: 0x000500D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A7B RID: 2683
		private uint? _time;

		// Token: 0x04000A7C RID: 2684
		private uint? _rank;

		// Token: 0x04000A7D RID: 2685
		private uint? _turns;

		// Token: 0x04000A7E RID: 2686
		private IExtension extensionObject;
	}
}
