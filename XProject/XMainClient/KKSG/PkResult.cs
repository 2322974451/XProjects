using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D2 RID: 1490
	[ProtoContract(Name = "PkResult")]
	[Serializable]
	public class PkResult : IExtensible
	{
		// Token: 0x17001A63 RID: 6755
		// (get) Token: 0x06005513 RID: 21779 RVA: 0x000A1E28 File Offset: 0x000A0028
		// (set) Token: 0x06005514 RID: 21780 RVA: 0x000A1E54 File Offset: 0x000A0054
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001A64 RID: 6756
		// (get) Token: 0x06005515 RID: 21781 RVA: 0x000A1E64 File Offset: 0x000A0064
		// (set) Token: 0x06005516 RID: 21782 RVA: 0x000A1E84 File Offset: 0x000A0084
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

		// Token: 0x06005517 RID: 21783 RVA: 0x000A1EC8 File Offset: 0x000A00C8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06005518 RID: 21784 RVA: 0x000A1EE0 File Offset: 0x000A00E0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001A65 RID: 6757
		// (get) Token: 0x06005519 RID: 21785 RVA: 0x000A1EEC File Offset: 0x000A00EC
		// (set) Token: 0x0600551A RID: 21786 RVA: 0x000A1F18 File Offset: 0x000A0118
		[ProtoMember(2, IsRequired = false, Name = "winpoint", DataFormat = DataFormat.TwosComplement)]
		public int winpoint
		{
			get
			{
				return this._winpoint ?? 0;
			}
			set
			{
				this._winpoint = new int?(value);
			}
		}

		// Token: 0x17001A66 RID: 6758
		// (get) Token: 0x0600551B RID: 21787 RVA: 0x000A1F28 File Offset: 0x000A0128
		// (set) Token: 0x0600551C RID: 21788 RVA: 0x000A1F48 File Offset: 0x000A0148
		[XmlIgnore]
		[Browsable(false)]
		public bool winpointSpecified
		{
			get
			{
				return this._winpoint != null;
			}
			set
			{
				bool flag = value == (this._winpoint == null);
				if (flag)
				{
					this._winpoint = (value ? new int?(this.winpoint) : null);
				}
			}
		}

		// Token: 0x0600551D RID: 21789 RVA: 0x000A1F8C File Offset: 0x000A018C
		private bool ShouldSerializewinpoint()
		{
			return this.winpointSpecified;
		}

		// Token: 0x0600551E RID: 21790 RVA: 0x000A1FA4 File Offset: 0x000A01A4
		private void Resetwinpoint()
		{
			this.winpointSpecified = false;
		}

		// Token: 0x17001A67 RID: 6759
		// (get) Token: 0x0600551F RID: 21791 RVA: 0x000A1FB0 File Offset: 0x000A01B0
		// (set) Token: 0x06005520 RID: 21792 RVA: 0x000A1FDC File Offset: 0x000A01DC
		[ProtoMember(3, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001A68 RID: 6760
		// (get) Token: 0x06005521 RID: 21793 RVA: 0x000A1FEC File Offset: 0x000A01EC
		// (set) Token: 0x06005522 RID: 21794 RVA: 0x000A200C File Offset: 0x000A020C
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

		// Token: 0x06005523 RID: 21795 RVA: 0x000A2050 File Offset: 0x000A0250
		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		// Token: 0x06005524 RID: 21796 RVA: 0x000A2068 File Offset: 0x000A0268
		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		// Token: 0x17001A69 RID: 6761
		// (get) Token: 0x06005525 RID: 21797 RVA: 0x000A2074 File Offset: 0x000A0274
		// (set) Token: 0x06005526 RID: 21798 RVA: 0x000A20A0 File Offset: 0x000A02A0
		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17001A6A RID: 6762
		// (get) Token: 0x06005527 RID: 21799 RVA: 0x000A20B0 File Offset: 0x000A02B0
		// (set) Token: 0x06005528 RID: 21800 RVA: 0x000A20D0 File Offset: 0x000A02D0
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
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x06005529 RID: 21801 RVA: 0x000A2114 File Offset: 0x000A0314
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600552A RID: 21802 RVA: 0x000A212C File Offset: 0x000A032C
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001A6B RID: 6763
		// (get) Token: 0x0600552B RID: 21803 RVA: 0x000A2138 File Offset: 0x000A0338
		[ProtoMember(5, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001A6C RID: 6764
		// (get) Token: 0x0600552C RID: 21804 RVA: 0x000A2150 File Offset: 0x000A0350
		// (set) Token: 0x0600552D RID: 21805 RVA: 0x000A217C File Offset: 0x000A037C
		[ProtoMember(6, IsRequired = false, Name = "firstrank", DataFormat = DataFormat.TwosComplement)]
		public int firstrank
		{
			get
			{
				return this._firstrank ?? 0;
			}
			set
			{
				this._firstrank = new int?(value);
			}
		}

		// Token: 0x17001A6D RID: 6765
		// (get) Token: 0x0600552E RID: 21806 RVA: 0x000A218C File Offset: 0x000A038C
		// (set) Token: 0x0600552F RID: 21807 RVA: 0x000A21AC File Offset: 0x000A03AC
		[XmlIgnore]
		[Browsable(false)]
		public bool firstrankSpecified
		{
			get
			{
				return this._firstrank != null;
			}
			set
			{
				bool flag = value == (this._firstrank == null);
				if (flag)
				{
					this._firstrank = (value ? new int?(this.firstrank) : null);
				}
			}
		}

		// Token: 0x06005530 RID: 21808 RVA: 0x000A21F0 File Offset: 0x000A03F0
		private bool ShouldSerializefirstrank()
		{
			return this.firstrankSpecified;
		}

		// Token: 0x06005531 RID: 21809 RVA: 0x000A2208 File Offset: 0x000A0408
		private void Resetfirstrank()
		{
			this.firstrankSpecified = false;
		}

		// Token: 0x17001A6E RID: 6766
		// (get) Token: 0x06005532 RID: 21810 RVA: 0x000A2214 File Offset: 0x000A0414
		// (set) Token: 0x06005533 RID: 21811 RVA: 0x000A2240 File Offset: 0x000A0440
		[ProtoMember(7, IsRequired = false, Name = "dragoncount", DataFormat = DataFormat.TwosComplement)]
		public uint dragoncount
		{
			get
			{
				return this._dragoncount ?? 0U;
			}
			set
			{
				this._dragoncount = new uint?(value);
			}
		}

		// Token: 0x17001A6F RID: 6767
		// (get) Token: 0x06005534 RID: 21812 RVA: 0x000A2250 File Offset: 0x000A0450
		// (set) Token: 0x06005535 RID: 21813 RVA: 0x000A2270 File Offset: 0x000A0470
		[XmlIgnore]
		[Browsable(false)]
		public bool dragoncountSpecified
		{
			get
			{
				return this._dragoncount != null;
			}
			set
			{
				bool flag = value == (this._dragoncount == null);
				if (flag)
				{
					this._dragoncount = (value ? new uint?(this.dragoncount) : null);
				}
			}
		}

		// Token: 0x06005536 RID: 21814 RVA: 0x000A22B4 File Offset: 0x000A04B4
		private bool ShouldSerializedragoncount()
		{
			return this.dragoncountSpecified;
		}

		// Token: 0x06005537 RID: 21815 RVA: 0x000A22CC File Offset: 0x000A04CC
		private void Resetdragoncount()
		{
			this.dragoncountSpecified = false;
		}

		// Token: 0x17001A70 RID: 6768
		// (get) Token: 0x06005538 RID: 21816 RVA: 0x000A22D8 File Offset: 0x000A04D8
		// (set) Token: 0x06005539 RID: 21817 RVA: 0x000A2304 File Offset: 0x000A0504
		[ProtoMember(8, IsRequired = false, Name = "mystate", DataFormat = DataFormat.TwosComplement)]
		public KKVsRoleState mystate
		{
			get
			{
				return this._mystate ?? KKVsRoleState.KK_VS_ROLE_UNLOAD;
			}
			set
			{
				this._mystate = new KKVsRoleState?(value);
			}
		}

		// Token: 0x17001A71 RID: 6769
		// (get) Token: 0x0600553A RID: 21818 RVA: 0x000A2314 File Offset: 0x000A0514
		// (set) Token: 0x0600553B RID: 21819 RVA: 0x000A2334 File Offset: 0x000A0534
		[XmlIgnore]
		[Browsable(false)]
		public bool mystateSpecified
		{
			get
			{
				return this._mystate != null;
			}
			set
			{
				bool flag = value == (this._mystate == null);
				if (flag)
				{
					this._mystate = (value ? new KKVsRoleState?(this.mystate) : null);
				}
			}
		}

		// Token: 0x0600553C RID: 21820 RVA: 0x000A2378 File Offset: 0x000A0578
		private bool ShouldSerializemystate()
		{
			return this.mystateSpecified;
		}

		// Token: 0x0600553D RID: 21821 RVA: 0x000A2390 File Offset: 0x000A0590
		private void Resetmystate()
		{
			this.mystateSpecified = false;
		}

		// Token: 0x17001A72 RID: 6770
		// (get) Token: 0x0600553E RID: 21822 RVA: 0x000A239C File Offset: 0x000A059C
		// (set) Token: 0x0600553F RID: 21823 RVA: 0x000A23C8 File Offset: 0x000A05C8
		[ProtoMember(9, IsRequired = false, Name = "opstate", DataFormat = DataFormat.TwosComplement)]
		public KKVsRoleState opstate
		{
			get
			{
				return this._opstate ?? KKVsRoleState.KK_VS_ROLE_UNLOAD;
			}
			set
			{
				this._opstate = new KKVsRoleState?(value);
			}
		}

		// Token: 0x17001A73 RID: 6771
		// (get) Token: 0x06005540 RID: 21824 RVA: 0x000A23D8 File Offset: 0x000A05D8
		// (set) Token: 0x06005541 RID: 21825 RVA: 0x000A23F8 File Offset: 0x000A05F8
		[XmlIgnore]
		[Browsable(false)]
		public bool opstateSpecified
		{
			get
			{
				return this._opstate != null;
			}
			set
			{
				bool flag = value == (this._opstate == null);
				if (flag)
				{
					this._opstate = (value ? new KKVsRoleState?(this.opstate) : null);
				}
			}
		}

		// Token: 0x06005542 RID: 21826 RVA: 0x000A243C File Offset: 0x000A063C
		private bool ShouldSerializeopstate()
		{
			return this.opstateSpecified;
		}

		// Token: 0x06005543 RID: 21827 RVA: 0x000A2454 File Offset: 0x000A0654
		private void Resetopstate()
		{
			this.opstateSpecified = false;
		}

		// Token: 0x06005544 RID: 21828 RVA: 0x000A2460 File Offset: 0x000A0660
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014BF RID: 5311
		private PkResultType? _result;

		// Token: 0x040014C0 RID: 5312
		private int? _winpoint;

		// Token: 0x040014C1 RID: 5313
		private uint? _honorpoint;

		// Token: 0x040014C2 RID: 5314
		private int? _rank;

		// Token: 0x040014C3 RID: 5315
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040014C4 RID: 5316
		private int? _firstrank;

		// Token: 0x040014C5 RID: 5317
		private uint? _dragoncount;

		// Token: 0x040014C6 RID: 5318
		private KKVsRoleState? _mystate;

		// Token: 0x040014C7 RID: 5319
		private KKVsRoleState? _opstate;

		// Token: 0x040014C8 RID: 5320
		private IExtension extensionObject;
	}
}
