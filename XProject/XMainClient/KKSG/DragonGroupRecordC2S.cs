using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048F RID: 1167
	[ProtoContract(Name = "DragonGroupRecordC2S")]
	[Serializable]
	public class DragonGroupRecordC2S : IExtensible
	{
		// Token: 0x06003CDE RID: 15582 RVA: 0x00074350 File Offset: 0x00072550
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F28 RID: 3880
		private IExtension extensionObject;
	}
}
