using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UseItemArg")]
	[Serializable]
	public class UseItemArg : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
		public uint OpType
		{
			get
			{
				return this._OpType ?? 0U;
			}
			set
			{
				this._OpType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool OpTypeSpecified
		{
			get
			{
				return this._OpType != null;
			}
			set
			{
				bool flag = value == (this._OpType == null);
				if (flag)
				{
					this._OpType = (value ? new uint?(this.OpType) : null);
				}
			}
		}

		private bool ShouldSerializeOpType()
		{
			return this.OpTypeSpecified;
		}

		private void ResetOpType()
		{
			this.OpTypeSpecified = false;
		}

		[ProtoMember(4, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public ulong petid
		{
			get
			{
				return this._petid ?? 0UL;
			}
			set
			{
				this._petid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new ulong?(this.petid) : null);
				}
			}
		}

		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "color_id", DataFormat = DataFormat.TwosComplement)]
		public uint color_id
		{
			get
			{
				return this._color_id ?? 0U;
			}
			set
			{
				this._color_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool color_idSpecified
		{
			get
			{
				return this._color_id != null;
			}
			set
			{
				bool flag = value == (this._color_id == null);
				if (flag)
				{
					this._color_id = (value ? new uint?(this.color_id) : null);
				}
			}
		}

		private bool ShouldSerializecolor_id()
		{
			return this.color_idSpecified;
		}

		private void Resetcolor_id()
		{
			this.color_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _count;

		private uint? _OpType;

		private readonly List<ulong> _uids = new List<ulong>();

		private uint? _itemID;

		private ulong? _petid;

		private uint? _suit_id;

		private uint? _color_id;

		private IExtension extensionObject;
	}
}
