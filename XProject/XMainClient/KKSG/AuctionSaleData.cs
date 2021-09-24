using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionSaleData")]
	[Serializable]
	public class AuctionSaleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "perprice", DataFormat = DataFormat.TwosComplement)]
		public uint perprice
		{
			get
			{
				return this._perprice ?? 0U;
			}
			set
			{
				this._perprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool perpriceSpecified
		{
			get
			{
				return this._perprice != null;
			}
			set
			{
				bool flag = value == (this._perprice == null);
				if (flag)
				{
					this._perprice = (value ? new uint?(this.perprice) : null);
				}
			}
		}

		private bool ShouldSerializeperprice()
		{
			return this.perpriceSpecified;
		}

		private void Resetperprice()
		{
			this.perpriceSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "duelefttime", DataFormat = DataFormat.TwosComplement)]
		public uint duelefttime
		{
			get
			{
				return this._duelefttime ?? 0U;
			}
			set
			{
				this._duelefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool duelefttimeSpecified
		{
			get
			{
				return this._duelefttime != null;
			}
			set
			{
				bool flag = value == (this._duelefttime == null);
				if (flag)
				{
					this._duelefttime = (value ? new uint?(this.duelefttime) : null);
				}
			}
		}

		private bool ShouldSerializeduelefttime()
		{
			return this.duelefttimeSpecified;
		}

		private void Resetduelefttime()
		{
			this.duelefttimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "itemdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item itemdata
		{
			get
			{
				return this._itemdata;
			}
			set
			{
				this._itemdata = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _perprice;

		private uint? _duelefttime;

		private Item _itemdata = null;

		private IExtension extensionObject;
	}
}
