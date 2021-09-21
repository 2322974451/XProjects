using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A3 RID: 1699
	[ProtoContract(Name = "IBShopItemInfo")]
	[Serializable]
	public class IBShopItemInfo : IExtensible
	{
		// Token: 0x1700230C RID: 8972
		// (get) Token: 0x06006EBA RID: 28346 RVA: 0x000D3E08 File Offset: 0x000D2008
		// (set) Token: 0x06006EBB RID: 28347 RVA: 0x000D3E34 File Offset: 0x000D2034
		[ProtoMember(1, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
		public uint goodsid
		{
			get
			{
				return this._goodsid ?? 0U;
			}
			set
			{
				this._goodsid = new uint?(value);
			}
		}

		// Token: 0x1700230D RID: 8973
		// (get) Token: 0x06006EBC RID: 28348 RVA: 0x000D3E44 File Offset: 0x000D2044
		// (set) Token: 0x06006EBD RID: 28349 RVA: 0x000D3E64 File Offset: 0x000D2064
		[XmlIgnore]
		[Browsable(false)]
		public bool goodsidSpecified
		{
			get
			{
				return this._goodsid != null;
			}
			set
			{
				bool flag = value == (this._goodsid == null);
				if (flag)
				{
					this._goodsid = (value ? new uint?(this.goodsid) : null);
				}
			}
		}

		// Token: 0x06006EBE RID: 28350 RVA: 0x000D3EA8 File Offset: 0x000D20A8
		private bool ShouldSerializegoodsid()
		{
			return this.goodsidSpecified;
		}

		// Token: 0x06006EBF RID: 28351 RVA: 0x000D3EC0 File Offset: 0x000D20C0
		private void Resetgoodsid()
		{
			this.goodsidSpecified = false;
		}

		// Token: 0x1700230E RID: 8974
		// (get) Token: 0x06006EC0 RID: 28352 RVA: 0x000D3ECC File Offset: 0x000D20CC
		// (set) Token: 0x06006EC1 RID: 28353 RVA: 0x000D3EF8 File Offset: 0x000D20F8
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

		// Token: 0x1700230F RID: 8975
		// (get) Token: 0x06006EC2 RID: 28354 RVA: 0x000D3F08 File Offset: 0x000D2108
		// (set) Token: 0x06006EC3 RID: 28355 RVA: 0x000D3F28 File Offset: 0x000D2128
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

		// Token: 0x06006EC4 RID: 28356 RVA: 0x000D3F6C File Offset: 0x000D216C
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06006EC5 RID: 28357 RVA: 0x000D3F84 File Offset: 0x000D2184
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17002310 RID: 8976
		// (get) Token: 0x06006EC6 RID: 28358 RVA: 0x000D3F90 File Offset: 0x000D2190
		// (set) Token: 0x06006EC7 RID: 28359 RVA: 0x000D3FBC File Offset: 0x000D21BC
		[ProtoMember(3, IsRequired = false, Name = "nlimittime", DataFormat = DataFormat.TwosComplement)]
		public uint nlimittime
		{
			get
			{
				return this._nlimittime ?? 0U;
			}
			set
			{
				this._nlimittime = new uint?(value);
			}
		}

		// Token: 0x17002311 RID: 8977
		// (get) Token: 0x06006EC8 RID: 28360 RVA: 0x000D3FCC File Offset: 0x000D21CC
		// (set) Token: 0x06006EC9 RID: 28361 RVA: 0x000D3FEC File Offset: 0x000D21EC
		[XmlIgnore]
		[Browsable(false)]
		public bool nlimittimeSpecified
		{
			get
			{
				return this._nlimittime != null;
			}
			set
			{
				bool flag = value == (this._nlimittime == null);
				if (flag)
				{
					this._nlimittime = (value ? new uint?(this.nlimittime) : null);
				}
			}
		}

		// Token: 0x06006ECA RID: 28362 RVA: 0x000D4030 File Offset: 0x000D2230
		private bool ShouldSerializenlimittime()
		{
			return this.nlimittimeSpecified;
		}

		// Token: 0x06006ECB RID: 28363 RVA: 0x000D4048 File Offset: 0x000D2248
		private void Resetnlimittime()
		{
			this.nlimittimeSpecified = false;
		}

		// Token: 0x17002312 RID: 8978
		// (get) Token: 0x06006ECC RID: 28364 RVA: 0x000D4054 File Offset: 0x000D2254
		// (set) Token: 0x06006ECD RID: 28365 RVA: 0x000D4080 File Offset: 0x000D2280
		[ProtoMember(4, IsRequired = false, Name = "nlimitcount", DataFormat = DataFormat.TwosComplement)]
		public uint nlimitcount
		{
			get
			{
				return this._nlimitcount ?? 0U;
			}
			set
			{
				this._nlimitcount = new uint?(value);
			}
		}

		// Token: 0x17002313 RID: 8979
		// (get) Token: 0x06006ECE RID: 28366 RVA: 0x000D4090 File Offset: 0x000D2290
		// (set) Token: 0x06006ECF RID: 28367 RVA: 0x000D40B0 File Offset: 0x000D22B0
		[XmlIgnore]
		[Browsable(false)]
		public bool nlimitcountSpecified
		{
			get
			{
				return this._nlimitcount != null;
			}
			set
			{
				bool flag = value == (this._nlimitcount == null);
				if (flag)
				{
					this._nlimitcount = (value ? new uint?(this.nlimitcount) : null);
				}
			}
		}

		// Token: 0x06006ED0 RID: 28368 RVA: 0x000D40F4 File Offset: 0x000D22F4
		private bool ShouldSerializenlimitcount()
		{
			return this.nlimitcountSpecified;
		}

		// Token: 0x06006ED1 RID: 28369 RVA: 0x000D410C File Offset: 0x000D230C
		private void Resetnlimitcount()
		{
			this.nlimitcountSpecified = false;
		}

		// Token: 0x17002314 RID: 8980
		// (get) Token: 0x06006ED2 RID: 28370 RVA: 0x000D4118 File Offset: 0x000D2318
		// (set) Token: 0x06006ED3 RID: 28371 RVA: 0x000D4144 File Offset: 0x000D2344
		[ProtoMember(5, IsRequired = false, Name = "nbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint nbuycount
		{
			get
			{
				return this._nbuycount ?? 0U;
			}
			set
			{
				this._nbuycount = new uint?(value);
			}
		}

		// Token: 0x17002315 RID: 8981
		// (get) Token: 0x06006ED4 RID: 28372 RVA: 0x000D4154 File Offset: 0x000D2354
		// (set) Token: 0x06006ED5 RID: 28373 RVA: 0x000D4174 File Offset: 0x000D2374
		[XmlIgnore]
		[Browsable(false)]
		public bool nbuycountSpecified
		{
			get
			{
				return this._nbuycount != null;
			}
			set
			{
				bool flag = value == (this._nbuycount == null);
				if (flag)
				{
					this._nbuycount = (value ? new uint?(this.nbuycount) : null);
				}
			}
		}

		// Token: 0x06006ED6 RID: 28374 RVA: 0x000D41B8 File Offset: 0x000D23B8
		private bool ShouldSerializenbuycount()
		{
			return this.nbuycountSpecified;
		}

		// Token: 0x06006ED7 RID: 28375 RVA: 0x000D41D0 File Offset: 0x000D23D0
		private void Resetnbuycount()
		{
			this.nbuycountSpecified = false;
		}

		// Token: 0x17002316 RID: 8982
		// (get) Token: 0x06006ED8 RID: 28376 RVA: 0x000D41DC File Offset: 0x000D23DC
		// (set) Token: 0x06006ED9 RID: 28377 RVA: 0x000D4208 File Offset: 0x000D2408
		[ProtoMember(6, IsRequired = false, Name = "gift", DataFormat = DataFormat.Default)]
		public bool gift
		{
			get
			{
				return this._gift ?? false;
			}
			set
			{
				this._gift = new bool?(value);
			}
		}

		// Token: 0x17002317 RID: 8983
		// (get) Token: 0x06006EDA RID: 28378 RVA: 0x000D4218 File Offset: 0x000D2418
		// (set) Token: 0x06006EDB RID: 28379 RVA: 0x000D4238 File Offset: 0x000D2438
		[XmlIgnore]
		[Browsable(false)]
		public bool giftSpecified
		{
			get
			{
				return this._gift != null;
			}
			set
			{
				bool flag = value == (this._gift == null);
				if (flag)
				{
					this._gift = (value ? new bool?(this.gift) : null);
				}
			}
		}

		// Token: 0x06006EDC RID: 28380 RVA: 0x000D427C File Offset: 0x000D247C
		private bool ShouldSerializegift()
		{
			return this.giftSpecified;
		}

		// Token: 0x06006EDD RID: 28381 RVA: 0x000D4294 File Offset: 0x000D2494
		private void Resetgift()
		{
			this.giftSpecified = false;
		}

		// Token: 0x06006EDE RID: 28382 RVA: 0x000D42A0 File Offset: 0x000D24A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A7F RID: 6783
		private uint? _goodsid;

		// Token: 0x04001A80 RID: 6784
		private uint? _itemid;

		// Token: 0x04001A81 RID: 6785
		private uint? _nlimittime;

		// Token: 0x04001A82 RID: 6786
		private uint? _nlimitcount;

		// Token: 0x04001A83 RID: 6787
		private uint? _nbuycount;

		// Token: 0x04001A84 RID: 6788
		private bool? _gift;

		// Token: 0x04001A85 RID: 6789
		private IExtension extensionObject;
	}
}
