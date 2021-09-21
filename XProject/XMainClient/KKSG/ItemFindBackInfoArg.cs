using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F0 RID: 496
	[ProtoContract(Name = "ItemFindBackInfoArg")]
	[Serializable]
	public class ItemFindBackInfoArg : IExtensible
	{
		// Token: 0x06001C57 RID: 7255 RVA: 0x00037DE0 File Offset: 0x00035FE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400070E RID: 1806
		private IExtension extensionObject;
	}
}
