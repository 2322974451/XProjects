using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FMDArg")]
	[Serializable]
	public class FMDArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "quitRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong quitRoleID
		{
			get
			{
				return this._quitRoleID ?? 0UL;
			}
			set
			{
				this._quitRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool quitRoleIDSpecified
		{
			get
			{
				return this._quitRoleID != null;
			}
			set
			{
				bool flag = value == (this._quitRoleID == null);
				if (flag)
				{
					this._quitRoleID = (value ? new ulong?(this.quitRoleID) : null);
				}
			}
		}

		private bool ShouldSerializequitRoleID()
		{
			return this.quitRoleIDSpecified;
		}

		private void ResetquitRoleID()
		{
			this.quitRoleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "quitRoleName", DataFormat = DataFormat.Default)]
		public string quitRoleName
		{
			get
			{
				return this._quitRoleName ?? "";
			}
			set
			{
				this._quitRoleName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool quitRoleNameSpecified
		{
			get
			{
				return this._quitRoleName != null;
			}
			set
			{
				bool flag = value == (this._quitRoleName == null);
				if (flag)
				{
					this._quitRoleName = (value ? this.quitRoleName : null);
				}
			}
		}

		private bool ShouldSerializequitRoleName()
		{
			return this.quitRoleNameSpecified;
		}

		private void ResetquitRoleName()
		{
			this.quitRoleNameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _quitRoleID;

		private string _quitRoleName;

		private IExtension extensionObject;
	}
}
