using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleSmallInfo")]
	[Serializable]
	public class RoleSmallInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public uint roleLevel
		{
			get
			{
				return this._roleLevel ?? 0U;
			}
			set
			{
				this._roleLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new uint?(this.roleLevel) : null);
				}
			}
		}

		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "roleProfession", DataFormat = DataFormat.TwosComplement)]
		public uint roleProfession
		{
			get
			{
				return this._roleProfession ?? 0U;
			}
			set
			{
				this._roleProfession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleProfessionSpecified
		{
			get
			{
				return this._roleProfession != null;
			}
			set
			{
				bool flag = value == (this._roleProfession == null);
				if (flag)
				{
					this._roleProfession = (value ? new uint?(this.roleProfession) : null);
				}
			}
		}

		private bool ShouldSerializeroleProfession()
		{
			return this.roleProfessionSpecified;
		}

		private void ResetroleProfession()
		{
			this.roleProfessionSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "rolePPT", DataFormat = DataFormat.TwosComplement)]
		public uint rolePPT
		{
			get
			{
				return this._rolePPT ?? 0U;
			}
			set
			{
				this._rolePPT = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolePPTSpecified
		{
			get
			{
				return this._rolePPT != null;
			}
			set
			{
				bool flag = value == (this._rolePPT == null);
				if (flag)
				{
					this._rolePPT = (value ? new uint?(this.rolePPT) : null);
				}
			}
		}

		private bool ShouldSerializerolePPT()
		{
			return this.rolePPTSpecified;
		}

		private void ResetrolePPT()
		{
			this.rolePPTSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _roleName;

		private uint? _roleLevel;

		private uint? _roleProfession;

		private uint? _rolePPT;

		private IExtension extensionObject;
	}
}
