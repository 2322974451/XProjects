using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RewardInfo")]
	[Serializable]
	public class RewardInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "UniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong UniqueId
		{
			get
			{
				return this._UniqueId ?? 0UL;
			}
			set
			{
				this._UniqueId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool UniqueIdSpecified
		{
			get
			{
				return this._UniqueId != null;
			}
			set
			{
				bool flag = value == (this._UniqueId == null);
				if (flag)
				{
					this._UniqueId = (value ? new ulong?(this.UniqueId) : null);
				}
			}
		}

		private bool ShouldSerializeUniqueId()
		{
			return this.UniqueIdSpecified;
		}

		private void ResetUniqueId()
		{
			this.UniqueIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type ?? 0U;
			}
			set
			{
				this._Type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TypeSpecified
		{
			get
			{
				return this._Type != null;
			}
			set
			{
				bool flag = value == (this._Type == null);
				if (flag)
				{
					this._Type = (value ? new uint?(this.Type) : null);
				}
			}
		}

		private bool ShouldSerializeType()
		{
			return this.TypeSpecified;
		}

		private void ResetType()
		{
			this.TypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "SubType", DataFormat = DataFormat.TwosComplement)]
		public uint SubType
		{
			get
			{
				return this._SubType ?? 0U;
			}
			set
			{
				this._SubType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SubTypeSpecified
		{
			get
			{
				return this._SubType != null;
			}
			set
			{
				bool flag = value == (this._SubType == null);
				if (flag)
				{
					this._SubType = (value ? new uint?(this.SubType) : null);
				}
			}
		}

		private bool ShouldSerializeSubType()
		{
			return this.SubTypeSpecified;
		}

		private void ResetSubType()
		{
			this.SubTypeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "State", DataFormat = DataFormat.TwosComplement)]
		public uint State
		{
			get
			{
				return this._State ?? 0U;
			}
			set
			{
				this._State = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool StateSpecified
		{
			get
			{
				return this._State != null;
			}
			set
			{
				bool flag = value == (this._State == null);
				if (flag)
				{
					this._State = (value ? new uint?(this.State) : null);
				}
			}
		}

		private bool ShouldSerializeState()
		{
			return this.StateSpecified;
		}

		private void ResetState()
		{
			this.StateSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp ?? 0U;
			}
			set
			{
				this._TimeStamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TimeStampSpecified
		{
			get
			{
				return this._TimeStamp != null;
			}
			set
			{
				bool flag = value == (this._TimeStamp == null);
				if (flag)
				{
					this._TimeStamp = (value ? new uint?(this.TimeStamp) : null);
				}
			}
		}

		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		[ProtoMember(6, Name = "Param", DataFormat = DataFormat.Default)]
		public List<string> Param
		{
			get
			{
				return this._Param;
			}
		}

		[ProtoMember(7, Name = "Item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> Item
		{
			get
			{
				return this._Item;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "comment", DataFormat = DataFormat.Default)]
		public string comment
		{
			get
			{
				return this._comment ?? "";
			}
			set
			{
				this._comment = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commentSpecified
		{
			get
			{
				return this._comment != null;
			}
			set
			{
				bool flag = value == (this._comment == null);
				if (flag)
				{
					this._comment = (value ? this.comment : null);
				}
			}
		}

		private bool ShouldSerializecomment()
		{
			return this.commentSpecified;
		}

		private void Resetcomment()
		{
			this.commentSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "uniqueday", DataFormat = DataFormat.TwosComplement)]
		public uint uniqueday
		{
			get
			{
				return this._uniqueday ?? 0U;
			}
			set
			{
				this._uniqueday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uniquedaySpecified
		{
			get
			{
				return this._uniqueday != null;
			}
			set
			{
				bool flag = value == (this._uniqueday == null);
				if (flag)
				{
					this._uniqueday = (value ? new uint?(this.uniqueday) : null);
				}
			}
		}

		private bool ShouldSerializeuniqueday()
		{
			return this.uniquedaySpecified;
		}

		private void Resetuniqueday()
		{
			this.uniquedaySpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "isget", DataFormat = DataFormat.Default)]
		public bool isget
		{
			get
			{
				return this._isget ?? false;
			}
			set
			{
				this._isget = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isgetSpecified
		{
			get
			{
				return this._isget != null;
			}
			set
			{
				bool flag = value == (this._isget == null);
				if (flag)
				{
					this._isget = (value ? new bool?(this.isget) : null);
				}
			}
		}

		private bool ShouldSerializeisget()
		{
			return this.isgetSpecified;
		}

		private void Resetisget()
		{
			this.isgetSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _UniqueId;

		private uint? _Type;

		private uint? _SubType;

		private uint? _State;

		private uint? _TimeStamp;

		private readonly List<string> _Param = new List<string>();

		private readonly List<ItemBrief> _Item = new List<ItemBrief>();

		private string _name;

		private string _comment;

		private uint? _uniqueday;

		private bool? _isget;

		private IExtension extensionObject;
	}
}
