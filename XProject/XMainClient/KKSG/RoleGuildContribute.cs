using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleGuildContribute")]
	[Serializable]
	public class RoleGuildContribute : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "RoleName", DataFormat = DataFormat.Default)]
		public string RoleName
		{
			get
			{
				return this._RoleName ?? "";
			}
			set
			{
				this._RoleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RoleNameSpecified
		{
			get
			{
				return this._RoleName != null;
			}
			set
			{
				bool flag = value == (this._RoleName == null);
				if (flag)
				{
					this._RoleName = (value ? this.RoleName : null);
				}
			}
		}

		private bool ShouldSerializeRoleName()
		{
			return this.RoleNameSpecified;
		}

		private void ResetRoleName()
		{
			this.RoleNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new int?(this.contribute) : null);
				}
			}
		}

		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleId;

		private string _RoleName;

		private int? _contribute;

		private uint? _updateTime;

		private IExtension extensionObject;
	}
}
