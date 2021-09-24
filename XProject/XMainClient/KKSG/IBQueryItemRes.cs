using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBQueryItemRes")]
	[Serializable]
	public class IBQueryItemRes : IExtensible
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

		[ProtoMember(2, Name = "iteminfo", DataFormat = DataFormat.Default)]
		public List<IBShopItemInfo> iteminfo
		{
			get
			{
				return this._iteminfo;
			}
		}

		[ProtoMember(3, Name = "newproducts", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newproducts
		{
			get
			{
				return this._newproducts;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "viptab", DataFormat = DataFormat.Default)]
		public bool viptab
		{
			get
			{
				return this._viptab ?? false;
			}
			set
			{
				this._viptab = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool viptabSpecified
		{
			get
			{
				return this._viptab != null;
			}
			set
			{
				bool flag = value == (this._viptab == null);
				if (flag)
				{
					this._viptab = (value ? new bool?(this.viptab) : null);
				}
			}
		}

		private bool ShouldSerializeviptab()
		{
			return this.viptabSpecified;
		}

		private void Resetviptab()
		{
			this.viptabSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<IBShopItemInfo> _iteminfo = new List<IBShopItemInfo>();

		private readonly List<uint> _newproducts = new List<uint>();

		private bool? _viptab;

		private IExtension extensionObject;
	}
}
