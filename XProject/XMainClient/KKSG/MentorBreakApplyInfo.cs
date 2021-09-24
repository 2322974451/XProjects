using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorBreakApplyInfo")]
	[Serializable]
	public class MentorBreakApplyInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition pos
		{
			get
			{
				return this._pos ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._pos = new EMentorRelationPosition?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new EMentorRelationPosition?(this.pos) : null);
				}
			}
		}

		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		private void Resetpos()
		{
			this.posSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "breakTime", DataFormat = DataFormat.TwosComplement)]
		public int breakTime
		{
			get
			{
				return this._breakTime ?? 0;
			}
			set
			{
				this._breakTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool breakTimeSpecified
		{
			get
			{
				return this._breakTime != null;
			}
			set
			{
				bool flag = value == (this._breakTime == null);
				if (flag)
				{
					this._breakTime = (value ? new int?(this.breakTime) : null);
				}
			}
		}

		private bool ShouldSerializebreakTime()
		{
			return this.breakTimeSpecified;
		}

		private void ResetbreakTime()
		{
			this.breakTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private EMentorRelationPosition? _pos;

		private int? _breakTime;

		private ulong? _roleID;

		private string _roleName;

		private IExtension extensionObject;
	}
}
