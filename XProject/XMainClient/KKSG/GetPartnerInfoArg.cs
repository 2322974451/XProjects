using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000305 RID: 773
	[ProtoContract(Name = "GetPartnerInfoArg")]
	[Serializable]
	public class GetPartnerInfoArg : IExtensible
	{
		// Token: 0x06002A44 RID: 10820 RVA: 0x00051EF0 File Offset: 0x000500F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A7F RID: 2687
		private IExtension extensionObject;
	}
}
