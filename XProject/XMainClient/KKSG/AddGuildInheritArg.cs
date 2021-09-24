using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AddGuildInheritArg")]
	[Serializable]
	public class AddGuildInheritArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqRoleId", DataFormat = DataFormat.TwosComplement)]
		public ulong reqRoleId
		{
			get
			{
				return this._reqRoleId ?? 0UL;
			}
			set
			{
				this._reqRoleId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqRoleIdSpecified
		{
			get
			{
				return this._reqRoleId != null;
			}
			set
			{
				bool flag = value == (this._reqRoleId == null);
				if (flag)
				{
					this._reqRoleId = (value ? new ulong?(this.reqRoleId) : null);
				}
			}
		}

		private bool ShouldSerializereqRoleId()
		{
			return this.reqRoleIdSpecified;
		}

		private void ResetreqRoleId()
		{
			this.reqRoleIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _reqRoleId;

		private IExtension extensionObject;
	}
}
