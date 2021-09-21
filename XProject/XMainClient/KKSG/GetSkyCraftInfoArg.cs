using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E0 RID: 992
	[ProtoContract(Name = "GetSkyCraftInfoArg")]
	[Serializable]
	public class GetSkyCraftInfoArg : IExtensible
	{
		// Token: 0x060034BC RID: 13500 RVA: 0x00065180 File Offset: 0x00063380
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D19 RID: 3353
		private IExtension extensionObject;
	}
}
