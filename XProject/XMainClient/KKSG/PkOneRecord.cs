using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000603 RID: 1539
	[ProtoContract(Name = "PkOneRecord")]
	[Serializable]
	public class PkOneRecord : IExtensible
	{
		// Token: 0x17001CFD RID: 7421
		// (get) Token: 0x06005C81 RID: 23681 RVA: 0x000B03F4 File Offset: 0x000AE5F4
		// (set) Token: 0x06005C82 RID: 23682 RVA: 0x000B0421 File Offset: 0x000AE621
		[ProtoMember(1, IsRequired = false, Name = "opposer", DataFormat = DataFormat.TwosComplement)]
		public ulong opposer
		{
			get
			{
				return this._opposer ?? 0UL;
			}
			set
			{
				this._opposer = new ulong?(value);
			}
		}

		// Token: 0x17001CFE RID: 7422
		// (get) Token: 0x06005C83 RID: 23683 RVA: 0x000B0430 File Offset: 0x000AE630
		// (set) Token: 0x06005C84 RID: 23684 RVA: 0x000B0450 File Offset: 0x000AE650
		[XmlIgnore]
		[Browsable(false)]
		public bool opposerSpecified
		{
			get
			{
				return this._opposer != null;
			}
			set
			{
				bool flag = value == (this._opposer == null);
				if (flag)
				{
					this._opposer = (value ? new ulong?(this.opposer) : null);
				}
			}
		}

		// Token: 0x06005C85 RID: 23685 RVA: 0x000B0494 File Offset: 0x000AE694
		private bool ShouldSerializeopposer()
		{
			return this.opposerSpecified;
		}

		// Token: 0x06005C86 RID: 23686 RVA: 0x000B04AC File Offset: 0x000AE6AC
		private void Resetopposer()
		{
			this.opposerSpecified = false;
		}

		// Token: 0x17001CFF RID: 7423
		// (get) Token: 0x06005C87 RID: 23687 RVA: 0x000B04B8 File Offset: 0x000AE6B8
		// (set) Token: 0x06005C88 RID: 23688 RVA: 0x000B04E4 File Offset: 0x000AE6E4
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001D00 RID: 7424
		// (get) Token: 0x06005C89 RID: 23689 RVA: 0x000B04F4 File Offset: 0x000AE6F4
		// (set) Token: 0x06005C8A RID: 23690 RVA: 0x000B0514 File Offset: 0x000AE714
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

		// Token: 0x06005C8B RID: 23691 RVA: 0x000B0558 File Offset: 0x000AE758
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06005C8C RID: 23692 RVA: 0x000B0570 File Offset: 0x000AE770
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001D01 RID: 7425
		// (get) Token: 0x06005C8D RID: 23693 RVA: 0x000B057C File Offset: 0x000AE77C
		// (set) Token: 0x06005C8E RID: 23694 RVA: 0x000B059D File Offset: 0x000AE79D
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

		// Token: 0x17001D02 RID: 7426
		// (get) Token: 0x06005C8F RID: 23695 RVA: 0x000B05A8 File Offset: 0x000AE7A8
		// (set) Token: 0x06005C90 RID: 23696 RVA: 0x000B05C4 File Offset: 0x000AE7C4
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

		// Token: 0x06005C91 RID: 23697 RVA: 0x000B05F4 File Offset: 0x000AE7F4
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06005C92 RID: 23698 RVA: 0x000B060C File Offset: 0x000AE80C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001D03 RID: 7427
		// (get) Token: 0x06005C93 RID: 23699 RVA: 0x000B0618 File Offset: 0x000AE818
		// (set) Token: 0x06005C94 RID: 23700 RVA: 0x000B0644 File Offset: 0x000AE844
		[ProtoMember(4, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public int point
		{
			get
			{
				return this._point ?? 0;
			}
			set
			{
				this._point = new int?(value);
			}
		}

		// Token: 0x17001D04 RID: 7428
		// (get) Token: 0x06005C95 RID: 23701 RVA: 0x000B0654 File Offset: 0x000AE854
		// (set) Token: 0x06005C96 RID: 23702 RVA: 0x000B0674 File Offset: 0x000AE874
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
					this._point = (value ? new int?(this.point) : null);
				}
			}
		}

		// Token: 0x06005C97 RID: 23703 RVA: 0x000B06B8 File Offset: 0x000AE8B8
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x000B06D0 File Offset: 0x000AE8D0
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001D05 RID: 7429
		// (get) Token: 0x06005C99 RID: 23705 RVA: 0x000B06DC File Offset: 0x000AE8DC
		// (set) Token: 0x06005C9A RID: 23706 RVA: 0x000B0708 File Offset: 0x000AE908
		[ProtoMember(5, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		// Token: 0x17001D06 RID: 7430
		// (get) Token: 0x06005C9B RID: 23707 RVA: 0x000B0718 File Offset: 0x000AE918
		// (set) Token: 0x06005C9C RID: 23708 RVA: 0x000B0738 File Offset: 0x000AE938
		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		// Token: 0x06005C9D RID: 23709 RVA: 0x000B077C File Offset: 0x000AE97C
		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		// Token: 0x06005C9E RID: 23710 RVA: 0x000B0794 File Offset: 0x000AE994
		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		// Token: 0x17001D07 RID: 7431
		// (get) Token: 0x06005C9F RID: 23711 RVA: 0x000B07A0 File Offset: 0x000AE9A0
		// (set) Token: 0x06005CA0 RID: 23712 RVA: 0x000B07CC File Offset: 0x000AE9CC
		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
			}
		}

		// Token: 0x17001D08 RID: 7432
		// (get) Token: 0x06005CA1 RID: 23713 RVA: 0x000B07DC File Offset: 0x000AE9DC
		// (set) Token: 0x06005CA2 RID: 23714 RVA: 0x000B07FC File Offset: 0x000AE9FC
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new PkResultType?(this.result) : null);
				}
			}
		}

		// Token: 0x06005CA3 RID: 23715 RVA: 0x000B0840 File Offset: 0x000AEA40
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06005CA4 RID: 23716 RVA: 0x000B0858 File Offset: 0x000AEA58
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06005CA5 RID: 23717 RVA: 0x000B0864 File Offset: 0x000AEA64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400167F RID: 5759
		private ulong? _opposer;

		// Token: 0x04001680 RID: 5760
		private uint? _profession;

		// Token: 0x04001681 RID: 5761
		private string _name;

		// Token: 0x04001682 RID: 5762
		private int? _point;

		// Token: 0x04001683 RID: 5763
		private uint? _honorpoint;

		// Token: 0x04001684 RID: 5764
		private PkResultType? _result;

		// Token: 0x04001685 RID: 5765
		private IExtension extensionObject;
	}
}
