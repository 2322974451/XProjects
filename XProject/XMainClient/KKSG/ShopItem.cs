using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ShopItem")]
	[Serializable]
	public class ShopItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item Item
		{
			get
			{
				return this._Item;
			}
			set
			{
				this._Item = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "dailybuycount", DataFormat = DataFormat.TwosComplement)]
		public uint dailybuycount
		{
			get
			{
				return this._dailybuycount ?? 0U;
			}
			set
			{
				this._dailybuycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dailybuycountSpecified
		{
			get
			{
				return this._dailybuycount != null;
			}
			set
			{
				bool flag = value == (this._dailybuycount == null);
				if (flag)
				{
					this._dailybuycount = (value ? new uint?(this.dailybuycount) : null);
				}
			}
		}

		private bool ShouldSerializedailybuycount()
		{
			return this.dailybuycountSpecified;
		}

		private void Resetdailybuycount()
		{
			this.dailybuycountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "weekbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint weekbuycount
		{
			get
			{
				return this._weekbuycount ?? 0U;
			}
			set
			{
				this._weekbuycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekbuycountSpecified
		{
			get
			{
				return this._weekbuycount != null;
			}
			set
			{
				bool flag = value == (this._weekbuycount == null);
				if (flag)
				{
					this._weekbuycount = (value ? new uint?(this.weekbuycount) : null);
				}
			}
		}

		private bool ShouldSerializeweekbuycount()
		{
			return this.weekbuycountSpecified;
		}

		private void Resetweekbuycount()
		{
			this.weekbuycountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private Item _Item = null;

		private uint? _slot;

		private uint? _buycount;

		private uint? _dailybuycount;

		private uint? _weekbuycount;

		private IExtension extensionObject;
	}
}
