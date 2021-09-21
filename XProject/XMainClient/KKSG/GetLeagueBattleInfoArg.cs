using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000373 RID: 883
	[ProtoContract(Name = "GetLeagueBattleInfoArg")]
	[Serializable]
	public class GetLeagueBattleInfoArg : IExtensible
	{
		// Token: 0x06003054 RID: 12372 RVA: 0x0005D454 File Offset: 0x0005B654
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BF9 RID: 3065
		private IExtension extensionObject;
	}
}
