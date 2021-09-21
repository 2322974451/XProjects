using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000156 RID: 342
	[ProtoContract(Name = "GetQADataReq")]
	[Serializable]
	public class GetQADataReq : IExtensible
	{
		// Token: 0x060014F7 RID: 5367 RVA: 0x0002A350 File Offset: 0x00028550
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000534 RID: 1332
		private IExtension extensionObject;
	}
}
