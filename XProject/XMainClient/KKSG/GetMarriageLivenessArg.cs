using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000491 RID: 1169
	[ProtoContract(Name = "GetMarriageLivenessArg")]
	[Serializable]
	public class GetMarriageLivenessArg : IExtensible
	{
		// Token: 0x06003CE9 RID: 15593 RVA: 0x00074480 File Offset: 0x00072680
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F2C RID: 3884
		private IExtension extensionObject;
	}
}
