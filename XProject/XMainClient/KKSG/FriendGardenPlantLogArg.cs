using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000268 RID: 616
	[ProtoContract(Name = "FriendGardenPlantLogArg")]
	[Serializable]
	public class FriendGardenPlantLogArg : IExtensible
	{
		// Token: 0x06002267 RID: 8807 RVA: 0x00043398 File Offset: 0x00041598
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000888 RID: 2184
		private IExtension extensionObject;
	}
}
