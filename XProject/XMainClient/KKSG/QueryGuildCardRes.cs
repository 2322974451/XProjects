using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009E RID: 158
	[ProtoContract(Name = "QueryGuildCardRes")]
	[Serializable]
	public class QueryGuildCardRes : IExtensible
	{
		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x000172AC File Offset: 0x000154AC
		// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x000172D8 File Offset: 0x000154D8
		[ProtoMember(1, IsRequired = false, Name = "playcount", DataFormat = DataFormat.TwosComplement)]
		public uint playcount
		{
			get
			{
				return this._playcount ?? 0U;
			}
			set
			{
				this._playcount = new uint?(value);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x000172E8 File Offset: 0x000154E8
		// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x00017308 File Offset: 0x00015508
		[XmlIgnore]
		[Browsable(false)]
		public bool playcountSpecified
		{
			get
			{
				return this._playcount != null;
			}
			set
			{
				bool flag = value == (this._playcount == null);
				if (flag)
				{
					this._playcount = (value ? new uint?(this.playcount) : null);
				}
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0001734C File Offset: 0x0001554C
		private bool ShouldSerializeplaycount()
		{
			return this.playcountSpecified;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00017364 File Offset: 0x00015564
		private void Resetplaycount()
		{
			this.playcountSpecified = false;
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x00017370 File Offset: 0x00015570
		// (set) Token: 0x06000ACD RID: 2765 RVA: 0x0001739C File Offset: 0x0001559C
		[ProtoMember(2, IsRequired = false, Name = "changecount", DataFormat = DataFormat.TwosComplement)]
		public uint changecount
		{
			get
			{
				return this._changecount ?? 0U;
			}
			set
			{
				this._changecount = new uint?(value);
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x000173AC File Offset: 0x000155AC
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x000173CC File Offset: 0x000155CC
		[XmlIgnore]
		[Browsable(false)]
		public bool changecountSpecified
		{
			get
			{
				return this._changecount != null;
			}
			set
			{
				bool flag = value == (this._changecount == null);
				if (flag)
				{
					this._changecount = (value ? new uint?(this.changecount) : null);
				}
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00017410 File Offset: 0x00015610
		private bool ShouldSerializechangecount()
		{
			return this.changecountSpecified;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00017428 File Offset: 0x00015628
		private void Resetchangecount()
		{
			this.changecountSpecified = false;
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00017434 File Offset: 0x00015634
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x00017460 File Offset: 0x00015660
		[ProtoMember(3, IsRequired = false, Name = "canplaycount", DataFormat = DataFormat.TwosComplement)]
		public uint canplaycount
		{
			get
			{
				return this._canplaycount ?? 0U;
			}
			set
			{
				this._canplaycount = new uint?(value);
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x00017470 File Offset: 0x00015670
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00017490 File Offset: 0x00015690
		[XmlIgnore]
		[Browsable(false)]
		public bool canplaycountSpecified
		{
			get
			{
				return this._canplaycount != null;
			}
			set
			{
				bool flag = value == (this._canplaycount == null);
				if (flag)
				{
					this._canplaycount = (value ? new uint?(this.canplaycount) : null);
				}
			}
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x000174D4 File Offset: 0x000156D4
		private bool ShouldSerializecanplaycount()
		{
			return this.canplaycountSpecified;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x000174EC File Offset: 0x000156EC
		private void Resetcanplaycount()
		{
			this.canplaycountSpecified = false;
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x000174F8 File Offset: 0x000156F8
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x00017524 File Offset: 0x00015724
		[ProtoMember(4, IsRequired = false, Name = "canchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint canchangecount
		{
			get
			{
				return this._canchangecount ?? 0U;
			}
			set
			{
				this._canchangecount = new uint?(value);
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00017534 File Offset: 0x00015734
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x00017554 File Offset: 0x00015754
		[XmlIgnore]
		[Browsable(false)]
		public bool canchangecountSpecified
		{
			get
			{
				return this._canchangecount != null;
			}
			set
			{
				bool flag = value == (this._canchangecount == null);
				if (flag)
				{
					this._canchangecount = (value ? new uint?(this.canchangecount) : null);
				}
			}
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00017598 File Offset: 0x00015798
		private bool ShouldSerializecanchangecount()
		{
			return this.canchangecountSpecified;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000175B0 File Offset: 0x000157B0
		private void Resetcanchangecount()
		{
			this.canchangecountSpecified = false;
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x000175BC File Offset: 0x000157BC
		// (set) Token: 0x06000ADF RID: 2783 RVA: 0x000175E8 File Offset: 0x000157E8
		[ProtoMember(5, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x000175F8 File Offset: 0x000157F8
		// (set) Token: 0x06000AE1 RID: 2785 RVA: 0x00017618 File Offset: 0x00015818
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0001765C File Offset: 0x0001585C
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00017674 File Offset: 0x00015874
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00017680 File Offset: 0x00015880
		// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x000176AC File Offset: 0x000158AC
		[ProtoMember(6, IsRequired = false, Name = "canallcount", DataFormat = DataFormat.TwosComplement)]
		public uint canallcount
		{
			get
			{
				return this._canallcount ?? 0U;
			}
			set
			{
				this._canallcount = new uint?(value);
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x000176BC File Offset: 0x000158BC
		// (set) Token: 0x06000AE7 RID: 2791 RVA: 0x000176DC File Offset: 0x000158DC
		[XmlIgnore]
		[Browsable(false)]
		public bool canallcountSpecified
		{
			get
			{
				return this._canallcount != null;
			}
			set
			{
				bool flag = value == (this._canallcount == null);
				if (flag)
				{
					this._canallcount = (value ? new uint?(this.canallcount) : null);
				}
			}
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00017720 File Offset: 0x00015920
		private bool ShouldSerializecanallcount()
		{
			return this.canallcountSpecified;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00017738 File Offset: 0x00015938
		private void Resetcanallcount()
		{
			this.canallcountSpecified = false;
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x00017744 File Offset: 0x00015944
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x00017770 File Offset: 0x00015970
		[ProtoMember(7, IsRequired = false, Name = "bestresult", DataFormat = DataFormat.TwosComplement)]
		public uint bestresult
		{
			get
			{
				return this._bestresult ?? 0U;
			}
			set
			{
				this._bestresult = new uint?(value);
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00017780 File Offset: 0x00015980
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x000177A0 File Offset: 0x000159A0
		[XmlIgnore]
		[Browsable(false)]
		public bool bestresultSpecified
		{
			get
			{
				return this._bestresult != null;
			}
			set
			{
				bool flag = value == (this._bestresult == null);
				if (flag)
				{
					this._bestresult = (value ? new uint?(this.bestresult) : null);
				}
			}
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x000177E4 File Offset: 0x000159E4
		private bool ShouldSerializebestresult()
		{
			return this.bestresultSpecified;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000177FC File Offset: 0x000159FC
		private void Resetbestresult()
		{
			this.bestresultSpecified = false;
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00017808 File Offset: 0x00015A08
		[ProtoMember(8, Name = "bestcards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestcards
		{
			get
			{
				return this._bestcards;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00017820 File Offset: 0x00015A20
		// (set) Token: 0x06000AF2 RID: 2802 RVA: 0x0001784C File Offset: 0x00015A4C
		[ProtoMember(9, IsRequired = false, Name = "buychangcount", DataFormat = DataFormat.TwosComplement)]
		public uint buychangcount
		{
			get
			{
				return this._buychangcount ?? 0U;
			}
			set
			{
				this._buychangcount = new uint?(value);
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0001785C File Offset: 0x00015A5C
		// (set) Token: 0x06000AF4 RID: 2804 RVA: 0x0001787C File Offset: 0x00015A7C
		[XmlIgnore]
		[Browsable(false)]
		public bool buychangcountSpecified
		{
			get
			{
				return this._buychangcount != null;
			}
			set
			{
				bool flag = value == (this._buychangcount == null);
				if (flag)
				{
					this._buychangcount = (value ? new uint?(this.buychangcount) : null);
				}
			}
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x000178C0 File Offset: 0x00015AC0
		private bool ShouldSerializebuychangcount()
		{
			return this.buychangcountSpecified;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x000178D8 File Offset: 0x00015AD8
		private void Resetbuychangcount()
		{
			this.buychangcountSpecified = false;
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x000178E4 File Offset: 0x00015AE4
		// (set) Token: 0x06000AF8 RID: 2808 RVA: 0x00017905 File Offset: 0x00015B05
		[ProtoMember(10, IsRequired = false, Name = "bestrole", DataFormat = DataFormat.Default)]
		public string bestrole
		{
			get
			{
				return this._bestrole ?? "";
			}
			set
			{
				this._bestrole = value;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00017910 File Offset: 0x00015B10
		// (set) Token: 0x06000AFA RID: 2810 RVA: 0x0001792C File Offset: 0x00015B2C
		[XmlIgnore]
		[Browsable(false)]
		public bool bestroleSpecified
		{
			get
			{
				return this._bestrole != null;
			}
			set
			{
				bool flag = value == (this._bestrole == null);
				if (flag)
				{
					this._bestrole = (value ? this.bestrole : null);
				}
			}
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0001795C File Offset: 0x00015B5C
		private bool ShouldSerializebestrole()
		{
			return this.bestroleSpecified;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00017974 File Offset: 0x00015B74
		private void Resetbestrole()
		{
			this.bestroleSpecified = false;
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x00017980 File Offset: 0x00015B80
		// (set) Token: 0x06000AFE RID: 2814 RVA: 0x000179AC File Offset: 0x00015BAC
		[ProtoMember(11, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x000179BC File Offset: 0x00015BBC
		// (set) Token: 0x06000B00 RID: 2816 RVA: 0x000179DC File Offset: 0x00015BDC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00017A20 File Offset: 0x00015C20
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00017A38 File Offset: 0x00015C38
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00017A44 File Offset: 0x00015C44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002B8 RID: 696
		private uint? _playcount;

		// Token: 0x040002B9 RID: 697
		private uint? _changecount;

		// Token: 0x040002BA RID: 698
		private uint? _canplaycount;

		// Token: 0x040002BB RID: 699
		private uint? _canchangecount;

		// Token: 0x040002BC RID: 700
		private uint? _allcount;

		// Token: 0x040002BD RID: 701
		private uint? _canallcount;

		// Token: 0x040002BE RID: 702
		private uint? _bestresult;

		// Token: 0x040002BF RID: 703
		private readonly List<uint> _bestcards = new List<uint>();

		// Token: 0x040002C0 RID: 704
		private uint? _buychangcount;

		// Token: 0x040002C1 RID: 705
		private string _bestrole;

		// Token: 0x040002C2 RID: 706
		private ErrorCode? _errorcode;

		// Token: 0x040002C3 RID: 707
		private IExtension extensionObject;
	}
}
