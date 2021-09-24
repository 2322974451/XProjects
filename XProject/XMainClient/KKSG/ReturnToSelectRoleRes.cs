using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReturnToSelectRoleRes")]
	[Serializable]
	public class ReturnToSelectRoleRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "accountData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoadAccountData accountData
		{
			get
			{
				return this._accountData;
			}
			set
			{
				this._accountData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LoadAccountData _accountData = null;

		private IExtension extensionObject;
	}
}
