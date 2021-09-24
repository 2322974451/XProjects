using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBShopItemInfo")]
	[Serializable]
	public class IBShopItemInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "nlimittime", DataFormat = DataFormat.TwosComplement)]
		public uint nlimittime
		{
			get
			{
				return this._nlimittime ?? 0U;
			}
			set
			{
				this._nlimittime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nlimittimeSpecified
		{
			get
			{
				return this._nlimittime != null;
			}
			set
			{
				bool flag = value == (this._nlimittime == null);
				if (flag)
				{
					this._nlimittime = (value ? new uint?(this.nlimittime) : null);
				}
			}
		}

		private bool ShouldSerializenlimittime()
		{
			return this.nlimittimeSpecified;
		}

		private void Resetnlimittime()
		{
			this.nlimittimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nlimitcount", DataFormat = DataFormat.TwosComplement)]
		public uint nlimitcount
		{
			get
			{
				return this._nlimitcount ?? 0U;
			}
			set
			{
				this._nlimitcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nlimitcountSpecified
		{
			get
			{
				return this._nlimitcount != null;
			}
			set
			{
				bool flag = value == (this._nlimitcount == null);
				if (flag)
				{
					this._nlimitcount = (value ? new uint?(this.nlimitcount) : null);
				}
			}
		}

		private bool ShouldSerializenlimitcount()
		{
			return this.nlimitcountSpecified;
		}

		private void Resetnlimitcount()
		{
			this.nlimitcountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "nbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint nbuycount
		{
			get
			{
				return this._nbuycount ?? 0U;
			}
			set
			{
				this._nbuycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nbuycountSpecified
		{
			get
			{
				return this._nbuycount != null;
			}
			set
			{
				bool flag = value == (this._nbuycount == null);
				if (flag)
				{
					this._nbuycount = (value ? new uint?(this.nbuycount) : null);
				}
			}
		}

		private bool ShouldSerializenbuycount()
		{
			return this.nbuycountSpecified;
		}

		private void Resetnbuycount()
		{
			this.nbuycountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "gift", DataFormat = DataFormat.Default)]
		public bool gift
		{
			get
			{
				return this._gift ?? false;
			}
			set
			{
				this._gift = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool giftSpecified
		{
			get
			{
				return this._gift != null;
			}
			set
			{
				bool flag = value == (this._gift == null);
				if (flag)
				{
					this._gift = (value ? new bool?(this.gift) : null);
				}
			}
		}

		private bool ShouldSerializegift()
		{
			return this.giftSpecified;
		}

		private void Resetgift()
		{
			this.giftSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _goodsid;

		private uint? _itemid;

		private uint? _nlimittime;

		private uint? _nlimitcount;

		private uint? _nbuycount;

		private bool? _gift;

		private IExtension extensionObject;
	}
}
