using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D1 RID: 465
	[ProtoContract(Name = "NewGetFlowerRewardListArg")]
	[Serializable]
	public class NewGetFlowerRewardListArg : IExtensible
	{
		// Token: 0x06001B16 RID: 6934 RVA: 0x00035918 File Offset: 0x00033B18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006BD RID: 1725
		private IExtension extensionObject;
	}
}
