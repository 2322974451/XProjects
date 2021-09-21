using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011C RID: 284
	[ProtoContract(Name = "GetLevelSealInfoArg")]
	[Serializable]
	public class GetLevelSealInfoArg : IExtensible
	{
		// Token: 0x060011A7 RID: 4519 RVA: 0x00023F7C File Offset: 0x0002217C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400046B RID: 1131
		private IExtension extensionObject;
	}
}
