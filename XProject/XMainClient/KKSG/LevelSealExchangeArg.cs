using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000214 RID: 532
	[ProtoContract(Name = "LevelSealExchangeArg")]
	[Serializable]
	public class LevelSealExchangeArg : IExtensible
	{
		// Token: 0x06001DF0 RID: 7664 RVA: 0x0003ADA0 File Offset: 0x00038FA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400077B RID: 1915
		private IExtension extensionObject;
	}
}
