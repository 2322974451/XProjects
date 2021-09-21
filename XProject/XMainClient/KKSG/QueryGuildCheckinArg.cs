using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AD RID: 173
	[ProtoContract(Name = "QueryGuildCheckinArg")]
	[Serializable]
	public class QueryGuildCheckinArg : IExtensible
	{
		// Token: 0x06000BFC RID: 3068 RVA: 0x00019670 File Offset: 0x00017870
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002FA RID: 762
		private IExtension extensionObject;
	}
}
