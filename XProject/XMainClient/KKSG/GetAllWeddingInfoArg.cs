using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046F RID: 1135
	[ProtoContract(Name = "GetAllWeddingInfoArg")]
	[Serializable]
	public class GetAllWeddingInfoArg : IExtensible
	{
		// Token: 0x06003B51 RID: 15185 RVA: 0x0007159C File Offset: 0x0006F79C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EBD RID: 3773
		private IExtension extensionObject;
	}
}
