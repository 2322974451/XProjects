using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LotteryDrawRes")]
	[Serializable]
	public class LotteryDrawRes : IExtensible
	{

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

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, Name = "itemrecord", DataFormat = DataFormat.Default)]
		public List<ItemRecord> itemrecord
		{
			get
			{
				return this._itemrecord;
			}
		}

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

		private bool ShouldSerializeprice()
		{
			return this.priceSpecified;
		}

		private void Resetprice()
		{
			this.priceSpecified = false;
		}

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

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
		}

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

		private bool ShouldSerializecurrencytype()
		{
			return this.currencytypeSpecified;
		}

		private void Resetcurrencytype()
		{
			this.currencytypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<ItemRecord> _itemrecord = new List<ItemRecord>();

		private uint? _price;

		private uint? _index;

		private uint? _currencytype;

		private IExtension extensionObject;
	}
}
