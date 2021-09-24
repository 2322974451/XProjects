using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetInviteInfo")]
	[Serializable]
	public class PetInviteInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "petuid", DataFormat = DataFormat.TwosComplement)]
		public ulong petuid
		{
			get
			{
				return this._petuid ?? 0UL;
			}
			set
			{
				this._petuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petuidSpecified
		{
			get
			{
				return this._petuid != null;
			}
			set
			{
				bool flag = value == (this._petuid == null);
				if (flag)
				{
					this._petuid = (value ? new ulong?(this.petuid) : null);
				}
			}
		}

		private bool ShouldSerializepetuid()
		{
			return this.petuidSpecified;
		}

		private void Resetpetuid()
		{
			this.petuidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "petconfigid", DataFormat = DataFormat.TwosComplement)]
		public uint petconfigid
		{
			get
			{
				return this._petconfigid ?? 0U;
			}
			set
			{
				this._petconfigid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petconfigidSpecified
		{
			get
			{
				return this._petconfigid != null;
			}
			set
			{
				bool flag = value == (this._petconfigid == null);
				if (flag)
				{
					this._petconfigid = (value ? new uint?(this.petconfigid) : null);
				}
			}
		}

		private bool ShouldSerializepetconfigid()
		{
			return this.petconfigidSpecified;
		}

		private void Resetpetconfigid()
		{
			this.petconfigidSpecified = false;
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

		[ProtoMember(7, IsRequired = false, Name = "petppt", DataFormat = DataFormat.TwosComplement)]
		public uint petppt
		{
			get
			{
				return this._petppt ?? 0U;
			}
			set
			{
				this._petppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petpptSpecified
		{
			get
			{
				return this._petppt != null;
			}
			set
			{
				bool flag = value == (this._petppt == null);
				if (flag)
				{
					this._petppt = (value ? new uint?(this.petppt) : null);
				}
			}
		}

		private bool ShouldSerializepetppt()
		{
			return this.petpptSpecified;
		}

		private void Resetpetppt()
		{
			this.petpptSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private ulong? _petuid;

		private uint? _petconfigid;

		private string _rolename;

		private uint? _profession;

		private uint? _ppt;

		private uint? _petppt;

		private IExtension extensionObject;
	}
}
