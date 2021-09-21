using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018A RID: 394
	[ProtoContract(Name = "ReturnToSelectRoleRes")]
	[Serializable]
	public class ReturnToSelectRoleRes : IExtensible
	{
		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x0002F6AC File Offset: 0x0002D8AC
		// (set) Token: 0x060017C1 RID: 6081 RVA: 0x0002F6C4 File Offset: 0x0002D8C4
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

		// Token: 0x060017C2 RID: 6082 RVA: 0x0002F6D0 File Offset: 0x0002D8D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005DD RID: 1501
		private LoadAccountData _accountData = null;

		// Token: 0x040005DE RID: 1502
		private IExtension extensionObject;
	}
}
