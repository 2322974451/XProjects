using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000221 RID: 545
	[ProtoContract(Name = "AuctionAllReqRes")]
	[Serializable]
	public class AuctionAllReqRes : IExtensible
	{
		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x06001E82 RID: 7810 RVA: 0x0003BEB0 File Offset: 0x0003A0B0
		// (set) Token: 0x06001E83 RID: 7811 RVA: 0x0003BEDC File Offset: 0x0003A0DC
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x06001E84 RID: 7812 RVA: 0x0003BEEC File Offset: 0x0003A0EC
		// (set) Token: 0x06001E85 RID: 7813 RVA: 0x0003BF0C File Offset: 0x0003A10C
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x0003BF50 File Offset: 0x0003A150
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x0003BF68 File Offset: 0x0003A168
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x06001E88 RID: 7816 RVA: 0x0003BF74 File Offset: 0x0003A174
		[ProtoMember(2, Name = "itembrief", DataFormat = DataFormat.Default)]
		public List<AuctItemBrief> itembrief
		{
			get
			{
				return this._itembrief;
			}
		}

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x06001E89 RID: 7817 RVA: 0x0003BF8C File Offset: 0x0003A18C
		[ProtoMember(3, Name = "overlapdata", DataFormat = DataFormat.Default)]
		public List<AuctOverlapData> overlapdata
		{
			get
			{
				return this._overlapdata;
			}
		}

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x06001E8A RID: 7818 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
		[ProtoMember(4, Name = "saledata", DataFormat = DataFormat.Default)]
		public List<AuctionSaleData> saledata
		{
			get
			{
				return this._saledata;
			}
		}

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x06001E8B RID: 7819 RVA: 0x0003BFBC File Offset: 0x0003A1BC
		// (set) Token: 0x06001E8C RID: 7820 RVA: 0x0003BFE8 File Offset: 0x0003A1E8
		[ProtoMember(5, IsRequired = false, Name = "autorefreshlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint autorefreshlefttime
		{
			get
			{
				return this._autorefreshlefttime ?? 0U;
			}
			set
			{
				this._autorefreshlefttime = new uint?(value);
			}
		}

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x06001E8D RID: 7821 RVA: 0x0003BFF8 File Offset: 0x0003A1F8
		// (set) Token: 0x06001E8E RID: 7822 RVA: 0x0003C018 File Offset: 0x0003A218
		[XmlIgnore]
		[Browsable(false)]
		public bool autorefreshlefttimeSpecified
		{
			get
			{
				return this._autorefreshlefttime != null;
			}
			set
			{
				bool flag = value == (this._autorefreshlefttime == null);
				if (flag)
				{
					this._autorefreshlefttime = (value ? new uint?(this.autorefreshlefttime) : null);
				}
			}
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x0003C05C File Offset: 0x0003A25C
		private bool ShouldSerializeautorefreshlefttime()
		{
			return this.autorefreshlefttimeSpecified;
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x0003C074 File Offset: 0x0003A274
		private void Resetautorefreshlefttime()
		{
			this.autorefreshlefttimeSpecified = false;
		}

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x06001E91 RID: 7825 RVA: 0x0003C080 File Offset: 0x0003A280
		// (set) Token: 0x06001E92 RID: 7826 RVA: 0x0003C0AC File Offset: 0x0003A2AC
		[ProtoMember(6, IsRequired = false, Name = "tradeprice", DataFormat = DataFormat.TwosComplement)]
		public uint tradeprice
		{
			get
			{
				return this._tradeprice ?? 0U;
			}
			set
			{
				this._tradeprice = new uint?(value);
			}
		}

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x06001E93 RID: 7827 RVA: 0x0003C0BC File Offset: 0x0003A2BC
		// (set) Token: 0x06001E94 RID: 7828 RVA: 0x0003C0DC File Offset: 0x0003A2DC
		[XmlIgnore]
		[Browsable(false)]
		public bool tradepriceSpecified
		{
			get
			{
				return this._tradeprice != null;
			}
			set
			{
				bool flag = value == (this._tradeprice == null);
				if (flag)
				{
					this._tradeprice = (value ? new uint?(this.tradeprice) : null);
				}
			}
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x0003C120 File Offset: 0x0003A320
		private bool ShouldSerializetradeprice()
		{
			return this.tradepriceSpecified;
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x0003C138 File Offset: 0x0003A338
		private void Resettradeprice()
		{
			this.tradepriceSpecified = false;
		}

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x06001E97 RID: 7831 RVA: 0x0003C144 File Offset: 0x0003A344
		// (set) Token: 0x06001E98 RID: 7832 RVA: 0x0003C170 File Offset: 0x0003A370
		[ProtoMember(7, IsRequired = false, Name = "leftfreerefreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint leftfreerefreshcount
		{
			get
			{
				return this._leftfreerefreshcount ?? 0U;
			}
			set
			{
				this._leftfreerefreshcount = new uint?(value);
			}
		}

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x06001E99 RID: 7833 RVA: 0x0003C180 File Offset: 0x0003A380
		// (set) Token: 0x06001E9A RID: 7834 RVA: 0x0003C1A0 File Offset: 0x0003A3A0
		[XmlIgnore]
		[Browsable(false)]
		public bool leftfreerefreshcountSpecified
		{
			get
			{
				return this._leftfreerefreshcount != null;
			}
			set
			{
				bool flag = value == (this._leftfreerefreshcount == null);
				if (flag)
				{
					this._leftfreerefreshcount = (value ? new uint?(this.leftfreerefreshcount) : null);
				}
			}
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x0003C1E4 File Offset: 0x0003A3E4
		private bool ShouldSerializeleftfreerefreshcount()
		{
			return this.leftfreerefreshcountSpecified;
		}

		// Token: 0x06001E9C RID: 7836 RVA: 0x0003C1FC File Offset: 0x0003A3FC
		private void Resetleftfreerefreshcount()
		{
			this.leftfreerefreshcountSpecified = false;
		}

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x06001E9D RID: 7837 RVA: 0x0003C208 File Offset: 0x0003A408
		// (set) Token: 0x06001E9E RID: 7838 RVA: 0x0003C234 File Offset: 0x0003A434
		[ProtoMember(8, IsRequired = false, Name = "itemleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemleftcount
		{
			get
			{
				return this._itemleftcount ?? 0U;
			}
			set
			{
				this._itemleftcount = new uint?(value);
			}
		}

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x06001E9F RID: 7839 RVA: 0x0003C244 File Offset: 0x0003A444
		// (set) Token: 0x06001EA0 RID: 7840 RVA: 0x0003C264 File Offset: 0x0003A464
		[XmlIgnore]
		[Browsable(false)]
		public bool itemleftcountSpecified
		{
			get
			{
				return this._itemleftcount != null;
			}
			set
			{
				bool flag = value == (this._itemleftcount == null);
				if (flag)
				{
					this._itemleftcount = (value ? new uint?(this.itemleftcount) : null);
				}
			}
		}

		// Token: 0x06001EA1 RID: 7841 RVA: 0x0003C2A8 File Offset: 0x0003A4A8
		private bool ShouldSerializeitemleftcount()
		{
			return this.itemleftcountSpecified;
		}

		// Token: 0x06001EA2 RID: 7842 RVA: 0x0003C2C0 File Offset: 0x0003A4C0
		private void Resetitemleftcount()
		{
			this.itemleftcountSpecified = false;
		}

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x06001EA3 RID: 7843 RVA: 0x0003C2CC File Offset: 0x0003A4CC
		// (set) Token: 0x06001EA4 RID: 7844 RVA: 0x0003C2F8 File Offset: 0x0003A4F8
		[ProtoMember(9, IsRequired = false, Name = "freerefreshlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint freerefreshlefttime
		{
			get
			{
				return this._freerefreshlefttime ?? 0U;
			}
			set
			{
				this._freerefreshlefttime = new uint?(value);
			}
		}

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x06001EA5 RID: 7845 RVA: 0x0003C308 File Offset: 0x0003A508
		// (set) Token: 0x06001EA6 RID: 7846 RVA: 0x0003C328 File Offset: 0x0003A528
		[XmlIgnore]
		[Browsable(false)]
		public bool freerefreshlefttimeSpecified
		{
			get
			{
				return this._freerefreshlefttime != null;
			}
			set
			{
				bool flag = value == (this._freerefreshlefttime == null);
				if (flag)
				{
					this._freerefreshlefttime = (value ? new uint?(this.freerefreshlefttime) : null);
				}
			}
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x0003C36C File Offset: 0x0003A56C
		private bool ShouldSerializefreerefreshlefttime()
		{
			return this.freerefreshlefttimeSpecified;
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x0003C384 File Offset: 0x0003A584
		private void Resetfreerefreshlefttime()
		{
			this.freerefreshlefttimeSpecified = false;
		}

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x06001EA9 RID: 7849 RVA: 0x0003C390 File Offset: 0x0003A590
		// (set) Token: 0x06001EAA RID: 7850 RVA: 0x0003C3BC File Offset: 0x0003A5BC
		[ProtoMember(10, IsRequired = false, Name = "need_copyitem", DataFormat = DataFormat.Default)]
		public bool need_copyitem
		{
			get
			{
				return this._need_copyitem ?? false;
			}
			set
			{
				this._need_copyitem = new bool?(value);
			}
		}

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x06001EAB RID: 7851 RVA: 0x0003C3CC File Offset: 0x0003A5CC
		// (set) Token: 0x06001EAC RID: 7852 RVA: 0x0003C3EC File Offset: 0x0003A5EC
		[XmlIgnore]
		[Browsable(false)]
		public bool need_copyitemSpecified
		{
			get
			{
				return this._need_copyitem != null;
			}
			set
			{
				bool flag = value == (this._need_copyitem == null);
				if (flag)
				{
					this._need_copyitem = (value ? new bool?(this.need_copyitem) : null);
				}
			}
		}

		// Token: 0x06001EAD RID: 7853 RVA: 0x0003C430 File Offset: 0x0003A630
		private bool ShouldSerializeneed_copyitem()
		{
			return this.need_copyitemSpecified;
		}

		// Token: 0x06001EAE RID: 7854 RVA: 0x0003C448 File Offset: 0x0003A648
		private void Resetneed_copyitem()
		{
			this.need_copyitemSpecified = false;
		}

		// Token: 0x06001EAF RID: 7855 RVA: 0x0003C454 File Offset: 0x0003A654
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400079F RID: 1951
		private ErrorCode? _errcode;

		// Token: 0x040007A0 RID: 1952
		private readonly List<AuctItemBrief> _itembrief = new List<AuctItemBrief>();

		// Token: 0x040007A1 RID: 1953
		private readonly List<AuctOverlapData> _overlapdata = new List<AuctOverlapData>();

		// Token: 0x040007A2 RID: 1954
		private readonly List<AuctionSaleData> _saledata = new List<AuctionSaleData>();

		// Token: 0x040007A3 RID: 1955
		private uint? _autorefreshlefttime;

		// Token: 0x040007A4 RID: 1956
		private uint? _tradeprice;

		// Token: 0x040007A5 RID: 1957
		private uint? _leftfreerefreshcount;

		// Token: 0x040007A6 RID: 1958
		private uint? _itemleftcount;

		// Token: 0x040007A7 RID: 1959
		private uint? _freerefreshlefttime;

		// Token: 0x040007A8 RID: 1960
		private bool? _need_copyitem;

		// Token: 0x040007A9 RID: 1961
		private IExtension extensionObject;
	}
}
