using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayNotifyArg")]
	[Serializable]
	public class PayNotifyArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "p", DataFormat = DataFormat.Default)]
		public string p
		{
			get
			{
				return this._p ?? "";
			}
			set
			{
				this._p = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pSpecified
		{
			get
			{
				return this._p != null;
			}
			set
			{
				bool flag = value == (this._p == null);
				if (flag)
				{
					this._p = (value ? this.p : null);
				}
			}
		}

		private bool ShouldSerializep()
		{
			return this.pSpecified;
		}

		private void Resetp()
		{
			this.pSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "v", DataFormat = DataFormat.Default)]
		public string v
		{
			get
			{
				return this._v ?? "";
			}
			set
			{
				this._v = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vSpecified
		{
			get
			{
				return this._v != null;
			}
			set
			{
				bool flag = value == (this._v == null);
				if (flag)
				{
					this._v = (value ? this.v : null);
				}
			}
		}

		private bool ShouldSerializev()
		{
			return this.vSpecified;
		}

		private void Resetv()
		{
			this.vSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "ext", DataFormat = DataFormat.Default)]
		public string ext
		{
			get
			{
				return this._ext ?? "";
			}
			set
			{
				this._ext = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extSpecified
		{
			get
			{
				return this._ext != null;
			}
			set
			{
				bool flag = value == (this._ext == null);
				if (flag)
				{
					this._ext = (value ? this.ext : null);
				}
			}
		}

		private bool ShouldSerializeext()
		{
			return this.extSpecified;
		}

		private void Resetext()
		{
			this.extSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PayParamType type
		{
			get
			{
				return this._type ?? PayParamType.PAY_PARAM_NONE;
			}
			set
			{
				this._type = new PayParamType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new PayParamType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
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

		[ProtoMember(6, IsRequired = false, Name = "amount", DataFormat = DataFormat.TwosComplement)]
		public int amount
		{
			get
			{
				return this._amount ?? 0;
			}
			set
			{
				this._amount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool amountSpecified
		{
			get
			{
				return this._amount != null;
			}
			set
			{
				bool flag = value == (this._amount == null);
				if (flag)
				{
					this._amount = (value ? new int?(this.amount) : null);
				}
			}
		}

		private bool ShouldSerializeamount()
		{
			return this.amountSpecified;
		}

		private void Resetamount()
		{
			this.amountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayParameterInfo data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _p;

		private string _v;

		private string _ext;

		private PayParamType? _type;

		private string _paramid;

		private int? _amount;

		private PayParameterInfo _data = null;

		private int? _count;

		private IExtension extensionObject;
	}
}
