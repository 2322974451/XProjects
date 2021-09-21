using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032C RID: 812
	[ProtoContract(Name = "PhotographEffectArg")]
	[Serializable]
	public class PhotographEffectArg : IExtensible
	{
		// Token: 0x06002CC1 RID: 11457 RVA: 0x00056A50 File Offset: 0x00054C50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B14 RID: 2836
		private IExtension extensionObject;
	}
}
