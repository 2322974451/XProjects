using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008C RID: 140
	[ProtoContract(Name = "FetchGAPPArg")]
	[Serializable]
	public class FetchGAPPArg : IExtensible
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x00014040 File Offset: 0x00012240
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400025E RID: 606
		private IExtension extensionObject;
	}
}
