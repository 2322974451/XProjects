using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayFriendItemRes")]
	[Serializable]
	public class PayFriendItemRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		private void Resetret()
		{
			this.retSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "url_param", DataFormat = DataFormat.Default)]
		public string url_param
		{
			get
			{
				return this._url_param ?? "";
			}
			set
			{
				this._url_param = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool url_paramSpecified
		{
			get
			{
				return this._url_param != null;
			}
			set
			{
				bool flag = value == (this._url_param == null);
				if (flag)
				{
					this._url_param = (value ? this.url_param : null);
				}
			}
		}

		private bool ShouldSerializeurl_param()
		{
			return this.url_paramSpecified;
		}

		private void Reseturl_param()
		{
			this.url_paramSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "billno", DataFormat = DataFormat.Default)]
		public string billno
		{
			get
			{
				return this._billno ?? "";
			}
			set
			{
				this._billno = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool billnoSpecified
		{
			get
			{
				return this._billno != null;
			}
			set
			{
				bool flag = value == (this._billno == null);
				if (flag)
				{
					this._billno = (value ? this.billno : null);
				}
			}
		}

		private bool ShouldSerializebillno()
		{
			return this.billnoSpecified;
		}

		private void Resetbillno()
		{
			this.billnoSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "paramid", DataFormat = DataFormat.Default)]
		public string paramid
		{
			get
			{
				return this._paramid ?? "";
			}
			set
			{
				this._paramid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramidSpecified
		{
			get
			{
				return this._paramid != null;
			}
			set
			{
				bool flag = value == (this._paramid == null);
				if (flag)
				{
					this._paramid = (value ? this.paramid : null);
				}
			}
		}

		private bool ShouldSerializeparamid()
		{
			return this.paramidSpecified;
		}

		private void Resetparamid()
		{
			this.paramidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "price", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ret;

		private string _token;

		private string _url_param;

		private string _billno;

		private string _paramid;

		private uint? _price;

		private IExtension extensionObject;
	}
}
