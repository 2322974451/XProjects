using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009D RID: 157
	[ProtoContract(Name = "QueryGuildCardArg")]
	[Serializable]
	public class QueryGuildCardArg : IExtensible
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x00017278 File Offset: 0x00015478
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002B7 RID: 695
		private IExtension extensionObject;
	}
}
