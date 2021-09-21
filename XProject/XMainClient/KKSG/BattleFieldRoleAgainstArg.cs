using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E5 RID: 1253
	[ProtoContract(Name = "BattleFieldRoleAgainstArg")]
	[Serializable]
	public class BattleFieldRoleAgainstArg : IExtensible
	{
		// Token: 0x060040BE RID: 16574 RVA: 0x0007B488 File Offset: 0x00079688
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001023 RID: 4131
		private IExtension extensionObject;
	}
}
