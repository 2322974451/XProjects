using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ShopRecordOne")]
	[Serializable]
	public class ShopRecordOne : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
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
					this._type = (value ? new uint?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<Item> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(4, Name = "slots", DataFormat = DataFormat.TwosComplement)]
		public List<uint> slots
		{
			get
			{
				return this._slots;
			}
		}

		[ProtoMember(5, Name = "buycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> buycount
		{
			get
			{
				return this._buycount;
			}
		}

		[ProtoMember(6, Name = "dailybuycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dailybuycount
		{
			get
			{
				return this._dailybuycount;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "refreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint refreshcount
		{
			get
			{
				return this._refreshcount ?? 0U;
			}
			set
			{
				this._refreshcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshcountSpecified
		{
			get
			{
				return this._refreshcount != null;
			}
			set
			{
				bool flag = value == (this._refreshcount == null);
				if (flag)
				{
					this._refreshcount = (value ? new uint?(this.refreshcount) : null);
				}
			}
		}

		private bool ShouldSerializerefreshcount()
		{
			return this.refreshcountSpecified;
		}

		private void Resetrefreshcount()
		{
			this.refreshcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "refreshtime", DataFormat = DataFormat.TwosComplement)]
		public uint refreshtime
		{
			get
			{
				return this._refreshtime ?? 0U;
			}
			set
			{
				this._refreshtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshtimeSpecified
		{
			get
			{
				return this._refreshtime != null;
			}
			set
			{
				bool flag = value == (this._refreshtime == null);
				if (flag)
				{
					this._refreshtime = (value ? new uint?(this.refreshtime) : null);
				}
			}
		}

		private bool ShouldSerializerefreshtime()
		{
			return this.refreshtimeSpecified;
		}

		private void Resetrefreshtime()
		{
			this.refreshtimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "refreshday", DataFormat = DataFormat.TwosComplement)]
		public uint refreshday
		{
			get
			{
				return this._refreshday ?? 0U;
			}
			set
			{
				this._refreshday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshdaySpecified
		{
			get
			{
				return this._refreshday != null;
			}
			set
			{
				bool flag = value == (this._refreshday == null);
				if (flag)
				{
					this._refreshday = (value ? new uint?(this.refreshday) : null);
				}
			}
		}

		private bool ShouldSerializerefreshday()
		{
			return this.refreshdaySpecified;
		}

		private void Resetrefreshday()
		{
			this.refreshdaySpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		[ProtoMember(11, Name = "weekbuycount", DataFormat = DataFormat.Default)]
		public List<ItemBrief> weekbuycount
		{
			get
			{
				return this._weekbuycount;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _updatetime;

		private readonly List<Item> _items = new List<Item>();

		private readonly List<uint> _slots = new List<uint>();

		private readonly List<ItemBrief> _buycount = new List<ItemBrief>();

		private readonly List<ItemBrief> _dailybuycount = new List<ItemBrief>();

		private uint? _refreshcount;

		private uint? _refreshtime;

		private uint? _refreshday;

		private bool? _ishint;

		private readonly List<ItemBrief> _weekbuycount = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
