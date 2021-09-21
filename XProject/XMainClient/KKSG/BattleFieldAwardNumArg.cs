using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D8 RID: 1240
	[ProtoContract(Name = "BattleFieldAwardNumArg")]
	[Serializable]
	public class BattleFieldAwardNumArg : IExtensible
	{
		// Token: 0x06004036 RID: 16438 RVA: 0x0007A4B8 File Offset: 0x000786B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FFE RID: 4094
		private IExtension extensionObject;
	}
}
