using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006E RID: 110
	[ProtoContract(Name = "QueryOpenGameArg")]
	[Serializable]
	public class QueryOpenGameArg : IExtensible
	{
		// Token: 0x06000726 RID: 1830 RVA: 0x0001057C File Offset: 0x0000E77C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001D2 RID: 466
		private IExtension extensionObject;
	}
}
