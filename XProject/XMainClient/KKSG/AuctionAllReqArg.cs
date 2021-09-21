using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000220 RID: 544
	[ProtoContract(Name = "AuctionAllReqArg")]
	[Serializable]
	public class AuctionAllReqArg : IExtensible
	{
		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06001E50 RID: 7760 RVA: 0x0003B844 File Offset: 0x00039A44
		// (set) Token: 0x06001E51 RID: 7761 RVA: 0x0003B870 File Offset: 0x00039A70
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public AuctionAllReqType reqtype
		{
			get
			{
				return this._reqtype ?? AuctionAllReqType.ART_REQSALE;
			}
			set
			{
				this._reqtype = new AuctionAllReqType?(value);
			}
		}

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x06001E52 RID: 7762 RVA: 0x0003B880 File Offset: 0x00039A80
		// (set) Token: 0x06001E53 RID: 7763 RVA: 0x0003B8A0 File Offset: 0x00039AA0
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new AuctionAllReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x0003B8E4 File Offset: 0x00039AE4
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0003B8FC File Offset: 0x00039AFC
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x06001E56 RID: 7766 RVA: 0x0003B908 File Offset: 0x00039B08
		// (set) Token: 0x06001E57 RID: 7767 RVA: 0x0003B934 File Offset: 0x00039B34
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06001E58 RID: 7768 RVA: 0x0003B944 File Offset: 0x00039B44
		// (set) Token: 0x06001E59 RID: 7769 RVA: 0x0003B964 File Offset: 0x00039B64
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x0003B9A8 File Offset: 0x00039BA8
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x0003B9C0 File Offset: 0x00039BC0
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x0003B9CC File Offset: 0x00039BCC
		// (set) Token: 0x06001E5D RID: 7773 RVA: 0x0003B9F9 File Offset: 0x00039BF9
		[ProtoMember(3, IsRequired = false, Name = "itemuniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong itemuniqueid
		{
			get
			{
				return this._itemuniqueid ?? 0UL;
			}
			set
			{
				this._itemuniqueid = new ulong?(value);
			}
		}

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x0003BA08 File Offset: 0x00039C08
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x0003BA28 File Offset: 0x00039C28
		[XmlIgnore]
		[Browsable(false)]
		public bool itemuniqueidSpecified
		{
			get
			{
				return this._itemuniqueid != null;
			}
			set
			{
				bool flag = value == (this._itemuniqueid == null);
				if (flag)
				{
					this._itemuniqueid = (value ? new ulong?(this.itemuniqueid) : null);
				}
			}
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x0003BA6C File Offset: 0x00039C6C
		private bool ShouldSerializeitemuniqueid()
		{
			return this.itemuniqueidSpecified;
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x0003BA84 File Offset: 0x00039C84
		private void Resetitemuniqueid()
		{
			this.itemuniqueidSpecified = false;
		}

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06001E62 RID: 7778 RVA: 0x0003BA90 File Offset: 0x00039C90
		// (set) Token: 0x06001E63 RID: 7779 RVA: 0x0003BABC File Offset: 0x00039CBC
		[ProtoMember(4, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06001E64 RID: 7780 RVA: 0x0003BACC File Offset: 0x00039CCC
		// (set) Token: 0x06001E65 RID: 7781 RVA: 0x0003BAEC File Offset: 0x00039CEC
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x06001E66 RID: 7782 RVA: 0x0003BB30 File Offset: 0x00039D30
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x06001E67 RID: 7783 RVA: 0x0003BB48 File Offset: 0x00039D48
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x06001E68 RID: 7784 RVA: 0x0003BB54 File Offset: 0x00039D54
		// (set) Token: 0x06001E69 RID: 7785 RVA: 0x0003BB80 File Offset: 0x00039D80
		[ProtoMember(5, IsRequired = false, Name = "perprice", DataFormat = DataFormat.TwosComplement)]
		public uint perprice
		{
			get
			{
				return this._perprice ?? 0U;
			}
			set
			{
				this._perprice = new uint?(value);
			}
		}

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x06001E6A RID: 7786 RVA: 0x0003BB90 File Offset: 0x00039D90
		// (set) Token: 0x06001E6B RID: 7787 RVA: 0x0003BBB0 File Offset: 0x00039DB0
		[XmlIgnore]
		[Browsable(false)]
		public bool perpriceSpecified
		{
			get
			{
				return this._perprice != null;
			}
			set
			{
				bool flag = value == (this._perprice == null);
				if (flag)
				{
					this._perprice = (value ? new uint?(this.perprice) : null);
				}
			}
		}

		// Token: 0x06001E6C RID: 7788 RVA: 0x0003BBF4 File Offset: 0x00039DF4
		private bool ShouldSerializeperprice()
		{
			return this.perpriceSpecified;
		}

		// Token: 0x06001E6D RID: 7789 RVA: 0x0003BC0C File Offset: 0x00039E0C
		private void Resetperprice()
		{
			this.perpriceSpecified = false;
		}

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x06001E6E RID: 7790 RVA: 0x0003BC18 File Offset: 0x00039E18
		// (set) Token: 0x06001E6F RID: 7791 RVA: 0x0003BC45 File Offset: 0x00039E45
		[ProtoMember(6, IsRequired = false, Name = "overlapid", DataFormat = DataFormat.TwosComplement)]
		public ulong overlapid
		{
			get
			{
				return this._overlapid ?? 0UL;
			}
			set
			{
				this._overlapid = new ulong?(value);
			}
		}

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06001E70 RID: 7792 RVA: 0x0003BC54 File Offset: 0x00039E54
		// (set) Token: 0x06001E71 RID: 7793 RVA: 0x0003BC74 File Offset: 0x00039E74
		[XmlIgnore]
		[Browsable(false)]
		public bool overlapidSpecified
		{
			get
			{
				return this._overlapid != null;
			}
			set
			{
				bool flag = value == (this._overlapid == null);
				if (flag)
				{
					this._overlapid = (value ? new ulong?(this.overlapid) : null);
				}
			}
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x0003BCB8 File Offset: 0x00039EB8
		private bool ShouldSerializeoverlapid()
		{
			return this.overlapidSpecified;
		}

		// Token: 0x06001E73 RID: 7795 RVA: 0x0003BCD0 File Offset: 0x00039ED0
		private void Resetoverlapid()
		{
			this.overlapidSpecified = false;
		}

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x0003BCDC File Offset: 0x00039EDC
		// (set) Token: 0x06001E75 RID: 7797 RVA: 0x0003BD09 File Offset: 0x00039F09
		[ProtoMember(7, IsRequired = false, Name = "auctuid", DataFormat = DataFormat.TwosComplement)]
		public ulong auctuid
		{
			get
			{
				return this._auctuid ?? 0UL;
			}
			set
			{
				this._auctuid = new ulong?(value);
			}
		}

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06001E76 RID: 7798 RVA: 0x0003BD18 File Offset: 0x00039F18
		// (set) Token: 0x06001E77 RID: 7799 RVA: 0x0003BD38 File Offset: 0x00039F38
		[XmlIgnore]
		[Browsable(false)]
		public bool auctuidSpecified
		{
			get
			{
				return this._auctuid != null;
			}
			set
			{
				bool flag = value == (this._auctuid == null);
				if (flag)
				{
					this._auctuid = (value ? new ulong?(this.auctuid) : null);
				}
			}
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x0003BD7C File Offset: 0x00039F7C
		private bool ShouldSerializeauctuid()
		{
			return this.auctuidSpecified;
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x0003BD94 File Offset: 0x00039F94
		private void Resetauctuid()
		{
			this.auctuidSpecified = false;
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06001E7A RID: 7802 RVA: 0x0003BDA0 File Offset: 0x00039FA0
		// (set) Token: 0x06001E7B RID: 7803 RVA: 0x0003BDCC File Offset: 0x00039FCC
		[ProtoMember(8, IsRequired = false, Name = "istreasure", DataFormat = DataFormat.Default)]
		public bool istreasure
		{
			get
			{
				return this._istreasure ?? false;
			}
			set
			{
				this._istreasure = new bool?(value);
			}
		}

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x06001E7C RID: 7804 RVA: 0x0003BDDC File Offset: 0x00039FDC
		// (set) Token: 0x06001E7D RID: 7805 RVA: 0x0003BDFC File Offset: 0x00039FFC
		[XmlIgnore]
		[Browsable(false)]
		public bool istreasureSpecified
		{
			get
			{
				return this._istreasure != null;
			}
			set
			{
				bool flag = value == (this._istreasure == null);
				if (flag)
				{
					this._istreasure = (value ? new bool?(this.istreasure) : null);
				}
			}
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x0003BE40 File Offset: 0x0003A040
		private bool ShouldSerializeistreasure()
		{
			return this.istreasureSpecified;
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x0003BE58 File Offset: 0x0003A058
		private void Resetistreasure()
		{
			this.istreasureSpecified = false;
		}

		// Token: 0x06001E80 RID: 7808 RVA: 0x0003BE64 File Offset: 0x0003A064
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000796 RID: 1942
		private AuctionAllReqType? _reqtype;

		// Token: 0x04000797 RID: 1943
		private uint? _itemid;

		// Token: 0x04000798 RID: 1944
		private ulong? _itemuniqueid;

		// Token: 0x04000799 RID: 1945
		private uint? _itemcount;

		// Token: 0x0400079A RID: 1946
		private uint? _perprice;

		// Token: 0x0400079B RID: 1947
		private ulong? _overlapid;

		// Token: 0x0400079C RID: 1948
		private ulong? _auctuid;

		// Token: 0x0400079D RID: 1949
		private bool? _istreasure;

		// Token: 0x0400079E RID: 1950
		private IExtension extensionObject;
	}
}
