using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildAuctReqArg")]
	[Serializable]
	public class GuildAuctReqArg : IExtensible
	{

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

		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

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

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

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

		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

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

		private bool ShouldSerializeitemtype()
		{
			return this.itemtypeSpecified;
		}

		private void Resetitemtype()
		{
			this.itemtypeSpecified = false;
		}

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

		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildAuctReqType? _reqtype;

		private ulong? _uid;

		private int? _acttype;

		private int? _itemtype;

		private uint? _curauctprice;

		private IExtension extensionObject;
	}
}
