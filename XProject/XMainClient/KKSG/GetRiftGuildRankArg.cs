using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000527 RID: 1319
	[ProtoContract(Name = "GetRiftGuildRankArg")]
	[Serializable]
	public class GetRiftGuildRankArg : IExtensible
	{
		// Token: 0x060043D6 RID: 17366 RVA: 0x000810E0 File Offset: 0x0007F2E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010E9 RID: 4329
		private IExtension extensionObject;
	}
}
