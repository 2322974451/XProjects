using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageRelationOpRes")]
	[Serializable]
	public class MarriageRelationOpRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "oppoRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong oppoRoleID
		{
			get
			{
				return this._oppoRoleID ?? 0UL;
			}
			set
			{
				this._oppoRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool oppoRoleIDSpecified
		{
			get
			{
				return this._oppoRoleID != null;
			}
			set
			{
				bool flag = value == (this._oppoRoleID == null);
				if (flag)
				{
					this._oppoRoleID = (value ? new ulong?(this.oppoRoleID) : null);
				}
			}
		}

		private bool ShouldSerializeoppoRoleID()
		{
			return this.oppoRoleIDSpecified;
		}

		private void ResetoppoRoleID()
		{
			this.oppoRoleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "oppoRoleName", DataFormat = DataFormat.Default)]
		public string oppoRoleName
		{
			get
			{
				return this._oppoRoleName ?? "";
			}
			set
			{
				this._oppoRoleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool oppoRoleNameSpecified
		{
			get
			{
				return this._oppoRoleName != null;
			}
			set
			{
				bool flag = value == (this._oppoRoleName == null);
				if (flag)
				{
					this._oppoRoleName = (value ? this.oppoRoleName : null);
				}
			}
		}

		private bool ShouldSerializeoppoRoleName()
		{
			return this.oppoRoleNameSpecified;
		}

		private void ResetoppoRoleName()
		{
			this.oppoRoleNameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private ulong? _oppoRoleID;

		private string _oppoRoleName;

		private IExtension extensionObject;
	}
}
