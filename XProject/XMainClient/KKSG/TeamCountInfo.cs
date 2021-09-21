using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065C RID: 1628
	[ProtoContract(Name = "TeamCountInfo")]
	[Serializable]
	public class TeamCountInfo : IExtensible
	{
		// Token: 0x17002019 RID: 8217
		// (get) Token: 0x060065B5 RID: 26037 RVA: 0x000C22F0 File Offset: 0x000C04F0
		// (set) Token: 0x060065B6 RID: 26038 RVA: 0x000C231C File Offset: 0x000C051C
		[ProtoMember(1, IsRequired = false, Name = "teamType", DataFormat = DataFormat.TwosComplement)]
		public int teamType
		{
			get
			{
				return this._teamType ?? 0;
			}
			set
			{
				this._teamType = new int?(value);
			}
		}

		// Token: 0x1700201A RID: 8218
		// (get) Token: 0x060065B7 RID: 26039 RVA: 0x000C232C File Offset: 0x000C052C
		// (set) Token: 0x060065B8 RID: 26040 RVA: 0x000C234C File Offset: 0x000C054C
		[XmlIgnore]
		[Browsable(false)]
		public bool teamTypeSpecified
		{
			get
			{
				return this._teamType != null;
			}
			set
			{
				bool flag = value == (this._teamType == null);
				if (flag)
				{
					this._teamType = (value ? new int?(this.teamType) : null);
				}
			}
		}

		// Token: 0x060065B9 RID: 26041 RVA: 0x000C2390 File Offset: 0x000C0590
		private bool ShouldSerializeteamType()
		{
			return this.teamTypeSpecified;
		}

		// Token: 0x060065BA RID: 26042 RVA: 0x000C23A8 File Offset: 0x000C05A8
		private void ResetteamType()
		{
			this.teamTypeSpecified = false;
		}

		// Token: 0x1700201B RID: 8219
		// (get) Token: 0x060065BB RID: 26043 RVA: 0x000C23B4 File Offset: 0x000C05B4
		// (set) Token: 0x060065BC RID: 26044 RVA: 0x000C23E0 File Offset: 0x000C05E0
		[ProtoMember(2, IsRequired = false, Name = "finishCountToday", DataFormat = DataFormat.TwosComplement)]
		public int finishCountToday
		{
			get
			{
				return this._finishCountToday ?? 0;
			}
			set
			{
				this._finishCountToday = new int?(value);
			}
		}

		// Token: 0x1700201C RID: 8220
		// (get) Token: 0x060065BD RID: 26045 RVA: 0x000C23F0 File Offset: 0x000C05F0
		// (set) Token: 0x060065BE RID: 26046 RVA: 0x000C2410 File Offset: 0x000C0610
		[XmlIgnore]
		[Browsable(false)]
		public bool finishCountTodaySpecified
		{
			get
			{
				return this._finishCountToday != null;
			}
			set
			{
				bool flag = value == (this._finishCountToday == null);
				if (flag)
				{
					this._finishCountToday = (value ? new int?(this.finishCountToday) : null);
				}
			}
		}

		// Token: 0x060065BF RID: 26047 RVA: 0x000C2454 File Offset: 0x000C0654
		private bool ShouldSerializefinishCountToday()
		{
			return this.finishCountTodaySpecified;
		}

		// Token: 0x060065C0 RID: 26048 RVA: 0x000C246C File Offset: 0x000C066C
		private void ResetfinishCountToday()
		{
			this.finishCountTodaySpecified = false;
		}

		// Token: 0x1700201D RID: 8221
		// (get) Token: 0x060065C1 RID: 26049 RVA: 0x000C2478 File Offset: 0x000C0678
		// (set) Token: 0x060065C2 RID: 26050 RVA: 0x000C24A4 File Offset: 0x000C06A4
		[ProtoMember(3, IsRequired = false, Name = "buyCountToday", DataFormat = DataFormat.TwosComplement)]
		public int buyCountToday
		{
			get
			{
				return this._buyCountToday ?? 0;
			}
			set
			{
				this._buyCountToday = new int?(value);
			}
		}

		// Token: 0x1700201E RID: 8222
		// (get) Token: 0x060065C3 RID: 26051 RVA: 0x000C24B4 File Offset: 0x000C06B4
		// (set) Token: 0x060065C4 RID: 26052 RVA: 0x000C24D4 File Offset: 0x000C06D4
		[XmlIgnore]
		[Browsable(false)]
		public bool buyCountTodaySpecified
		{
			get
			{
				return this._buyCountToday != null;
			}
			set
			{
				bool flag = value == (this._buyCountToday == null);
				if (flag)
				{
					this._buyCountToday = (value ? new int?(this.buyCountToday) : null);
				}
			}
		}

		// Token: 0x060065C5 RID: 26053 RVA: 0x000C2518 File Offset: 0x000C0718
		private bool ShouldSerializebuyCountToday()
		{
			return this.buyCountTodaySpecified;
		}

		// Token: 0x060065C6 RID: 26054 RVA: 0x000C2530 File Offset: 0x000C0730
		private void ResetbuyCountToday()
		{
			this.buyCountTodaySpecified = false;
		}

		// Token: 0x1700201F RID: 8223
		// (get) Token: 0x060065C7 RID: 26055 RVA: 0x000C253C File Offset: 0x000C073C
		// (set) Token: 0x060065C8 RID: 26056 RVA: 0x000C2568 File Offset: 0x000C0768
		[ProtoMember(4, IsRequired = false, Name = "extraAddCount", DataFormat = DataFormat.TwosComplement)]
		public int extraAddCount
		{
			get
			{
				return this._extraAddCount ?? 0;
			}
			set
			{
				this._extraAddCount = new int?(value);
			}
		}

		// Token: 0x17002020 RID: 8224
		// (get) Token: 0x060065C9 RID: 26057 RVA: 0x000C2578 File Offset: 0x000C0778
		// (set) Token: 0x060065CA RID: 26058 RVA: 0x000C2598 File Offset: 0x000C0798
		[XmlIgnore]
		[Browsable(false)]
		public bool extraAddCountSpecified
		{
			get
			{
				return this._extraAddCount != null;
			}
			set
			{
				bool flag = value == (this._extraAddCount == null);
				if (flag)
				{
					this._extraAddCount = (value ? new int?(this.extraAddCount) : null);
				}
			}
		}

		// Token: 0x060065CB RID: 26059 RVA: 0x000C25DC File Offset: 0x000C07DC
		private bool ShouldSerializeextraAddCount()
		{
			return this.extraAddCountSpecified;
		}

		// Token: 0x060065CC RID: 26060 RVA: 0x000C25F4 File Offset: 0x000C07F4
		private void ResetextraAddCount()
		{
			this.extraAddCountSpecified = false;
		}

		// Token: 0x17002021 RID: 8225
		// (get) Token: 0x060065CD RID: 26061 RVA: 0x000C2600 File Offset: 0x000C0800
		// (set) Token: 0x060065CE RID: 26062 RVA: 0x000C262C File Offset: 0x000C082C
		[ProtoMember(5, IsRequired = false, Name = "helpcount", DataFormat = DataFormat.TwosComplement)]
		public uint helpcount
		{
			get
			{
				return this._helpcount ?? 0U;
			}
			set
			{
				this._helpcount = new uint?(value);
			}
		}

		// Token: 0x17002022 RID: 8226
		// (get) Token: 0x060065CF RID: 26063 RVA: 0x000C263C File Offset: 0x000C083C
		// (set) Token: 0x060065D0 RID: 26064 RVA: 0x000C265C File Offset: 0x000C085C
		[XmlIgnore]
		[Browsable(false)]
		public bool helpcountSpecified
		{
			get
			{
				return this._helpcount != null;
			}
			set
			{
				bool flag = value == (this._helpcount == null);
				if (flag)
				{
					this._helpcount = (value ? new uint?(this.helpcount) : null);
				}
			}
		}

		// Token: 0x060065D1 RID: 26065 RVA: 0x000C26A0 File Offset: 0x000C08A0
		private bool ShouldSerializehelpcount()
		{
			return this.helpcountSpecified;
		}

		// Token: 0x060065D2 RID: 26066 RVA: 0x000C26B8 File Offset: 0x000C08B8
		private void Resethelpcount()
		{
			this.helpcountSpecified = false;
		}

		// Token: 0x060065D3 RID: 26067 RVA: 0x000C26C4 File Offset: 0x000C08C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018A3 RID: 6307
		private int? _teamType;

		// Token: 0x040018A4 RID: 6308
		private int? _finishCountToday;

		// Token: 0x040018A5 RID: 6309
		private int? _buyCountToday;

		// Token: 0x040018A6 RID: 6310
		private int? _extraAddCount;

		// Token: 0x040018A7 RID: 6311
		private uint? _helpcount;

		// Token: 0x040018A8 RID: 6312
		private IExtension extensionObject;
	}
}
