using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000332 RID: 818
	[ProtoContract(Name = "GCFFightInfoArg")]
	[Serializable]
	public class GCFFightInfoArg : IExtensible
	{
		// Token: 0x06002D0E RID: 11534 RVA: 0x00057368 File Offset: 0x00055568
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B2C RID: 2860
		private IExtension extensionObject;
	}
}
