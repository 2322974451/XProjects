using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049B RID: 1179
	[ProtoContract(Name = "StartWeddingCarArg")]
	[Serializable]
	public class StartWeddingCarArg : IExtensible
	{
		// Token: 0x06003D73 RID: 15731 RVA: 0x000754CC File Offset: 0x000736CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F4D RID: 3917
		private IExtension extensionObject;
	}
}
