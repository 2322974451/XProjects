using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ZoneRoleInfo")]
	[Serializable]
	public class ZoneRoleInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public RoleType roleprofession
		{
			get
			{
				return this._roleprofession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._roleprofession = new RoleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new RoleType?(this.roleprofession) : null);
				}
			}
		}

		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
		public uint rolelevel
		{
			get
			{
				return this._rolelevel ?? 0U;
			}
			set
			{
				this._rolelevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolelevelSpecified
		{
			get
			{
				return this._rolelevel != null;
			}
			set
			{
				bool flag = value == (this._rolelevel == null);
				if (flag)
				{
					this._rolelevel = (value ? new uint?(this.rolelevel) : null);
				}
			}
		}

		private bool ShouldSerializerolelevel()
		{
			return this.rolelevelSpecified;
		}

		private void Resetrolelevel()
		{
			this.rolelevelSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "paycnt", DataFormat = DataFormat.TwosComplement)]
		public uint paycnt
		{
			get
			{
				return this._paycnt ?? 0U;
			}
			set
			{
				this._paycnt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paycntSpecified
		{
			get
			{
				return this._paycnt != null;
			}
			set
			{
				bool flag = value == (this._paycnt == null);
				if (flag)
				{
					this._paycnt = (value ? new uint?(this.paycnt) : null);
				}
			}
		}

		private bool ShouldSerializepaycnt()
		{
			return this.paycntSpecified;
		}

		private void Resetpaycnt()
		{
			this.paycntSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "opentime", DataFormat = DataFormat.TwosComplement)]
		public uint opentime
		{
			get
			{
				return this._opentime ?? 0U;
			}
			set
			{
				this._opentime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opentimeSpecified
		{
			get
			{
				return this._opentime != null;
			}
			set
			{
				bool flag = value == (this._opentime == null);
				if (flag)
				{
					this._opentime = (value ? new uint?(this.opentime) : null);
				}
			}
		}

		private bool ShouldSerializeopentime()
		{
			return this.opentimeSpecified;
		}

		private void Resetopentime()
		{
			this.opentimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _serverid;

		private string _servername;

		private ulong? _roleid;

		private string _rolename;

		private RoleType? _roleprofession;

		private uint? _rolelevel;

		private uint? _paycnt;

		private uint? _opentime;

		private IExtension extensionObject;
	}
}
