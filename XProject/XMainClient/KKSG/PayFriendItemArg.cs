using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayFriendItemArg")]
	[Serializable]
	public class PayFriendItemArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "payparam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayParameterInfo payparam
		{
			get
			{
				return this._payparam;
			}
			set
			{
				this._payparam = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializegoodsid()
		{
			return this.goodsidSpecified;
		}

		private void Resetgoodsid()
		{
			this.goodsidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
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
					this._count = (value ? new uint?(this.count) : null);
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

		[ProtoMember(4, IsRequired = false, Name = "toroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong toroleid
		{
			get
			{
				return this._toroleid ?? 0UL;
			}
			set
			{
				this._toroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool toroleidSpecified
		{
			get
			{
				return this._toroleid != null;
			}
			set
			{
				bool flag = value == (this._toroleid == null);
				if (flag)
				{
					this._toroleid = (value ? new ulong?(this.toroleid) : null);
				}
			}
		}

		private bool ShouldSerializetoroleid()
		{
			return this.toroleidSpecified;
		}

		private void Resettoroleid()
		{
			this.toroleidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public string text
		{
			get
			{
				return this._text ?? "";
			}
			set
			{
				this._text = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		private void Resettext()
		{
			this.textSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PayParameterInfo _payparam = null;

		private uint? _goodsid;

		private uint? _count;

		private ulong? _toroleid;

		private string _text;

		private IExtension extensionObject;
	}
}
