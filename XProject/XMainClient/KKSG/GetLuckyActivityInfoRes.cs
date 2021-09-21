using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F3 RID: 1267
	[ProtoContract(Name = "GetLuckyActivityInfoRes")]
	[Serializable]
	public class GetLuckyActivityInfoRes : IExtensible
	{
		// Token: 0x1700140C RID: 5132
		// (get) Token: 0x0600417B RID: 16763 RVA: 0x0007CABC File Offset: 0x0007ACBC
		// (set) Token: 0x0600417C RID: 16764 RVA: 0x0007CAE8 File Offset: 0x0007ACE8
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

		// Token: 0x1700140D RID: 5133
		// (get) Token: 0x0600417D RID: 16765 RVA: 0x0007CAF8 File Offset: 0x0007ACF8
		// (set) Token: 0x0600417E RID: 16766 RVA: 0x0007CB18 File Offset: 0x0007AD18
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

		// Token: 0x0600417F RID: 16767 RVA: 0x0007CB5C File Offset: 0x0007AD5C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004180 RID: 16768 RVA: 0x0007CB74 File Offset: 0x0007AD74
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700140E RID: 5134
		// (get) Token: 0x06004181 RID: 16769 RVA: 0x0007CB80 File Offset: 0x0007AD80
		[ProtoMember(2, Name = "itemrecord", DataFormat = DataFormat.Default)]
		public List<ItemRecord> itemrecord
		{
			get
			{
				return this._itemrecord;
			}
		}

		// Token: 0x1700140F RID: 5135
		// (get) Token: 0x06004182 RID: 16770 RVA: 0x0007CB98 File Offset: 0x0007AD98
		// (set) Token: 0x06004183 RID: 16771 RVA: 0x0007CBC4 File Offset: 0x0007ADC4
		[ProtoMember(3, IsRequired = false, Name = "currencytype", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001410 RID: 5136
		// (get) Token: 0x06004184 RID: 16772 RVA: 0x0007CBD4 File Offset: 0x0007ADD4
		// (set) Token: 0x06004185 RID: 16773 RVA: 0x0007CBF4 File Offset: 0x0007ADF4
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

		// Token: 0x06004186 RID: 16774 RVA: 0x0007CC38 File Offset: 0x0007AE38
		private bool ShouldSerializecurrencytype()
		{
			return this.currencytypeSpecified;
		}

		// Token: 0x06004187 RID: 16775 RVA: 0x0007CC50 File Offset: 0x0007AE50
		private void Resetcurrencytype()
		{
			this.currencytypeSpecified = false;
		}

		// Token: 0x17001411 RID: 5137
		// (get) Token: 0x06004188 RID: 16776 RVA: 0x0007CC5C File Offset: 0x0007AE5C
		// (set) Token: 0x06004189 RID: 16777 RVA: 0x0007CC88 File Offset: 0x0007AE88
		[ProtoMember(4, IsRequired = false, Name = "price", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001412 RID: 5138
		// (get) Token: 0x0600418A RID: 16778 RVA: 0x0007CC98 File Offset: 0x0007AE98
		// (set) Token: 0x0600418B RID: 16779 RVA: 0x0007CCB8 File Offset: 0x0007AEB8
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

		// Token: 0x0600418C RID: 16780 RVA: 0x0007CCFC File Offset: 0x0007AEFC
		private bool ShouldSerializeprice()
		{
			return this.priceSpecified;
		}

		// Token: 0x0600418D RID: 16781 RVA: 0x0007CD14 File Offset: 0x0007AF14
		private void Resetprice()
		{
			this.priceSpecified = false;
		}

		// Token: 0x17001413 RID: 5139
		// (get) Token: 0x0600418E RID: 16782 RVA: 0x0007CD20 File Offset: 0x0007AF20
		// (set) Token: 0x0600418F RID: 16783 RVA: 0x0007CD4C File Offset: 0x0007AF4C
		[ProtoMember(5, IsRequired = false, Name = "ispay", DataFormat = DataFormat.Default)]
		public bool ispay
		{
			get
			{
				return this._ispay ?? false;
			}
			set
			{
				this._ispay = new bool?(value);
			}
		}

		// Token: 0x17001414 RID: 5140
		// (get) Token: 0x06004190 RID: 16784 RVA: 0x0007CD5C File Offset: 0x0007AF5C
		// (set) Token: 0x06004191 RID: 16785 RVA: 0x0007CD7C File Offset: 0x0007AF7C
		[XmlIgnore]
		[Browsable(false)]
		public bool ispaySpecified
		{
			get
			{
				return this._ispay != null;
			}
			set
			{
				bool flag = value == (this._ispay == null);
				if (flag)
				{
					this._ispay = (value ? new bool?(this.ispay) : null);
				}
			}
		}

		// Token: 0x06004192 RID: 16786 RVA: 0x0007CDC0 File Offset: 0x0007AFC0
		private bool ShouldSerializeispay()
		{
			return this.ispaySpecified;
		}

		// Token: 0x06004193 RID: 16787 RVA: 0x0007CDD8 File Offset: 0x0007AFD8
		private void Resetispay()
		{
			this.ispaySpecified = false;
		}

		// Token: 0x06004194 RID: 16788 RVA: 0x0007CDE4 File Offset: 0x0007AFE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001055 RID: 4181
		private ErrorCode? _errorcode;

		// Token: 0x04001056 RID: 4182
		private readonly List<ItemRecord> _itemrecord = new List<ItemRecord>();

		// Token: 0x04001057 RID: 4183
		private uint? _currencytype;

		// Token: 0x04001058 RID: 4184
		private uint? _price;

		// Token: 0x04001059 RID: 4185
		private bool? _ispay;

		// Token: 0x0400105A RID: 4186
		private IExtension extensionObject;
	}
}
