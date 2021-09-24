using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpRoleBrief")]
	[Serializable]
	public class PvpRoleBrief : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
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
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "roleserverid", DataFormat = DataFormat.TwosComplement)]
		public uint roleserverid
		{
			get
			{
				return this._roleserverid ?? 0U;
			}
			set
			{
				this._roleserverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleserveridSpecified
		{
			get
			{
				return this._roleserverid != null;
			}
			set
			{
				bool flag = value == (this._roleserverid == null);
				if (flag)
				{
					this._roleserverid = (value ? new uint?(this.roleserverid) : null);
				}
			}
		}

		private bool ShouldSerializeroleserverid()
		{
			return this.roleserveridSpecified;
		}

		private void Resetroleserverid()
		{
			this.roleserveridSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _rolename;

		private uint? _rolelevel;

		private uint? _roleprofession;

		private uint? _roleserverid;

		private IExtension extensionObject;
	}
}
