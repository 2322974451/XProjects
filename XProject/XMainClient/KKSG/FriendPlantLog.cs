using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendPlantLog")]
	[Serializable]
	public class FriendPlantLog : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "role_name", DataFormat = DataFormat.Default)]
		public string role_name
		{
			get
			{
				return this._role_name ?? "";
			}
			set
			{
				this._role_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role_nameSpecified
		{
			get
			{
				return this._role_name != null;
			}
			set
			{
				bool flag = value == (this._role_name == null);
				if (flag)
				{
					this._role_name = (value ? this.role_name : null);
				}
			}
		}

		private bool ShouldSerializerole_name()
		{
			return this.role_nameSpecified;
		}

		private void Resetrole_name()
		{
			this.role_nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "exist_sprite", DataFormat = DataFormat.Default)]
		public bool exist_sprite
		{
			get
			{
				return this._exist_sprite ?? false;
			}
			set
			{
				this._exist_sprite = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool exist_spriteSpecified
		{
			get
			{
				return this._exist_sprite != null;
			}
			set
			{
				bool flag = value == (this._exist_sprite == null);
				if (flag)
				{
					this._exist_sprite = (value ? new bool?(this.exist_sprite) : null);
				}
			}
		}

		private bool ShouldSerializeexist_sprite()
		{
			return this.exist_spriteSpecified;
		}

		private void Resetexist_sprite()
		{
			this.exist_spriteSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "mature", DataFormat = DataFormat.Default)]
		public bool mature
		{
			get
			{
				return this._mature ?? false;
			}
			set
			{
				this._mature = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool matureSpecified
		{
			get
			{
				return this._mature != null;
			}
			set
			{
				bool flag = value == (this._mature == null);
				if (flag)
				{
					this._mature = (value ? new bool?(this.mature) : null);
				}
			}
		}

		private bool ShouldSerializemature()
		{
			return this.matureSpecified;
		}

		private void Resetmature()
		{
			this.matureSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "abnormal_state", DataFormat = DataFormat.Default)]
		public bool abnormal_state
		{
			get
			{
				return this._abnormal_state ?? false;
			}
			set
			{
				this._abnormal_state = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abnormal_stateSpecified
		{
			get
			{
				return this._abnormal_state != null;
			}
			set
			{
				bool flag = value == (this._abnormal_state == null);
				if (flag)
				{
					this._abnormal_state = (value ? new bool?(this.abnormal_state) : null);
				}
			}
		}

		private bool ShouldSerializeabnormal_state()
		{
			return this.abnormal_stateSpecified;
		}

		private void Resetabnormal_state()
		{
			this.abnormal_stateSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "help_times", DataFormat = DataFormat.TwosComplement)]
		public uint help_times
		{
			get
			{
				return this._help_times ?? 0U;
			}
			set
			{
				this._help_times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool help_timesSpecified
		{
			get
			{
				return this._help_times != null;
			}
			set
			{
				bool flag = value == (this._help_times == null);
				if (flag)
				{
					this._help_times = (value ? new uint?(this.help_times) : null);
				}
			}
		}

		private bool ShouldSerializehelp_times()
		{
			return this.help_timesSpecified;
		}

		private void Resethelp_times()
		{
			this.help_timesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _role_id;

		private string _role_name;

		private uint? _profession_id;

		private bool? _exist_sprite;

		private bool? _mature;

		private bool? _abnormal_state;

		private uint? _help_times;

		private IExtension extensionObject;
	}
}
