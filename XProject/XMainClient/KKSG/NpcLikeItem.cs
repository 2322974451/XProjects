using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcLikeItem")]
	[Serializable]
	public class NpcLikeItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "addexp", DataFormat = DataFormat.TwosComplement)]
		public uint addexp
		{
			get
			{
				return this._addexp ?? 0U;
			}
			set
			{
				this._addexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool addexpSpecified
		{
			get
			{
				return this._addexp != null;
			}
			set
			{
				bool flag = value == (this._addexp == null);
				if (flag)
				{
					this._addexp = (value ? new uint?(this.addexp) : null);
				}
			}
		}

		private bool ShouldSerializeaddexp()
		{
			return this.addexpSpecified;
		}

		private void Resetaddexp()
		{
			this.addexpSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public NpcFlItemType type
		{
			get
			{
				return this._type ?? NpcFlItemType.NPCFL_ITEM_NORMAL;
			}
			set
			{
				this._type = new NpcFlItemType?(value);
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
					this._type = (value ? new NpcFlItemType?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _itemid;

		private uint? _itemcount;

		private uint? _addexp;

		private NpcFlItemType? _type;

		private IExtension extensionObject;
	}
}
