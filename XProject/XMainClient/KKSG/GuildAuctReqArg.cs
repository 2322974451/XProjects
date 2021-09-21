using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A1 RID: 673
	[ProtoContract(Name = "GuildAuctReqArg")]
	[Serializable]
	public class GuildAuctReqArg : IExtensible
	{
		// Token: 0x17000BB0 RID: 2992
		// (get) Token: 0x06002598 RID: 9624 RVA: 0x00049364 File Offset: 0x00047564
		// (set) Token: 0x06002599 RID: 9625 RVA: 0x00049390 File Offset: 0x00047590
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public GuildAuctReqType reqtype
		{
			get
			{
				return this._reqtype ?? GuildAuctReqType.GART_ACT_TYPE;
			}
			set
			{
				this._reqtype = new GuildAuctReqType?(value);
			}
		}

		// Token: 0x17000BB1 RID: 2993
		// (get) Token: 0x0600259A RID: 9626 RVA: 0x000493A0 File Offset: 0x000475A0
		// (set) Token: 0x0600259B RID: 9627 RVA: 0x000493C0 File Offset: 0x000475C0
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
					this._reqtype = (value ? new GuildAuctReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x00049404 File Offset: 0x00047604
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x0004941C File Offset: 0x0004761C
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x0600259E RID: 9630 RVA: 0x00049428 File Offset: 0x00047628
		// (set) Token: 0x0600259F RID: 9631 RVA: 0x00049455 File Offset: 0x00047655
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x060025A0 RID: 9632 RVA: 0x00049464 File Offset: 0x00047664
		// (set) Token: 0x060025A1 RID: 9633 RVA: 0x00049484 File Offset: 0x00047684
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x060025A2 RID: 9634 RVA: 0x000494C8 File Offset: 0x000476C8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060025A3 RID: 9635 RVA: 0x000494E0 File Offset: 0x000476E0
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000BB4 RID: 2996
		// (get) Token: 0x060025A4 RID: 9636 RVA: 0x000494EC File Offset: 0x000476EC
		// (set) Token: 0x060025A5 RID: 9637 RVA: 0x00049518 File Offset: 0x00047718
		[ProtoMember(3, IsRequired = false, Name = "acttype", DataFormat = DataFormat.TwosComplement)]
		public int acttype
		{
			get
			{
				return this._acttype ?? 0;
			}
			set
			{
				this._acttype = new int?(value);
			}
		}

		// Token: 0x17000BB5 RID: 2997
		// (get) Token: 0x060025A6 RID: 9638 RVA: 0x00049528 File Offset: 0x00047728
		// (set) Token: 0x060025A7 RID: 9639 RVA: 0x00049548 File Offset: 0x00047748
		[XmlIgnore]
		[Browsable(false)]
		public bool acttypeSpecified
		{
			get
			{
				return this._acttype != null;
			}
			set
			{
				bool flag = value == (this._acttype == null);
				if (flag)
				{
					this._acttype = (value ? new int?(this.acttype) : null);
				}
			}
		}

		// Token: 0x060025A8 RID: 9640 RVA: 0x0004958C File Offset: 0x0004778C
		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		// Token: 0x060025A9 RID: 9641 RVA: 0x000495A4 File Offset: 0x000477A4
		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

		// Token: 0x17000BB6 RID: 2998
		// (get) Token: 0x060025AA RID: 9642 RVA: 0x000495B0 File Offset: 0x000477B0
		// (set) Token: 0x060025AB RID: 9643 RVA: 0x000495DC File Offset: 0x000477DC
		[ProtoMember(4, IsRequired = false, Name = "itemtype", DataFormat = DataFormat.TwosComplement)]
		public int itemtype
		{
			get
			{
				return this._itemtype ?? 0;
			}
			set
			{
				this._itemtype = new int?(value);
			}
		}

		// Token: 0x17000BB7 RID: 2999
		// (get) Token: 0x060025AC RID: 9644 RVA: 0x000495EC File Offset: 0x000477EC
		// (set) Token: 0x060025AD RID: 9645 RVA: 0x0004960C File Offset: 0x0004780C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemtypeSpecified
		{
			get
			{
				return this._itemtype != null;
			}
			set
			{
				bool flag = value == (this._itemtype == null);
				if (flag)
				{
					this._itemtype = (value ? new int?(this.itemtype) : null);
				}
			}
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x00049650 File Offset: 0x00047850
		private bool ShouldSerializeitemtype()
		{
			return this.itemtypeSpecified;
		}

		// Token: 0x060025AF RID: 9647 RVA: 0x00049668 File Offset: 0x00047868
		private void Resetitemtype()
		{
			this.itemtypeSpecified = false;
		}

		// Token: 0x17000BB8 RID: 3000
		// (get) Token: 0x060025B0 RID: 9648 RVA: 0x00049674 File Offset: 0x00047874
		// (set) Token: 0x060025B1 RID: 9649 RVA: 0x000496A0 File Offset: 0x000478A0
		[ProtoMember(5, IsRequired = false, Name = "curauctprice", DataFormat = DataFormat.TwosComplement)]
		public uint curauctprice
		{
			get
			{
				return this._curauctprice ?? 0U;
			}
			set
			{
				this._curauctprice = new uint?(value);
			}
		}

		// Token: 0x17000BB9 RID: 3001
		// (get) Token: 0x060025B2 RID: 9650 RVA: 0x000496B0 File Offset: 0x000478B0
		// (set) Token: 0x060025B3 RID: 9651 RVA: 0x000496D0 File Offset: 0x000478D0
		[XmlIgnore]
		[Browsable(false)]
		public bool curauctpriceSpecified
		{
			get
			{
				return this._curauctprice != null;
			}
			set
			{
				bool flag = value == (this._curauctprice == null);
				if (flag)
				{
					this._curauctprice = (value ? new uint?(this.curauctprice) : null);
				}
			}
		}

		// Token: 0x060025B4 RID: 9652 RVA: 0x00049714 File Offset: 0x00047914
		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		// Token: 0x060025B5 RID: 9653 RVA: 0x0004972C File Offset: 0x0004792C
		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		// Token: 0x060025B6 RID: 9654 RVA: 0x00049738 File Offset: 0x00047938
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400094F RID: 2383
		private GuildAuctReqType? _reqtype;

		// Token: 0x04000950 RID: 2384
		private ulong? _uid;

		// Token: 0x04000951 RID: 2385
		private int? _acttype;

		// Token: 0x04000952 RID: 2386
		private int? _itemtype;

		// Token: 0x04000953 RID: 2387
		private uint? _curauctprice;

		// Token: 0x04000954 RID: 2388
		private IExtension extensionObject;
	}
}
