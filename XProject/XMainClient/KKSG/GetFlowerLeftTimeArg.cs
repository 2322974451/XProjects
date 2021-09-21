using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000144 RID: 324
	[ProtoContract(Name = "GetFlowerLeftTimeArg")]
	[Serializable]
	public class GetFlowerLeftTimeArg : IExtensible
	{
		// Token: 0x060013FC RID: 5116 RVA: 0x000285C0 File Offset: 0x000267C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004FA RID: 1274
		private IExtension extensionObject;
	}
}
