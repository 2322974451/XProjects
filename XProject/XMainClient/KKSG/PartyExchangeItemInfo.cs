using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PartyExchangeItemInfo")]
	[Serializable]
	public class PartyExchangeItemInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
		public uint profession_id
		{
			get
			{
				return this._profession_id ?? 0U;
			}
			set
			{
				this._profession_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool profession_idSpecified
		{
			get
			{
				return this._profession_id != null;
			}
			set
			{
				bool flag = value == (this._profession_id == null);
				if (flag)
				{
					this._profession_id = (value ? new uint?(this.profession_id) : null);
				}
			}
		}

		private bool ShouldSerializeprofession_id()
		{
			return this.profession_idSpecified;
		}

		private void Resetprofession_id()
		{
			this.profession_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _role_id;

		private uint? _time;

		private uint? _level;

		private string _name;

		private uint? _profession_id;

		private IExtension extensionObject;
	}
}
