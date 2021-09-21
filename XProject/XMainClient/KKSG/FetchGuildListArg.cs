using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000084 RID: 132
	[ProtoContract(Name = "FetchGuildListArg")]
	[Serializable]
	public class FetchGuildListArg : IExtensible
	{
		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000131A0 File Offset: 0x000113A0
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x000131CC File Offset: 0x000113CC
		[ProtoMember(1, IsRequired = false, Name = "start", DataFormat = DataFormat.TwosComplement)]
		public int start
		{
			get
			{
				return this._start ?? 0;
			}
			set
			{
				this._start = new int?(value);
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x000131DC File Offset: 0x000113DC
		// (set) Token: 0x060008AA RID: 2218 RVA: 0x000131FC File Offset: 0x000113FC
		[XmlIgnore]
		[Browsable(false)]
		public bool startSpecified
		{
			get
			{
				return this._start != null;
			}
			set
			{
				bool flag = value == (this._start == null);
				if (flag)
				{
					this._start = (value ? new int?(this.start) : null);
				}
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00013240 File Offset: 0x00011440
		private bool ShouldSerializestart()
		{
			return this.startSpecified;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00013258 File Offset: 0x00011458
		private void Resetstart()
		{
			this.startSpecified = false;
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x00013264 File Offset: 0x00011464
		// (set) Token: 0x060008AE RID: 2222 RVA: 0x00013290 File Offset: 0x00011490
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x000132A0 File Offset: 0x000114A0
		// (set) Token: 0x060008B0 RID: 2224 RVA: 0x000132C0 File Offset: 0x000114C0
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x00013304 File Offset: 0x00011504
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0001331C File Offset: 0x0001151C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x00013328 File Offset: 0x00011528
		// (set) Token: 0x060008B4 RID: 2228 RVA: 0x00013354 File Offset: 0x00011554
		[ProtoMember(3, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public int reason
		{
			get
			{
				return this._reason ?? 0;
			}
			set
			{
				this._reason = new int?(value);
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00013364 File Offset: 0x00011564
		// (set) Token: 0x060008B6 RID: 2230 RVA: 0x00013384 File Offset: 0x00011584
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new int?(this.reason) : null);
				}
			}
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x000133C8 File Offset: 0x000115C8
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x000133E0 File Offset: 0x000115E0
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x000133EC File Offset: 0x000115EC
		// (set) Token: 0x060008BA RID: 2234 RVA: 0x00013418 File Offset: 0x00011618
		[ProtoMember(4, IsRequired = false, Name = "sortType", DataFormat = DataFormat.TwosComplement)]
		public int sortType
		{
			get
			{
				return this._sortType ?? 0;
			}
			set
			{
				this._sortType = new int?(value);
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x00013428 File Offset: 0x00011628
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x00013448 File Offset: 0x00011648
		[XmlIgnore]
		[Browsable(false)]
		public bool sortTypeSpecified
		{
			get
			{
				return this._sortType != null;
			}
			set
			{
				bool flag = value == (this._sortType == null);
				if (flag)
				{
					this._sortType = (value ? new int?(this.sortType) : null);
				}
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0001348C File Offset: 0x0001168C
		private bool ShouldSerializesortType()
		{
			return this.sortTypeSpecified;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x000134A4 File Offset: 0x000116A4
		private void ResetsortType()
		{
			this.sortTypeSpecified = false;
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x000134B0 File Offset: 0x000116B0
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x000134DC File Offset: 0x000116DC
		[ProtoMember(5, IsRequired = false, Name = "reverse", DataFormat = DataFormat.Default)]
		public bool reverse
		{
			get
			{
				return this._reverse ?? false;
			}
			set
			{
				this._reverse = new bool?(value);
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x000134EC File Offset: 0x000116EC
		// (set) Token: 0x060008C2 RID: 2242 RVA: 0x0001350C File Offset: 0x0001170C
		[XmlIgnore]
		[Browsable(false)]
		public bool reverseSpecified
		{
			get
			{
				return this._reverse != null;
			}
			set
			{
				bool flag = value == (this._reverse == null);
				if (flag)
				{
					this._reverse = (value ? new bool?(this.reverse) : null);
				}
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00013550 File Offset: 0x00011750
		private bool ShouldSerializereverse()
		{
			return this.reverseSpecified;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00013568 File Offset: 0x00011768
		private void Resetreverse()
		{
			this.reverseSpecified = false;
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x00013574 File Offset: 0x00011774
		// (set) Token: 0x060008C6 RID: 2246 RVA: 0x00013595 File Offset: 0x00011795
		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x000135A0 File Offset: 0x000117A0
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x000135BC File Offset: 0x000117BC
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

		// Token: 0x060008C9 RID: 2249 RVA: 0x000135EC File Offset: 0x000117EC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00013604 File Offset: 0x00011804
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00013610 File Offset: 0x00011810
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400023E RID: 574
		private int? _start;

		// Token: 0x0400023F RID: 575
		private int? _count;

		// Token: 0x04000240 RID: 576
		private int? _reason;

		// Token: 0x04000241 RID: 577
		private int? _sortType;

		// Token: 0x04000242 RID: 578
		private bool? _reverse;

		// Token: 0x04000243 RID: 579
		private string _name;

		// Token: 0x04000244 RID: 580
		private IExtension extensionObject;
	}
}
