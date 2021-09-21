using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000392 RID: 914
	[ProtoContract(Name = "LeagueBattleMatchTimeoutNtf")]
	[Serializable]
	public class LeagueBattleMatchTimeoutNtf : IExtensible
	{
		// Token: 0x06003182 RID: 12674 RVA: 0x0005F5D8 File Offset: 0x0005D7D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C4B RID: 3147
		private IExtension extensionObject;
	}
}
