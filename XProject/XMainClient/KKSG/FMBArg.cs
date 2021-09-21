using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015E RID: 350
	[ProtoContract(Name = "FMBArg")]
	[Serializable]
	public class FMBArg : IExtensible
	{
		// Token: 0x0600155F RID: 5471 RVA: 0x0002AFB0 File Offset: 0x000291B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400054E RID: 1358
		private IExtension extensionObject;
	}
}
