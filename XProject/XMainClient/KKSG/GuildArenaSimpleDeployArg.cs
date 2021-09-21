using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A5 RID: 421
	[ProtoContract(Name = "GuildArenaSimpleDeployArg")]
	[Serializable]
	public class GuildArenaSimpleDeployArg : IExtensible
	{
		// Token: 0x060018F9 RID: 6393 RVA: 0x00031A40 File Offset: 0x0002FC40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000631 RID: 1585
		private IExtension extensionObject;
	}
}
