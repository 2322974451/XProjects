using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayClickRes")]
	[Serializable]
	public class PayClickRes : IExtensible
	{

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

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "payCardFirstClick", DataFormat = DataFormat.Default)]
		public bool payCardFirstClick
		{
			get
			{
				return this._payCardFirstClick ?? false;
			}
			set
			{
				this._payCardFirstClick = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool payCardFirstClickSpecified
		{
			get
			{
				return this._payCardFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payCardFirstClick == null);
				if (flag)
				{
					this._payCardFirstClick = (value ? new bool?(this.payCardFirstClick) : null);
				}
			}
		}

		private bool ShouldSerializepayCardFirstClick()
		{
			return this.payCardFirstClickSpecified;
		}

		private void ResetpayCardFirstClick()
		{
			this.payCardFirstClickSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "payAileenFirstClick", DataFormat = DataFormat.Default)]
		public bool payAileenFirstClick
		{
			get
			{
				return this._payAileenFirstClick ?? false;
			}
			set
			{
				this._payAileenFirstClick = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool payAileenFirstClickSpecified
		{
			get
			{
				return this._payAileenFirstClick != null;
			}
			set
			{
				bool flag = value == (this._payAileenFirstClick == null);
				if (flag)
				{
					this._payAileenFirstClick = (value ? new bool?(this.payAileenFirstClick) : null);
				}
			}
		}

		private bool ShouldSerializepayAileenFirstClick()
		{
			return this.payAileenFirstClickSpecified;
		}

		private void ResetpayAileenFirstClick()
		{
			this.payAileenFirstClickSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "payFirstAwardClick", DataFormat = DataFormat.Default)]
		public bool payFirstAwardClick
		{
			get
			{
				return this._payFirstAwardClick ?? false;
			}
			set
			{
				this._payFirstAwardClick = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool payFirstAwardClickSpecified
		{
			get
			{
				return this._payFirstAwardClick != null;
			}
			set
			{
				bool flag = value == (this._payFirstAwardClick == null);
				if (flag)
				{
					this._payFirstAwardClick = (value ? new bool?(this.payFirstAwardClick) : null);
				}
			}
		}

		private bool ShouldSerializepayFirstAwardClick()
		{
			return this.payFirstAwardClickSpecified;
		}

		private void ResetpayFirstAwardClick()
		{
			this.payFirstAwardClickSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "growthFundClick", DataFormat = DataFormat.Default)]
		public bool growthFundClick
		{
			get
			{
				return this._growthFundClick ?? false;
			}
			set
			{
				this._growthFundClick = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool growthFundClickSpecified
		{
			get
			{
				return this._growthFundClick != null;
			}
			set
			{
				bool flag = value == (this._growthFundClick == null);
				if (flag)
				{
					this._growthFundClick = (value ? new bool?(this.growthFundClick) : null);
				}
			}
		}

		private bool ShouldSerializegrowthFundClick()
		{
			return this.growthFundClickSpecified;
		}

		private void ResetgrowthFundClick()
		{
			this.growthFundClickSpecified = false;
		}

		[ProtoMember(6, Name = "info", DataFormat = DataFormat.Default)]
		public List<PayMember> info
		{
			get
			{
				return this._info;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errcode;

		private bool? _payCardFirstClick;

		private bool? _payAileenFirstClick;

		private bool? _payFirstAwardClick;

		private bool? _growthFundClick;

		private readonly List<PayMember> _info = new List<PayMember>();

		private IExtension extensionObject;
	}
}
