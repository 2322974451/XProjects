using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleRoleBrief")]
	[Serializable]
	public class LeagueBattleRoleBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
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
					this._profession = (value ? new uint?(this.profession) : null);
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

		[ProtoMember(6, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private uint? _level;

		private uint? _serverid;

		private uint? _profession;

		private uint? _ppt;

		private uint? _pkpoint;

		private string _account;

		private IExtension extensionObject;
	}
}
