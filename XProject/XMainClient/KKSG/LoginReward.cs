using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginReward")]
	[Serializable]
	public class LoginReward : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public int day
		{
			get
			{
				return this._day ?? 0;
			}
			set
			{
				this._day = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new int?(this.day) : null);
				}
			}
		}

		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		private void Resetday()
		{
			this.daySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState state
		{
			get
			{
				return this._state ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._state = new LoginRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new LoginRewardState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(4, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _day;

		private uint? _itemID;

		private LoginRewardState? _state;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
