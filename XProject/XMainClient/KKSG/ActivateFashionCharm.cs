using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivateFashionCharm")]
	[Serializable]
	public class ActivateFashionCharm : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
		public uint suit_id
		{
			get
			{
				return this._suit_id ?? 0U;
			}
			set
			{
				this._suit_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool suit_idSpecified
		{
			get
			{
				return this._suit_id != null;
			}
			set
			{
				bool flag = value == (this._suit_id == null);
				if (flag)
				{
					this._suit_id = (value ? new uint?(this.suit_id) : null);
				}
			}
		}

		private bool ShouldSerializesuit_id()
		{
			return this.suit_idSpecified;
		}

		private void Resetsuit_id()
		{
			this.suit_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "activate_count", DataFormat = DataFormat.TwosComplement)]
		public uint activate_count
		{
			get
			{
				return this._activate_count ?? 0U;
			}
			set
			{
				this._activate_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activate_countSpecified
		{
			get
			{
				return this._activate_count != null;
			}
			set
			{
				bool flag = value == (this._activate_count == null);
				if (flag)
				{
					this._activate_count = (value ? new uint?(this.activate_count) : null);
				}
			}
		}

		private bool ShouldSerializeactivate_count()
		{
			return this.activate_countSpecified;
		}

		private void Resetactivate_count()
		{
			this.activate_countSpecified = false;
		}

		[ProtoMember(3, Name = "items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> items
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

		private uint? _suit_id;

		private uint? _activate_count;

		private readonly List<uint> _items = new List<uint>();

		private IExtension extensionObject;
	}
}
