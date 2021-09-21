using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031E RID: 798
	[ProtoContract(Name = "LeavePartnerArg")]
	[Serializable]
	public class LeavePartnerArg : IExtensible
	{
		// Token: 0x06002BDE RID: 11230 RVA: 0x00054FB4 File Offset: 0x000531B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ADD RID: 2781
		private IExtension extensionObject;
	}
}
