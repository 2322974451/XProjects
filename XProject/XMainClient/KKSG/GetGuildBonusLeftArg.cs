using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000362 RID: 866
	[ProtoContract(Name = "GetGuildBonusLeftArg")]
	[Serializable]
	public class GetGuildBonusLeftArg : IExtensible
	{
		// Token: 0x06002F50 RID: 12112 RVA: 0x0005B53C File Offset: 0x0005973C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BBB RID: 3003
		private IExtension extensionObject;
	}
}
