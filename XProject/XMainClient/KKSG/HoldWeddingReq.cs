using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046D RID: 1133
	[ProtoContract(Name = "HoldWeddingReq")]
	[Serializable]
	public class HoldWeddingReq : IExtensible
	{
		// Token: 0x06003B45 RID: 15173 RVA: 0x00071464 File Offset: 0x0006F664
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EB9 RID: 3769
		private IExtension extensionObject;
	}
}
