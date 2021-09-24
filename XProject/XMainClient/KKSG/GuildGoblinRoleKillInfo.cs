using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildGoblinRoleKillInfo")]
	[Serializable]
	public class GuildGoblinRoleKillInfo : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public int killNum
		{
			get
			{
				return this._killNum ?? 0;
			}
			set
			{
				this._killNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new int?(this.killNum) : null);
				}
			}
		}

		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "ability", DataFormat = DataFormat.TwosComplement)]
		public int ability
		{
			get
			{
				return this._ability ?? 0;
			}
			set
			{
				this._ability = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abilitySpecified
		{
			get
			{
				return this._ability != null;
			}
			set
			{
				bool flag = value == (this._ability == null);
				if (flag)
				{
					this._ability = (value ? new int?(this.ability) : null);
				}
			}
		}

		private bool ShouldSerializeability()
		{
			return this.abilitySpecified;
		}

		private void Resetability()
		{
			this.abilitySpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public int roleLevel
		{
			get
			{
				return this._roleLevel ?? 0;
			}
			set
			{
				this._roleLevel = new int?(value);
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
					this._roleLevel = (value ? new int?(this.roleLevel) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _roleName;

		private int? _killNum;

		private int? _ability;

		private int? _roleLevel;

		private IExtension extensionObject;
	}
}
