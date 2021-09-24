using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpNowUnitData")]
	[Serializable]
	public class PvpNowUnitData : IExtensible
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

		[ProtoMember(5, IsRequired = false, Name = "killCount", DataFormat = DataFormat.TwosComplement)]
		public int killCount
		{
			get
			{
				return this._killCount ?? 0;
			}
			set
			{
				this._killCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killCountSpecified
		{
			get
			{
				return this._killCount != null;
			}
			set
			{
				bool flag = value == (this._killCount == null);
				if (flag)
				{
					this._killCount = (value ? new int?(this.killCount) : null);
				}
			}
		}

		private bool ShouldSerializekillCount()
		{
			return this.killCountSpecified;
		}

		private void ResetkillCount()
		{
			this.killCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "dieCount", DataFormat = DataFormat.TwosComplement)]
		public int dieCount
		{
			get
			{
				return this._dieCount ?? 0;
			}
			set
			{
				this._dieCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dieCountSpecified
		{
			get
			{
				return this._dieCount != null;
			}
			set
			{
				bool flag = value == (this._dieCount == null);
				if (flag)
				{
					this._dieCount = (value ? new int?(this.dieCount) : null);
				}
			}
		}

		private bool ShouldSerializedieCount()
		{
			return this.dieCountSpecified;
		}

		private void ResetdieCount()
		{
			this.dieCountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public int groupid
		{
			get
			{
				return this._groupid ?? 0;
			}
			set
			{
				this._groupid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new int?(this.groupid) : null);
				}
			}
		}

		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _roleName;

		private uint? _roleLevel;

		private uint? _roleProfession;

		private int? _killCount;

		private int? _dieCount;

		private int? _groupid;

		private IExtension extensionObject;
	}
}
