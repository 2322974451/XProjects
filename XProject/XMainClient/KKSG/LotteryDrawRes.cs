using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F7 RID: 1271
	[ProtoContract(Name = "LotteryDrawRes")]
	[Serializable]
	public class LotteryDrawRes : IExtensible
	{
		// Token: 0x17001417 RID: 5143
		// (get) Token: 0x060041A2 RID: 16802 RVA: 0x0007CF3C File Offset: 0x0007B13C
		// (set) Token: 0x060041A3 RID: 16803 RVA: 0x0007CF68 File Offset: 0x0007B168
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001418 RID: 5144
		// (get) Token: 0x060041A4 RID: 16804 RVA: 0x0007CF78 File Offset: 0x0007B178
		// (set) Token: 0x060041A5 RID: 16805 RVA: 0x0007CF98 File Offset: 0x0007B198
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

		// Token: 0x060041A6 RID: 16806 RVA: 0x0007CFDC File Offset: 0x0007B1DC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x0007CFF4 File Offset: 0x0007B1F4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001419 RID: 5145
		// (get) Token: 0x060041A8 RID: 16808 RVA: 0x0007D000 File Offset: 0x0007B200
		[ProtoMember(2, Name = "itemrecord", DataFormat = DataFormat.Default)]
		public List<ItemRecord> itemrecord
		{
			get
			{
				return this._itemrecord;
			}
		}

		// Token: 0x1700141A RID: 5146
		// (get) Token: 0x060041A9 RID: 16809 RVA: 0x0007D018 File Offset: 0x0007B218
		// (set) Token: 0x060041AA RID: 16810 RVA: 0x0007D044 File Offset: 0x0007B244
		[ProtoMember(3, IsRequired = false, Name = "price", DataFormat = DataFormat.TwosComplement)]
		public uint price
		{
			get
			{
				return this._price ?? 0U;
			}
			set
			{
				this._price = new uint?(value);
			}
		}

		// Token: 0x1700141B RID: 5147
		// (get) Token: 0x060041AB RID: 16811 RVA: 0x0007D054 File Offset: 0x0007B254
		// (set) Token: 0x060041AC RID: 16812 RVA: 0x0007D074 File Offset: 0x0007B274
		[XmlIgnore]
		[Browsable(false)]
		public bool priceSpecified
		{
			get
			{
				return this._price != null;
			}
			set
			{
				bool flag = value == (this._price == null);
				if (flag)
				{
					this._price = (value ? new uint?(this.price) : null);
				}
			}
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x0007D0B8 File Offset: 0x0007B2B8
		private bool ShouldSerializeprice()
		{
			return this.priceSpecified;
		}

		// Token: 0x060041AE RID: 16814 RVA: 0x0007D0D0 File Offset: 0x0007B2D0
		private void Resetprice()
		{
			this.priceSpecified = false;
		}

		// Token: 0x1700141C RID: 5148
		// (get) Token: 0x060041AF RID: 16815 RVA: 0x0007D0DC File Offset: 0x0007B2DC
		// (set) Token: 0x060041B0 RID: 16816 RVA: 0x0007D108 File Offset: 0x0007B308
		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x1700141D RID: 5149
		// (get) Token: 0x060041B1 RID: 16817 RVA: 0x0007D118 File Offset: 0x0007B318
		// (set) Token: 0x060041B2 RID: 16818 RVA: 0x0007D138 File Offset: 0x0007B338
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x060041B3 RID: 16819 RVA: 0x0007D17C File Offset: 0x0007B37C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x060041B4 RID: 16820 RVA: 0x0007D194 File Offset: 0x0007B394
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x1700141E RID: 5150
		// (get) Token: 0x060041B5 RID: 16821 RVA: 0x0007D1A0 File Offset: 0x0007B3A0
		// (set) Token: 0x060041B6 RID: 16822 RVA: 0x0007D1CC File Offset: 0x0007B3CC
		[ProtoMember(5, IsRequired = false, Name = "currencytype", DataFormat = DataFormat.TwosComplement)]
		public uint currencytype
		{
			get
			{
				return this._currencytype ?? 0U;
			}
			set
			{
				this._currencytype = new uint?(value);
			}
		}

		// Token: 0x1700141F RID: 5151
		// (get) Token: 0x060041B7 RID: 16823 RVA: 0x0007D1DC File Offset: 0x0007B3DC
		// (set) Token: 0x060041B8 RID: 16824 RVA: 0x0007D1FC File Offset: 0x0007B3FC
		[XmlIgnore]
		[Browsable(false)]
		public bool currencytypeSpecified
		{
			get
			{
				return this._currencytype != null;
			}
			set
			{
				bool flag = value == (this._currencytype == null);
				if (flag)
				{
					this._currencytype = (value ? new uint?(this.currencytype) : null);
				}
			}
		}

		// Token: 0x060041B9 RID: 16825 RVA: 0x0007D240 File Offset: 0x0007B440
		private bool ShouldSerializecurrencytype()
		{
			return this.currencytypeSpecified;
		}

		// Token: 0x060041BA RID: 16826 RVA: 0x0007D258 File Offset: 0x0007B458
		private void Resetcurrencytype()
		{
			this.currencytypeSpecified = false;
		}

		// Token: 0x060041BB RID: 16827 RVA: 0x0007D264 File Offset: 0x0007B464
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400105F RID: 4191
		private ErrorCode? _errorcode;

		// Token: 0x04001060 RID: 4192
		private readonly List<ItemRecord> _itemrecord = new List<ItemRecord>();

		// Token: 0x04001061 RID: 4193
		private uint? _price;

		// Token: 0x04001062 RID: 4194
		private uint? _index;

		// Token: 0x04001063 RID: 4195
		private uint? _currencytype;

		// Token: 0x04001064 RID: 4196
		private IExtension extensionObject;
	}
}
