using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarRoleRank")]
	[Serializable]
	public class ResWarRoleRank : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "res", DataFormat = DataFormat.TwosComplement)]
		public uint res
		{
			get
			{
				return this._res ?? 0U;
			}
			set
			{
				this._res = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resSpecified
		{
			get
			{
				return this._res != null;
			}
			set
			{
				bool flag = value == (this._res == null);
				if (flag)
				{
					this._res = (value ? new uint?(this.res) : null);
				}
			}
		}

		private bool ShouldSerializeres()
		{
			return this.resSpecified;
		}

		private void Resetres()
		{
			this.resSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "guild", DataFormat = DataFormat.TwosComplement)]
		public ulong guild
		{
			get
			{
				return this._guild ?? 0UL;
			}
			set
			{
				this._guild = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildSpecified
		{
			get
			{
				return this._guild != null;
			}
			set
			{
				bool flag = value == (this._guild == null);
				if (flag)
				{
					this._guild = (value ? new ulong?(this.guild) : null);
				}
			}
		}

		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _rolename;

		private string _guildname;

		private uint? _res;

		private ulong? _roleid;

		private ulong? _guild;

		private IExtension extensionObject;
	}
}
