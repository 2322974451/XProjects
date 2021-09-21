using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014C RID: 332
	[ProtoContract(Name = "GetFlowerRewardListArg")]
	[Serializable]
	public class GetFlowerRewardListArg : IExtensible
	{
		// Token: 0x06001443 RID: 5187 RVA: 0x00028DD0 File Offset: 0x00026FD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400050C RID: 1292
		private IExtension extensionObject;
	}
}
