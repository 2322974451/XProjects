using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000410 RID: 1040
	[ProtoContract(Name = "GetGuildPartyReceiveInfoArg")]
	[Serializable]
	public class GetGuildPartyReceiveInfoArg : IExtensible
	{
		// Token: 0x06003767 RID: 14183 RVA: 0x0006A1AC File Offset: 0x000683AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DBA RID: 3514
		private IExtension extensionObject;
	}
}
