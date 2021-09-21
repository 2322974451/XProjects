using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DD RID: 477
	[ProtoContract(Name = "FirstPassInfoReqArg")]
	[Serializable]
	public class FirstPassInfoReqArg : IExtensible
	{
		// Token: 0x06001B88 RID: 7048 RVA: 0x00036610 File Offset: 0x00034810
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006DB RID: 1755
		private IExtension extensionObject;
	}
}
