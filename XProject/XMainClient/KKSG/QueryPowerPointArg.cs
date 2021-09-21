using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B8 RID: 440
	[ProtoContract(Name = "QueryPowerPointArg")]
	[Serializable]
	public class QueryPowerPointArg : IExtensible
	{
		// Token: 0x060019C2 RID: 6594 RVA: 0x0003317C File Offset: 0x0003137C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000667 RID: 1639
		private IExtension extensionObject;
	}
}
