using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageApplyResponse")]
	[Serializable]
	public class MarriageApplyResponse : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isAgree", DataFormat = DataFormat.Default)]
		public bool isAgree
		{
			get
			{
				return this._isAgree ?? false;
			}
			set
			{
				this._isAgree = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isAgreeSpecified
		{
			get
			{
				return this._isAgree != null;
			}
			set
			{
				bool flag = value == (this._isAgree == null);
				if (flag)
				{
					this._isAgree = (value ? new bool?(this.isAgree) : null);
				}
			}
		}

		private bool ShouldSerializeisAgree()
		{
			return this.isAgreeSpecified;
		}

		private void ResetisAgree()
		{
			this.isAgreeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
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

		private bool? _isAgree;

		private ulong? _roleID;

		private string _roleName;

		private IExtension extensionObject;
	}
}
