using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BE RID: 1214
	[ProtoContract(Name = "GetDragonGuildTaskInfoArg")]
	[Serializable]
	public class GetDragonGuildTaskInfoArg : IExtensible
	{
		// Token: 0x06003F3E RID: 16190 RVA: 0x00078940 File Offset: 0x00076B40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FBB RID: 4027
		private IExtension extensionObject;
	}
}
