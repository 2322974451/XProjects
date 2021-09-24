using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PartnerShopItemClient")]
	[Serializable]
	public class PartnerShopItemClient : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buy_count", DataFormat = DataFormat.TwosComplement)]
		public uint buy_count
		{
			get
			{
				return this._buy_count ?? 0U;
			}
			set
			{
				this._buy_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buy_countSpecified
		{
			get
			{
				return this._buy_count != null;
			}
			set
			{
				bool flag = value == (this._buy_count == null);
				if (flag)
				{
					this._buy_count = (value ? new uint?(this.buy_count) : null);
				}
			}
		}

		private bool ShouldSerializebuy_count()
		{
			return this.buy_countSpecified;
		}

		private void Resetbuy_count()
		{
			this.buy_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private uint? _itemid;

		private uint? _buy_count;

		private IExtension extensionObject;
	}
}
