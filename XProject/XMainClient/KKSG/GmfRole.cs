using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfRole")]
	[Serializable]
	public class GmfRole : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public GuildMatchFightState state
		{
			get
			{
				return this._state ?? GuildMatchFightState.GUILD_MF_NONE;
			}
			set
			{
				this._state = new GuildMatchFightState?(value);
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
					this._state = (value ? new GuildMatchFightState?(this.state) : null);
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

		[ProtoMember(6, IsRequired = false, Name = "guildpos", DataFormat = DataFormat.TwosComplement)]
		public int guildpos
		{
			get
			{
				return this._guildpos ?? 0;
			}
			set
			{
				this._guildpos = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildposSpecified
		{
			get
			{
				return this._guildpos != null;
			}
			set
			{
				bool flag = value == (this._guildpos == null);
				if (flag)
				{
					this._guildpos = (value ? new int?(this.guildpos) : null);
				}
			}
		}

		private bool ShouldSerializeguildpos()
		{
			return this.guildposSpecified;
		}

		private void Resetguildpos()
		{
			this.guildposSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _rolename;

		private uint? _pkpoint;

		private int? _index;

		private GuildMatchFightState? _state;

		private int? _guildpos;

		private int? _profession;

		private uint? _ppt;

		private IExtension extensionObject;
	}
}
